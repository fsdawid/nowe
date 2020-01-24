#include <iostream>
#include <string>
using namespace std;

struct node{
    int val;
    int val2;
    int val3;
    int val4;
    int val5;
    int val6;
    node* next;
};

void push(node*&H, int x) //Dodawanie na pocz�tek listy
{
    
    node* tmp = new node;
    tmp-> val = x;    
    tmp->next =H;
    H = tmp;
        
}

void pushLast(node*&H, int x) //Dodawanie na koniec listy
{
    
    node* tmp = new node;
    tmp-> val = x;    
 
    node* p = H;
    while(p->next !=NULL)    
        p = p->next;
        p->next = tmp;
        tmp->next = NULL;

        
}

void pop(node*&H) //Usuni�cie z ko�ca listy
{
    
    node* p =H;
    if(p == NULL)
        cout<<"Pusta lista"<<endl;
    else if(p->next == NULL)
    {
         H = NULL;
         delete p;
    }   
    else
    {
        while(p->next != NULL)
        {
            p = p->next;
        }
        node*s = H;
            while(s ->next != p)
            {
                s = s ->next;    
            }
            s->next = p->next;
            delete p;
    }
        
}

void popBeg(node*&H) //Usuni�cie z pocz�tku listy
{
    node*p =H;
    H = H->next;
    delete p;
}

void show(node* H){
    
 cout<<"H -> ";
 node*p =H;
 
 while(p != NULL)
 {
  cout<<p->val<<" -> ";
  p = p->next;
  
 }
 cout<<"NULL"<<endl;
    
}

void push_x(node*H, int x, int po_ktorym) // Dodanie elementu na wskazan� pozycje
{
    node* tmp = new node;
    tmp->val = x;
    node* p = H;
    while(p->val != po_ktorym)
        p = p->next;
    tmp ->next = p->next;
    p->next = tmp;
}


int main(){
    
    node* H = NULL;    
    push(H, 1);
    push(H, 2);
    push(H, 3);
    show(H);
    push_x(H,4,2);
    show(H);
    

    return 0;

}
