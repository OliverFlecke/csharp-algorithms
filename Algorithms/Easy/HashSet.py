class MyHashSet:

    def __init__(self):
        self.size = 10000
        self.array = [[]] * self.size

    def add(self, key: int) -> None:
        if not self.contains(key):
            self.array[self.hash(key)].append(key)

    def remove(self, key: int) -> None:
        if self.contains(key):
            self.array[self.hash(key)].remove(key)

    def contains(self, key: int) -> bool:
        return key in self.array[self.hash(key)]

    def hash(self, key: int) -> int:
        return key % self.size