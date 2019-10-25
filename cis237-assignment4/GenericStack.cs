using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericStack<T>
    {
        //Node class for linked list.
        protected class Node {
            public T Data { get; set; } //Data held by the node.

            public Node Next { get; set; } //The next node in the list.
        }

        //Variables used for the linked list.
        protected Node _head;
        protected Node _tail; //There is no point for a tail, since it will only add and remove from the front.
        protected int _size = 0;


        //Property for size that will be used for walking through the stack later on.
        public int Size {
            get { return _size; }
        }

        /// <summary>
        /// IsEmpty checks to see if the _head of the list is null, then returns the boolean result.
        /// </summary>
        protected bool IsEmpty {
            get{ return _head == null; }
        }

        /// <summary>
        /// Push will take an inserted value and place it at the front of the stack. and increments the size.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value) {
            //This takes holds the current head value.
            Node oldHead = _head;

            //Reassign head
            _head = new Node();
            //Pass value
            _head.Data = value;
            //Assign oldHead to the next in the chain
            _head.Next = oldHead;

            //Increase size
            _size++; 
        }

        /// <summary>
        /// Pop removes the value at the front of the stack and decrements the size.
        /// </summary>
        public T Pop() {
            //Checks to see if the stack is empty. Returns exception if it is.
            if (IsEmpty)
                throw new Exception("Stack is Empty");

            //Saves the value that is being deleted.
            T poppedValue = _head.Data;

            //Sets head to the next in the chain.
            _head = _head.Next;

            //Decrements size.
            _size--;

            //Returns popped value.
            return poppedValue;
        }

    }
}
