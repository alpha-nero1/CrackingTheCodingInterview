// Followed awesome journaldev tutroial: https://www.journaldev.com/35238/hash-table-in-c-plus-plus

// Figure out how to import the generic linked-list properly
// Continue the tutorial to cover collision detection.

#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>

using namespace std;
#define CAPACITY 5000;

class HashtableEntry {
  public: 
    const char* key;
    const char* value;
    HashtableEntry(const char* key, const char* value) {
      this->key = key;
      this->value = value;
    }
};

class Hashtable {
  private:
    // The double star means a pointer to a pointer of the variable.
    HashtableEntry **items;
    int insertion_count;
    int collision_count;
    int size;

    // Code to free entry from memory.
    void free_item(HashtableEntry* item) {
      free((char*)item->key); // Here we casted to char* so we could use the free func.
      free((char*)item->value);
      free(item);
    }

    // Handle item entry collision...
    void handle_collision(HashtableEntry* item) {

    }

  public:
    // Constructor.
    Hashtable() {
      
    }

    unsigned long hash(const char* key) {
      unsigned long totalHash = 0;
      int prime = 37;
      for (int i = 0; key[i]; i++) {
        totalHash += prime + key[i];
      }
      return totalHash % CAPACITY;
    }

    // Code to create a hash table entry.
    HashtableEntry* create_item(const char* key, const char* value) {
      HashtableEntry* item = (HashtableEntry*) malloc (sizeof(HashtableEntry)); // Create the uninitialised pointer to our new item/block.
      item->key = (const char*) malloc (strlen(key) + 1);
      item->value = (const char*) malloc (strlen(value) + 1);
      strcpy((char*)item->key, key);
      strcpy((char*)item->value, value);
      return item;
    }

    // Code to create the hashtable.
    Hashtable* create_table(int size) {
      Hashtable* table = (Hashtable*) malloc (sizeof(Hashtable));
      table->size = size;
      table->collision_count = 0;
      table->insertion_count = 0;
      table->items = (HashtableEntry**) calloc (table->size, sizeof(HashtableEntry*)); // calloc allocates and zero-initialises an array.
      for (int i = 0; i < table->size; i++) {
        table->items[i] = NULL;
      }
      return table;
    }

    HashtableEntry* set(const char* key, const char* value) {
      int hash_index = hash(key);
      HashtableEntry* item = create_item(key, value);
      HashtableEntry* current_item = items[hash_index];
      if (current_item == NULL) {
        // Free rein!
        if (insertion_count == size) {
          // Table is full!
          printf("Set error, hashtable is full!\n");
          free_item(item);
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
        handle_collision(item);
        return;
      }
    }

    const char* get(const char* key) {
      int hash_index = hash(key);
      HashtableEntry* item = items[hash_index];
      // Okay we have the "item" lets see if we can move to a non null item with matching key.
      if (item != NULL) {
        if (strcmp(item->key, key) == 0) {
          return item->value;
        }
      }
      return NULL;
    }

    void print() {
      printf("\n Hashtable\n-----------------\n");
      for (int i = 0; i < size; i++) {
        if (items[i]) {
          HashtableEntry* item = items[i];
          printf("{ %s %s }\n", item->key, item->value);
        }
      }
      printf("-----------------");
    }

    // ~ is a bitwise not operator, my guess is this takes care of memory cleanup.
    ~Hashtable() {
      // Destruct!
      for (int i = 0; i < size; i++) {
        HashtableEntry* item = items[i];
        if (item != NULL) {
          free_item(item);
        }
      }
      free(items);
      free(this);
    }
};

int main() {
  return 0;
}
