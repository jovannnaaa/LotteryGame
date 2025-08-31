using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame
{
    public class AIHost
    {
        private readonly Random rng = new Random();
        private readonly string playerName;

        public AIHost(string playerName = "Играч")
        {
            this.playerName = playerName;
        }

        // Метод кој дава порака при извлекување на број
        public string AnnounceDraw(int number, int drawIndex)
        {
            string[] reactions = new string[]
            {
                $"Let's see which number comes out... Number {number}!",
                $"The next number is {number}. Will it be lucky for you?",
                $"Attention! Number {number} has been drawn!"

            };

            return reactions[rng.Next(reactions.Length)];
        }

        // Метод кој дава порака за резултат
        public string AnnounceResult(List<int> selected, List<int> drawn, int hits)
        {
            if (hits == 7)
                return $"WOW! {playerName} hit everything! Jackpot and you go to the Bingo bonus!";
            else if (hits >= 5)
                return $"Great! {playerName} hit {hits} numbers!";
            else if (hits >= 3)
                return $"Good! {playerName} hit {hits} numbers!";
            else
                return $"Unfortunately, only {hits} numbers. Try the JOCKER card!";

        }

        // Метод за слободен коментар
        public string SaySomething()
        {
            string[] messages = new string[]
            {
                "Get ready, we’re starting the draw!",
                "Let’s see if luck is on your side...",
                "Watch out, the next number might be yours!"

            };
            return messages[rng.Next(messages.Length)];
        }
    }
}
