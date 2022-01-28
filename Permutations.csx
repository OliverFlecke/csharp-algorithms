#!/usr/bin/env dotnet-script
using System.Collections.Generic;

// "" -> []
// A -> [ A ]
// AB -> [ AB, BA ]
// ABC -> [ ABC, ACB, BAC, BCA, CAB, CBA ] 3! = 6

// AA -> [ AA ]
// ABB -> [ ABB, BAB, BBA ]

/// <summary>
/// Compute all of the permutations of a given array.
/// </summary>
/// <remarks>
/// Idea: Iterate through each index of the array, and swap it with
/// every other position in the array (including the position itself,
/// hence why we are starting from l = 0).
/// Then recursively compute the permutations from in the subarray
/// from l + 1 and to the end. This means, that when l == items.Length
/// we have swapped every possible position with each other.
/// After the recursive call has been performed, swap back the items,
/// so that the next iteration is operating on the original array.
///
/// n is the length of the array.
/// Runtime: O(n!)
/// Space: O(n * n!) - There are n! permutations, each using n space
/// Both of these are the optimal case, as there are n! permutations
/// and we have to generate all of them.
/// </remarks>
/// <param name="items">Items to generate permutations for.</param>
/// <param name="l">Index to swap with.</param>
/// <typeparam name="T">Type of items in the array.</typeparam>
/// <returns>List of arrays, each a unique permutation.</returns>
IEnumerable<T[]> Permutations<T>(T[] items, int l = 0)
{
    if (items.Length == 0) return Array.Empty<T[]>();
    if (items.Length == l)
        return new List<T[]>() { items.Clone() as T[] };

    var permutations = new List<T[]>();

    for (int i = l; i < items.Length; i++)
    {
        Swap(items, i, l);
        permutations.AddRange(Permutations(items, l + 1));
        Swap(items, i, l);
    }

    return permutations;

    static void Swap(T[] items, int i, int j)
    {
        var temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }
}

int Factorial(int x)
{
    if (x == 0 || x == 1) return 1;
    return x * Factorial(x - 1);
}

var str = "ABCD";
var ABCD = Permutations(str.ToCharArray());
Console.WriteLine($"Expected permutations: {Factorial(str.Length)}. Actual: {ABCD.Count()}");

/// <summary>
/// Alternative approach, which also handles duplicates. (but only for strings)
/// </summary>
/// <remarks>
/// Idea is to remove the i'th element from the string, append it to
/// the answer string and then recurse. This will build up the answer
/// string until str is an empty string
///
/// n is the length of str
/// Runtime: O(n!)
///     Each iteration runs n, then recursively n - 1, n - 2 ... 1 times
///     Creating a copy of the string in each iteration of the loop takes O(n)
///     Checking and adding to the HashSet is both O(1) (amortized)
///
/// Space: O(n!)
///     There is n! different permutations which has to be generated
///
///     Could be optimized by printing the permutations directly or
///     using `yield` to only return one element at a time — but this
///     would then cause issues with the duplicate detection.
/// </remarks>
/// <param name="str"></param>
/// <param name="answer"></param>
/// <returns></returns>
IEnumerable<string> PermutationsWithDuplicates(string str, string answer = "")
{
    if (str == "")
        return new List<string>() { answer };

    var permutations = new HashSet<string>();

    for (int i = 0; i < str.Length; i++)
    {
        var tmp = str.Substring(0, i) + str.Substring(i + 1);
        foreach (var item in PermutationsWithDuplicates(tmp, answer + str[i]))
        {
            if (!permutations.Contains(item)) permutations.Add(item);
        }
    }

    return permutations;
}

var abbStr = "ABB";
var ABB = PermutationsWithDuplicates(abbStr);
foreach (var p in ABB)
{
    Console.WriteLine($"Permutation: {p}");
}

Console.WriteLine("Finished");