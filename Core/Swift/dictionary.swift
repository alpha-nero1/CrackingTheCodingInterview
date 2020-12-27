extension Character {
  func getCharCode() -> Int {
    let charStr = String(self);
    let charScalars = charStr.unicodeScalars;
    return Int(charScalars[charScalars.startIndex].value)  
  }
}

let INITIAL_ITEMS_SIZE = 100;

// Our hashing function...
func hash(key: String, maxNumber: Int) -> Int {
  var hashTotal = 0;
  let primeMultiplier = 37;
  for char in key {
    hashTotal = hashTotal + (primeMultiplier * (char.getCharCode() + hashTotal));
  }
  return hashTotal % maxNumber;
}

func getIndexOfKey(key: String, chainArr: [[Any]]) -> Int {
  for (i, _) in chainArr.enumerated() {
    let chainItem = chainArr[i];
    if (chainItem[0] as! String == key) {
      return i;
    }
  }
  return -1;
}

class Dictionary {

  private var items: [[[Any]]] = Array(repeating: [], count: INITIAL_ITEMS_SIZE)

  private var collisionCount = 0;

  private var insertionCount = 0;

  init() { }

  init(fromKeyValuePairs keyValuePairs: [[Any]]) {
    if (keyValuePairs.count > 0) {
      self.setKeyValuePairs(keyValuePairs: keyValuePairs);
    }
  }

  private func setKeyValuePairs(keyValuePairs: [[Any]]) -> Void {
    for keyValuePair in keyValuePairs {
      self.set(key: keyValuePair[0] as! String, value: keyValuePair[1]);
    }
  }

  public func set(key: String, value: Any) -> Void {
    let hashIndex = hash(key: key, maxNumber: self.items.count - 1);
    self.insertionCount += 1;
    let newPair = [key, value, self.insertionCount];
    if (self.items[hashIndex].count > 1) {
      // We are colliding.
      self.collisionCount += 1;
    }
    if (self.collisionCount > 10) {
      // Double the array size, we are colliding a lot.
      self.collisionCount = 0;
      self.items.append(contentsOf: Array(repeating: [], count: self.items.count))
    }
    let existingIndex = getIndexOfKey(key: key, chainArr: self.items[hashIndex]);
    if (existingIndex > -1) {
      self.items[hashIndex][existingIndex] = newPair;
    } else {
      self.items[hashIndex].append(newPair);
    }
  }

  public func get(key: String) -> Any? {
    let hashIndex = hash(key: key, maxNumber: self.items.count - 1);
    let chain = self.items[hashIndex];
    for pair in chain {
      if let pairKey = pair[0] as? String {
        if (pairKey == key) {
          return pair[1];
        }
      }
    }
    return nil;
  }

  public func remove(key: String) -> Void {
    let hashIndex = hash(key: key, maxNumber: self.items.count - 1);
    let chain = self.items[hashIndex];
    let existingIndex = getIndexOfKey(key: key, chainArr: chain);
    if (existingIndex > -1) {
      // we have an entry to delete.
      self.items[hashIndex].remove(at: existingIndex)
    }
  }

  public func has(key: String) -> Bool {
    return self.get(key: key) != nil;
  }

  public func entries() -> [[Any]] {
    var chainEntries: [[Any]] = [];
    let entries = self.items.filter { $0.count > 0 }
    for pair in entries {
      for item in pair {
        chainEntries.append(item);
      }
    }
    chainEntries.sort {
      let itemOne = $0 as [Any]
      let itemTwo = $1 as [Any]
      let orderOne = itemOne[2] as! Int
      let orderTwo = itemTwo[2] as! Int
      return orderOne < orderTwo;
    }
    return chainEntries;
  }

  public func toString() -> String {
    let entries = self.entries();
    var retStr = "{ \n";
    for (index, entry) in entries.enumerated() {
      let valueType = "\(type(of: entry[1]))"
      if (valueType == "String") {
        retStr += "  \"\(entry[0])\" : \"\(entry[1])\""
      } else {
        retStr += "  \"\(entry[0])\" : \(entry[1])"
      }
      if (index < entries.count - 1) {
        retStr += ",\n"
      }
    }
    retStr += "\n}"
    return retStr;
  }
}

let dict = Dictionary(fromKeyValuePairs: [["hey", "person!"]])
dict.remove(key: "hey");
dict.set(key: "mcklunky", value: 100);
print(dict.toString())
