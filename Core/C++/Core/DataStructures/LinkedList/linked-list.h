// Generic linked list implementation, using to complete cpp hashtable.
// src found: https://gist.github.com/dukky/9244500

#include <iostream>

template<class T>
struct Node {
	Node<T>* next;
	T data;
};

template<class T> class LinkedList
{
	public:
		Node<T>* first;
		Node<T>* last;
		LinkedList<T>() {
			first = NULL;
			last = NULL;
		}

		void add(T data) {
			if(!first) {
				// The list is empty
				first = new Node<T>;
				first->data = data;
				first->next = NULL;
				last = first;
			} else {
				// The list isn't empty
				if(last == first) {
					// The list has one element
					last = new Node<T>;
					last->data = data;
					last->next = NULL;
					first->next = last;
				} else {
					// The list has more than one element
					Node<T>* insdata = new Node<T>;
					insdata->data = data;
					insdata->next = NULL;
					last->next = insdata;
					last = insdata;
				}
			}
		}

		T get(int index) {
			if(index == 0) {
				// Get the first element
				return this->first->data;
			} else {
				// Get the index'th element
				Node<T>* curr = this->first;
				for(int i = 0; i < index; ++i) {
					curr = curr->next;
				}
				return curr->data;
			}
		}

		T operator[](int index) {
			return get(index);
		}

		~LinkedList<T>() {
			Node<T>* tempNode = first;
			// Go through the linked list and free up the nodes.
			while (tempNode) {
				tempNode = tempNode->next;
				free(tempNode->data);
				free(tempNode);
			}
		}
};