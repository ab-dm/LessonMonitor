﻿namespace ConsoleApp
{
    public class MyListImplementation
    {
        private Box _head;
        private Box _tail;
        private Box _current;
        private int _count;

        public MyListImplementation()
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

            return _current != null;
        }

        public void Add(int value)
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
                _tail.Next = box;
                _tail = box;
            }

            _count++;
        }

        public void Remuve(int value)
        {
            _count--;
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
