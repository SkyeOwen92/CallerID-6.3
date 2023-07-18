using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CallerID_6._3
{
    public enum  People
    {
        SpongeBob,
        Squidward,
        Crabs,
        Puff
    }
    class node
    {
        public Nullable<People> who;
        public node next;
        public PictureBox photo { get; set; }
        public node(Nullable<People> me, node n)
        {
            who = me;
            next = n;
        }
    }
    internal class Q
    {
        public node front;
        public node rear;
        int size;
        public Q()
        {
            front = null;
            rear = null;
            size = 0;
        }
        public int Length()
        { return size; }
        public bool isEmpty()
        {
            return size == 0;
        }
        public void EnQue(Nullable<People> me)
        {
            node newest = new node(me,  null);
            if(isEmpty())
            {
                front = newest;
                rear = front; 
            }
            else
            {
                rear.next = newest;
                rear = newest;
            }
            size++;
        }
        public Nullable<People> DeQue()
        {
            if(isEmpty())
            {
                return null;
            }
            else
            {
                Nullable<People> e = front.who;
                front = front.next;
                size--; 
                if (isEmpty())
                {
                    rear = null; 
                }
                return e;
            }
        }
        public PictureBox[] move()
        {
            node p = front;
            PictureBox[] currentQ = new PictureBox[size];
            int i = 0;
            while (p != null)
            {
                currentQ[i] = p.photo;
                p = p.next;
                i++;
            }
            return currentQ;
        }
    }
}
