from typing import Iterator, List, Tuple, Union
from collections import deque

class HTMLTreeIterator:
    def __init__(self, root: HTMLElement):
        self.root = root
        self.current_path: List[HTMLElement] = []
        self.queue: deque = deque([(root, [])])

    def __iter__(self) -> Iterator[Tuple[HTMLElement, List[HTMLElement]]]:
        return self

    def __next__(self) -> Tuple[HTMLElement, List[HTMLElement]]:
        if not self.queue:
            raise StopIteration

        current, path = self.queue.popleft()
        for child in current.children:
            self.queue.append((child, path + [current]))
        
        return current, path

class HTMLQuerySelector:
    def __init__(self, root: HTMLElement):
        self.root = root

    def query(self, selector: str) -> List[HTMLElement]:
        if selector.startswith('#'):
            return self._find_by_id(selector[1:])
        elif selector.startswith('.'):
            return self._find_by_class(selector[1:])
        else:
            return self._find_by_tag(selector)

    def _find_by_id(self, id_: str) -> List[HTMLElement]:
        result = []
        for element, _ in HTMLTreeIterator(self.root):
            if element.id == id_:
                result.append(element)
        return result

    def _find_by_class(self, class_: str) -> List[HTMLElement]:
        result = []
        for element, _ in HTMLTreeIterator(self.root):
            if class_ in element.classes:
                result.append(element)
        return result

    def _find_by_tag(self, tag: str) -> List[HTMLElement]:
        result = []
        for element, _ in HTMLTreeIterator(self.root):
            if element.tag_name == tag:
                result.append(element)
        return result


