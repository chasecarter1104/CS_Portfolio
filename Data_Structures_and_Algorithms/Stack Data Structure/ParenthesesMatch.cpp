#include "ParenthesesMatch.h"

bool parenthesesMatch(const char* str){
    Stack<char> parenthesesStack;

    for (const char* c = str; *c != '\0'; ++c) {
        if (*c == '(') {
            parenthesesStack.push(*c);
        } else if (*c == ')') {
            // If stack is empty, no matching opening parenthesis found
            if (parenthesesStack.empty()) {
                return false;
            } else {
                parenthesesStack.pop();
            }
        }
    }

    // If stack is not empty, not all opening parentheses have been matched
    return parenthesesStack.empty();
}