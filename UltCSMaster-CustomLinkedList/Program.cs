// Mostly CoPilot generated Code

using System.Collections;

public interface ILinkedList<T> : ICollection<T> {
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class CustomLinkedList<T> : ILinkedList<T> {

    private class Node {
        public T Value;
        public Node? Next;

        public Node(T value) {
            Value = value;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    int ICollection<T>.Count => _count;

    bool ICollection<T>.IsReadOnly => false;

    void ICollection<T>.Add(T item)
    {
        if (item == null) {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        var newNode = new Node(item);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }
        _count++;
    }

    void ILinkedList<T>.AddToEnd(T item)
    {
        ((ICollection<T>)this).Add(item);
    }

    void ILinkedList<T>.AddToFront(T item)
    {
        if (item == null) {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        var newNode = new Node(item);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }
        _count++;
    }

    void ICollection<T>.Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    bool ICollection<T>.Contains(T item)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array cannot be null");
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Invalid array index");
        }

        var current = _head;
        while (current != null && arrayIndex < array.Length)
        {
            array[arrayIndex++] = current.Value!;
            current = current.Next;
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value!;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    bool ICollection<T>.Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        Node? current = _head;
        Node? previous = null;

        while (current != null)
        {
            if (current.Value!.Equals(item))
            {
                if (previous == null)
                {
                    // Removing the head
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current.Next == null)
                {
                    // Removing the tail
                    _tail = previous;
                }

                _count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }
}
