import java.util.Arrays;

class AAHashtable {

  public static int MAX_COLLISION_THRESHOLD = 10;

  public static int INITIAL_ITEMS_LENGTH = 100;

  private int insertionCount = 0;

  private int collisionCount = 0;

  private Object[][][] items = new Object[AAHashtable.INITIAL_ITEMS_LENGTH][0][0];

  public static void main(String[] args) {
    Object[][] arr = {
      {"hello", "There-6"},
      {"hello1", "Sausage"}
    };
    AAHashtable aaht = new AAHashtable(arr);
    aaht.set("hello", null);
    System.out.println(aaht.toString());
    aaht.printEntries();
    System.out.println("hey " + aaht.get("hello"));
  }

  public AAHashtable() { }

  public AAHashtable(Object[][] keyValuePairs) {
    if (keyValuePairs != null && keyValuePairs.length > 0) {
      for (int i = 0; i < keyValuePairs.length; i++) {
        Object[] pair = keyValuePairs[i];
        this.set(pair[0].toString(), pair[1]);
      }
    }
  }

  public Object get(String key) {
    if (key != null && key.length() > 0) {
      int hash = HashUtils.Hash(key, this.items.length - 1);
      Object[][] chain = this.items[hash];
      for (int i = 0; i < chain.length; i++) {
        Object[] chainItem = chain[i];
        if (chainItem[0] == key) {
          return chainItem[1];
        }
      }
    }
    return null;
  }

  public void set(String key, Object value) {
    if (key != null && key.length() > 0) {
      int hash = HashUtils.Hash(key, this.items.length - 1);
      this.insertionCount += 1;
      Object[] newPair = { key, value, this.insertionCount };
      if (this.items[hash].length > 0) {
        // Oops, collision.
        this.collisionCount += 1;
      }
      if (this.collisionCount > AAHashtable.MAX_COLLISION_THRESHOLD) {
        this.collisionCount = 0;
        this.items = (Object[][][])ArrayUtils.Double((Object[])this.items);
      }
      int existingIndex = ArrayUtils.GetIndexOfKey(key, this.items[hash]);
      if (existingIndex > -1) {
        this.items[hash][existingIndex] = newPair;
      } else {
        this.items[hash] = (Object[][])ArrayUtils.AppendNestedArray(newPair, this.items[hash]);
      }
    }
  }

  public boolean has(String key) {
    return this.get(key) != null;
  }

  public Object[][] entries() {
    Object[][] flatEntries = new Object[0][0]; // [[]]
    Object[][][] nonEmptyChainEntries = Arrays.stream(this.items)
      .filter(chain -> chain.length > 0)
      .toArray(Object[][][]::new); // [[[0, 1, 2], [0, 1, 2]], [[0, 1, 2]]]

    for (int i = 0; i < nonEmptyChainEntries.length; i++) {
      Object[][] chain = nonEmptyChainEntries[i];
      for (int j = 0; j < chain.length; j++) {
        Object[] item = chain[j];
        flatEntries = ArrayUtils.AppendNestedArray(item, flatEntries);
      }
    }
    return flatEntries;
  }

  public void printEntries() {
    Object[][] entries = this.entries();
    System.out.println("entries: ");
    for (int i = 0; i < entries.length; i++) {
      System.out.println(Arrays.toString(entries[i]));
    }
  }

  public String toString() {
    String retString = "{\n";
    Object[][] entries = this.entries();
    for (int i = 0; i < entries.length; i++) {
      Object[] entry = entries[i];
      if (entry[1] instanceof String) {
        retString += "  \"" + entry[0] + "\" : \"" + entry[1] + "\"";
      } else {
        retString += "  \"" + entry[0] + "\" :" + entry[1];
      }
      if (i < entries.length - 1) {
        retString += ",\n";
      }
    }
    retString += "\n}";
    return retString;
  }
}