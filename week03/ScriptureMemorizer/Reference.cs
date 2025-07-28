public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }

    // 🔹 NEW: Parse a string like "John 3:16" or "Proverbs 3:5-6"
    public static Reference Parse(string input)
    {
        string[] parts = input.Split(' ');
        string book = parts[0];
        string[] chapterAndVerses = parts[1].Split(':');
        int chapter = int.Parse(chapterAndVerses[0]);

        string[] verseParts = chapterAndVerses[1].Split('-');
        int startVerse = int.Parse(verseParts[0]);
        int endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : startVerse;

        return new Reference(book, chapter, startVerse, endVerse);
    }
}
