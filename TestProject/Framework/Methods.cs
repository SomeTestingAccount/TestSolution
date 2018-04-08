using System.Collections.Generic;

namespace TestProject.Framework
{
    /// <summary>
    /// Класс для работы с методами API Vk. 
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Переменная для хранения актуальной версии API.
        /// </summary>
        private static KeyValuePair<string, string> ApiVersion = new KeyValuePair<string, string>("v", "5.66");

        /// <summary>
        /// Выполнение метода auth_signup
        /// </summary>
        /// <param name="paramsDictionary">Параметры запроса.</param>
        /// <returns>Ответ выполненного запроса.</returns>
        public static Results auth_signup(Dictionary<string, string> paramsDictionary)
        {
            if (!paramsDictionary.ContainsKey(ApiVersion.Key))
            {
                paramsDictionary.Add(ApiVersion.Key, ApiVersion.Value);
            }

            var response = Reqests.PostRequest("https://api.vk.com/method/auth.signup", paramsDictionary);
            return new Results(response);
        }
    }
}