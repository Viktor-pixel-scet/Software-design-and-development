from design_patterns.flyweight import HTMLElementFactory

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
    
    def print_html(self):
        for element, text in self.parsed_data:
            print(element.wrap_content(text))