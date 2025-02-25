#ifndef GRAPH_H
#define GRAPH_H

#include <iostream>
#include <deque>
#include <unordered_map>
#include <unordered_set>
#include <queue>
#include <vector>
#include <algorithm>
#include "GameState.h"

using std::endl;
using std::cout;
using std::ostream;
using std::deque;
using std::unordered_map;
using std::unordered_set;
using std::queue;
using std::vector;

template <typename T>
class Graph;

template <typename T>
ostream& operator << (ostream& out, const Graph<T>& g);

template <typename T>
class Graph {
    friend ostream& operator << <>(ostream& out, const Graph<T>& g);

private:
    unordered_map<T, vector<T>> adjList;
    unordered_map<T, int> vertexPositions; // Store positions of vertices
    int maxVertices;
    int numVertices;

public:
    Graph();
    Graph(int maxVertices);
    Graph(const Graph<T>& obToCopy) = delete;             // Prevent copy construction
    Graph& operator=(const Graph<T>& objToCopy) = delete; // Prevent copy assignment

    void addVertex(const T& vertex);
    void addEdge(const T& source, const T& target);
    void getPath(deque<T>& solution, const T& source, const T& target);
    int findVertexPos(const T& item) const;               // Optional
    bool vertexExists(const T& item) const;
    int getNumVertices() const;

};

/*********************************************
* Constructs an empty graph with a max number of verticies of 100
* 
*********************************************/
template<typename T>
Graph<T>::Graph() : maxVertices(100), numVertices(0) {}

/*********************************************
* Constructs an empty graph with a given max number of verticies
* 
*********************************************/
template<typename T>
Graph<T>::Graph(int maxVertices) : maxVertices(maxVertices), numVertices(0) {}



/*********************************************
* Adds a Vertex to the GraphIf number of verticies is less than the 
* Max Possible number of verticies.  
*********************************************/
template <typename T>
void Graph<T>::addVertex(const T& vertex) {
    if (numVertices < maxVertices && adjList.find(vertex) == adjList.end()) {
        adjList[vertex] = vector<T>();
        vertexPositions[vertex] = numVertices; // Store the position of the new vertex
        numVertices++;
    }
}

/*********************************************
* Returns the current number of vertices
* 
*********************************************/
template<typename T>
int Graph<T>::getNumVertices() const {
    return numVertices;
}

/*********************************************
* Returns the position in the verticies list where the given vertex is located, -1 if not found.
* 
*********************************************/
template <typename T>
int Graph<T>::findVertexPos(const T& item) const {
    auto it = vertexPositions.find(item);
    if (it != vertexPositions.end()) {
        return it->second;
    }
    return -1; // Vertex not found
}

/*********************************************
* Returns the position in the verticies list where the given vertex is located, -1 if not found.
* 
*********************************************/
template <typename T>
bool Graph<T>::vertexExists(const T& item) const {
    return adjList.find(item) != adjList.end();
} 


/*********************************************
* Adds an edge going in the direction of source going to target
* 
*********************************************/
template <typename T>
void Graph<T>::addEdge(const T& source, const T& target) {
    if (vertexExists(source) && vertexExists(target)) {
        adjList[source].push_back(target);
    }
}

/*
  getPath will return the shortest path from source to dest.  
  Given the test graph:
  
[a]-----------[c]
|  \            \
|   \            \
[b]  [d]----[g]---[h]
|          /  \
|         /    \
|        /      \
|     [f]--------[i]
|    /   \       /
|   /     \     /
|  /       \   /
[e]         [j]

getPath('a', 'f') should return 
'a' -> 'b' -> 'e' -> 'f'   or   'a' -> 'd' -> 'g' -> 'f'
*/

template <typename T>
void Graph<T>::getPath(deque<T>& solution, const T& source, const T& target) {
    if (!vertexExists(source) || !vertexExists(target)) {
        return;
    }

    unordered_map<T, T> parent;
    unordered_set<T> visited;
    queue<T> q;

    q.push(source);
    visited.insert(source);
    parent[source] = source;

    bool found = false;

    while (!q.empty() && !found) {
        T current = q.front();
        q.pop();

        for (const T& neighbor : adjList[current]) {
            if (visited.find(neighbor) == visited.end()) {
                visited.insert(neighbor);
                parent[neighbor] = current;
                q.push(neighbor);

                if (neighbor == target) {
                    found = true;
                    break;
                }
            }
        }
    }

    if (found) {
        T step = target;
        while (!(step == source)) { // Use !(step == source) instead of step != source
            solution.push_front(step);
            step = parent[step];
        }
        solution.push_front(source);
    }
}

/*********************************************
* Returns a display of the graph in the format
* vertex: edge edge
Your display will look something like the following

    j: i f
    c: h a
    b: e a
    h: g c
    f: g i j e
    e: f b
    i: g f j
    d: g a
    g: h i f d
    a: b c d
*********************************************/
template <typename T>
ostream& operator << (ostream& out, const Graph<T>& g) {
    for (const auto& pair : g.adjList) {
        out << pair.first << ": ";
        for (const auto& neighbor : pair.second) {
            out << neighbor << " ";
        }
        out << endl;
    }
    return out;
}

#endif
