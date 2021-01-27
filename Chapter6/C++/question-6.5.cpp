// g++ question-6.5.cpp -o out && ./out

#import <iostream>

using namespace std;

bool jugs_of_water(int vol_one, int vol_two, int target_vol) {
  int jug_one, jug_two;
  jug_one = vol_one;
  int tries = 0;
  while (jug_one != target_vol) {
    if (tries > 10) {
      return false;
    }
    if (jug_two != vol_two) {
      jug_one -= vol_two;
      jug_two += jug_one;
    } else {
      jug_two += jug_one;
      jug_one = 0;
    }
    cout << "\n Jug one: ";
    cout << jug_one;
    cout << " Jug two: ";
    cout << jug_two;
    tries += 1;
  }
  return jug_one == target_vol;
}

int main() {
  bool res = jugs_of_water(5, 3, 4);
  cout << "\n";
  return 0;
}