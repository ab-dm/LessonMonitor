namespace ConsoleApp
{
    public class Queue
    {
        private Box _head;
        private Box _tail;
        private Box _current;
        private int _count;


        public Queue()
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

        public int Dequeue()
        {
            int value = _head.Value;
            _head = _head.Next;
            _current = _head;
            _count--;

            return value;
        }
        public void Enqueue(int value)
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
