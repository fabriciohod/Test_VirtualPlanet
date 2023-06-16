namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        public static bool SequenceEqualIgnoreOrder<T>(this List<T> list1, List<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            Dictionary<T, int> dictionary = new Dictionary<T, int>();

            foreach (T item in list1)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary[item] = 1;
                }
            }

            foreach (T item in list2)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]--;
                    if (dictionary[item] == 0)
                    {
                        dictionary.Remove(item);
                    }
                }
                else
                {
                    return false;
                }
            }

            return dictionary.Count == 0;
        }

    }
}