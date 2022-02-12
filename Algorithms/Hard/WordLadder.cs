// https://leetcode.com/problems/word-ladder/
public class WordLadderSolution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var words = new HashSet<string>(wordList);
        if (!words.Contains(endWord)) return 0;

        var wordLength = beginWord.Length;
        var count = 1;
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        var visited = new HashSet<string>();
        visited.Add(beginWord);

        while (queue.Count > 0)
        {
            var length = queue.Count;
            for (int l = 0; l < length; l++)
            {
                var current = queue.Dequeue();
                if (current == endWord) return count;

                for (int i = 0; i < wordLength; i++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        var word = current.ToCharArray();
                        word[i] = c;
                        var w = new string(word);
                        if (!visited.Contains(w) && words.Contains(w))
                        {
                            queue.Enqueue(w);
                            visited.Add(w);
                        }
                    }
                }
            }

            count++;
        }

        return 0;
    }
}