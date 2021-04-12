using System;

namespace Lab_5_2
{
    enum Roshambo
    {
        rock,
        paper,
        scissors
    }

    enum Winner
    {
        left,
        right,
        draw
    }

    class Player
    {
       
        public Roshambo Choice;

        

        public virtual Roshambo GenerateRoshambo()
        {
            Choice = Roshambo.rock;
            return Choice;
        }
    }

    class BigDummyRock : Player
    {
        public string IdiotName = "Idiot";
        public override Roshambo GenerateRoshambo()
        {

            return Roshambo.rock;
        }
    }

    class RandomShoot : Player
    {
        public string SmartName = "Smarty Pants";
        public override Roshambo GenerateRoshambo()
        {
            Random rand = new Random();
            int shoot = rand.Next(0, 3);
            Choice = (Roshambo)shoot;
            return Choice;

        }
    }

    class Human : Player
    {
        public string HumanName;

        public override Roshambo GenerateRoshambo()
        {
            
            return Choice;
        }
    }

    class Program
    {
       
        static Winner Play(Player left, Player right)
        {
            if (left.Choice == right.Choice)
            {
                
                return Winner.draw;
            }
            else if (left.Choice == Roshambo.rock && right.Choice == Roshambo.paper)
            {
                return Winner.right;
            }
            else if (left.Choice == Roshambo.rock && right.Choice == Roshambo.scissors)
            {
                
                return Winner.left;
            }
            else if (left.Choice == Roshambo.paper && right.Choice == Roshambo.rock)
            {
                return Winner.left;
            }
            else if (left.Choice == Roshambo.paper && right.Choice == Roshambo.scissors)
            {
                return Winner.right;
            }
            else if (left.Choice == Roshambo.scissors && right.Choice == Roshambo.rock)
            {
                return Winner.right;
            }
            else if (left.Choice == Roshambo.scissors && right.Choice == Roshambo.paper)
            {
                return Winner.left;
            }
            else
            {
                return Winner.left;
            }
        }
        static void Main(string[] args)
        {
            //BigDummyRock idiot = new BigDummyRock();
            //Roshambo idChoice;
            //idChoice = idiot.GenerateRoshambo();
            ////Console.WriteLine(idChoice);
            

            //RandomShoot smart = new RandomShoot();
            //Roshambo smartChoice;
            //smartChoice = smart.GenerateRoshambo();
            ////Console.WriteLine(smartChoice);
            ///
            BigDummyRock idiot = new BigDummyRock();
            Roshambo idChoice;
            idChoice = idiot.GenerateRoshambo();

            RandomShoot smart = new RandomShoot();
            Roshambo smartChoice;
            smartChoice = smart.GenerateRoshambo();

            Human person = new Human();
            
            

            Console.WriteLine("Welcome to Rock Paper Scissors!");
            Console.WriteLine();
            Console.Write("Enter your name: ");
            person.HumanName = Console.ReadLine();
            

            Console.Write("Would you like to play the Dummy or The Smart One? Enter - D or S: ");
            string against = Console.ReadLine().ToLower(); 
            
            bool again = true;
            while (again)
            {
                Console.Write("Would you like to throw Rock, Paper or Scissors? Enter - R or P or S: ");
                string weapon = Console.ReadLine().ToLower();
                
                
                if (weapon == "r")
                {
                    person.Choice = (Roshambo)0;
                }
                else if (weapon == "p")
                {
                    person.Choice = (Roshambo)1;
                }
                else
                {
                    person.Choice = (Roshambo)2;
                }
                
                if (against == "d")
                {
                    Console.WriteLine($"{person.HumanName}: {person.Choice}");
                    Console.WriteLine($"{idiot.IdiotName}: {idiot.Choice}");
                    Winner result = Play(person, idiot);
                    if (result == Winner.left)
                    {
                        Console.WriteLine($"{person.HumanName} wins!");
                    }
                    else if (result == Winner.right)
                    {
                        Console.WriteLine($"{idiot.IdiotName} wins!");
                    }
                    else
                    {
                        Console.WriteLine("Draw!");
                    }
                }
                else if (against == "s")
                {
                    Console.WriteLine($"{person.HumanName}: {person.Choice}");
                    Console.WriteLine($"{smart.SmartName}: {smart.Choice}");
                    Winner result = Play(person, smart);
                    if (result == Winner.left)
                    {
                        Console.WriteLine($"{person.HumanName} wins!");
                    }
                    else if (result == Winner.right)
                    {
                        Console.WriteLine($"{smart.SmartName} wins!");
                    }
                    else
                    {
                        Console.WriteLine("Draw!");
                    }
                }
             

                Console.Write("Play Again? Enter - Y/N: ");
                string cont = Console.ReadLine().ToLower();
                if (cont != "n" && cont != "y")
                {
                    Console.WriteLine("That is not a correct option. Enter Y or N.");
                    Console.WriteLine();
                }
                else if (cont == "n")
                {
                    again = false;
                }
                else
                {
                    again = true;
                }
            }
            
        }
    }
}
