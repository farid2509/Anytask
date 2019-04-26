using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashItems
    {
        public object Key { get; private set; }
        public object Value { get; private set; }

        public HashItems(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashTable
    {
        private HashItems[] table;
        private int _maxSize;

        public HashTable(int size)
        {
            table = new HashItems[size];
            _maxSize = size;
        }

        static void Main()
        {

        }

        public void PutPair(object key, object value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException();
            }
            var index = Math.Abs(key.GetHashCode() % _maxSize);

            while (true)
            {
                if (table[index] == null)
                {
                    break;
                }
                if (table[index].Key.Equals(key))
                {
                    break;
                }
                index = (index + 1) % _maxSize;
            }
            table[index] = new HashItems(key, value);
        }

        public object GetValueByKey(object key)
        {
            var index = Math.Abs(key.GetHashCode() % _maxSize);
            var startindex = index;
            while (true)
            {
                if (table[index].Key.Equals(key))
                {
                    return table[index].Value;
                }
                if (table[index] == null)
                {
                    return null;
                }
                if (startindex == index)
                {
                    return null;
                }
                index = (index + 1) % _maxSize;
            }
        }
    }
}