﻿namespace Darkmoon.Greatness.Core.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> items, int start)
    {
        return items.Select((item, index) => (index + start, item));
    }

    public static IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> items)
    {
        return items.Select((item, index) => (index, item));
    }

    /// <summary>
    ///     Nested for loop helper
    /// </summary>
    public static IEnumerable<(T, T)> Product<T>(this IEnumerable<T> items, IEnumerable<T> other) =>
        from item1 in items from item2 in other select (item1, item2);

    public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Task<TResult>> method,
        int concurrency = int.MaxValue
    )
    {
        using var semaphore = new SemaphoreSlim(concurrency);
        return await Task.WhenAll(
                source.Select(async s =>
                    {
                        try
                        {
                            // ReSharper disable once AccessToDisposedClosure
                            await semaphore.WaitAsync().ConfigureAwait(false);
                            return await method(s).ConfigureAwait(false);
                        }
                        finally
                        {
                            // ReSharper disable once AccessToDisposedClosure
                            semaphore.Release();
                        }
                    }
                )
            )
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Executes a specified action on each element in a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="items">The collection to iterate over.</param>
    /// <param name="action">The action to perform on each element in the collection.</param>
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T item in items)
        {
            action(item);
        }
    }
}