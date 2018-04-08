using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using TestProject.Framework;

namespace TestProject.Tests
{
    //Тестирование метода auth_signup.
    internal class AuthSignupTest
    {
        // Переменные для хранения параметров тестов.
        private Dictionary<string, string> _positiveParams;
        private Dictionary<string, string> _negativeParams;

        // Инициализация параметров тестов.
        [SetUp]
        public void Initailization()
        {
            _positiveParams = new Dictionary<string, string>
            {
                {"first_name", "Иван"},
                {"last_name", "Иванов"},
                {"birthday", "01.01.1990"},
                {"client_id", "client_id"},
                {"client_secret", "client_secret"},
                {"phone", "phone"},
                {"password", "123123Aa"},
                {"test_mode", "1"},
                {"sex", "2"}
            };

            _negativeParams = new Dictionary<string, string>
            {
                {"first_name", "Иван"},
                {"last_name", "Иванов"},
                {"birthday", "01.01.1990"},
                {"client_id", "client_id"},
                {"client_secret", "client_secret"},
                {"password", "123123Aa"},
                {"test_mode", "1"},
                {"sex", "2"}
            };
        }

        //Тест с корректными параметрами, запрос должен вернуть произвольный sid.
        [Test]
        public void PositiveTest()
        {
            var result = Methods.auth_signup(_positiveParams);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Http код отличается от 200");
            Assert.That(result.Success, Is.True, $"Запрос вернул ошибку:" +
                                                 $"\n Код ошибки:{result.ResponeBody["error"]["error_code"]}" +
                                                 $"\n {result.ResponeBody["error"]["error_msg"]}");
            Assert.That(result.ResponeBody["response"]["sid"], Is.Not.Null.Or.Empty, "Осутствует параметр sid");
        }

        //Тест без указания телефона, запрос должен вернуть ошибку.
        [Test]
        public void NegativeTest()
        {
            var result = Methods.auth_signup(_negativeParams);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Http код отличается от 200");
            Assert.That(result.Success, Is.False, "Запрос прошёл успешно, а должен был выдать ошибку");
            Assert.That(result.ResponeBody["error"]["error_code"].ToString(), Is.EqualTo("100"),
                "Код ошибки отличается от ожидаемого");
            Assert.That(result.ResponeBody["error"]["error_msg"].ToString(),
                Is.EqualTo("One of the parameters specified was missing or invalid: phone is undefined"),
                "Некорректное сообщение об ошибке");
        }
    }
}