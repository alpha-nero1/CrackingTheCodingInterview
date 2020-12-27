// Hashtable implementation.

const hash = (key, numberCap) => {
  const prime = 37;
  let retIndex = 0;
  for (let i = 0; i < key.length; i++) {
    // Build our large and close to randim number.
    retIndex += (prime * retIndex + key.charCodeAt(i));
  }
  // Here we are saying that the index = huge number % items length
  // Remember that with a % b the result can never be larger than b.
  retIndex %= numberCap;
  return parseInt(retIndex);
}

const getIndexOfKey = (key, chainArr) => {
  for (let i = 0; i < chainArr.length; i++) {
    let chainItem = chainArr[i];
    if (chainItem[0] === key) {
      return i;
    }
  }
  return -1;
}

class Hashtable {

  constructor(keyValuePairs) {
    this.insertionCount = 0;
    this._items = new Array(100);
    this._collisionCount = 0;
    this.setKeyValuePairs(keyValuePairs)

  }

  setKeyValuePairs(keyValuePairs) {
    if (keyValuePairs && keyValuePairs.length) {
      keyValuePairs.forEach(pair => {
        this.set(pair[0], pair[1]);
      })
    }
  }

  get(key) {
    const getIndex = hash(key, this._items.length - 1);
    if (this._items[getIndex]) {
      if (this._items[getIndex].length > 1) {
        const correctValue = this._items[getIndex].find(entry => entry[0] === key);
        return correctValue[1];
      } else {
        return this._items[getIndex][0][1];
      }
    }
    return this._items[getIndex];
  }

  remove(key) {
    const getIndex = hash(key, this._items.length - 1);
    const chain = this._items[getIndex];
    if (chain && chain.length > 0) {
      const existingIndex = getIndexOfKey(key, chain);
      if (existingIndex > -1) {
        chain.splice(existingIndex, 1);
      }
    }
  }

  set(key, value) {
    const setIndex = hash(key, this._items.length - 1);
    const newPair = [key, value, this.insertionCount]
    if (this._items[setIndex]) {
      const existingIndex = getIndexOfKey(key, this._items[setIndex]);
      if (existingIndex > -1) {
        this._items[setIndex][existingIndex] = newPair;
      } else {
        this._items[setIndex].push(newPair);
      }
      this._collisionCount++;
      if (this._collisionCount > 10) {
        this._collisionCount = 0;
        // Double the size of array.
        this._items.concat(...new Array(this._items.length));
      }
    } else {
      this._items[setIndex] = [newPair];
    }
    this.insertionCount++;
  }

  has(key) {
    return typeof this.get(key) !== 'undefined';
  }

  toString() {
    let str = `{\n`;
    const values = this._items.filter(value => !!value)
    values.forEach((chain, i) => {
      if (chain && chain.length) {
        chain.forEach((entry, j) => {
          const isLastOfLastIndex = i === values.length - 1 && j === chain.length - 1;
          if (typeof entry[1] === 'string') {
            str += `  "${entry[0]}" : "${entry[1]}"`
          } else if (typeof entry[1] === 'object') {
            str += `  "${entry[0]}" : ${JSON.stringify(entry[1])}`
          } else {
            str += `  "${entry[0]}" : ${entry[1]}`
          }
          if (!isLastOfLastIndex) {
            str += ',\n'
          }
        });
      }
    })
    str += '\n}'
    return str;
  }

  // Get the entries sorted by insertion order!
  entries() {
    let list = [];
    const values = this._items.filter(value => !!value)
    values.forEach(chain => {
      chain.forEach(entry => {
        list.push(entry)
      })
    })
    return list.sort((a, b) => a[2] - b[2])
  }
}

const ht = new Hashtable([["hello", "There!!!!"]])
ht.remove("hello")
console.log(ht.toString())

module.exports = { Hashtable }

