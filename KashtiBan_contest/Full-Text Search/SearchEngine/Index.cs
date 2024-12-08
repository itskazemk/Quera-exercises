namespace SearchEngine;

public class Index
{
    char[] charsToTrim = ['*', ' ', '\''];
    private List<Document> documents = new();
    private Dictionary<string, HashSet<long>> textIndex = new();
    private SortedDictionary<DateOnly, HashSet<long>> dateIndex = new();

    public Index() { }

    public Index(string filePath)
    {
        throw new NotImplementedException();
    }

    public void IndexDocument(Document document)
    {
        documents.Add(document);

        var trimText = document.Text.Trim(charsToTrim).ToUpper();

        foreach (var word in trimText.Split(' '))
        {
            if (textIndex.TryGetValue(word, out var hashSet_id))
            {
                if (hashSet_id.TryGetValue(document.Id, out var id_value))
                {
                    continue;
                }
                else
                {
                    hashSet_id.Add(document.Id);
                }
            }
            else
            {
                textIndex.Add(word, new() { document.Id });
            }
        }

        //TODO got error here in similar dates
        dateIndex.Add(DateOnly.FromDateTime(document.Date), new() { document.Id });
    }

    public void SaveIndexToFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public List<Document> Search(Query query)
    {
        //TODO change hashSet to long only
        Dictionary<HashSet<long>, int> id_count = [];

        var list = new List<Document>();
        if (query.Text is not null)
        {
            var trimQuery = query.Text.Trim(charsToTrim).ToUpper();

            foreach (var word in trimQuery.Split(' '))
            {
                var ids = textIndex.Where(x => x.Key == word).Select(x => x.Value).ToList();

                foreach (var id in ids)
                {
                    if (id_count.ContainsKey(id))
                    {
                        id_count[id]++;
                    }
                    else
                    {
                        id_count.Add(id, 1);
                    }
                }
            }

            var dsafadsf = trimQuery;

            // var foundedItems = textIndex.Where(x => x.Key.Contains(query.Text));
            // foreach (var item in foundedItems)
            // {
            //     var safaf = item.Value.First();
            // }
        }

        return list;
    }
}
