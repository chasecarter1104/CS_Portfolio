#ifndef ORDEREDLINKEDLIST_H
#define ORDEREDLINKEDLIST_H
#include <iostream>
#include <stdexcept>

template <class Type>
struct Node
{
  Type data;
  Node<Type>* next{nullptr};
};

template <class Type>
class Stack;

template <class Type>
std::ostream& operator<<(std::ostream&, const Stack<Type>& stack);

template <class Type>
class Stack
{
friend std::ostream& operator<< <>(std::ostream&, const Stack<Type>& list);
public:
  Stack();
  Stack(const Stack& other);
  Stack<Type>& operator=(const Stack<Type>& other);
  ~Stack();

  int size() const;
  bool empty() const;
  Type top() const;
  void push(const Type&);
  void pop();
  void pop(int);
  Type topPop();
  void clear();
private:
    Node<Type>* head{nullptr};

    void copy(const Stack& other);

    void printRecursive(std::ostream& out, Node<Type>* current) const;
};

template <class Type>
Stack<Type>::Stack() : head(nullptr)
{
}

template <class Type>
Stack<Type>::Stack(const Stack<Type>& other)
{
    copy(other);
}

template <class Type>
Stack<Type>& Stack<Type>::operator=(const Stack& other)
{
    if(this != &other){
        clear();
        copy(other);
    }

    return *this;
}

template <class Type>
Stack<Type>::~Stack()
{
    clear();
}

template <class Type>
int Stack<Type>::size() const
{
    int count = 0;
    Node<Type>* current = head;
    while(current != nullptr){
        count++;
        current = current->next;
    }
    return count;
}

template <class Type>
bool Stack<Type>::empty() const
{
    return size() == 0;
}

template <class Type>
Type Stack<Type>::top() const
{
    if (empty())
        throw std::logic_error("Stack is empty");
    return head->data;
}

template <class Type>
void Stack<Type>::push(const Type& item)
{
    Node<Type>* newNode = new Node<Type>{item, head};
    head = newNode;
}

template <class Type>
void Stack<Type>::pop()
{
    if (!empty()) {
        Node<Type>* temp = head;
        head = head->next;
        delete temp;
    }
}

template <class Type>
void Stack<Type>::pop(int count)
{
    while (count-- > 0) {
        pop();
    }
}

template <class Type>
Type Stack<Type>::topPop()
{
    Type topItem = top();
    pop();
    return topItem;
}

template <class Type>
void Stack<Type>::clear()
{
    while (!empty()) {
        pop();
    }
}

template <class Type>
void Stack<Type>::copy(const Stack<Type>& other)
{
    if (other.empty())
        return;

    Node<Type>* current = other.head;
    head = new Node<Type>{current->data, nullptr};
    Node<Type>* tail = head;
    current = current->next;

    while (current != nullptr) {
        tail->next = new Node<Type>{current->data, nullptr};
        tail = tail->next;
        current = current->next;
    }
}

template <class Type>
void Stack<Type>::printRecursive(std::ostream& out, Node<Type>* current) const
{
    if (current == nullptr)
        return;
    printRecursive(out, current->next);
    out << current->data;
    if (current != head)
        out << "->";
}

template <class Type>
std::ostream& operator<<(std::ostream& out, const Stack<Type>& stack)
{
    stack.printRecursive(out, stack.head);
    return out;
}

#endif
