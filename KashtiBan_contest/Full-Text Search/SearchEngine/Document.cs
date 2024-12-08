namespace SearchEngine;

public class Document
{
    public Document(long id, string text, DateTime date)
    {
        Id = id;
        Text = text;
        Date = date;
    }

    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
}
