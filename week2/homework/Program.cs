var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => (string[] args)=> {
    
    string sentence = "the quick brown fox jumps over the lazy dog";
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

          string[] words = sentence.Split(' ');
           foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
               
                wordCount[word]++;
            }
            else
            { wordCount[word] = 1;
            }
        }
     Console.WriteLine("Word frequency in sentence:");
        foreach (KeyValuePair<string, int> pair in wordCount)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
});


app.Run();
