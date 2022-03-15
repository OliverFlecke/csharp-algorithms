public class MinRemoveToMakeValidParenthesesSolution
{
    public string MinRemoveToMakeValid(string s)
    {
        int count = 0;
        int i = 0;
        var list = s.ToList();

        while (i < list.Count)
        {
            if (list[i] == '(')
            {
                count++;
                i++;
            }
            else if (list[i] == ')')
            {
                if (count <= 0)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    count--;
                    i++;
                }
            }
            else i++;
        }

        if (count > 0)
        {
            i--;
            count = 0;
            while (i >= 0)
            {

                if (list[i] == ')')
                {
                    count++;
                    i--;
                }
                else if (list[i] == '(')
                {
                    if (count <= 0)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        count--;
                        i--;
                    }
                }
                else i--;
            }
        }

        return string.Join("", list);
    }
}