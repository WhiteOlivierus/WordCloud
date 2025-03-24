# WordCloud Service

The WordCloud Service is a simple C# library for generating word cloud data from an input. It supports processing either an array of words or a string of text, and outputs an ordered list of word-count pairs.

## Features

- **Word Counting**: Counts the occurrence of each word.
- **Flexible Input**:  
  - Accepts an array of words.
  - Accepts a text string and splits it into words.
- **Ordering**:  
  - Orders the output list first by the number of occurrences (descending).
  - For words with the same count, orders them alphabetically.
- **Case Sensitivity Options**:  
  - By default, the service is case-insensitive (e.g., "Word" and "word" are combined).
  - Supports passing a custom `StringComparer` to enforce case-sensitive counting.
- **Input Validation**:  
  - Throws an `ArgumentNullException` if the input is null.

## How to Use

1. **Installation**:  
   Include the `WordCloudService` class in your project. If needed, clone or copy this repository.

2. **Creating an Instance**:  
   Instantiate the service:
   ```csharp
   var wordCloudService = new WordCloudService();
   ```

3. **Using an Array of Words**:  
   To generate a word cloud from an array of words, call:
   ```csharp
   var words = new[] { "Word", "word", "Cloud", "Droplet", "droplet" };
   var result = wordCloudService.Generate(words);
   // result will be ordered by count then alphabetically
   ```

4. **Using a Text String**:  
   To generate a word cloud from a text string, call:
   ```csharp
   var text = "Word Word Cloud";
   var result = wordCloudService.Generate(text);
   // result will contain the word counts derived from the text
   ```

5. **Custom Case Sensitivity**:  
   To perform case-sensitive processing, provide a custom comparer:
   ```csharp
   var words = new[] { "Word", "word" };
   var result = wordCloudService.Generate(words, StringComparer.Ordinal);
   // "Word" and "word" will be counted separately
   ```

That’s it! The WordCloud Service is now ready to integrate into your application for generating word clouds based on your input data.