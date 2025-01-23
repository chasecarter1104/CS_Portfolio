#ifndef ORDEREDLINKEDLIST_HPP
#define ORDEREDLINKEDLIST_HPP
#include <iostream>
#include <stdexcept>

template <typename Type>
struct Node
{
    Type data{};
    Node<Type>* next{ nullptr };
};

template <typename Type>
class OrderedLinkedList;

template <typename Type>
std::ostream& operator<<(std::ostream&, const OrderedLinkedList<Type>& list);

template <typename Type>
class OrderedLinkedList
{
public:
    OrderedLinkedList() {} // Default constructor has no code boy has data members initialize themselves
    OrderedLinkedList(const OrderedLinkedList& other);
    OrderedLinkedList<Type>& operator=(const OrderedLinkedList<Type>& other);
    ~OrderedLinkedList();

    int size() const;
    bool empty() const;
    Type get(int) const;
    Type getFirst() const;
    Type getLast() const;
    void insert(const Type&);
    int find(const Type&) const;
    void remove(const Type&);
    void clear();
    OrderedLinkedList<Type> everyOtherOdd();
    OrderedLinkedList<Type> everyOtherEven();
    friend std::ostream& operator<< <>(std::ostream&, const OrderedLinkedList<Type>& list);
private:
    Node<Type>* front{ nullptr };
    Node<Type>* back{ nullptr };
    int count{ 0 };
};

template <typename Type>
OrderedLinkedList<Type>::OrderedLinkedList(const OrderedLinkedList<Type>& other) {
    front = nullptr;
    back = nullptr;
    count = 0;

    // Iterate through the other list and copy each element
    Node<Type>* current = other.front;
    while (current != nullptr) {
        insert(current->data);
        current = current->next;
    }
}

template<typename Type>
OrderedLinkedList<Type>& OrderedLinkedList<Type>::operator=(const OrderedLinkedList<Type>& other) {
    if (this != &other) {
        // Clear this list
        clear();

        // Iterate through the other list and copy each element
        Node<Type>* current = other.front;
        while (current != nullptr) {
            insert(current->data);
            current = current->next;
        }
    }
    return *this;
}

template<typename Type>
OrderedLinkedList<Type>::~OrderedLinkedList() {
    clear();
}

template<typename Type>
int OrderedLinkedList<Type>::size() const {
    return count;
}

template<typename Type>
bool OrderedLinkedList<Type>::empty() const {
    if (count == 0) {
        return true;
    }
    else {
        return false;
    }
}

template<typename Type>
Type OrderedLinkedList<Type>::get(int pos) const {
    if (pos < 0 || pos >= count)
        throw std::out_of_range("Index out of range");

    Node<Type>* current = front;
    for (int i = 0; i < pos; ++i)
        current = current->next;

    return current->data;
}

template<typename Type>
Type OrderedLinkedList<Type>::getFirst() const {
    if (empty())
        throw std::out_of_range("List is empty");

    return front->data;
}

template<typename Type>
Type OrderedLinkedList<Type>::getLast() const {
    if (empty())
        throw std::out_of_range("List is empty");

    return back->data;
}

template <typename Type>
void OrderedLinkedList<Type>::insert(const Type& item) {
    Node<Type>* newNode = new Node<Type>;
    newNode->data = item;
    newNode->next = nullptr;

    // If the list is empty or the item should be inserted at the front
    if (empty() || item < front->data) {
        newNode->next = front;
        front = newNode;
        // If the list was empty, back should point to the newly inserted node
        if (empty()) {
            back = newNode;
        }
    }
    else {
        Node<Type>* prev = nullptr;
        Node<Type>* current = front;
        // Find the correct position to insert the item
        while (current != nullptr && current->data < item) {
            prev = current;
            current = current->next;
        }
        // Insert the item
        prev->next = newNode;
        newNode->next = current;
        // Update back pointer if necessary
        if (prev == back) {
            back = newNode;
        }
    }
    count++;
}

template<typename Type>
int OrderedLinkedList<Type>::find(const Type& item) const {
    Node<Type>* current = front;
    int pos = 0;
    while (current) {
        if (current->data == item)
            return pos;
        current = current->next;
        pos++;
    }
    return -1;
}

template<typename Type>
void OrderedLinkedList<Type>::remove(const Type& item) {
    if (empty())
        return;

    Node<Type>* prev = nullptr;
    Node<Type>* current = front;
    while (current) {
        if (current->data == item) {
            if (current == front) {
                front = front->next;
                if (!front)
                    back = nullptr;
            }
            else {
                prev->next = current->next;
                if (!prev->next)
                    back = prev;
            }
            delete current;
            count--;
            return;
        }
        prev = current;
        current = current->next;
    }
}

template<typename Type>
void OrderedLinkedList<Type>::clear() {
    Node<Type>* current = front;
    while (current) {
        Node<Type>* temp = current;
        current = current->next;
        delete temp;
    }
    front = back = nullptr;
    count = 0;
}

template<typename Type>
OrderedLinkedList<Type> OrderedLinkedList<Type>::everyOtherOdd() {
    OrderedLinkedList<Type> result;
    Node<Type>* current = front;
    int index = 0;
    while (current) {
        if (index % 2 == 0)
            result.insert(current->data);
        current = current->next;
        index++;
    }
    return result;
}

template<typename Type>
OrderedLinkedList<Type> OrderedLinkedList<Type>::everyOtherEven() {
    OrderedLinkedList<Type> result;
    Node<Type>* current = front;
    int index = 0;
    while (current) {
        if (index % 2 != 0)
            result.insert(current->data);
        current = current->next;
        index++;
    }
    return result;
}

template<typename Type>
std::ostream& operator<<(std::ostream& os, const OrderedLinkedList<Type>& list) {
    Node<Type>* current = list.front;
    while (current) {
        os << current->data;
        if (current->next)
            os << "->";
        current = current->next;
    }
    return os;
}
#endif