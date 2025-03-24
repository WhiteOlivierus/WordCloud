namespace WordCloud.Api.Features.WordCloud;

public class WordCloudService : IWordCloudService
{
    public IEnumerable<WordDroplet> Generate(IEnumerable<string> words, IEqualityComparer<string> equalityComparer = default!)
    {
        ArgumentNullException.ThrowIfNull(words);

        return words
            .GroupBy(w => w, (word, count) => new WordDroplet(word, count.Count()), comparer: equalityComparer ?? StringComparer.OrdinalIgnoreCase)
            .OrderByDescending(w => w.Amount)
            .ThenBy(w => w.Word);
    }

    public IEnumerable<WordDroplet> Generate(string text, IEqualityComparer<string> equalityComparer = default!)
    {
        ArgumentNullException.ThrowIfNull(text);

        return Generate(text.Split(" "), equalityComparer);
    }
}