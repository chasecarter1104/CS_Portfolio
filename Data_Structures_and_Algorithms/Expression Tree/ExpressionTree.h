#ifndef EXPRESSIONTREE_EXPRESSIONTREE_H
#define EXPRESSIONTREE_EXPRESSIONTREE_H

#include <iostream>
#include <string>
#include <sstream>
#include <cctype>
#include <cmath>

class ExpressionTree {
private:
    struct Node {
        std::string data;
        Node* left;
        Node* right;
        Node(std::string val) : data(val), left(nullptr), right(nullptr) {}
    };

    Node* root;

    // Private recursive methods
    Node* buildTree(const std::string& expr, size_t& index);
    double evaluate(Node* node) const;
    void printInOrder(std::ostream& os, Node* node) const;
    void printPostOrder(std::ostream& os, Node* node, bool& first) const;
    void deleteTree(Node* node); // Helper method to delete tree nodes
    Node* copyTree(const Node* node); // Helper method to copy tree nodes

    // Helper methods
    bool isOperator(char c) const;
    bool isOperand(char c) const;
    double calculate(double left, double right, char op) const;

public:
    ExpressionTree();
    ExpressionTree(const std::string& expr);
    ~ExpressionTree();
    ExpressionTree(const ExpressionTree& other);
    ExpressionTree& operator=(const ExpressionTree& other);
    void setExpression(const std::string& expr);
    double getResult() const;
    void printParseTreeInOrder(std::ostream& os) const;
    void printParseTreePostOrder(std::ostream& os) const;
};

ExpressionTree::ExpressionTree() : root(nullptr) {}

ExpressionTree::ExpressionTree(const std::string& expr) : root(nullptr) {
    setExpression(expr);
}

ExpressionTree::~ExpressionTree() {
    deleteTree(root);
}

void ExpressionTree::deleteTree(Node* node) {
    if (node != nullptr) {
        deleteTree(node->left);
        deleteTree(node->right);
        delete node;
    }
}

ExpressionTree::ExpressionTree(const ExpressionTree& other) : root(nullptr) {
    root = copyTree(other.root);
}

ExpressionTree& ExpressionTree::operator=(const ExpressionTree& other) {
    if (this != &other) {
        deleteTree(root);
        root = copyTree(other.root);
    }
    return *this;
}

ExpressionTree::Node* ExpressionTree::copyTree(const Node* node) {
    if (node == nullptr)
        return nullptr;

    Node* newNode = new Node(node->data);
    newNode->left = copyTree(node->left);
    newNode->right = copyTree(node->right);
    return newNode;
}

void ExpressionTree::setExpression(const std::string& expr) {
    deleteTree(root);
    size_t index = 0;
    root = buildTree(expr, index);
}

ExpressionTree::Node* ExpressionTree::buildTree(const std::string& expr, size_t& index) {
    if (index >= expr.length())
        return nullptr;

    if (expr[index] == '(') {
        index++; // Move past '('
        Node* leftNode = buildTree(expr, index);
        while (index < expr.length() && expr[index] == ' ') // Skip spaces
            index++;
        if (index >= expr.length() || !isOperator(expr[index]))
            return nullptr;
        char op = expr[index++];
        while (index < expr.length() && expr[index] == ' ') // Skip spaces
            index++;
        Node* rightNode = buildTree(expr, index);
        if (index >= expr.length() || expr[index] != ')')
            return nullptr;
        index++; // Move past ')'
        Node* newNode = new Node(std::string(1, op));
        newNode->left = leftNode;
        newNode->right = rightNode;
        return newNode;
    }

    std::string temp;
    while (index < expr.length() && (isOperand(expr[index]) || expr[index] == '.')) {
        temp += expr[index++];
    }
    if (!temp.empty()) {
        return new Node(temp);
    }

    return nullptr; // Invalid character
}

double ExpressionTree::getResult() const {
    return evaluate(root);
}

double ExpressionTree::evaluate(Node* node) const {
    if (node == nullptr)
        return 0.0;

    if (!isOperator(node->data[0]))
        return std::stod(node->data);

    double leftVal = evaluate(node->left);
    double rightVal = evaluate(node->right);

    return calculate(leftVal, rightVal, node->data[0]);
}

void ExpressionTree::printParseTreeInOrder(std::ostream& os) const {
    printInOrder(os, root);
}

void ExpressionTree::printParseTreePostOrder(std::ostream& os) const {
    bool first = true;
    printPostOrder(os, root, first);
}

void ExpressionTree::printInOrder(std::ostream& os, Node* node) const {
    if (node == nullptr)
        return;
    if (node->left != nullptr) {
        printInOrder(os, node->left);
    }
    os << node->data;
    if (node->right != nullptr) {
        printInOrder(os, node->right);
    }
}

void ExpressionTree::printPostOrder(std::ostream& os, Node* node, bool& first) const {
    if (node == nullptr)
        return;
    printPostOrder(os, node->left, first);
    printPostOrder(os, node->right, first);
    if (!first) {
        os << " ";
    } else {
        first = false;
    }
    os << node->data;
}

bool ExpressionTree::isOperator(char c) const {
    return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
}

bool ExpressionTree::isOperand(char c) const {
    return std::isdigit(c);
}

double ExpressionTree::calculate(double left, double right, char op) const {
    switch (op) {
        case '+': return left + right;
        case '-': return left - right;
        case '*': return left * right;
        case '/': return left / right;
        case '^': return std::pow(left, right);
        default: return 0.0; // Invalid operator, should not happen
    }
}

#endif //EXPRESSIONTREE_EXPRESSIONTREE_H
