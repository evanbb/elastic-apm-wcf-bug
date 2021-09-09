using System;
using System.Net.Http;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private const string JsonPlaceholderBaseUri = "https://jsonplaceholder.typicode.com/posts";
    
    private static readonly HttpClient httpClient = new System.Net.Http.HttpClient();

    public string GetData(int value)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            new Uri(JsonPlaceholderBaseUri)
        );

        var response = httpClient
            .SendAsync(request)
            .GetAwaiter()
            .GetResult()
            .Content
            .ReadAsStringAsync()
            .GetAwaiter()
            .GetResult();

        return string.Format("You entered: {0}, and we got {1} from the server", value, response);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }
}
