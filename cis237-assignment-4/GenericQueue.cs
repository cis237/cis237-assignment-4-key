// Author: David Barnes
// Class: CIS 237
// Assignment: 4
using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class GenericQueue<T>
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
        // Private node to point the the end of the list. Can sometimes be called TAIL
        private Node tail;
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

        // Public property to return the size of the stack
        public int Size
        {
            get
            {
                return N;
            }
        }

        /// <summary>
        /// public method to add a new node to the end of the list (queue)
        /// </summary>
        /// <param name="Data">The data to store in the node. Is of type T</param>
        public void Enqueue(T Data)
        {
            //create a new node called oldLast that points to the same place as last
            Node oldLast = tail;
            //Create a new node and assign it to last. It will become that last node in the queue
            tail = new Node();
            //Attach the passed in data to the new nodes data
            tail.Data = Data;
            //Set last's next to null. It should be anyway, but just in case.
            tail.Next = null;
            //If the list is empty, and this add will be the first node in the queue
            if (IsEmpty)
            {
                //Set first to equal the last that was just created.
                head = tail;
            }
            else
            {
                //This is not the only item in the list, so set oldLast's next to the new node pointed to by last.
                oldLast.Next = tail;
            }
            //increment the size of the queue
            N++;
        }

        /// <summary>
        /// public method to remove a node from the front of the list (queue)
        /// </summary>
        /// <returns>The data that was in the dequeued node</returns>
        public T Dequeue()
        {
            //If the queue is empty we want to just return the default type, which in the case of a droid will be null
            if (!IsEmpty)
            {
                //get the data from the first node
                T data = head.Data;
                //Set the first pointer to first's next pointer
                head = head.Next;
                //decrement the size
                N--;
                //if the queue is empty after taking out the last node
                if (IsEmpty)
                {
                    //set the last pointer to null
                    tail = null;
                }
                //return the data that was extracted
                return data;
            }
            return default(T);
        }
    }
}
