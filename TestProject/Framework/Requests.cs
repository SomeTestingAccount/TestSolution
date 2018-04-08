using System.Collections.Generic;
using System.Net.Http;

namespace TestProject.Framework
{
    /// <summary>
    /// Класс для выполнения запросов.
    /// </summary>
    public static class Reqests
    {
        /// <summary>
        /// Инициализация HTTP клиента.
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Выполнение GET запроса.
        /// </summary>
        /// <param name="url">URL запроса.</param>
        /// <returns>Ответ запроса.</returns>
        public static HttpResponseMessage GetRequest(string url)
        {
            return client.GetAsync(url).Result;
        }

        /// <summary>
        /// Выполниние POST запроса.
        /// </summary>
        /// <param name="url">URL запроса.</param>
        /// <param name="paramsDictionary">Параметры запроса.</param>
        /// <returns>Ответ запроса.</returns>
        public static HttpResponseMessage PostRequest(string url, Dictionary<string, string> paramsDictionary)
        {
            var paras = new FormUrlEncodedContent(paramsDictionary);
            return client.PostAsync(url, paras).Result;
        }
    }
}