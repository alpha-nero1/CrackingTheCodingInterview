import java.util.Arrays;

class ArrayUtils {
  
  public static Object[][] AppendNestedArray(Object[] item, Object[][] array) {
    if (array != null) {
      Object[][] incrementedCopy = Arrays.copyOf(array, array.length + 1);
      incrementedCopy[incrementedCopy.length - 1] = item;
      return incrementedCopy;
    }
    return array;
  }

  public static void PrintArray(Object[] arr) {
    int len = arr.length;
    for (int i = 0; i < len; i++) {
      System.out.println(arr[i].toString());
    }
  }

  public static void PrintArray(Object[][] arr) {
    int len = arr.length;
    for (int i = 0; i < len; i++) {
      Arrays.toString(arr[i]);
    }
  }

  public static int GetIndexOfKey(String key, Object[][] arr) {
    for (int i = 0; i < arr.length; i++) {
      Object[] chainItem = arr[i];
      if (chainItem[0] == key) {
        return i;
      }
    }
    return -1;
  }

  public static Object[] Double(Object[] array) {
    Object[] newArr = new Object[0];
    if (array != null) {
      int len = array.length;
      newArr = new Object[len * 2];
      System.arraycopy(array, 0, newArr, 0, len);
    }
    return newArr;
  }
}