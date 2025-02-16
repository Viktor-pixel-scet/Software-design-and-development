from typing import Optional, List, Dict, Any
from datetime import datetime
import json

class HTMLElementLifecycle:
    def __init__(self):
        self.created_at: datetime = datetime.now()
        self.updated_at: Optional[datetime] = None
        self.rendered_count: int = 0
        self.event_history: List[Dict[str, Any]] = []

    def _log_event(self, event_name: str, details: Dict[str, Any] = None):
        event = {
            'event': event_name,
            'timestamp': datetime.now(),
            'details': details or {}
        }
        self.event_history.append(event)
    
    def on_created(self):
        self._log_event('created', {
            'created_at': self.created_at
        })
    
    def on_inserted(self):
        self._log_event('inserted')
    
    def on_removed(self):
        self._log_event('removed')
    
    def on_styles_applied(self, styles: Dict[str, str]):
        self._log_event('styles_applied', {
            'styles': styles
        })
    
    def on_class_list_applied(self, classes: List[str]):
        self._log_event('classes_applied', {
            'classes': classes
        })
    
    def on_attribute_changed(self, attribute: str, old_value: Any, new_value: Any):
        self._log_event('attribute_changed', {
            'attribute': attribute,
            'old_value': old_value,
            'new_value': new_value
        })
    
    def on_child_added(self, child: 'HTMLElement'):
        self._log_event('child_added', {
            'child_tag': child.tag_name
        })
    
    def on_rendered(self):
        self.rendered_count += 1
        self._log_event('rendered', {
            'render_count': self.rendered_count
        })
    
    def get_lifecycle_report(self) -> str:
        return json.dumps(self.event_history, default=str, indent=2)

class HTMLElement(HTMLElementLifecycle):
    def __init__(self, tag_name: str):
        super().__init__()
        self.tag_name = tag_name
        self.attributes: Dict[str, str] = {}
        self.styles: Dict[str, str] = {}
        self.classes: List[str] = []
        self.children: List['HTMLElement'] = []
        self.parent: Optional['HTMLElement'] = None
        self.id: Optional[str] = None
        self.on_created()

    def set_attribute(self, name: str, value: str):
        old_value = self.attributes.get(name)
        self.attributes[name] = value
        self.on_attribute_changed(name, old_value, value)

    def add_child(self, child: 'HTMLElement'):
        child.parent = self
        self.children.append(child)
        self.on_child_added(child)

    def render(self) -> str:
        attributes = self._build_attributes_string()
        content = self._build_content()
        self.on_rendered()
        return f"<{self.tag_name}{attributes}>{content}</{self.tag_name}>"

    def _build_attributes_string(self) -> str:
        attrs = []
        if self.id:
            attrs.append(f'id="{self.id}"')
        if self.classes:
            attrs.append(f'class="{" ".join(self.classes)}"')
        if self.styles:
            style_str = '; '.join(f'{k}: {v}' for k, v in self.styles.items())
            attrs.append(f'style="{style_str}"')
        for name, value in self.attributes.items():
            attrs.append(f'{name}="{value}"')
        return ' ' + ' '.join(attrs) if attrs else ''

    def _build_content(self) -> str:
        return ''.join(child.render() for child in self.children)