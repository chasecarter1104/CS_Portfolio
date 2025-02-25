#include <iostream>
#include <sstream>
#include "Collection.h"
#include <string>

using std::cin;
using std::cout;
using std::endl;
using std::string;
using std::stoi;
using std::stringstream;
using std::runtime_error;

bool TestCollection();
bool TestFill();
bool TestExceedSize();
bool TestAddBeginning();
bool TestExtractionOperator();
bool TestDeepCopy();

bool checkCase(int testNum, int& correct, string name, bool condition) {

    if (!condition) {
        cout << "Failed: " << name << endl;
    }
    else {
        cout << name << ": passed" << endl;
        correct++;
        return true;
    }
    return false;
}

int main(int argc, char** argv)
{

    int test = 0;
    int count = 0;

    if (argc > 1) {
        test = stoi(argv[1]);
    }
    switch (test) {
    case 0:
        if (TestCollection()) count++;
        if (TestFill()) count++;
        if (TestExceedSize()) count++;
        if (TestAddBeginning()) count++;
        if (TestExtractionOperator()) count++;
        if (TestDeepCopy()) count++;
        cout << "Passed " << count << " out of 6 tests";
        return count != 6;
    case 1:
        return !TestCollection();
    case 2:
        return !TestFill();
    case 3:
        return !TestExceedSize();
    case 4:
        return !TestAddBeginning();
    case 5:
        return !TestExtractionOperator();
    case 6:
        return !TestDeepCopy();
    }
    return 0;
}
bool TestCollection() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestCollection Tests--------" << endl;

    Collection one;
    one.add(2.2);
    one.add(4.5);

    checkCase(testNum++, correct, "Adding 1", one.get(0) == 2.2);
    checkCase(testNum++, correct, "Adding 2", one.get(1) == 4.5);
    checkCase(testNum++, correct, "Adding 3 - Size() Test", one.getSize() == 2);
    return testNum - 1 == correct;
}
bool TestFill() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestFill Tests--------" << endl;

    Collection one;
    for (int i = 0; i < one.getCapacity(); i++) {
        one.add(i);
    }

    checkCase(testNum++, correct, "Exceed Size 1", one.get(0) == 0);
    checkCase(testNum++, correct, "Exceed Size 2", one.get(one.getCapacity() - 1) == one.getCapacity() - 1);

    return testNum - 1 == correct;
}

bool TestExceedSize() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestExceeedSize Tests--------" << endl;

    Collection one;
    for (int i = 0; i < one.getCapacity(); i++) {
        one.add(i);
    }

    testNum++;
    try {
        one.add(666);
        cout << "Failed: TestExceeedSize 1 - An exception should have been thrown, but was not" << endl;
    }
    catch (std::runtime_error&) {
        cout << "TestExceeedSize 1: passed" << endl;
        correct++;
    }

    testNum++;
    try {
        one.addFront(666);
        cout << "Failed: TestExceeedSize 2 - An exception should have been thrown, but was not" << endl;
    }
    catch (std::runtime_error&) {
        cout << "TestExceeedSize 2: passed" << endl;
        correct++;
    }


    return testNum - 1 == correct;
}

bool TestAddBeginning() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestAddBeginning Tests--------" << endl;

    Collection one;

    for (double i = 0; i < 5; i += 1) {
        one.add(i);
    }
    one.addFront(2);
    checkCase(testNum++, correct, "Add to Front Check 1", one.get(0) == 2);
    checkCase(testNum++, correct, "Add to Front Check 2", one.get(5) == 4);
    checkCase(testNum++, correct, "Add to Front Check 3", one.getSize() == 6);

    return testNum - 1 == correct;
}
bool TestExtractionOperator() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestExtractionOperator Tests--------" << endl;

    Collection one;
    one.add(1);
    one.add(2);
    stringstream sout;
    sout << one;
    checkCase(testNum++, correct, "Overloaded Extraction Operator", sout.str() == "1 2");
    return testNum - 1 == correct;
}


bool TestDeepCopy() {
    int testNum = 1;
    int correct = 0;
    cout << "--------TestDeepCopy Tests--------" << endl;
    Collection one;
    one.add(1);
    one.add(2);

    Collection two(one); //Copy constructor
    checkCase(testNum++, correct, "Deep Copy 1", two.get(0) == 1);
    checkCase(testNum++, correct, "Deep Copy 2", two.get(1) == 2);
    //Make sure it is a deep-copy
    two.addFront(3);
    checkCase(testNum++, correct, "Deep Copy 3", two.get(0) == 3);
    checkCase(testNum++, correct, "Deep Copy 4", one.get(0) == 1);

    two = one; // overloaded assignment operator
    checkCase(testNum++, correct, "Deep Copy 5", two.get(0) == 1);
    checkCase(testNum++, correct, "Deep Copy 6", two.get(1) == 2);
    //Make sure it is a deep-copy
    two.addFront(3);
    checkCase(testNum++, correct, "Deep Copy 7", two.get(0) == 3);
    checkCase(testNum++, correct, "Deep Copy 8", one.get(0) == 1);
    return testNum - 1 == correct;

}