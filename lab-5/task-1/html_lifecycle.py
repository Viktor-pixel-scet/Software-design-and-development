from typing import Dict, List, Optional, Any
from datetime import datetime
import json

class HTMLElementLifecycle:
    def __init__(self):
        self.created_at: datetime = datetime.now()
        self.updated_at: Optional[datetime] = None
        self.rendered_count: int = 0
        self.event_history: List[Dict[str, Any]] = []
        
    def log_event(self, event_name: str, details: Dict[str, Any] = None):
        event = {
            'event': event_name,
            'timestamp': datetime.now(),
            'details': details or {}
        }
        self.event_history.append(event)
        
    def on_created(self):
        self.log_event('created', {'created_at': self.created_at})
        
    def on_rendered(self):
        self.rendered_count += 1
        self.log_event('rendered', {'render_count': self.rendered_count})
        
    def on_style_applied(self, property_name: str, value: str):
        self.log_event('style_applied', {'property': property_name, 'value': value})
        
    def on_class_added(self, class_name: str):
        self.log_event('class_added', {'class': class_name})
        
    def on_attribute_changed(self, name: str, old_value: str, new_value: str):
        self.log_event('attribute_changed', {
            'attribute': name,
            'old_value': old_value,
            'new_value': new_value
        })
        
    def on_child_added(self, child_tag: str):
        self.log_event('child_added', {'child_tag': child_tag})
        
    def on_removed(self):
        self.log_event('removed')
        
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
        self.on_child_added(child.tag_name)
        
    def add_class(self, class_name: str):
        if class_name not in self.classes:
            self.classes.append(class_name)
            self.on_class_added(class_name)
            
    def set_style(self, property_name: str, value: str):
        self.styles[property_name] = value
        self.on_style_applied(property_name, value)
        
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
        
    def remove_from_parent(self):
        if self.parent:
            self.parent.children.remove(self)
            self.parent = None
            self.on_removed()