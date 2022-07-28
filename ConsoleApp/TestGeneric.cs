using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TestGeneric<T>
    {
        private T[] _objects;

        public TestGeneric(int copacity)
        {
            _objects = new T[copacity];
        }

        public int Count { get; set; }

        public void Place(T gameObject)
        {

        }

        public T Get(int index)
        {
            return _objects[index];
        }
    }
}
