#include "LinkedList.hpp"
#include "MemberDO.h"

#include<iostream>
#include<string>
#include<stdexcept>
#include<sstream>

using std::cout;
using std::endl;
using std::string;
using std::ostringstream;
using std::out_of_range;
using std::stoi;


template <typename elemType>
bool checkTest(string testName, elemType whatItShouldBe, elemType whatItIs);
bool testConstructor();
bool testInsert();
bool testOutput();
bool testGets();
bool testFind();
bool testRemove();
bool testClear();
bool testDeepCopy();
bool testTemplate();
bool testEdgeCases();

int main(int argc, char** argv) {

    int test = 0;
    int count = 0;

    if (argc > 1) {
        test = stoi(argv[1]);
    }
    switch (test) {
    case 0:
        if (testConstructor()) count++;
        if (testInsert()) count++;
        if (testOutput()) count++;
        if (testGets()) count++;
        if (testFind()) count++;
        if (testRemove()) count++;
        if (testClear()) count++;
        if (testDeepCopy()) count++;
        if (testTemplate()) count++;
        if (testEdgeCases()) count++;
        cout << "Passed " << count << " out of 10 tests";
        return count != 10;
    case 1:
        return !testConstructor();
    case 2:
        return !testInsert();
    case 3:
        return !testOutput();
    case 4:
        return !testGets();
    case 5:
        return !testFind();
    case 6:
        return !testRemove();
    case 7:
        return !testClear();
    case 8:
        return !testDeepCopy();
    case 9:
        return !testTemplate();
    case 10:
        return !testEdgeCases();
    }

}

bool testConstructor() {
    bool passed = true;
    cout << "-------------Test Constructor--------------" << endl;
    OrderedLinkedList<int> intList;
    passed &= checkTest("Constructor 1", intList.size(), 0); // 1
    passed &= checkTest("Constructor 2", intList.empty(), true); // 2
    OrderedLinkedList<char> charList;
    passed &= checkTest("Constructor 3", charList.size(), 0); // 3
    passed &= checkTest("Constructor 4", charList.empty(), true); // 4
    return passed;
}

bool testInsert() {
    bool passed = true;
    cout << "-------------Test Insert--------------" << endl;
    OrderedLinkedList<int> intList;
    //insert - empty list
    intList.insert(100);
    passed &= checkTest("Insert 1", intList.size(), 1); // 1
    passed &= checkTest("Insert 2", intList.get(0), 100); // 2
    passed &= checkTest("Insert 3", intList.empty(), false); // 3
    //insert - first
    intList.insert(28);
    passed &= checkTest("Insert 4", intList.size(), 2); // 4
    passed &= checkTest("Insert 5", intList.get(0), 28); // 5
    passed &= checkTest("Insert 6", intList.get(1), 100); // 6
    //insert - last
    intList.insert(395);
    passed &= checkTest("Insert 7", intList.size(), 3); // 7
    passed &= checkTest("Insert 8", intList.get(0), 28); // 8
    passed &= checkTest("Insert 9", intList.get(1), 100); // 9
    passed &= checkTest("Insert 10", intList.get(2), 395); // 10
    //insert - middle
    intList.insert(35);
    passed &= checkTest("Insert 11", intList.get(1), 35); // 11
    passed &= checkTest("Insert 12", intList.get(2), 100); // 12
    passed &= checkTest("Insert 13", intList.get(3), 395); // 13
    passed &= checkTest("Insert 14", intList.get(0), 28); // 14
    passed &= checkTest("Insert 15", intList.empty(), false); // 15
    OrderedLinkedList<char> charList;
    charList.insert('w');
    charList.insert('i');
    charList.insert('n');
    charList.insert('z');
    passed &= checkTest("Insert 16", charList.get(0), 'i'); // 16
    passed &= checkTest("Insert 17", charList.get(3), 'z'); // 17
    passed &= checkTest("Insert 18", charList.get(2), 'w'); // 18
    passed &= checkTest("Insert 19", charList.get(1), 'n'); // 19
    return passed;
}

bool testGets() {
    bool passed = true;
    cout << "-------------Test Gets--------------" << endl;
    OrderedLinkedList<int> intList;
    intList.insert(100);
    passed &= checkTest("Get 1", intList.getFirst(), 100); // 1
    passed &= checkTest("Get 2", intList.getLast(), 100); // 2
    intList.insert(28);
    passed &= checkTest("Get 3", intList.getFirst(), 28); // 3
    passed &= checkTest("Get 4", intList.getLast(), 100); // 4
    intList.insert(395);
    passed &= checkTest("Get 5", intList.getFirst(), 28); // 5
    passed &= checkTest("Get 6", intList.getLast(), 395); // 6
    intList.insert(35);
    passed &= checkTest("Get 7", intList.getFirst(), 28); // 7
    passed &= checkTest("Get 8", intList.getLast(), 395); // 8
    return passed;
}

bool testFind() {
    bool passed = true;
    cout << "-------------Test Find--------------" << endl;
    OrderedLinkedList<int> intList;
    intList.insert(6);
    intList.insert(1);
    intList.insert(3);
    intList.insert(7);
    passed &= checkTest("Find 1", intList.find(7), 3); // 1
    passed &= checkTest("Find 2", intList.find(6), 2); // 2
    passed &= checkTest("Find 3", intList.find(2), -1); // 3
    passed &= checkTest("Find 4", intList.find(1), 0); // 4
    passed &= checkTest("Find 5", intList.find(4), -1); // 5
    OrderedLinkedList<char> charList;
    charList.insert('d');
    charList.insert('o');
    charList.insert('n');
    charList.insert('e');
    passed &= checkTest("Find 6", charList.find('d'), 0); // 6
    passed &= checkTest("Find 7", charList.find('e'), 1); // 7
    passed &= checkTest("Find 8", charList.find('2'), -1); // 8
    passed &= checkTest("Find 9", charList.find('o'), 3); // 9
    passed &= checkTest("Find 10", charList.find('a'), -1); // 10
    OrderedLinkedList<double> dList;
    passed &= checkTest("Find 11", dList.find(2.5), -1); // 11
    dList.insert(2.5);
    passed &= checkTest("Find 12", dList.find(2.5), 0); // 12
    return passed;

}

bool testOutput() {
    bool passed = true;
    cout << "-------------Test Output--------------" << endl;
    OrderedLinkedList<int> intList;
    ostringstream output;
    output << intList;
    passed &= checkTest("Output 1", output.str(), string("")); // 1
    output.str("");
    output.clear();
    intList.insert(4);
    output << intList;
    passed &= checkTest("Output 2", output.str(), string("4")); // 2
    output.str("");
    output.clear();
    intList.insert(8);
    output << intList;
    passed &= checkTest("Output 3", output.str(), string("4->8")); // 3
    output.str("");
    output.clear();
    intList.insert(2);
    output << intList;
    passed &= checkTest("Output 4", output.str(), string("2->4->8")); // 4
    output.str("");
    output.clear();
    intList.insert(5);
    output << intList;
    passed &= checkTest("Output 5", output.str(), string("2->4->5->8")); // 5
    output.str("");
    output.clear();
    return passed;
}

bool testRemove() {
    bool passed = true;
    cout << "-------------Test Remove--------------" << endl;
    OrderedLinkedList<int> intList;
    intList.insert(6);
    intList.remove(6);
    passed &= checkTest("Remove 1", intList.find(6), -1); // 1
    passed &= checkTest("Remove 2", intList.size(), 0); // 2
    passed &= checkTest("Remove 3", intList.empty(), true); // 3
    intList.insert(2);
    passed &= checkTest("Remove 4", intList.find(2), 0); // 4
    passed &= checkTest("Remove 5", intList.get(0), 2); // 5
    passed &= checkTest("Remove 6", intList.getFirst(), 2); // 6
    passed &= checkTest("Remove 7", intList.getLast(), 2); // 7
    intList.insert(6);
    intList.insert(1);
    intList.insert(3);
    intList.insert(7);
    intList.remove(1);
    passed &= checkTest("Remove 8", intList.find(1), -1); // 8
    passed &= checkTest("Remove 9", intList.size(), 4); // 9
    passed &= checkTest("Remove 10", intList.empty(), false); // 10
    passed &= checkTest("Remove 11", intList.get(0), 2); // 11
    passed &= checkTest("Remove 12", intList.get(2), 6); // 12
    passed &= checkTest("Remove 13", intList.getFirst(), 2); // 13
    passed &= checkTest("Remove 14", intList.getLast(), 7); // 14
    ostringstream output;
    output << intList;
    passed &= checkTest("Remove 15", output.str(), string("2->3->6->7")); // 15
    output.str("");
    output.clear();
    intList.remove(3);
    passed &= checkTest("Remove 16", intList.find(3), -1); // 16
    passed &= checkTest("Remove 17", intList.size(), 3); // 17
    passed &= checkTest("Remove 18", intList.get(1), 6); // 18
    output << intList;
    passed &= checkTest("Remove 19", output.str(), string("2->6->7")); // 19
    output.str("");
    output.clear();
    passed &= checkTest("Remove 20", intList.getFirst(), 2); // 20
    passed &= checkTest("Remove 21", intList.getLast(), 7); // 21
    intList.remove(7);
    passed &= checkTest("Remove 22", intList.find(7), -1); // 22
    passed &= checkTest("Remove 23", intList.size(), 2); // 23
    output << intList;
    passed &= checkTest("Remove 24", output.str(), string("2->6")); // 24
    output.str("");
    output.clear();
    passed &= checkTest("Remove 25", intList.get(1), 6); // 25
    passed &= checkTest("Remove 26", intList.getFirst(), 2); // 26
    passed &= checkTest("Remove 27", intList.getLast(), 6); // 27
    intList.remove(6);
    passed &= checkTest("Remove 28", intList.find(6), -1); // 28
    passed &= checkTest("Remove 29", intList.get(0), 2); // 29
    passed &= checkTest("Remove 30", intList.getFirst(), 2); // 30
    passed &= checkTest("Remove 31", intList.getLast(), 2); // 31
    output << intList;
    passed &= checkTest("Remove 32", output.str(), string("2")); // 32
    output.str("");
    output.clear();
    intList.remove(2);
    passed &= checkTest("Remove 33", intList.find(2), -1); // 33
    passed &= checkTest("Remove 34", intList.size(), 0); // 34
    passed &= checkTest("Remove 35", intList.empty(), true); // 35
    output << intList;
    passed &= checkTest("Remove 36", output.str(), string("")); // 36
    output.str("");
    output.clear();
    return passed;
}

bool testClear() {
    bool passed = true;
    cout << "-------------Test Clear--------------" << endl;
    OrderedLinkedList<int> intList;
    intList.insert(5);
    intList.clear();
    passed &= checkTest("Clear 1", intList.size(), 0); // 1
    passed &= checkTest("Clear 2", intList.empty(), true); // 2
    passed &= checkTest("Clear 3", intList.find(5), -1); // 3
    ostringstream output;
    output << intList;
    passed &= checkTest("Clear 4", output.str(), string("")); // 4
    output.str("");
    output.clear();
    intList.insert(4);
    intList.insert(374);
    intList.insert(234);
    intList.clear();
    passed &= checkTest("Clear 5", intList.size(), 0); // 5
    passed &= checkTest("Clear 6", intList.empty(), true); // 6
    passed &= checkTest("Clear 7", intList.find(234), -1); // 7
    output << intList;
    passed &= checkTest("Clear 8", output.str(), string("")); // 8
    output.str("");
    output.clear();
    return passed;
}

bool testDeepCopy() {
    bool passed = true;
    cout << "-------------Test Deep Copy--------------" << endl;
    OrderedLinkedList<int> intList;
    intList.insert(12);
    intList.insert(2);
    intList.insert(15);
    OrderedLinkedList<int> copiedList(intList);
    passed &= checkTest("Deep Copy 1", intList.size(), 3); // 1
    passed &= checkTest("Deep Copy 2", copiedList.size(), 3); // 2
    ostringstream output;
    output << intList;
    passed &= checkTest("Deep Copy 3", output.str(), string("2->12->15")); // 3
    output.str("");
    output.clear();
    output << copiedList;
    passed &= checkTest("Deep Copy 4", output.str(), string("2->12->15")); // 4
    output.str("");
    output.clear();
    intList.insert(8);
    output << intList;
    passed &= checkTest("Deep Copy 5", output.str(), string("2->8->12->15")); // 5
    output.str("");
    output.clear();
    output << copiedList;
    passed &= checkTest("Deep Copy 6", output.str(), string("2->12->15")); // 6
    output.str("");
    output.clear();
    copiedList = intList;
    passed &= checkTest("Deep Copy 7", intList.size(), 4); // 7
    passed &= checkTest("Deep Copy 8", copiedList.size(), 4); // 8
    copiedList.remove(15);
    output << intList;
    passed &= checkTest("Deep Copy 9", output.str(), string("2->8->12->15")); // 9
    output.str("");
    output.clear();
    output << copiedList;
    passed &= checkTest("Deep Copy 10", output.str(), string("2->8->12")); // 10
    output.str("");
    output.clear();
    return passed;
}

bool testTemplate() {
    bool passed = true;
    cout << "-------------Test Template--------------" << endl;
    OrderedLinkedList<MemberDO> memberList;
    passed &= checkTest("Templates 1", memberList.size(), 0); // 1
    MemberDO data;
    data.setKey(2555);
    data.setLastName("Smith");
    data.setFirstInitial('J');
    data.setDues(15.15);
    memberList.insert(data);
    passed &= checkTest("Templates 2", memberList.size(), 1); // 2
    passed &= checkTest("Templates 3", memberList.get(0).getKey(), 2555); // 3
    MemberDO data1(25, "Rogers", 'A', 17.50);
    memberList.insert(data1);
    passed &= checkTest("Templates 4", memberList.find(data1), 0); // 4
    passed &= checkTest("Templates 5", memberList.get(0).getLastName(), string("Rogers")); // 5
    memberList.insert(MemberDO(3100, "Jackson", 'M', 250.00));
    passed &= checkTest("Templates 6", memberList.get(2).getKey(), 3100); // 6
    memberList.insert(MemberDO(2660, "Franklin", 'F', 20.00));
    passed &= checkTest("Templates 7", memberList.get(2).getFirstInitial(), 'F'); // 7
    passed &= checkTest("Templates 8", memberList.get(0).getDues(), 17.50); // 8
    data = MemberDO(3100, "Jackson", 'M', 250.00);
    passed &= checkTest("Templates 9", memberList.find(data), 3); // 9
    memberList.remove(data);
    passed &= checkTest("Templates 10", memberList.find(data), -1); // 10
    return passed;
}

bool  testEdgeCases() {
    bool passed = true;
    cout << "-------------Test Edge Cases--------------" << endl;
    OrderedLinkedList<int> intList;
    OrderedLinkedList<int> odd;
    OrderedLinkedList<int> even;
    intList.insert(9);
    odd = intList.everyOtherOdd();
    passed &= checkTest("Edge Cases 1", odd.size(), 1); // 1
    ostringstream output;
    output << odd;
    passed &= checkTest("Edge Cases 2", output.str(), string("9")); // 2
    output.str("");
    output.clear();
    intList.insert(4);
    even = intList.everyOtherEven();
    passed &= checkTest("Edge Cases 3", even.size(), 1); // 3
    output << even;
    passed &= checkTest("Edge Cases 4", output.str(), string("9")); // 4
    output.str("");
    output.clear();
    intList.insert(15);
    intList.insert(23);
    intList.insert(32);
    intList.insert(99);
    odd = intList.everyOtherOdd();
    output << odd;
    passed &= checkTest("Edge Cases 5", output.str(), string("4->15->32")); // 5
    output.str("");
    output.clear();
    even = intList.everyOtherEven();
    output << even;
    passed &= checkTest("Edge Cases 6", output.str(), string("9->23->99")); // 6
    output.str("");
    output.clear();

    //Boundary cases
    intList.clear();
    intList.clear(); //clear an empty list
    passed &= checkTest("Edge Cases 7", string("No errors"), string("No errors")); // 7
    intList.remove(10);
    passed &= checkTest("Edge Cases 8", string("No errors"), string("No errors")); // 8
    odd = intList.everyOtherOdd();
    passed &= checkTest("Edge Cases 9", odd.size(), 0); // 9
    odd.insert(1);
    intList.remove(10);
    passed &= checkTest("Edge Cases 10", string("No errors"), string("No errors")); // 10
    even = odd.everyOtherEven();
    passed &= checkTest("Edge Cases 11", even.size(), 0); // 11
    try {
        intList.get(0);
        passed &= checkTest("Edge Cases 12", string("No error"), string("out_of_range error")); // 12
    }
    catch (out_of_range&) {
        passed &= checkTest("Edge Cases 12", string("out_of_range error"), string("out_of_range error")); // 12
    }
    try {
        intList.get(-1);
        passed &= checkTest("Edge Cases 13", string("No error"), string("out_of_range error")); // 13
    }
    catch (out_of_range&) {
        passed &= checkTest("Edge Cases 13", string("out_of_range error"), string("out_of_range error")); // 13
    }
    try {
        intList.getFirst();
        passed &= checkTest("Edge Cases 14", string("No error"), string("out_of_range error")); // 14
    }
    catch (out_of_range&) {
        passed &= checkTest("Edge Cases 14", string("out_of_range error"), string("out_of_range error")); // 14
    }
    try {
        intList.getLast();
        passed &= checkTest("Edge Cases 15", string("No error"), string("out_of_range error")); // 15
    }
    catch (out_of_range&) {
        passed &= checkTest("Edge Cases 15", string("out_of_range error"), string("out_of_range error")); // 15
    }

    return passed;
}

//This helps with testing, do not modify.
template<class elemType>
bool checkTest(string testName, elemType actual, elemType expected) {

    if (actual == expected) {
        cout << "Passed " << testName << endl;
        return true;
    }
    else {
        cout << "***Failed test " << testName << " ** " << endl << "   Output was " << actual << endl << "   Output should have been " << expected << endl;
        return false;
    }
}