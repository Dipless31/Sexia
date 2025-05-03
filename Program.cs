﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var token = Environment.GetEnvironmentVariable("NEXIA_TOKEN");
            var bot = new TelegramBotClient(token);
            bot.StartReceiving(Update, Error, new ReceiverOptions { AllowedUpdates = { } }, cts.Token);
            Console.WriteLine("Нексия завелась....");
            while (true)
            {

            }
        }

        private static async Task Update(ITelegramBotClient bot, Update update, CancellationToken token)
        {

            if (update.Message is not null)
            {
                var message = update.Message;

                if (message.Text == "/start")
                {
                    var keyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton[] { "Профиль" },
                        new KeyboardButton[] { "Купить VPN" },
                        new KeyboardButton[] { "Поддержка" }
                    })
                    {
                        ResizeKeyboard = true
                    };

                    await bot.SendMessage(message.Chat.Id, "Выберите действие:", replyMarkup: keyboard);
                }
                if (message.Text == "Профиль")
                {
                    await bot.SendMessage(message.Chat.Id, "Ваш профиль:\n- Подписка: активна\n- Дата окончания: 12.04.2025");
                }

                if (message.Text == "Купить VPN")
                {
                    await bot.SendMessage(message.Chat.Id, "Для покупки перейдите по ссылке: https://example.com");
                }

                if (message.Text == "Поддержка")
                {
                    await bot.SendMessage(message.Chat.Id, "Свяжитесь с нами: @support_bot");
                }

            }



            // if (update.CallbackQuery is not null) {
            //         var callback = update.CallbackQuery;
            //         if (callback.Data == "button_pressed") {
            //             await bot.SendMessage(callback.Message.Chat.Id, "https://vk.com/audio585705204_456239022_222a2bc144cff58ed0");
            //     }bkjbjkbjkb
            //     } dsfklsdfldksfsdfklds;f
        }
        private static async Task Error(ITelegramBotClient bot, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            System.Console.WriteLine("АШИПКА");
        }
    }
}