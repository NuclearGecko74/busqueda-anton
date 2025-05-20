using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busqueda_anton.src.DataStructures
{
    internal class HashTable
    {
        private const int SIZE = 7;
        private Node[] dataMap = new Node[SIZE];

        public void Set(string key, int value)
        {
            int index = hash(key);
            Node newNode = new Node(key, value);
            if (dataMap[index] == null)
            {
                dataMap[index] = newNode;
            }
            else
            {
                Node temp = dataMap[index];
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }

        public int Get(string key)
        {
            int index = hash(key);
            Node temp = dataMap[index];
            while(temp.next != null)
            {
                if(temp.key == key)
                {
                    return temp.value;
                }
                temp = temp.next;
            }
            return 0;
        }

        List<string> Keys()
        {
            List<string> allKeys = new List<string>();
            for(int i = 0; i < SIZE; i++)
            {
                Node temp = dataMap[i];
                while(temp != null)
                {
                    allKeys.Add(temp.key);
                    temp = temp.next;
                }
            }
            return allKeys;
        }

        public void PrintTable()
        {
            for(int i = 0; i < SIZE; i++)
            {
                Console.WriteLine(i + ":");
                if (dataMap[i] != null)
                {
                    Node temp = dataMap[i];
                    while(temp != null)
                    {
                        Console.WriteLine(" {" + temp.key + ", " + temp.value + "}");
                        temp = temp.next;
                    }
                }
            }
        }

        private int hash(string key)
        {
            int hash = 0;
            for(int i = 0; i < key.Length; i++)
            {
                int asciiValue = (int)key[i];
                hash = (hash + asciiValue * 23) % SIZE;
            }
            return hash;
        }
    }
}
