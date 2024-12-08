namespace SearchEngine;

public class Query
{
    public Query(string? text, DateTime? date, DateTime? endDate)
    {
        Text = text;
        Date = date;
        EndDate = endDate;
    }

    public string? Text { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? EndDate { get; set; }
}
