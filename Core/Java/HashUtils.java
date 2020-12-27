class HashUtils {
  public static int Hash(String key, int max) {
    long totalHash = 0;
    int prime = 37;
    for (int i = 0; i < key.length(); i++) {
      char c = key.charAt(i);
      int code = (int) c;
      totalHash += prime * (totalHash + code);
    }
    totalHash = totalHash % max;
    return (int) totalHash;
  }
}