using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_project_hashtable
{
    public class HashTable
    {
        private const int Size = 100;
        private HashNode[] buckets;

        public HashTable()
        {
            buckets = new HashNode[Size];
        }

        private int GetBucketIndex(string key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % Size;
            return Math.Abs(index);
        }

        public void Add(string key, object value)
        {
            int index = GetBucketIndex(key);
            HashNode newNode = new HashNode(key, value);

            if (buckets[index] == null)
            {
                buckets[index] = newNode;
            }
            else
            {
                HashNode current = buckets[index];
                while (current.Next != null)
                {
                    if (current.Key == key)
                    {
                        current.Value = value; // Update existing key with new value
                        return;
                    }
                    current = current.Next;
                }

                if (current.Key == key)
                {
                    current.Value = value; // Update existing key with new value
                }
                else
                {
                    current.Next = newNode; // Add new node at the end of the list
                }
            }
        }

        public object Get(string key)
        {
            int index = GetBucketIndex(key);
            HashNode current = buckets[index];

            while (current != null)
            {
                if (current.Key == key)
                {
                    return current.Value;
                }
                current = current.Next;
            }

            return null; // Key not found
        }

        public bool Remove(string key)
        {
            int index = GetBucketIndex(key);
            HashNode current = buckets[index];
            HashNode previous = null;

            while (current != null)
            {
                if (current.Key == key)
                {
                    if (previous == null)
                    {
                        buckets[index] = current.Next; // Remove first node
                    }
                    else
                    {
                        previous.Next = current.Next; // Bypass the node to remove it
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false; // Key not found
        }

        public void DisplayAll()
        {
            for (int i = 0; i < Size; i++)
            {
                HashNode current = buckets[i];
                while (current != null)
                {
                    Console.WriteLine($"Key: {current.Key}, Value: {current.Value}");
                    current = current.Next;
                }
            }
        }
    }
}
