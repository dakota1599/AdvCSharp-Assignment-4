/*
 DAKOTA SHAPIRO
 CIS 237 MW 3:30PM - 5:45PM
 LAST UPDATED: 10/31/19
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericQueue<T>
    {
        protected class Node {
            
            public T Data { get; set; } //Data held by the node.

            public Node Next { get; set; } //The next node in the list.
        }

        //Variables used for the linked list.
        protected Node _head;
        protected Node _tail; //Tail is needed here for adding to the back.
        protected int _size = 0;

        /// <summary>
        /// IsEmpty checks to see if the _head of the list is null, then returns the boolean result.
        /// </summary>
        protected bool IsEmpty
        {
            get { return _head == null; }
        }


        //Property for size that will be used for walking through the stack later on.
        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Adds to the back of the queue, then increments size.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value) {
            //MAKE A POINTER TO THE _tail CALLED oldTail
            Node oldTail = _tail;
            //MAKE A NEW NODE AND ASSIGN IT TO THE TAIL VARIABLE
            _tail = new Node();
            //SET THE DATA ON THE NEW NODE
            _tail.Data = value;

            //CHECK TO SEE IF THE LIST IS EMPTY. IF SO, MAKE THE HEAD
            //POINT TO THE SAME LOCATION AS THE TAIL.
            if (IsEmpty)
            { //CAN CHECK IsEmpty BECAUSE SIZE NOT INCREMENTED YET.
                _head = _tail;
            }
            //WE NEED TO TAKE THE oldTail AND MAKE IT'S NEXT PROPERTY
            //POINT TO THE TAIL THAT WE JUST CREATED.
            else
            {
                oldTail.Next = _tail;
            }
            //INCREMENT THE SIZE
            _size++;
        }

        /// <summary>
        /// Removes from the front of the queue, then decrements size.
        /// </summary>
        /// <returns></returns>
        public T Dequeue() {
            //Checks to see if the Queue is empty. Throws exception if it is.
            if (IsEmpty)
                throw new Exception("Queue is empty.");

            //Saves dequeued value for returning later.
            T dequeuedValue = _head.Data;

            //Sets the head to the next in the chain.
            _head = _head.Next;

            //Decrements the size.
            _size--;

            //Returns the dequeuedValue.
            return dequeuedValue;
        }
    }
}
