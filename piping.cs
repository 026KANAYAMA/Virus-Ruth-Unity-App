using UnityEngine;
using System;
using System.Net.Http;
using System.Threading.Tasks;


public class piping
{
    private static readonly HttpClient httpClient = new HttpClient();


    public async static Task<string> htpAsync(string player)
    {
         //piping serverから受けとったデータを格納したい
        string key = "0";  // http://localhost:8080/key の形でpiping-serverにアクセスしたい
        
        if(player == "Virus"){
            key = "Virus";
        }
        else if(player == "People"){
            key = "People";
        }

        Debug.Log($"http://{InputField.ip}/{key}");
        
        var numDirect = await Task.Run<string>(async () => {
            try
            {
                return await httpClient.GetStringAsync($"http://{InputField.ip}:8888/{key}");
            }
            catch(HttpRequestException)
            {
                Debug.Log("HttpRequestExceptionが起こりました");
                return string.Empty;
            }
        });
        
        
        return numDirect;
    }
        
        
}

