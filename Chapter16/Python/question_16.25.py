class LruCache():
    used_counts = {}
    cache = {}

    def __init__(self, max_size = 3):
        self.max_size = max_size
        self.lowest_used_count = self.max_size;

    def get(self, key):
        self.used_counts[key] = (self.used_counts.get(key) or 0) + 1
        if (self.used_counts.get(key) < self.lowest_used_count):
            self.lowest_used_count = self.used_counts.get(key)
        return self.cache.get(key)

    def set(self, key, value):
        self.used_counts[key] = 0
        if (len(self.cache) > self.max_size):
            # Kick out the least used element.
            lowest_used_item = self.used_counts.get(self.lowest_used_count)
            if (lowest_used_item != None):
                self.cache.pop(lowest_used_item)
                self.used_counts.pop(lowest_used_item)

        self.cache[key] = value

    def print(self):
        for key in self.cache:
            print(key, self.cache[key])


cache = LruCache()

cache.set('hello', 'thisurl')
cache.set('hello1', 'thisurl')
cache.set('hello2', 'thisurl')
cache.set('hello3', 'thisurl')
cache.set('hello4', 'thisurl')

cache.get('hello')
cache.get('hello1')
cache.get('hello2')
cache.get('hello3')
cache.get('hello4')

cache.print()