using System;
using System.Collections.Generic;

namespace chachi
{
    public class Dojo
    {
        public int Happiness {get; set;}
        public int Fullness {get; set;}
        public int Energy {get; set;}
        public int Meals {get; set;}

        public Random rand {get; set;}

        public Dojo()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            rand = new Random();
        }

        public string Feed()
        {
            string message;
            if(Meals < 1)
            {
                message = "You do not have any food! \n Go to work for more meals";
                return message;
            }
            Meals -= 1;
            if(rand.Next(4) > 0)
            {
                int result = rand.Next(5,11);
                Fullness += result;
                message = String.Format($"Chachi gained {result} in Fullness!");
                return message;
            }
            else
            {
                return "You fed Chachi but it looks like he's not quite full.";
            }
        }
        public string Play()
        {
            string message;
            message = "Chachi wants moooore";
            if(Energy < 5)
            {
                message = "Chachi doesn't have enough energy to play. \n Try Sleeping";
            }

            if(rand.Next(4) > 0)
            {
                int result = rand.Next(5, 11);
                Happiness += result;
                message = String.Format($"Chachi is pleased. His Happiness gained {result}");
            }
            Energy -= 5;
            return message;
        }
        public string Work()
        {
            string message;
            if(Energy < 5)
            {
                return "Chachi doesn't have enough energy to play. \n Try Sleeping";
            }
            int result = rand.Next(1, 4);
            Meals += result;
            Energy -= 5;
            return String.Format($"Chachi has gained {result} Meal(s)");
        }
        public string Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            return "Chachi's energy raised by 15 but he's a little hungry & little cranky";
        }
        public string Reset()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            return "The game has been reset!";
        }

    }
}