from abc import ABC, abstractmethod
from typing import List, Dict, Any, Optional
from datetime import datetime
from html_lifecycle import HTMLElement

class HTMLCommand(ABC):
    def __init__(self):
        self.timestamp: datetime = datetime.now()
        self.description: str = ''
        
    @abstractmethod
    def execute(self):
        pass
        
    @abstractmethod
    def undo(self):
        pass

class AddClassCommand(HTMLCommand):
    def __init__(self, element: HTMLElement, class_name: str):
        super().__init__()
        self.element = element
        self.class_name = class_name
        self.description = f"Add class '{class_name}' to {element.tag_name}"
        
    def execute(self):
        if self.class_name not in self.element.classes:
            self.element.add_class(self.class_name)
            
    def undo(self):
        if self.class_name in self.element.classes:
            self.element.classes.remove(self.class_name)

class SetAttributeCommand(HTMLCommand):
    def __init__(self, element: HTMLElement, name: str, value: str):
        super().__init__()
        self.element = element
        self.name = name
        self.value = value
        self.old_value = element.attributes.get(name)
        self.description = f"Set attribute '{name}={value}' on {element.tag_name}"
        
    def execute(self):
        self.element.set_attribute(self.name, self.value)
        
    def undo(self):
        if self.old_value is None:
            del self.element.attributes[self.name]
        else:
            self.element.attributes[self.name] = self.old_value

class AddChildCommand(HTMLCommand):
    def __init__(self, parent: HTMLElement, child: HTMLElement):
        super().__init__()
        self.parent = parent
        self.child = child
        self.description = f"Add {child.tag_name} to {parent.tag_name}"
        
    def execute(self):
        self.parent.add_child(self.child)
        
    def undo(self):
        self.child.remove_from_parent()

class CommandHistory:
    def __init__(self):
        self.commands: List[HTMLCommand] = []
        self.current_index: int = -1
        
    def execute(self, command: HTMLCommand):
        self.current_index += 1
        if self.current_index < len(self.commands):
            self.commands[self.current_index:] = []
        self.commands.append(command)
        command.execute()
        
    def undo(self) -> bool:
        if self.current_index >= 0:
            self.commands[self.current_index].undo()
            self.current_index -= 1
            return True
        return False
        
    def redo(self) -> bool:
        if self.current_index + 1 < len(self.commands):
            self.current_index += 1
            self.commands[self.current_index].execute()
            return True
        return False
        
    def get_history(self) -> List[Dict[str, Any]]:
        return [
            {
                'command': cmd.__class__.__name__,
                'timestamp': cmd.timestamp,
                'description': cmd.description
            }
            for cmd in self.commands
        ]