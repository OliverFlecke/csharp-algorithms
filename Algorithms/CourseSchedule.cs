// Leetcode: https://leetcode.com/problems/course-schedule/

// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

// For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
// Return true if you can finish all courses. Otherwise, return false.

// ## Example 1:
// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: true
// Explanation: There are a total of 2 courses to take.
// To take course 1 you should have finished course 0. So it is possible.

// ## Example 2:
// Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
// Output: false
// Explanation: There are a total of 2 courses to take.
// To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

// ## Constraints:

// 1 <= numCourses <= 105
// 0 <= prerequisites.length <= 5000
// prerequisites[i].length == 2
// 0 <= ai, bi < numCourses
// All the pairs prerequisites[i] are unique.

namespace Algorithms;

public class CourseScheduleSolution {
    public bool CanFinish(int n, int[][] prerequisites) {
        var neighbors = new Dictionary<int, ISet<int>>();
        for (int i = 0; i < n; i++) // Initialize all nodes
        {
            neighbors.Add(i, new HashSet<int>());
        }

        foreach (var edge in prerequisites)
        {
            neighbors[edge[0]].Add(edge[1]);
        }

        var leaves = new HashSet<int>(); // Act as a queue
        for (int i = 0; i < n; i++)
        {
            if (neighbors[i].Count == 0) leaves.Add(i);
        }

        var passed = new HashSet<int>();
        while (leaves.Count > 0)
        {
            var current = leaves.First();
            leaves.Remove(current);
            passed.Add(current);

            for (int i = 0; i < n; i++)
            {
                neighbors[i].Remove(current);
                if (neighbors[i].Count == 0 && !passed.Contains(i))
                {
                    leaves.Add(i);
                }
            }
        }

        return passed.Count == n;
    }

    /// <remarks>
    /// Improved run time by tracking the indegree and child -> parent
    /// relationship.
    /// </remarks>
    /// <param name="n"></param>
    /// <param name="prerequisites"></param>
    /// <returns></returns>
    public bool CanFinish2(int n, int[][] prerequisites) {
        var neighbors = new Dictionary<int, ISet<int>>();
        var indegree = new int[n];

        for (int i = 0; i < n; i++) // Initialize all nodes
        {
            neighbors.Add(i, new HashSet<int>());
        }

        foreach (var edge in prerequisites)
        {
            neighbors[edge[1]].Add(edge[0]);
            indegree[edge[0]]++;
        }

        var leaves = new LinkedList<int>(); // Act as a queue
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0) leaves.AddLast(i);
        }

        var passed = new HashSet<int>();
        while (leaves.Count > 0)
        {
            var current = leaves.First();
            leaves.RemoveFirst();
            passed.Add(current);

            foreach (var parent in neighbors[current])
            {
                indegree[parent]--;
                if (indegree[parent] == 0 && !passed.Contains(parent))
                {
                    leaves.AddLast(parent);
                }
            }
        }

        return passed.Count == n;
    }
}