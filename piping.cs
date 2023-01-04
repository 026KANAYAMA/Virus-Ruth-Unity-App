using UnityEngine;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

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
        
        //await numDirect = 
        var numDirect = await Getman();
        
        Task<string> Getman(){
            Task<string> num  = httpClient.GetStringAsync($"http://192.168.0.5:8888/{key}");
            //Debug.Log(num);
            return num;
        }

        return numDirect;
    }
        
        
}

