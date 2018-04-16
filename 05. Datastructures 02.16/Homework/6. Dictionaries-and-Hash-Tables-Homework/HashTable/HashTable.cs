using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    private const int DefaultCapacity = 27;

    private const float LoadFactor = 0.70f;

    public HashTable(int capacity = DefaultCapacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }
    
    public void Add(TKey key, TValue value)
    {
        this.GrowIfNeeded();
        
        int slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                // Note: throw an exception on duplicated key
                throw new ArgumentException("Key already exists " + key);
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        this.GrowIfNeeded();

        int slotNumber = this.FindSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotNumber])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            // Note: throw an exception on missing key
            throw new KeyNotFoundException("The key: " + key + " was not found");
        }

        return element.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            var value = this.Get(key);
            return value;
        }

        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var element = this.Find(key);
        if (element == null)
        {
            value = default(TValue);
            return false;
        }

        value = element.Value;
        return true;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        var slotNumber = this.FindSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements == null)
        {
            return null;
        }

        foreach (KeyValue<TKey, TValue> element in elements)
        {
            if (element.Key.Equals(key))
            {
                return element;
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var element = this.Find(key);
        return element != null;
    }

    public bool Remove(TKey key)
    {
        int slotNumber = this.FindSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements == null)
        {
            return false;
        }

        var currentElement = elements.First;
        while (currentElement != null)
        {
            if (currentElement.Value.Key.Equals(key))
            {
                elements.Remove(currentElement);
                this.Count--;
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(element => element.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(element => element.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elements in this.slots)
        {
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private int FindSlotNumber(TKey key)
    {
        var slotNumber = Math.Abs(key.GetHashCode()) % this.Capacity;
        return slotNumber;
    }

    private void GrowIfNeeded()
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }
    }

    private void Grow()
    {
        var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }
}