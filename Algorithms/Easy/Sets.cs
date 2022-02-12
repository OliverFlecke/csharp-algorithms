public class SetSolutions
{
    // https://leetcode.com/problems/intersection-of-two-arrays/
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var s = new HashSet<int>(nums1);
        s.IntersectWith(nums2);

        return s.ToArray();
    }

    // https://leetcode.com/problems/intersection-of-two-arrays-ii/
    public int[] Intersect2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        var result = new List<int>();

        var i = 0;
        var j = 0;
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                result.Add(nums1[i]);
                i++;
                j++;
            }
            else if (nums1[i] < nums2[j]) i++;
            else j++;
        }

        return result.ToArray();
    }
}