#include <iostream>
 using namespace std;

 struct slistEl
 {
 slistEl * next;
 int data;
 };
 class stack
 {
 private:
 slistEl * S; 
 public:
 stack(); 
 ~stack();
 bool empty(void);
 slistEl * top(void);
 void push(int v);
 void pop(void);
 };
 stack::stack()
 {
 S = NULL;
 }
 stack::~stack()
 {
 while(S) pop();
 }
 bool stack::empty(void)
 {
 return !S;
 }
 slistEl * stack::top(void)
 {
 return S;
 }

 void stack::push(int v)
 {
 slistEl * e = new slistEl;
 e->data = v;
 e->next = S;
 S = e;
 }

 void stack::pop(void)
 {
 if(S)
 {
 slistEl * e = S;
 S = S->next;
 delete e;
 }
 }

 int main()
 {
 stack S;
 int i;
 for(i = 1; i <= 10; i++) S.push(i);
 while(!S.empty())
 {
 cout << S.top()->data << endl;
 S.pop();
 }
 } 



Implementacja kolejki za pomoc¹ listy
#include <iostream>
 using namespace std;
 const int MAXINT = -2147483647;
 struct slistEl
 {
 slistEl * next;
 int data;
 };
 class queue
 {
 private:
 slistEl * head;
 slistEl * tail;
 public:
 queue(); 
 ~queue(); 
 bool empty(void);
 int front(void);
 void push(int v);
 void pop(void);
 };
queue::queue()
 {
 head = tail = NULL;
 }
 queue::~queue()
 {
 while(head) pop();
 }

 bool queue::empty(void)
 {
 return !head;
 }

 int queue::front(void)
 {
 if(head) return head->data;
 else return -MAXINT;
 }

 void queue::push(int v)
 {
 slistEl * p = new slistEl;
 p->next = NULL;
 p->data = v;
 if(tail) tail->next = p;
 else head = p;
 tail = p;
 }

 void queue::pop(void)
 {
 if(head)
 {
 slistEl * p = head;
 head = head->next;
 if(!head) tail = NULL;
 delete p;
 }
 }

 int main()
 {
 queue Q; 
 int i;
 for(i = 1; i <= 10; i++) Q.push(i);
 while(!Q.empty())
 {
 cout << Q.front() << endl;
 Q.pop();
 }
 } 
