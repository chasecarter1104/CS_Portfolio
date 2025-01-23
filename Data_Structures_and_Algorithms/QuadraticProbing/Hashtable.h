#ifndef ORDEREDLINKEDLIST_H
#define ORDEREDLINKEDLIST_H
#include <iostream>
#include <vector>

class Hashtable {
public:
    Hashtable();
    Hashtable(int size);
    Hashtable(int size, double loadFactorThreshold);
    Hashtable(const Hashtable& other);
    Hashtable& operator=(const Hashtable& other);
    ~Hashtable();

    int size() const;
    int capacity() const;
    double getLoadFactorThreshold() const;
    bool empty() const;
    void insert(int value);
    void remove(int value);
    bool contains(int value) const;
    int indexOf(int value) const;
    void clear();

    static bool isPrime(int n);
    static int nextPrime(int n);

private:
    struct HashtableEntry {
        bool occupied;
        int value;
    };

    int probe(int value, int i) const;
    void resize();

    std::vector<HashtableEntry> table_;
    int capacity_;
    double loadFactorThreshold_;
    static const int TOMBSTONE_VALUE = -99999999; // Tombstone indicator

    int size_;
};
#endif