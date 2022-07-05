// https://leetcode.com/problems/boats-to-save-people/
public class NumberOfRescureBoatsSolution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int left = 0, right = people.Length - 1;
        int count = 0;

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
            {
                left++;
            }

            right--;
            count++;
        }

        return count;
    }
}

