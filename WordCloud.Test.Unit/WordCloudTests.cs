using WordCloud.Api.Features.WordCloud;

namespace WordCloud.Test.Unit;

public class WordCloudTests
{
    [Fact]
    public void EmptyArray_ReturnsEmptyList()
    {
        var sut = new WordCloudService();

        var result = sut.Generate([]);

        Assert.Empty(result);
    }

    [Fact]
    public void FiveWords_ReturnsOrderedListOfWordFirstOnAmountThenOnAlpabaticalOrderDroplets()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "Word", "Cloud", "Droplet", "Droplet"]);

        Assert.Equal(result, [new("Droplet", 2), new("Word", 2), new("Cloud", 1)]);
    }

    [Fact]
    public void NullList_ThrowsArgumentNullException()
    {
        var sut = new WordCloudService();

        var action = () => sut.Generate(words: null!);

        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void NullString_ThrowsArgumentNullException()
    {
        var sut = new WordCloudService();

        var action = () => sut.Generate(text: null!);

        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void OneWord_ReturnsListWithOneKeyAndValueOfOne()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word"]);

        Assert.Equal(result, [new("Word", 1)]);
    }

    [Fact]
    public void RandomCapatalization_ReturnsListWithOneKeyAndValueOfTwo()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "word"]);

        Assert.Equal(result, [new("Word", 2)]);
    }

    [Fact]
    public void RandomCapatalizationWithComparer_ReturnsListWithOneKeyAndValueOfTwo()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "word"], StringComparer.Ordinal);

        Assert.Equal(result, [new("Word", 1), new("word", 1)]);
    }

    [Fact]
    public void TextWithOneWord_ReturnsListWithOneKeyAndValueOfOne()
    {
        var sut = new WordCloudService();

        var result = sut.Generate("Word");

        Assert.Equal(result, [new("Word", 1)]);
    }

    [Fact]
    public void TextWithTwoWords_ReturnsListWithOneKeyAndValueOfTwo()
    {
        var sut = new WordCloudService();

        var result = sut.Generate("Word Word");

        Assert.Equal(result, [new("Word", 2)]);
    }

    [Fact]
    public void ThreeWords_ReturnsOrderedListOfWordDroplets()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "Word", "Cloud"]);

        Assert.Equal(result, [new("Word", 2), new("Cloud", 1)]);
    }

    [Fact]
    public void ThreeWords_ShouldNotEqualUnorderdList()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "Word", "Cloud"]);

        Assert.NotEqual(result, [new("Cloud", 1), new("Word", 2)]);
    }

    [Fact]
    public void TwoDifferentWords_ReturnsListWithTwoKeysAndValuesOne()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "Word"]);

        Assert.Equal(result, [new("Word", 2)]);
    }

    [Fact]
    public void TwoWordOfTheSameWord_ReturnsListWithOneKeyAndValueOfTwo()
    {
        var sut = new WordCloudService();

        var result = sut.Generate(["Word", "Cloud"]);

        Assert.Equal(result, [new("Word", 1), new("Cloud", 1)]);
    }
}