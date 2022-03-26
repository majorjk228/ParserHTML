using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ParserHTML
{
    public class GetRequest
    {
        HttpWebRequest _request; // создаем объект
        string _adress; //заводим переменная

        public Dictionary<string, string> Headers { get; set; }

        public string Response { get; set; }

        public string Accept { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string Referer { get; set; }

        public WebProxy Proxy { get; set; }

        public GetRequest(string adress) //конструктор который принимает адресс
        {
            _adress = adress;
            Headers = new Dictionary<string, string>();
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress); //создаем сам запрос
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse(); //ответ сервера
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd(); //записываем ответ
            }
            catch (Exception)
            {
            }
        }
            public void Run(CookieContainer cookieContainer)
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress); //создаем сам запрос
            _request.Method = "Get";
            _request.CookieContainer = cookieContainer;
            _request.Proxy = Proxy;
            _request.Accept = Accept;
            _request.Host = Host;
            _request.Referer = Referer;
            _request.UserAgent = UserAgent;

            foreach (var pair in Headers)
            {
                _request.Headers.Add(pair.Key, pair.Value);

            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse(); //ответ сервера
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd(); //записываем ответ
            }
            catch (Exception)
            {
            }
        }
    }
}