from typing import Dict, List, Set, Any
from collections import defaultdict
from html_lifecycle import HTMLElement

class HTMLMetricsCollector:
    def __init__(self):
        self.tag_count: Dict[str, int] = defaultdict(int)
        self.depth_stats: Dict[str, float] = {}
        self.class_usage: Dict[str, Set[str]] = defaultdict(set)
        self.style_usage: Dict[str, Set[str]] = defaultdict(set)
        self.element_count: int = 0
        self.max_depth: int = 0

    def analyze(self, root: HTMLElement):
        self._collect_metrics(root, 0)
        self._calculate_statistics()

    def _collect_metrics(self, element: HTMLElement, depth: int):
        self.element_count += 1
        self.tag_count[element.tag_name] += 1
        self.max_depth = max(self.max_depth, depth)

        for class_ in element.classes:
            self.class_usage[class_].add(element.tag_name)

        for style_prop in element.styles:
            self.style_usage[style_prop].add(element.tag_name)

        for child in element.children:
            self._collect_metrics(child, depth + 1)

    def _calculate_statistics(self):
        self.depth_stats = {
            'max_depth': self.max_depth,
            'avg_elements_per_level': self.element_count / (self.max_depth + 1)
        }

    def get_report(self) -> Dict[str, Any]:
        return {
            'element_statistics': {
                'total_elements': self.element_count,
                'unique_tags': len(self.tag_count),
                'tag_distribution': dict(self.tag_count)
            },
            'depth_statistics': self.depth_stats,
            'style_usage': {
                prop: list(tags)
                for prop, tags in self.style_usage.items()
            },
            'class_usage': {
                class_: list(tags)
                for class_, tags in self.class_usage.items()
            }
        }