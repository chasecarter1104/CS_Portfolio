#ifndef COLLECTION_H
#define COLLECTION_H

#include <iostream>
#include <stdexcept>

class Collection {
private:
    double* arr{ nullptr }; // pointer to dynamically allocated array
    int size; // number of elements in the array
    int capacity; // maximum number of elements that the array can hold

public:
    // default constructor
    Collection();

    // argument constructor
    Collection(int size);

    // copy constructor
    Collection(const Collection& other);

    // destructor
    ~Collection();

    // assignment operator
    Collection& operator=(const Collection& other);

    // get the number of elements in the array
    int getSize() const;

    // get the maximum number of elements that the array can hold
    int getCapacity() const;

    // add a value to the end of the array
    void add(double value);

    // add a value to the front of the array
    void addFront(double value);

    // get the value at the specified position in the array
    double get(int ndx);

    // get the first value in the array
    double getFront();

    // get the last value in the array
    double getEnd();

    // find the position of a value in the array
    int find(double needle);

    // overload the extraction operator to display the list
    friend std::ostream& operator<<(std::ostream& out, const Collection& c);
};

#endif