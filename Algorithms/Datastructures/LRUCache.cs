public class LRUCache
{
    int capacity;
    Dictionary<int, LinkedListNode<(int Key, int Value)>> cache = new();
    LinkedList<(int Key, int Value)> times = new();

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            MoveToHead(cache[key]);

            return cache[key].Value.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            node.Value = (key, value);
            MoveToHead(node);
        }
        else
        {
            var node = new LinkedListNode<(int, int)>((key, value));
            cache[key] = node;
            times.AddFirst(node);

            if (times.Count > this.capacity)
            {
                cache.Remove(times.Last.Value.Key);
                times.RemoveLast();
            }
        }
    }

    void MoveToHead(LinkedListNode<(int, int)> node)
    {
        times.Remove(node);
        times.AddFirst(node);
    }
}

