#ifndef BINARY_TREE_HPP
#define BINARY_TREE_HPP

#include <iostream>

template <typename Type>
struct Node {
    Type item{};
    Node<Type>* left{ nullptr };
    Node<Type>* right{ nullptr };
};

template <typename Type>
class BinaryTree {
public:
    BinaryTree(){}
    BinaryTree(const BinaryTree<Type>& objToCopy);
    BinaryTree<Type>& operator=(const BinaryTree& b); 
    ~BinaryTree();
    void insert(Type item);
    void preOrder(std::ostringstream& out);
    void inOrder(std::ostringstream& out);
    void postOrder(std::ostringstream& out);
    int nodeCount();
    Node<Type>* find(Type item);
    Node<Type>* findRightMostNode(Node<Type>* find);
    void remove(Type item);
    int  height();
    int leavesCount();

protected:
    Node<Type>* root{ nullptr };

private:
    void destroy(Node<Type>* curr);
    void insert(Type item, Node<Type>* curr);
    void preOrder(std::ostringstream& out, Node<Type>* curr);
    void postOrder(std::ostringstream& out, Node<Type>* curr);
    void inOrder(std::ostringstream& out, Node<Type>* curr);
    int nodeCount(Node<Type>* curr);
    int leavesCount(Node<Type>* curr);
    Node<Type>* find(Type item, Node<Type>* curr);
    Node<Type>* remove(Type item, Node<Type>* curr);
    int height(int level, Node<Type>* curr);
};

template <typename Type>
BinaryTree<Type>::~BinaryTree(){

}

template <typename Type>
BinaryTree<Type>::BinaryTree(const BinaryTree<Type>& b) {
    
}

template <typename Type>
BinaryTree<Type>& BinaryTree<Type>::operator=(const BinaryTree<Type>& b) {
  return *this;
}

template <typename Type>
void BinaryTree<Type>::destroy(Node<Type>* curr){

}

template <typename Type>
void BinaryTree<Type>::insert(Type item){

}

template <typename Type>
void BinaryTree<Type>::insert(Type item, Node<Type>* curr){

}

template <typename Type>
void BinaryTree<Type>::preOrder(std::ostringstream& out){

}

template <typename Type>
void BinaryTree<Type>::preOrder(std::ostringstream& out, Node<Type>* curr){

}

template <typename Type>
void BinaryTree<Type>::inOrder(std::ostringstream& out){

}

template <typename Type>
void BinaryTree<Type>::inOrder(std::ostringstream& out, Node<Type>* curr){

}

template <typename Type>
void BinaryTree<Type>::postOrder(std::ostringstream& out){

}

template <typename Type>
void BinaryTree<Type>::postOrder(std::ostringstream& out, Node<Type>* curr){

}

template <typename Type>
int BinaryTree<Type>::nodeCount(){
    return 0;
}

template <typename Type>
int BinaryTree<Type>::nodeCount(Node<Type>* curr){
    return 0;
}

template <typename Type>
int BinaryTree<Type>::leavesCount(){
    return 0;
}

template <typename Type>
int BinaryTree<Type>::leavesCount(Node<Type>* curr){
    return 0;
}


template <typename Type>
Node<Type>*BinaryTree<Type>::find(Type item){
    return nullptr;
}


template <typename Type>
Node<Type>* BinaryTree<Type>::find(Type item, Node<Type>* curr){
    return nullptr;
}

template <typename Type>
Node<Type>* BinaryTree<Type>::findRightMostNode(Node<Type>* curr){
    return nullptr;
}

template <typename Type>
void BinaryTree<Type>::remove(Type item){

}

template <typename Type>
Node<Type>* BinaryTree<Type>::remove(Type item, Node<Type>* curr){
    return nullptr;
}

template <typename Type>
int BinaryTree<Type>::height(){
    return 0;
}

template <typename Type>
int BinaryTree<Type>::height(int level, Node<Type>* curr){
    return 0;
}

#endif // BINARY_TREE_HPP
