class MyHashMap:

    def __init__(self):
        self.M = 5
        self.W = 20
        self.array = [[]] * (1 << (self.W - self.M))

    def put(self, key: int, value: int) -> None:
        t = self.hash(key)
        for i, (k, v) in enumerate(self.array[t]):
            if k == key:
                self.array[t][i] = (k, value)
                return

        self.array[t].append((key, value))

    def get(self, key: int) -> int:
        t = self.hash(key)
        for k, v in self.array[t]:
            if k == key: return v

        return -1


    def remove(self, key: int) -> None:
        t = self.hash(key)
        for i, (k, _) in enumerate(self.array[t]):
            if k == key:
                del self.array[t][i]
                return

    def hash(self, key: int) -> int:
        return ((key * 1031237) & (1 << self.W) - 1) >> self.M