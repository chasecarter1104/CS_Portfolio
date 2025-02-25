#include "Hashtable.h"
#include <cmath>
#include <algorithm>

Hashtable::Hashtable() : Hashtable(17, 0.65) {}

Hashtable::Hashtable(int size) : Hashtable(size, 0.65) {}

Hashtable::Hashtable(int size, double loadFactorThreshold)
        : capacity_(nextPrime(size)), loadFactorThreshold_(loadFactorThreshold), size_(0) {
    table_.resize(capacity_, {false, -1});
}

Hashtable::Hashtable(const Hashtable& other)
        : capacity_(other.capacity_), loadFactorThreshold_(other.loadFactorThreshold_), size_(other.size_) {
    table_ = other.table_;
}

Hashtable& Hashtable::operator=(const Hashtable& other) {
    if (this == &other) {
        return *this;
    }
    capacity_ = other.capacity_;
    loadFactorThreshold_ = other.loadFactorThreshold_;
    size_ = other.size_;
    table_ = other.table_;
    return *this;
}

Hashtable::~Hashtable() = default;

int Hashtable::size() const {
    return size_;
}

int Hashtable::capacity() const {
    return capacity_;
}

double Hashtable::getLoadFactorThreshold() const {
    return loadFactorThreshold_;
}

bool Hashtable::empty() const {
    return size_ == 0;
}

void Hashtable::insert(int value) {
    if (contains(value)) {
        return; // Avoid duplicates
    }

    double loadFactor = static_cast<double>(size_ + 1) / capacity_;
    if (loadFactor > loadFactorThreshold_) {
        resize(); // Resize when load factor threshold is exceeded
    }

    int i = 0;
    int index = probe(value, i);
    while (table_[index].occupied && table_[index].value != TOMBSTONE_VALUE) { // Handle collisions
        i++;
        index = probe(value, i);
    }

    table_[index] = {true, value}; // Insert into the correct slot
    size_++; // Increment size after insertion
}

void Hashtable::remove(int value) {
    int i = 0;
    int index = probe(value, i);

    // Probe until we find the desired value or reach an empty slot
    while (table_[index].occupied) {
        if (table_[index].value == value) { // If the slot contains the desired value
            table_[index].occupied = false; // Mark as unoccupied
            table_[index].value = TOMBSTONE_VALUE; // Insert tombstone
            size_--; // Decrease the size
            return; // Exit once removed
        }
        i++; // Move to the next slot in quadratic probing
        index = probe(value, i);
    }
}

bool Hashtable::contains(int value) const {
    return indexOf(value) != -1;
}

int Hashtable::indexOf(int value) const {
    int i = 0;
    int index = probe(value, i);

    // Loop until we find the value or hit an unoccupied slot (end of probe)
    while (table_[index].occupied || table_[index].value == TOMBSTONE_VALUE) {
        if (table_[index].occupied && table_[index].value == value) {
            return index; // Found the value
        }
        i++; // Quadratic probing step
        index = probe(value, i); // Get the next probing index
    }

    return -1; // If not found, return -1
}

void Hashtable::clear() {
    size_ = 0;
    table_.clear();
    capacity_ = nextPrime(17);
    table_.resize(capacity_, {false, -1});
}

bool Hashtable::isPrime(int n) {
    if (n <= 1) {
        return false;
    }
    if (n <= 3) {
        return true;
    }
    if (n % 2 == 0 || n % 3 == 0) {
        return false;
    }

    int limit = std::sqrt(n);
    for (int i = 5; i <= limit; i += 6) {
        if (n % i == 0 || n % (i + 2) == 0) {
            return false;
        }
    }

    return true;
}

int Hashtable::nextPrime(int n) {
    if (n <= 1) {
        return 2;
    }
    while (!isPrime(n)) {
        n++;
    }
    return n;
}

int Hashtable::probe(int value, int i) const {
    int baseIndex = value % capacity_;
    return (baseIndex + i * i) % capacity_;
}

void Hashtable::resize() {
    int newCapacity = nextPrime(capacity_ * 2);
    std::vector<HashtableEntry> newTable(newCapacity, {false, -1});

    for (const auto& entry : table_) {
        if (entry.occupied && entry.value != TOMBSTONE_VALUE) { // Insert only occupied entries
            int i = 0;
            int index = entry.value % newCapacity;
            while (newTable[index].occupied) { // Quadratic probing
                i++;
                index = (index + i * i) % newCapacity;
            }
            newTable[index] = {true, entry.value}; // Insert into the new table
        }
    }

    table_ = std::move(newTable); // Replace the old table with the new one
    capacity_ = newCapacity; // Update capacity
}