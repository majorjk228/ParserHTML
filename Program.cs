
using System;
using System.Net;

namespace ParserHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "20968"; //для сентах
            //var code = "935005085";

            var proxy = new WebProxy("127.0.0.1:8888");
            var cookieContainer = new CookieContainer();


            var postRequest = new PostRequest("https://santehopt-perm.ru/");
            postRequest.Data = $"ajax_call=y&INPUT_ID=title-search-input&q={code}&l=2";
            postRequest.Accept = "*/*";
            postRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.82 Safari/537.36";
            //postRequest.ContentType = "application/x-www-form-urlencoded";
            //postRequest.ContentType = "ContentType: application/x-www-form-urlencoded";
            postRequest.Referer = "https://santehopt-perm.ru/";
            postRequest.Host = "santehopt-perm.ru";
            postRequest.Proxy = proxy;

            postRequest.Headers.Add("Bx-ajax", "true");
            postRequest.Headers.Add("Origin", "https://santehopt-perm.ru/");
            postRequest.Headers.Add("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"99\", \"Google Chrome\";v=\"99\"");
            postRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            postRequest.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            postRequest.Headers.Add("Sec-Fetch-Dest", "empty");
            postRequest.Headers.Add("Sec-Fetch-Mode", "cors");
            postRequest.Headers.Add("Sec-Fetch-Site", "same-origin");

            postRequest.Run(cookieContainer);

            var strStart = postRequest.Response.IndexOf("JCTitleSearch"); //находим в хтмл
            strStart = postRequest.Response.IndexOf("'AJAX_PAGE' : '", strStart) + 15; //находим аджах после стрстарта
            var strEnd = postRequest.Response.IndexOf("',", strStart); //Ищем после аджаха
            var getPath = postRequest.Response.Substring(strStart, strEnd - strStart);

            Console.WriteLine(getPath);
            Console.ReadKey();s

            var getRequest = new GetRequest($"https://santehopt-perm.ru/search/?s=%D0%9F%D0%BE%D0%B8%D1%81%D0%BA&amp;q={getPath}");


        }
    }
}
