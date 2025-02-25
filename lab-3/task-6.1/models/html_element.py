class HTMLElement:
    def __init__(self, tag_name):
        self.opening_tag = f"<{tag_name}>"
        self.closing_tag = f"</{tag_name}>"
        
    def wrap_content(self, content):
        return f"{self.opening_tag}{content}{self.closing_tag}"