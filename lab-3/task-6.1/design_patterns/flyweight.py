from models.html_element import HTMLElement

class HTMLElementFactory:
    _elements = {}
    
    @classmethod
    def get_element(cls, tag_name):
        if tag_name not in cls._elements:
            cls._elements[tag_name] = HTMLElement(tag_name)
        return cls._elements[tag_name]
    
    @classmethod
    def get_cached_elements(cls):
        return cls._elements