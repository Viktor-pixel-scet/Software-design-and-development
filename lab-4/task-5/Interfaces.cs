namespace task_5
{
    public interface IMemento
    {
        string GetText();
        int GetCursorPosition();
        DateTime GetCreationDate();
        TextStyle GetStyle();
    }

    public interface ITextEditor
    {
        void Type(string text);
        void Undo();
        void Redo();
        void ShowTooltip(string buttonName);
        Task AnimateStateTransition();
        void SetStyle(TextStyle style);
        void SaveToFile(string filename);
        void LoadFromFile(string filename);
        void Find(string searchText);
        void Replace(string searchText, string replaceText);
    }
}
