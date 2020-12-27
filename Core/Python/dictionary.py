INITIAL_ITEMS_SIZE = 100

def hash(key, max):
  totalHash = 0
  prime = 37
  for char in key:
    totalHash += prime * (totalHash + ord(char))
  return totalHash % max

def getIndexOfKey(key, chainArr):
  for (i, _) in enumerate(chainArr):
    chainItem = chainArr[i]
    if (chainItem[0] == key):
      return i
  return -1

class Dictionary:

  __items = []

  __insertionCount = 0

  __collisionCount = 0

  def __init__(self, keyValuePairs):
    for _ in range(0, INITIAL_ITEMS_SIZE):
      self.__items.append([])
    if (keyValuePairs and len(keyValuePairs) > 0):
      self.__setKeyValuePairs(keyValuePairs)

  def __setKeyValuePairs(self, keyValuePairs):
    if (keyValuePairs and len(keyValuePairs) > 0):
      for pair in keyValuePairs:
        self.set(pair[0], pair[1])

  def set(self, key, value):
    hashIndex = hash(key, len(self.__items) - 1)
    self.__insertionCount += 1
    newPair = [key, value, self.__insertionCount]
    if (len(self.__items[hashIndex]) > 0):
      # Collision occured.
      self.__collisionCount += 1
    if (self.__collisionCount > 10):
      self.__collisionCount = 0
      for _ in range(0, len(self.__items)):
        self.__items.append([])
    existingIndex = getIndexOfKey(key, self.__items[hashIndex])
    if (existingIndex > -1):
      self.__items[hashIndex][existingIndex] = newPair
    else:
      self.__items[hashIndex].append(newPair)

  def get(self, key):
    hashIndex = hash(key, len(self.__items) - 1)
    chain = self.__items[hashIndex]
    for item in chain:
      if (item[0] == key):
        return item[1]
    return None

  def has(self, key):
    return self.get(key) is not None

  def entries(self):
    chainEntries = []
    entries = filter(lambda chain: len(chain) > 0, self.__items)
    for chain in entries:
      for item in chain:
        chainEntries.append(item)
    return sorted(chainEntries, key=lambda arr: arr[2])

  def __str__(self):
    retStr = '{ \n'
    entries = self.entries()
    for (index, entry) in enumerate(entries):
      if (type(entry[1]) is str):
        retStr += "  \"" + str(entry[0]) + "\" : \"" + str(entry[1]) + "\""
      else:
        retStr += "  \"" + str(entry[0]) + "\" : " + str(entry[1])
      if (index < (len(entries) - 1)):
        retStr += ",\n"
    retStr += '\n}'
    return retStr

newDict = Dictionary([["hello", 89], ["what?", "who!"], ["Stamm", None]])
newDict.set("happy", "Good feeling!")
newDict.set("happy", None)
newDict.set("happy", "Not none!!")
print(newDict.entries())
