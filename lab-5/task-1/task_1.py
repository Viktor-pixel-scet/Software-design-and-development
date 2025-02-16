
class HTMLElement:
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
            cls._elements[tag_name] = HTMLElement(tag_name)
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
    try:
        with open('book.txt', 'r', encoding='utf-8') as file:
            book_content = file.read()

        light_html = LightHTML(book_content)
        light_html.parse_book()

        print("Демонстрація HTML верстки:")
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
