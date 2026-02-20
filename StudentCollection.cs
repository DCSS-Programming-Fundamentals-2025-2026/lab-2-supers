using System;
using System.Collections;

public class StudentCollection : IEnumerable
{
    private Student[] items = new Student[200];
    private int count = 0;

    public int Count => count;

    public void Add(Student item)
    {
        if (count >= items.Length) throw new InvalidOperationException("Collection is full.");
        items[count] = item;
        count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count) throw new IndexOutOfRangeException("Invalid index.");

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        items[count - 1] = null;
        count--;
    }

    public Student GetAt(int index)
    {
        if (index < 0 || index >= count) throw new IndexOutOfRangeException("Invalid index.");
        return items[index];
    }

    public void SetAt(int index, Student item)
    {
        if (index < 0 || index >= count) throw new IndexOutOfRangeException("Invalid index.");
        items[index] = item;
    }

    public void Sort()
    {
        Array.Sort(items, 0, count);
    }

    public void Sort(IComparer comparer)
    {
        Array.Sort(items, 0, count, comparer);
    }

    public IEnumerator GetEnumerator()
    {
        return new StudentEnumerator(this);
    }

    private class StudentEnumerator : IEnumerator
    {
        private readonly StudentCollection _collection;
        private int _position = -1;

        public StudentEnumerator(StudentCollection collection)
        {
            _collection = collection;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _collection.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                if (_position < 0 || _position >= _collection.Count)
                    throw new InvalidOperationException();
                return _collection.GetAt(_position);
            }
        }
    }
}