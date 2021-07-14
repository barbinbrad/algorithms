using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Heap<T> : IEnumerable<T>
{
    private const int InitialCapacity = 0;
    private const int GrowFactor = 2;
    private const int MinGrow = 1;

    private int capacity = InitialCapacity;
    private T[] heap = new T[InitialCapacity];
    private int tail = 0;

    public int Count { get { return tail; } }
    public int Capacity { get { return capacity; } }

    protected Comparer<T> Comparer { get; private set; }
    protected abstract bool IsMoreExtremeThan(T x, T y);

    protected Heap() : this(Comparer<T>.Default)
    {
    }

    protected Heap(Comparer<T> comparer) : this(Enumerable.Empty<T>(), comparer)
    {
    }

    protected Heap(IEnumerable<T> collection)
        : this(collection, Comparer<T>.Default)
    {
    }

    protected Heap(IEnumerable<T> collection, Comparer<T> comparer)
    {
        if (collection == null) throw new ArgumentNullException("collection");
        if (comparer == null) throw new ArgumentNullException("comparer");

        Comparer = comparer;

        foreach (var item in collection)
        {
            if (Count == Capacity)
                Grow();

            heap[tail++] = item;
        }

        for (int i = Parent(tail - 1); i >= 0; i--)
            BubbleDown(i);
    }

    public void Insert(T item)
    {
        if (Count == Capacity)
            Grow();

        heap[tail++] = item;
        BubbleUp(tail - 1);
    }

    private void BubbleUp(int i)
    {
        if (i == 0 || IsMoreExtremeThan(heap[Parent(i)], heap[i]))
            return; 

        Swap(i, Parent(i));
        BubbleUp(Parent(i));
    }

    public T GetExtreme()
    {
        if (Count == 0) throw new InvalidOperationException("Heap is empty");
        return heap[0];
    }

    public T RemoveExtreme()
    {
        if (Count == 0) throw new InvalidOperationException("Heap is empty");
        T result = heap[0];
        tail--;
        Swap(tail, 0);
        BubbleDown(0);

        return result;
    }

    private void BubbleDown(int i)
    {
        int moreExtremeNode = MoreExtreme(i);
        if (moreExtremeNode == i) return;
        Swap(i, moreExtremeNode);
        BubbleDown(moreExtremeNode);
    }

    private int MoreExtreme(int i)
    {
        int moreExtremeNode = i;
        var youngerChild = YoungerChild(i);
        var olderChild = OlderChild(i);

        if(youngerChild < tail)
            moreExtremeNode = GetMoreExtreme(youngerChild, moreExtremeNode);

        if(olderChild < tail)
            moreExtremeNode = GetMoreExtreme(olderChild, moreExtremeNode);

        return moreExtremeNode;
    }

    private int GetMoreExtreme(int challenger, int champion)
    {
        if (challenger < tail && !IsMoreExtremeThan(heap[champion], heap[challenger]))
            return challenger;
        else
            return champion;
    }

    private void Swap(int i, int j)
    {
        T tmp = heap[i];
        heap[i] = heap[j];
        heap[j] = tmp;
    }

    private static int Parent(int i)
    {
        return (i + 1) / 2 - 1;
    }

    private static int YoungerChild(int i)
    {
        return (i + 1) * 2 - 1;
    }

    private static int OlderChild(int i)
    {
        return YoungerChild(i) + 1;
    }

    private void Grow()
    {
        int newCapacity = capacity * GrowFactor + MinGrow;
        var newHeap = new T[newCapacity];
        Array.Copy(heap, newHeap, capacity);
        heap = newHeap;
        capacity = newCapacity;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return heap.Take(Count).GetEnumerator();
    }

    

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

public class MaxHeap<T> : Heap<T>
{
    public MaxHeap()
        : this(Comparer<T>.Default)
    {
    }

    public MaxHeap(Comparer<T> comparer)
        : base(comparer)
    {
    }

    public MaxHeap(IEnumerable<T> collection, Comparer<T> comparer)
        : base(collection, comparer)
    {
    }

    public MaxHeap(IEnumerable<T> collection) : base(collection)
    {
    }

    protected override bool IsMoreExtremeThan(T x, T y)
    {
        return Comparer.Compare(x, y) >= 0;
    }
}

public class MinHeap<T> : Heap<T>
{
    public MinHeap()
        : this(Comparer<T>.Default)
    {
    }

    public MinHeap(Comparer<T> comparer)
        : base(comparer)
    {
    }

    public MinHeap(IEnumerable<T> collection) : base(collection)
    {
    }

    public MinHeap(IEnumerable<T> collection, Comparer<T> comparer)
        : base(collection, comparer)
    {
    }

    protected override bool IsMoreExtremeThan(T x, T y)
    {
        return Comparer.Compare(x, y) <= 0;
    }

    private static bool AssertHeapSort(Heap<int> heap, IEnumerable<int> expected)
    {
        var sorted = new List<int>();
        while (heap.Count > 0)
            sorted.Add(heap.RemoveExtreme());

        return sorted.SequenceEqual(expected);
    }
}