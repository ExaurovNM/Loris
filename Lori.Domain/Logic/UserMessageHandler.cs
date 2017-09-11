using Lori.Domain.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lori.Domain.Logic
{
    public class UserMessageHandler
    {
        public async Task Handle(MessageCallback messageCallback)
        {
            var message = messageCallback.Entry?.FirstOrDefault()?.Messaging?.FirstOrDefault();

            var text = message.Message.Text;

            if(text == "Начать")
            {
                await AskForRating(message.Sender.Id);
            }
        }

        private async Task AskForRating(string recipient)
        {
            var client = new FacebookClient();
            await client.SendMessage(
                "С каким минимальным рейтингом вы бы хотели видеть фильмы (Лори рекомендует не ниже 8.0)? Вы можете выбрать из списка или же написать любое число дробное число от 7 до 9, например 8.2", 
                new string[] { "7.0", "7.5", "8.0", "8.5", "9.0"},
                recipient);
        }
    }
}
