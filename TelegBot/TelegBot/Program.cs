using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace TelegBot
{
    class Program
    {
        private static List<long> _clientAwaitedMessages = new List<long>();
        //Люди, у которых следующее сообщение является сообщением для вас
        private static long _authorchatId = 1668844623; //Айди создателя

        //Ввод API ключа бота
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5855208759:AAGfAKMhbhvYsXL_dq4lh-g-KVH_CPRoAJ4");
            client.StartReceiving(Update, Error);

            Console.ReadLine();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken arg3)
        {
            var message = update.Message;
            string lowMessage = message.Text.ToLower();

            Console.WriteLine(message.Chat.Id);
            //Получение своего айди

            if (message.Text != null)
            {
                //Проверяем, есть ли этот пользователь в списках ожидания
                if (_clientAwaitedMessages.Contains(message.Chat.Id))
                {
                    await botClient.SendTextMessageAsync(_authorchatId,
                        $"Пользователь {message.Chat.Username} отправил сообщение: {message.Text}");
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        $"Ваше сообщение успешно доставлено!");

                    //Убираем из списка, тк он отправил сообщение
                    _clientAwaitedMessages.Remove(message.Chat.Id);
                    return;
                }

                //Список с языками программирования и дополнительными возможностями
                if (lowMessage.Contains("/start"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "\n Приветствую тебя будущий программист," +
                        "\n у меня есть для тебя обучающий материал, просто напиши мне цифру интересующего тебя языка программирования!" +
                        "\n 1: C++" +
                        "\n 2: C#" +
                        "\n 3: Python" +
                        "\n 4: JavaScript" +
                        "\n 5: PHP" +
                        "\n 6: Дополнительно" +
                        "\n 7: Связь с администратором");
                    return;
                }
                //Пункт 1 - Язык С++
                if (lowMessage.Contains("1"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Смотри что я подобрал для тебя!" +
                        "\n https://www.youtube.com/watch?v=kRcbYLK3OnQ&list=PLQOaTSbfxUtCrKs0nicOg2npJQYSPGO9r" +
                        "\n" +
                        "\n https://code-live.ru/tag/cpp-manual/?page=1" +
                        "\n" +
                        "\n https://learn.microsoft.com/ru-ru/cpp/cpp/cpp-language-reference?view=msvc-170");
                }
                //Пункт 2 - Язык С#
                if (lowMessage.Contains("2"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Смотри что я подобрал для тебя!" +
                        "\n https://www.youtube.com/watch?v=KyFWqbRfWIA&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N" +
                        "\n" +
                        "\n https://ru.code-basics.com/languages/csharp" +
                        "\n" +
                        "\n https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/");
                }
                //Пункт 3 - Язык Python
                if (lowMessage.Contains("3"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Смотри что я подобрал для тебя!" +
                        "\n https://www.youtube.com/watch?v=34Rp6KVGIEM&list=PLDyJYA6aTY1lPWXBPk0gw6gR8fEtPDGKa" +
                        "\n" +
                        "\n https://pythonworld.ru/samouchitel-python" +
                        "\n" +
                        "\n https://docs-python.ru/");
                }
                //Пункт 4 - Язык JavaScript
                if (lowMessage.Contains("4"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Смотри что я подобрал для тебя!" +
                        "\n https://www.youtube.com/watch?v=CxgOKJh4zWE&t=458s" +
                        "\n" +
                        "\n https://learn.javascript.ru/js" +
                        "\n" +
                        "\n https://javascript.ru/manual");
                }
                //Пункт 5 - Язык PHP
                if (lowMessage.Contains("5"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Смотри что я подобрал для тебя!" +
                        "\n https://www.youtube.com/watch?v=yi3jlTGQVTM&list=PLfWxkvC096mJEO6yb_WhmrEIk9pBXajFj" +
                        "\n" +
                        "\n https://proglib.io/p/samouchitel-dlya-nachinayushchih-kak-osvoit-php-s-nulya-za-30-minut-2021-02-08" +
                        "\n" +
                        "\n https://www.php.net/manual/ru/langref.php");
                }
                //Пункт 6 - Форумы программистов
                if (lowMessage.Contains("6"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "В моей подборке ты можешь найти форумы программистов на которых ты сможешь задать свой вопрос" +
                        "\n https://stackoverflow.com/" +
                        "\n" +
                        "\n https://www.cyberforum.ru/" +
                        "\n" +
                        "\n https://habr.com/ru/all/");
                }
                //Пункт 7 - Связь с администратором
                if (lowMessage.Contains("7") && !_clientAwaitedMessages.Contains(message.Chat.Id))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Напиши сообщение и я перенаправлю его администратору!");
                    _clientAwaitedMessages.Add(message.Chat.Id);
                }
            }
        }
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
