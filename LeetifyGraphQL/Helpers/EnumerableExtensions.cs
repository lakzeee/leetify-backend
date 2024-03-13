namespace LeetifyGraphQL.Helpers;

public static class EnumerableExtensions
{
    public static Dictionary<TKey, TElement> ToDictionaryById<TElement, TKey>(
        this IEnumerable<TElement> elements,
        Func<TElement, TKey> keySelector)
    {
        return elements.ToDictionary(keySelector, element => element);
    }
}