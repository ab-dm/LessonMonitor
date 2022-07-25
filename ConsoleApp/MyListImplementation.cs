namespace ConsoleApp
{
    internal class MyListImplementation
    {
        private Box _head;
        private Box _tail;
        private Box _current;

        public MyListImplementation()
        {
            _head = null;
            _tail = null;
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
        }

        public void Remuve(int value)
        {

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
