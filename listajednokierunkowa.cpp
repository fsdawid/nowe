#include <iostream>
#include <string>
using namespace std;


void insert_end(int x);
void display_forward();
void insert_front(int x);
void delete_front();
void delete_end();
struct node
{
int data;
node *prev;
node *next;
};
node *head = NULL, *tail = NULL;





int main()
{
    insert_end(8);
    insert_end(7);
    insert_end(6);
    insert_end(5);
    insert_end(4);
    insert_end(3);
    display_forward();
    cout << endl;
    insert_front(1);
    insert_front(2);
    insert_front(3);
    insert_front(4);
    insert_front(5);
    insert_front(6);
    display_forward();
    delete_front();
    cout << endl;
    display_forward();
    cout << endl;
    delete_end();
    display_forward();
    
    
    
    return 0;    
}


void display_forward()//Przeglad listy
{
node *temp;
if(head==NULL)
cout <<"No data inside\n";
else
{
temp = head;
while(temp!=NULL)
{
cout << temp->data << endl;
temp = temp->next;
}
}
}




void insert_end(int x)//Dodawanie na koniec
{
node* temp = new node;
temp->data = x;
temp->next = NULL;
temp->prev = NULL;
if (head == NULL)
head = tail = temp;
else {
tail->next = temp;
temp->prev = tail;
tail = temp;
}
}

void insert_front(int x)//Dodawanie na pocz¹tek
{
node* temp = new node;
temp->data = x;
temp->next = NULL;
temp->prev = NULL;
if (head == NULL)
head = tail = temp;
else
{
temp->next = head;
head->prev = temp;
head = temp;
}
}


void delete_front()//Usuwanie z pocz¹tku
{
node *temp;
if(head==NULL)
cout <<"No data inside\n";
else
{
temp = head;
head = head->next;
head->prev = NULL;
delete temp;
}
}



void delete_end()//Usuniêcie z koñca
{
node *temp;
if(tail==NULL)
cout <<"No data inside\n";
else
{
temp = tail;
tail = tail->prev;
tail->next = NULL;
delete temp;
}
