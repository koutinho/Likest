using Extensions.LikestCore;
using LikestCore.Abstract;
using LikestCore.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikestCore.Concrete
{
    /// <summary>
    /// Реализация ILikestApi с использованием RestSharp
    /// </summary>
    public class RestSharpLikestApi : ILikestApi
    {
        /// <summary>
        /// Загрузка системы
        /// </summary>
        public IObservable<(double current, double slowdown)> Load
        {
            get
            {
                return ObservableExtensionFeatures.
                    TimerFunc(TimeSpan.FromSeconds(1), GetLoadStatus)
                    .Retry()
                    .Where(d => d.Status.ToLower() == "success")
                    .Select(d => (d.Current, d.SlowDown))
                    .Publish()
                    .RefCount();
            }
        }

        private const string baseUrl = "http://likest.ru/api";

        private LoadData GetLoadStatus()
        {
            var request = new RestRequest("system.load", Method.GET);

            return Execute<LoadData>(request);
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(baseUrl);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw new Exception("Ошибка в процессе запроса к likest.ru");
            }

            return response.Data;
        }
    }
}
