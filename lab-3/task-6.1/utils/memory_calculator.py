class MemoryCalculator:
    @staticmethod
    def calculate_regular_memory_usage(parsed_data):
        return sum(len(e.wrap_content(text)) for e, text in parsed_data)
    
    @staticmethod
    def calculate_lightweight_memory_usage(parsed_data):
        return len(parsed_data) * 8  # Assuming pointer size is 8 bytes
    
    @staticmethod
    def print_memory_statistics(parsed_data, element_factory):
        memory_usage = MemoryCalculator.calculate_regular_memory_usage(parsed_data)
        lightweight_usage = MemoryCalculator.calculate_lightweight_memory_usage(parsed_data)
        
        memory_saved = memory_usage - lightweight_usage
        
        print(f"\nВикористання пам'яті без Легковаговика: {memory_usage} байт")
        print(f"Використання пам'яті з Легковаговиком: {lightweight_usage} байт")
        print(f"\nЕкономія пам'яті: {memory_saved} байт")
        
        if memory_usage > 0:
            save_percentage = (memory_saved / memory_usage) * 100
            print(f"Відсоток економії: {save_percentage:.2f}%")
            
        cached_elements = element_factory.get_cached_elements()
        print(f"\nКількість унікальних HTML елементів в кеші: {len(cached_elements)}")
        print("Кешовані елементи:", ", ".join(cached_elements.keys()))