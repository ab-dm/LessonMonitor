using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Stack
    {
        private Box _head;
        private Box _tail;
        private Box _current;
        private int _count;


        public Stack()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public int Current
        {
            get
            {
                return _current.Value;
            }
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                return false;
            }

            _current = _current.Next;

            return _current.Next != null;
        }

        public void Push(int value)
        {
            Box box = new Box(value);

            if (_head == null && _tail == null)
            {
                _head = box;
                _current = box;
                _tail = box;
            }
            else
            {
                var tempBox = _tail;
                _tail = box;
                _tail.Next = tempBox;
            }

            _count++;
        }

        public int Pull()
        {
            if (_tail == null)
            {
                return 0;
            }

            int value = _tail.Value;
            _tail = _tail.Next;
            _count--;

            return value;
        }
        
        private class Box
        {
            public Box(int value)
            {
                Value = value;
                Next = null;
            }

            public int Value { get; set; }
            public Box? Next { get; set; }
        }
    }
}
