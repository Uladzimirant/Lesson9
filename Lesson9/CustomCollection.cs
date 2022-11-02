using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class CustomCollection<T>
    {
        private const int DEFAULT_BUFFER_SIZE = 10;

        protected T[] _buffer;
        public int Count { get; protected set; }


        public CustomCollection() : this(DEFAULT_BUFFER_SIZE) {}


        public CustomCollection(int capacity)
        {
            _buffer = new T[capacity];
            Count = 0;
        }


        public CustomCollection(CustomCollection<T> other)
        {
            _buffer = (T[])other._buffer.Clone();
            Count = other.Count;
        }


        public CustomCollection(T[] elements) {
            _buffer = (T[])elements.Clone();
            Count = _buffer.Length;
        }


        public CustomCollection(IEnumerable<T> elements)
        {
            _buffer = elements.ToArray();
            Count = _buffer.Length;
        }
        

        public void Add(T element)
        {
            if (Count >= _buffer.Length)
            {
                Array.Resize(ref _buffer, _buffer.Length * 2);
            }
            _buffer[Count++] = element;
        }


        public void Add(IEnumerable<T> elements)
        {
            var size = elements.Count();
            if (Count + size > _buffer.Length)
            {
                Array.Resize(ref _buffer, Math.Max(_buffer.Length * 2, Count + size + _buffer.Length));
            }
            foreach (var element in elements)
            {
                _buffer[Count++] = element;
            }
        }

        public void Remove(T element)
        {
            var i = Array.IndexOf(_buffer, element);
            if (i == -1) return;
            if (i != (Count - 1)) Array.Copy(_buffer, i + 1, _buffer, i, _buffer.Length - i - 1);
            _buffer[--Count] = default; //Size - 1 is default then Size--
        }


        public T GetItem(int index)
        {
            return _buffer[index];
        }


        public T this[int index] 
        {
            get { return _buffer[index]; }
            set { _buffer[index] = value; }
        }


        public static bool operator ==(CustomCollection<T> a, CustomCollection<T> b)
        {
            if (a.Count != b.Count) return false;
            for (int i = 0; i < a.Count; i++)
            {
                if (!a._buffer[i].Equals(b._buffer[i])) return false;
            }
            return true;
        }

        public static bool operator !=(CustomCollection<T> a, CustomCollection<T> b)
        {
            return !(a == b);
        }
    }
}
