// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class GenericStack<T>
    {
        // Private Class Node used by this class
        private class Node
        {
            public T Data
            {
                get;
                set;
            }
            public Node Next
            {
                get;
                set;
            }
        }

        // Private node to point the the start of the list. Can sometimes be called HEAD
        private Node head;
        // Private int to hold the size of the stack
        private int N;

        // Public property to return if the list is empty or not
        public bool IsEmpty
        {
            get
            {
                return head == null;
            }
        }

        //public property to return the size of the stack
        public int Size
        {
            get
            {
                return N;
            }
        }

        /// <summary>
        /// public method to push a new item onto the stack
        /// </summary>
        /// <param name="Data">Data to store in the node. Is of type T</param>
        public void Push(T Data)
        {
            //Create a new node that points to the same place that first points to
            Node oldFirst = head;
            //Create a new node and assign it to the first variable. Now first points to the new node, and oldFirst points to the old first node.
            head = new Node();
            //Set the data that was passed in on the new node
            head.Data = Data;
            //Set the Next property of the first node to the oldfirst, which will finish the work of adding a new node to the start of the list (stack)
            head.Next = oldFirst;
            //Increase the size by 1.
            N++;
        }

        /// <summary>
        /// public method to pop off the first node in the list (stack)
        /// </summary>
        /// <returns>Return the data stored in the node. Is of type T</returns>
        public T Pop()
        {
            //Check to make sure the list is not empty. Can't pop if it is empty
            if (!IsEmpty)
            {
                //Get the data out of the first node and put it in a local variable
                T data = head.Data;
                //Set the first pointer to first's next property
                head = head.Next;
                //Decrement the size
                N--;
                //return the data that was extracted
                return data;
            }
            //This will happen if we try to pop on an empty list
            return default(T);
        }
    }
}
