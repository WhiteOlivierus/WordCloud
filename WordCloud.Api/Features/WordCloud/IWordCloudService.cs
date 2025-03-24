namespace WordCloud.Api.Features.WordCloud;

public interface IWordCloudService
{
    IEnumerable<WordDroplet> Generate(string text, IEqualityComparer<string> equalityComparer = default!);

    IEnumerable<WordDroplet> Generate(IEnumerable<string> words, IEqualityComparer<string> equalityComparer = default!);
}