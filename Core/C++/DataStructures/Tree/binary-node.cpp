#include<string>
#include "binary-node.h"
using namespace std;

class BinaryNode {
  public:
    int value;

    BinaryNode* left;

    BinaryNode* right;

    BinaryNode(int value) {
      this->value = value;
    }

    string left_value() {
      if (left != NULL) {
        return to_string(left->value);
      }
      return "";
    }

    string right_value() {
      if (right != NULL) {
        return to_string(right->value);
      }
      return "";
    }

    string get_string() {
      return "[BinaryNode value:" + to_string(value) + ", l:" + left_value() + ", r:" + right_value() + "]";
    }

    ~BinaryNode() {
      delete this->left;
      delete this->right;
    }
};
