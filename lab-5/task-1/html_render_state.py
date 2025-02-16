from abc import ABC, abstractmethod
from typing import List, Dict

class RenderContext:
    def __init__(self):
        self.indent_size: int = 2
        self.max_line_length: int = 80
        self.collapse_empty_elements: bool = True
        self.self_closing_tags: List[str] = ['img', 'br', 'hr']
        self.format_attributes: bool = True

class RenderState(ABC):
    @abstractmethod
    def render(self, element: HTMLElement, context: RenderContext) -> str:
        pass

class PrettyPrintRenderState(RenderState):
    def render(self, element: HTMLElement, context: RenderContext) -> str:
        self.context = context
        return self._render_element(element, 0)

    def _render_element(self, element: HTMLElement, depth: int) -> str:
        indent = ' ' * (depth * self.context.indent_size)
        attributes = self._format_attributes(element.attributes)
        
        if not element.children and element.tag_name in self.context.self_closing_tags:
            return f"{indent}<{element.tag_name}{attributes} />"

        opening = f"{indent}<{element.tag_name}{attributes}>"
        if not element.children:
            return f"{opening}</{element.tag_name}>"

        content = '\n'.join(
            self._render_element(child, depth + 1)
            for child in element.children
        )
        
        return f"{opening}\n{content}\n{indent}</{element.tag_name}>"

    def _format_attributes(self, attributes: Dict[str, str]) -> str:
        if not attributes or not self.context.format_attributes:
            return ''
        
        return ' ' + ' '.join(
            f'{key}="{value}"'
            for key, value in sorted(attributes.items())
        )