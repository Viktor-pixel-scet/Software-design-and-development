
using System.Text;

namespace task_5
{
    public sealed class TextEditor : ITextEditor
    {
        private readonly TextDocument _document;
        private readonly Stack<IMemento> _undoStack;
        private readonly Stack<IMemento> _redoStack;
        private bool _isAnimating;
        private string _lastSearchText;

        public TextEditor()
        {
            _document = new TextDocument();
            _undoStack = new Stack<IMemento>();
            _redoStack = new Stack<IMemento>();
            _lastSearchText = string.Empty;
        }

        public void Type(string text)
        {
            SaveState();
            var currentText = _document.GetText();
            var cursorPosition = _document.GetCursorPosition();
            string newText = currentText.Insert(cursorPosition, text);
            _document.SetText(newText, cursorPosition + text.Length);
            _redoStack.Clear();
        }

        public void Delete()
        {
            var currentText = _document.GetText();
            var cursorPosition = _document.GetCursorPosition();

            if (cursorPosition < currentText.Length)
            {
                SaveState();
                string newText = currentText.Remove(cursorPosition, 1);
                _document.SetText(newText, cursorPosition);
            }
        }

        public void Backspace()
        {
            var currentText = _document.GetText();
            var cursorPosition = _document.GetCursorPosition();

            if (cursorPosition > 0)
            {
                SaveState();
                string newText = currentText.Remove(cursorPosition - 1, 1);
                _document.SetText(newText, cursorPosition - 1);
            }
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;

            SaveStateForRedo();
            var memento = _undoStack.Pop();
            _document.RestoreFromMemento(memento);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;

            SaveState();
            var memento = _redoStack.Pop();
            _document.RestoreFromMemento(memento);
        }

        public void ShowTooltip(string buttonName)
        {
            var tooltip = buttonName switch
            {
                "Undo" => "Відмінити останню дію (Ctrl+Z)",
                "Redo" => "Повторити відмінену дію (Ctrl+Y)",
                "Find" => "Пошук тексту (Ctrl+F)",
                "Replace" => "Замінити текст (Ctrl+H)",
                "Save" => "Зберегти файл (Ctrl+S)",
                "Load" => "Завантажити файл (Ctrl+O)",
                "Style" => "Змінити стиль тексту (Ctrl+T)",
                _ => string.Empty
            };

            if (!string.IsNullOrEmpty(tooltip))
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write($"Підказка: {tooltip}".PadRight(Console.WindowWidth));
            }
        }

        public async Task AnimateStateTransition()
        {
            if (_isAnimating) return;

            _isAnimating = true;
            try
            {
                var (originalLeft, originalTop) = (Console.CursorLeft, Console.CursorTop);

                for (int i = 0; i < 3; i++)
                {
                    await AnimateFrame("↺ ", "↻ ", 100);
                }

                Console.SetCursorPosition(originalLeft, originalTop);
            }
            finally
            {
                _isAnimating = false;
            }
        }

        private static async Task AnimateFrame(string frame1, string frame2, int delay)
        {
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write(frame1);
            await Task.Delay(delay);
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write(frame2);
            await Task.Delay(delay);
        }

        public void SetStyle(TextStyle style)
        {
            SaveState();
            _document.SetStyle(style);
        }

        public void SaveToFile(string filename)
        {
            try
            {
                System.IO.File.WriteAllText(filename, _document.GetText());
                ShowTooltip($"Файл збережено: {filename}");
            }
            catch (Exception ex)
            {
                ShowTooltip($"Помилка збереження: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                SaveState();
                string text = System.IO.File.ReadAllText(filename);
                _document.SetText(text, 0);
                ShowTooltip($"Файл завантажено: {filename}");
            }
            catch (Exception ex)
            {
                ShowTooltip($"Помилка завантаження: {ex.Message}");
            }
        }

        public void Find(string searchText)
        {
            _lastSearchText = searchText;
            _document.HighlightSearchResults(searchText);
        }

        public void Replace(string searchText, string replaceText)
        {
            SaveState();
            string newText = _document.GetText().Replace(searchText, replaceText);
            _document.SetText(newText, _document.GetCursorPosition());
        }

        private void SaveState()
        {
            _undoStack.Push(_document.CreateMemento());
        }

        private void SaveStateForRedo()
        {
            _redoStack.Push(_document.CreateMemento());
        }

        public void ProcessKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Modifiers == ConsoleModifiers.Control)
            {
                ProcessControlKeys(keyInfo.Key);
            }
            else
            {
                ProcessRegularKeys(keyInfo);
            }
        }

        private void ProcessControlKeys(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Z:
                    Undo(); ShowTooltip("Undo");
                    break;
                case ConsoleKey.Y:
                    Redo(); ShowTooltip("Redo");
                    break;
                case ConsoleKey.S:
                    ShowSaveDialog(); ShowTooltip("Save");
                    break;
                case ConsoleKey.O:
                    ShowLoadDialog(); ShowTooltip("Load");
                    break;
                case ConsoleKey.F:
                    ShowFindDialog(); ShowTooltip("Find");
                    break;
                case ConsoleKey.H:
                    ShowReplaceDialog(); ShowTooltip("Replace");
                    break;
                case ConsoleKey.T:
                    ShowStyleDialog(); ShowTooltip("Style");
                    break;
            }
        }

        private void ProcessRegularKeys(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Delete:
                    Delete();
                    break;
                case ConsoleKey.Backspace:
                    Backspace();
                    break;
                case ConsoleKey.LeftArrow:
                    _document.MoveCursor(-1);
                    break;
                case ConsoleKey.RightArrow:
                    _document.MoveCursor(1);
                    break;
                default:
                    if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Type(keyInfo.KeyChar.ToString());
                    }
                    break;
            }
        }

        private void ShowSaveDialog()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("Введіть ім'я файлу для збереження: ");
            string filename = Console.ReadLine();
            if (!string.IsNullOrEmpty(filename))
            {
                SaveToFile(filename);
            }
        }

        private void ShowLoadDialog()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("Введіть ім'я файлу для завантаження: ");
            string filename = Console.ReadLine();
            if (!string.IsNullOrEmpty(filename))
            {
                LoadFromFile(filename);
            }
        }

        private void ShowFindDialog()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("Введіть текст для пошуку: ");
            string searchText = Console.ReadLine();
            if (!string.IsNullOrEmpty(searchText))
            {
                Find(searchText);
            }
        }

        private void ShowReplaceDialog()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write("Введіть текст для пошуку: ");
            string searchText = Console.ReadLine();
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("Введіть текст для заміни: ");
            string replaceText = Console.ReadLine();
            if (!string.IsNullOrEmpty(searchText) && replaceText != null)
            {
                Replace(searchText, replaceText);
            }
        }

        private void ShowStyleDialog()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine("Виберіть колір тексту (0-15): ");
            if (int.TryParse(Console.ReadLine(), out int colorIndex) && colorIndex >= 0 && colorIndex <= 15)
            {
                var style = new TextStyle((ConsoleColor)colorIndex, ConsoleColor.Black);
                SetStyle(style);
            }
        }

        public void DisplayCurrentState()
        {
            Console.Clear();
            Console.WriteLine("=== Розширений текстовий редактор ===");
            var style = _document.GetStyle();
            Console.ForegroundColor = style.TextColor;
            Console.BackgroundColor = style.BackgroundColor;

            string displayText = string.IsNullOrEmpty(_lastSearchText)
                ? _document.GetText()
                : _document.GetHighlightedText();

            // Display text with cursor
            int cursorPos = _document.GetCursorPosition();
            string textBeforeCursor = displayText.Substring(0, cursorPos);
            string textAfterCursor = displayText.Substring(cursorPos);

            Console.Write("Текст: ");
            Console.Write(textBeforeCursor);

            var currentFg = Console.ForegroundColor;
            var currentBg = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(textAfterCursor.Length > 0 ? textAfterCursor[0].ToString() : " ");

            Console.ForegroundColor = currentFg;
            Console.BackgroundColor = currentBg;

            if (textAfterCursor.Length > 1)
            {
                Console.Write(textAfterCursor.Substring(1));
            }
            Console.WriteLine();

            Console.ResetColor();

            Console.WriteLine($"Позиція курсора: {_document.GetCursorPosition()}");
            Console.WriteLine($"Кількість збережених станів (Undo): {_undoStack.Count}");
            Console.WriteLine($"Кількість станів для Redo: {_redoStack.Count}");

            DisplayCommands();
        }

        private static void DisplayCommands()
        {
            Console.WriteLine("\nКоманди:");
            Console.WriteLine("• Ctrl+Z - Відмінити");
            Console.WriteLine("• Ctrl+Y - Повторити");
            Console.WriteLine("• Ctrl+S - Зберегти");
            Console.WriteLine("• Ctrl+O - Завантажити");
            Console.WriteLine("• Ctrl+F - Пошук");
            Console.WriteLine("• Ctrl+H - Заміна");
            Console.WriteLine("• Ctrl+T - Зміна стилю");
            Console.WriteLine("• ←/→ - Переміщення курсора");
            Console.WriteLine("• Delete - Видалити символ");
            Console.WriteLine("• Backspace - Видалити попередній символ");
            Console.WriteLine("• ESC - Вийти");
        }
    }
    public sealed class TextDocumentMemento : IMemento
    {
        private readonly string _text;
        private readonly int _cursorPosition;
        private readonly DateTime _creationDate;
        private readonly TextStyle _style;

        public TextDocumentMemento(string text, int cursorPosition, TextStyle style)
        {
            _text = text;
            _cursorPosition = cursorPosition;
            _creationDate = DateTime.Now;
            _style = style;
        }

        public string GetText() => _text;
        public int GetCursorPosition() => _cursorPosition;
        public DateTime GetCreationDate() => _creationDate;
        public TextStyle GetStyle() => _style;
    }

    public sealed class TextDocument
    {
        private string _text = string.Empty;
        private int _cursorPosition;
        private TextStyle _currentStyle;
        private readonly StringBuilder _searchHighlight = new();

        public TextDocument()
        {
            _currentStyle = new TextStyle(ConsoleColor.White, ConsoleColor.Black);
        }

        public void SetText(string text, int cursorPosition)
        {
            _text = text;
            _cursorPosition = Math.Min(cursorPosition, text.Length);
        }

        public void SetStyle(TextStyle style) => _currentStyle = style;
        public string GetText() => _text;
        public int GetCursorPosition() => _cursorPosition;
        public TextStyle GetStyle() => _currentStyle;

        public TextDocumentMemento CreateMemento() =>
            new(_text, _cursorPosition, _currentStyle);

        public void RestoreFromMemento(IMemento memento)
        {
            _text = memento.GetText();
            _cursorPosition = memento.GetCursorPosition();
            _currentStyle = memento.GetStyle();
        }

        public void MoveCursor(int offset)
        {
            _cursorPosition = Math.Clamp(_cursorPosition + offset, 0, _text.Length);
        }

        public void HighlightSearchResults(string searchText)
        {
            _searchHighlight.Clear();
            _searchHighlight.Append(_text);

            if (string.IsNullOrEmpty(searchText)) return;

            int index = _text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
            while (index != -1)
            {
                _searchHighlight.Insert(index, "<<");
                _searchHighlight.Insert(index + searchText.Length + 2, ">>");
                index = _text.IndexOf(searchText, index + 1, StringComparison.OrdinalIgnoreCase);
            }
        }
        public string GetHighlightedText() => _searchHighlight.ToString();
    }
}
