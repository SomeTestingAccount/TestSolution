using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TestProject.Framework
{
    /// <summary>
    /// Класс для работы с методами API Vk. 
    /// </summary>
    public class Results
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="response">Ответ запроса</param>
        public Results(HttpResponseMessage response)
        {
            StatusCode = response.StatusCode;
            ResponeBody = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            Success = ResponeBody["response"] != null;
        }

        /// <summary>
        /// HTTP код запроса
        /// </summary>
        public HttpStatusCode StatusCode;

        /// <summary>
        /// Распаршенный JSON ответ запроса.
        /// </summary>
        public JObject ResponeBody;

        /// <summary>
        /// Признак "успешности" запроса. True - запрос вернул в JSON какой либо response, False - запрос вернул error. 
        /// </summary>
        public bool Success;
    }
}