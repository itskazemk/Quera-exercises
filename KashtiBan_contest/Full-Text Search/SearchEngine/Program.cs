using System;
using System.Collections.Generic;

namespace SearchEngine;

class Program
{
    static void Main(string[] args)
    {
        Index index = new Index();

        index.IndexDocument(new Document(1, "Quera online coding contests", DateTime.Now));
        index.IndexDocument(new Document(2, "Quera for programmers", DateTime.Now.AddDays(-4)));
        index.IndexDocument(new Document(3, "Practice coding skills", DateTime.Now.AddMonths(-11)));
        index.IndexDocument(
            new Document(69, "Quera fsdfdsfor progdsfsdframmers", DateTime.Now.AddDays(-5))
        );

        Query query = new Query("Quera", null, null);
        List<Document> result = index.Search(query);
    }
}
