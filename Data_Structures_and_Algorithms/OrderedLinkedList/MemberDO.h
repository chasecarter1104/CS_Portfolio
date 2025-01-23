#ifndef MEMBERDO
#define MEMBERDO

#include "LinkedList.hpp"
#include <string>

class MemberDO
{
private:
    int key{ 0 };
    std::string lastName;
    char firstInit{ ' ' };
    double dues{ 0.0 };
public:
    MemberDO();
    MemberDO(int, std::string, char, double);

    int getKey() const;
    void setKey(int);
    std::string getLastName() const;
    void setLastName(std::string);
    char getFirstInitial() const;
    void setFirstInitial(char);
    double getDues() const;
    void setDues(double);
    bool operator<(const MemberDO&) const;
    bool operator==(const MemberDO&) const;
    bool operator!=(const MemberDO&) const;


};

#endif