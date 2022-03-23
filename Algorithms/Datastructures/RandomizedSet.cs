public class RandomizedSet
{
    List<int> numbers = new();
    Dictionary<int, int> locations = new();
    Random random = new();


    public bool Insert(int val)
    {
        if (locations.ContainsKey(val)) return false;

        locations[val] = numbers.Count;
        numbers.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!locations.ContainsKey(val)) return false;

        var location = locations[val];
        (numbers[location], numbers[^1]) = (numbers[^1], numbers[location]);
        locations[numbers[location]] = location;

        locations.Remove(val);
        numbers.RemoveAt(numbers.Count - 1);
        return true;
    }

    public int GetRandom()
    {
        return numbers[random.Next(numbers.Count)];
    }
}

