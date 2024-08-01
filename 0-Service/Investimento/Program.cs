using Investimento;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiUrl = "https://api.andbank.com.br/candidate/positions";
    private const string apiKey = "JNQ!cpe7mzw!vqv-zew";

    static async Task Main(string[] args)
    {
        var policy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));

        client.DefaultRequestHeaders.Add("X-Test-Key", apiKey);

        var positions = await policy.ExecuteAsync(() => FetchData());

        // Process and store data here...
    }

    private static async Task<List<Position>> FetchData()
    {
        var response = await client.GetFromJsonAsync<List<Position>>(apiUrl);
        return response ?? new List<Position>();
    }
}

