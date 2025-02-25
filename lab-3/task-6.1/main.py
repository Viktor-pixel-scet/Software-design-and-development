from services.parser import LightHTML
from design_patterns.flyweight import HTMLElementFactory
from utils.memory_calculator import MemoryCalculator

def main():
    try:
        with open('data/book.txt', 'r', encoding='utf-8') as file:
            book_content = file.read()
            
        light_html = LightHTML(book_content)
        light_html.parse_book()
        
        print("Демонстрація HTML верстки:")
        light_html.print_html()
        
        MemoryCalculator.print_memory_statistics(
            light_html.parsed_data, 
            HTMLElementFactory
        )
        
    except FileNotFoundError:
        print("Помилка: Файл 'data/book.txt' не знайдено")
    except Exception as e:
        print(f"Помилка при обробці файлу: {str(e)}")

if __name__ == "__main__":
    main()