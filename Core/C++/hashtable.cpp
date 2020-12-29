// Followed awesome journaldev tutroial: https://www.journaldev.com/35238/hash-table-in-c-plus-plus

// Figure out how to import the generic linked-list properly
// Continue the tutorial to cover collision detection.

#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
#include<string>

using namespace std;
#define CAPACITY 5000;

typedef struct LinkedList LinkedList;
 
class HashtableEntry {
  public: 
    const char* key;
    const char* value;
    HashtableEntry(const char* key, const char* value) {
      this->key = key;
      this->value = value;
    }
};

// Define the Linkedlist here, NOTE: This is a "C" impementation. its actually using calloc and malloc...
struct LinkedList {
    HashtableEntry* item; 
    LinkedList* next;
};
 
LinkedList* allocate_list () {
    // Allocates memory for a Linkedlist pointer
    LinkedList* list = (LinkedList*) malloc (sizeof(LinkedList));
    return list;
}
 
LinkedList* linkedlist_insert(LinkedList* list, HashtableEntry* item) {
    // Inserts the item onto the Linked List
    if (!list) {
        LinkedList* head = allocate_list();
        head->item = item;
        head->next = NULL;
        list = head;
        return list;
    } 
     
    else if (list->next == NULL) {
        LinkedList* node = allocate_list();
        node->item = item;
        node->next = NULL;
        list->next = node;
        return list;
    }
 
    LinkedList* temp = list;
    while (temp->next->next) {
        temp = temp->next;
    }
     
    LinkedList* node = allocate_list();
    node->item = item;
    node->next = NULL;
    temp->next = node;
     
    return list;
}
 
HashtableEntry* linkedlist_remove(LinkedList* list) {
    // Removes the head from the linked list
    // and returns the item of the popped element
    if (!list)
        return NULL;
    if (!list->next)
        return NULL;
    LinkedList* node = list->next;
    LinkedList* temp = list;
    temp->next = NULL;
    list = node;
    HashtableEntry* it = NULL;
    memcpy(temp->item, it, sizeof(HashtableEntry));
    free((char*)temp->item->key);
    free((char*)temp->item->value);
    free((char*)temp->item);
    free(temp);
    return it;
}
 
void free_linkedlist(LinkedList* list) {
    LinkedList* temp = list;
    while (list) {
        temp = list;
        list = list->next;
        free((char*)temp->item->key);
        free((char*)temp->item->value);
        free(temp->item);
        free(temp);
    }
}

// I am aware that the "items" are redundant.
class Hashtable {
  private:
    // The double star means a pointer to a pointer of the variable.
    HashtableEntry **items;
    LinkedList** overflow_buckets;
    int insertion_count;
    int collision_count;
    int size;

    // Handle item entry collision...
    void handle_collision(HashtableEntry* item, unsigned long index) {
      LinkedList* chain = overflow_buckets[index];
      if (chain == NULL) {
        chain = allocate_list();
        chain->item = item;
        overflow_buckets[index] = chain;
        return;
      }
      overflow_buckets[index] = linkedlist_insert(overflow_buckets[index], item);
    }

  public:
    // Constructor.
    Hashtable() {
      size = CAPACITY;
      collision_count = 0;
      insertion_count = 0;
      items = new HashtableEntry *[size];
      overflow_buckets = new LinkedList *[size];
      for (int i = 0; i < size; i++) {
        items[i] = NULL;
      }
    }

    // Our hash function...
    unsigned long hash(const char* key) { // ✅
      unsigned long totalHash = 0;
      int prime = 37;
      for (int i = 0; key[i]; i++) {
        totalHash += prime + key[i];
      }
      return totalHash % CAPACITY;
    }

    // set the var.
    void set(const char* key, const char* value) { // ✅
      int hash_index = hash(key);
      HashtableEntry* item = new HashtableEntry(key, value);
      HashtableEntry* current_item = items[hash_index];
      if (current_item == NULL) {
        // Free rein!
        if (insertion_count == size) {
          // Table is full!
          printf("Set error, hashtable is full!\n");
          delete item;
          return;
        }
        // Else insert directly.
        items[hash_index] = item;
        insertion_count += 1;
      } else {
        if (strcmp(current_item->key, key) == 0) { // strcmp performs a binary comparison of two strings... "0" means contents are equal.
          strcpy((char*)items[hash_index]->value, value); // we've got our current item and we are switching the value.
          return;
        }
        // Else handle collision.
        handle_collision(item, hash_index);
      }
    }

    const char* get(const char* key) { // ✅
      int hash_index = hash(key);
      HashtableEntry* item = items[hash_index];
      LinkedList* chain = overflow_buckets[hash_index];

      while (item != NULL) {
        if (strcmp(item->key, key) == 0) {
          return item->value;
        }
        if (chain == NULL) {
          return NULL;
        }
        item = chain->item;
        chain = chain->next;
      }
      // Okay we have the "item" lets see if we can move to a non null item with matching key.
      if (item != NULL) {
        if (strcmp(item->key, key) == 0) {
          return item->value;
        }
      }
      return NULL;
    }

    void remove(const char* key) { // ✅
      int hash_index = hash(key);
      HashtableEntry* item = items[hash_index];
      LinkedList* chain = overflow_buckets[hash_index];
      if (item == NULL) {
        return;
      }
      if (chain == NULL && strcmp(item->key, key) == 0) {
        // No collision.
        items[hash_index] = NULL;
        delete item;
        insertion_count -= 1;
        return;
      }
      if (chain != NULL) {
        if (strcmp(item->key, key) == 0) {
          // Remove this item and set the head of the list as the next item.
          delete item;
          LinkedList* node = chain;
          chain = node->next;
          node->next = NULL;
          items[hash_index] = new HashtableEntry(node->item->key, node->item->value);
          delete node;
          overflow_buckets[hash_index] = chain;
          return;
        }

        LinkedList* curr = chain;
        LinkedList* prev = NULL;

        while (curr) {
          if (strcmp(curr->item->key, key) == 0) {
            // Found item in chain to remove...
            if (prev == NULL) {
              // First el of chain, remove the chain.
              delete chain;
              overflow_buckets[hash_index] = NULL;
            } else {
              prev->next = curr->next;
              curr->next = NULL;
              delete curr;
              overflow_buckets[hash_index] = chain;
            }
          }
          prev = curr;
          curr = curr->next;
        }
      }
    }

    // To string function.
    string to_string() { // ✅
      string str = "{\n";
      bool hasPassedFirstEntry = false;
      for (int i = 0; i < size; i++) {
        if (items[i]) {
          HashtableEntry* item = items[i];
          if (hasPassedFirstEntry) {
            str = str + ",\n";
          }
          str = str + "  \"" + item->key + "\" : \"" + item->value + "\"";
          hasPassedFirstEntry = true;
        }
      }
      str = str + "\n}\n";
      return str;
    }

    void print() {
      cout << to_string();
    }

    // ~ is a bitwise not operator, my guess is this takes care of memory cleanup.
    ~Hashtable() {
      // Destruct!
      for (int i = 0; i < size; i++) {
        HashtableEntry* item = items[i];
        if (item != NULL) {
          delete item;
        }
      }
      delete[] items;
      delete this;
    }
};

int main() {
  Hashtable* ht = new Hashtable();
  ht->set("dog", "45KJD0");
  ht->set("catter", "78FGLK");
  ht->set("stormtrooper", "FN2187");
  ht->remove("dog");
  cout << ht->get("stormtrooper");
  ht->print();
  return 0;
}
