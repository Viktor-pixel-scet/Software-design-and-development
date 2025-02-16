from html_lifecycle import HTMLElement
from html_iterator import HTMLTreeIterator, HTMLDepthFirstIterator, HTMLQuerySelector
from html_commands import CommandHistory, AddClassCommand, SetAttributeCommand, AddChildCommand
from html_visitor import HTMLMetricsCollector
from html_render_state import RenderContext, PrettyPrintRenderState, MinifiedRenderState

class LightweightHTMLElement:
    def __init__(self, tag_name):
        self.opening_tag = f"<{tag_name}>"
        self.closing_tag = f"</{tag_name}>"
        
    def wrap_content(self, content):
        return f"{self.opening_tag}{content}{self.closing_tag}"

class HTMLElementFactory:
    _elements = {}
    
    @classmethod
    def get_element(cls, tag_name):
        if tag_name not in cls._elements:
            cls._elements[tag_name] = LightweightHTMLElement(tag_name)
        return cls._elements[tag_name]

class LightHTML:
    def __init__(self, content):
        self.content = content
        self.factory = HTMLElementFactory()
        self.parsed_data = []
        
    def parse_book(self):
        lines = self.content.split('\n')
        for i, line in enumerate(lines):
            if i == 0:
                element = self.factory.get_element('h1')
            elif line.startswith(' '):
                element = self.factory.get_element('blockquote')
            elif len(line.strip()) < 20:
                element = self.factory.get_element('h2')
            else:
                element = self.factory.get_element('p')
            self.parsed_data.append((element, line))
            
    def calculate_memory_usage(self):
        return sum(len(e.wrap_content(text)) for e, text in self.parsed_data)
        
    def lightweight_memory_usage(self):
        return len(self.parsed_data) * 8
        
    def print_html(self):
        for element, text in self.parsed_data:
            print(element.wrap_content(text))

def main():
    root = HTMLElement('html')
    head = HTMLElement('head')
    body = HTMLElement('body')
    
    history = CommandHistory()
    
    meta = HTMLElement('meta')
    history.execute(SetAttributeCommand(meta, 'charset', 'UTF-8'))
    history.execute(AddChildCommand(head, meta))
    
    style = HTMLElement('style')
    history.execute(AddChildCommand(head, style))
    
    header = HTMLElement('header')
    history.execute(AddClassCommand(header, 'main-header'))
    history.execute(SetAttributeCommand(header, 'role', 'banner'))
    
    nav = HTMLElement('nav')
    history.execute(AddClassCommand(nav, 'navigation'))
    history.execute(AddChildCommand(header, nav))
    
    history.execute(AddChildCommand(root, head))
    history.execute(AddChildCommand(root, body))
    history.execute(AddChildCommand(body, header))
    
    context = RenderContext()
    renderer = PrettyPrintRenderState()
    output = renderer.render(root, context)
    
    print("=== Generated HTML ===")
    print(output)
    
    metrics_collector = HTMLMetricsCollector()
    metrics_collector.analyze(root)
    report = metrics_collector.get_report()
    
    print("\n=== HTML Metrics Report ===")
    print(f"Total elements: {report['element_statistics']['total_elements']}")
    print(f"Max depth: {report['depth_statistics']['max_depth']}")
    
    print("\n=== Command History ===")
    for cmd in history.get_history():
        print(f"{cmd['command']}: {cmd['description']} ({cmd['timestamp']})")
    
    print("\n=== Element Lifecycle ===")
    print(root.get_lifecycle_report())
    
    print("\n=== BFS Iteration ===")
    for element, path in HTMLTreeIterator(root):
        depth = len(path)
        indent = '  ' * depth
        print(f"{indent}{element.tag_name}")
    
    print("\n=== DFS Iteration ===")
    for element, path in HTMLDepthFirstIterator(root):
        depth = len(path)
        indent = '  ' * depth
        print(f"{indent}{element.tag_name}")

    print("\n=== Query Selector ===")
    selector = HTMLQuerySelector(root)
    header_elements = selector.query('header')
    print(f"Found {len(header_elements)} header elements")
    
    print("\n=== Pretty Print Rendering ===")
    print(renderer.render(root, context))
    
    print("\n=== Minified Rendering ===")
    minified_renderer = MinifiedRenderState()
    print(minified_renderer.render(root, context))
    
    try:
        with open('book.txt', 'r', encoding='utf-8') as file:
            book_content = file.read()
        light_html = LightHTML(book_content)
        light_html.parse_book()
        print("\nДемонстрація HTML верстки:")
        light_html.print_html()
        
        memory_usage = light_html.calculate_memory_usage()
        print(f"\nВикористання пам'яті без Легковаговика: {memory_usage} байт")
        
        lightweight_usage = light_html.lightweight_memory_usage()
        print(f"Використання пам'яті з Легковаговиком: {lightweight_usage} байт")
        
        memory_saved = memory_usage - lightweight_usage
        print(f"\nЕкономія пам'яті: {memory_saved} байт")
        
        if memory_usage > 0:
            save_percentage = (memory_saved / memory_usage) * 100
            print(f"Відсоток економії: {save_percentage:.2f}%")
            
        print(f"\nКількість унікальних HTML елементів в кеші: {len(HTMLElementFactory._elements)}")
        print("Кешовані елементи:", ", ".join(HTMLElementFactory._elements.keys()))
        
    except FileNotFoundError:
        print("Помилка: Файл 'book.txt' не знайдено")
        
    except Exception as e:
        print(f"Помилка при обробці файлу: {str(e)}")

if __name__ == "__main__":
    main()