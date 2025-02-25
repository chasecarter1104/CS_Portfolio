﻿#include "Collection.h"
#include <iostream>
#include <stdexcept>
#include <sstream>
#include <iomanip>

// Default constructor
Collection::Collection() : size(0), capacity(10) {
    arr = new double[capacity];
}

// Argument constructor
Collection::Collection(int size) : size(size), capacity(size + 10) {
    arr = new double[capacity];
}

// Copy constructor
Collection::Collection(const Collection& other) : size(other.size), capacity(other.capacity) {
    arr = new double[capacity];
    for (int i = 0; i < size; ++i) {
        arr[i] = other.arr[i];
    }
}

// Destructor
Collection::~Collection() {
    delete[] arr;
}

// Assignment operator
Collection& Collection::operator=(const Collection& other) {
    if (this != &other) {
        delete[] arr;
        size = other.size;
        capacity = other.capacity;
        arr = new double[capacity];
        for (int i = 0; i < size; ++i) {
            arr[i] = other.arr[i];
        }
    }
    return *this;
}

// Get the number of elements in the array
int Collection::getSize() const {
    return size;
}

// Get the maximum number of elements that the array can hold
int Collection::getCapacity() const {
    return capacity;
}

// Add a value to the end of the array
void Collection::add(double value) {
    if (size >= capacity) {
        throw std::runtime_error("List Full");
    }
    arr[size++] = value;
}

// Add a value to the front of the array
void Collection::addFront(double value) {
    if (size >= capacity) {
        throw std::runtime_error("List Full");
    }
    for (int i = size; i > 0; --i) {
        arr[i] = arr[i - 1];
    }
    arr[0] = value;
    ++size;
}

// Get the value at the specified position in the array
double Collection::get(int ndx) {
    if (ndx < 0 || ndx >= size) {
        throw std::out_of_range("Index out of bounds");
    }
    return arr[ndx];
}

// Get the first value in the array
double Collection::getFront() {
    if (size == 0) {
        throw std::out_of_range("Array is empty");
    }
    return arr[0];
}

// Get the last value in the array
double Collection::getEnd() {
    if (size == 0) {
        throw std::out_of_range("Array is empty");
    }
    return arr[size - 1];
}

// Find the position of a value in the array
int Collection::find(double needle) {
    for (int i = 0; i < size; ++i) {
        if (arr[i] == needle) {
            return i;
        }
    }
    return -1;
}

// Overload the extraction operator to display the list
std::ostream& operator<<(std::ostream& out, const Collection& c) {
    for (int i = 0; i < c.size; ++i) {
        out << c.arr[i];
        if (i < c.size - 1) {
            out << " ";
        }
    }
    return out;
}