using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    struct ArraySpan<T>
    {
        T[] _array;

        int _offset;

        int _length;

        public ArraySpan(T[] array, int offset, int length)
        {
            _array = array;
            _offset = offset;
            _length = length;
        }

        public T this[int index]
        {
            get {return _array[_offset + index]; }
            set { _array[_offset + index] = value; }
        }

    }
}
