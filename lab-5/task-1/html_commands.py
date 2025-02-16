from typing import List, Optional
from datetime import datetime

class CommandHistory:
    def __init__(self):
        self.commands: List[HTMLCommand] = []
        self.current_index: int = -1

    def execute(self, command: 'HTMLCommand'):
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