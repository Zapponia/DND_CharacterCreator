using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CharacterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();
            character.StatSelectorAndRolling(character);
            Console.ReadKey();
        }
    }


    class Character
    {
        string name;
        int strength = 0;
        int dexterity = 0;
        int constitution = 0;
        int intelligence = 0;
        int wisdom = 0;
        int charisma = 0;

        /// <summary>
        /// Function to name the character
        /// </summary>
        /// <param name="character">Character to name</param>
        public void CharacterNaming(Character character)
        {
            Console.WriteLine("Please enter your characters name");
            string name = Console.ReadLine();
            bool namePicking = true;
            while (namePicking)
            {
                Console.Clear();
                Console.WriteLine("{0}, are you sure you want {0} to be your characters name? (y/n)", name);
                string input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "yes")
                {
                    character.name = name;
                    namePicking = false;
                }
                else if (input.ToLower() == "n" || input.ToLower() == "no")
                {
                    Console.WriteLine("Please enter your characters name");
                    name = Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("I'm sorry I didn't understand try again \n" +
                        "Press enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();
            }
        }

        /// <summary>
        /// Rolls three random sixsided die and puts them in a stat
        /// </summary>
        /// <param name="character">Character to roll them for</param>
        public void StatSelectorAndRolling(Character character)
        {
            int rollTotal = 0;
            int die1;
            int die2;
            int die3;
            for (int b = 0; b < 6; b +=1)
            {
                bool roll = true;
                bool statPick = true;
                while (roll)
                {
                    Random d6 = new Random();
                    //Loop for shit and giggles
                    for (int i = 0; i < 3; i += 1)
                    {
                        for (int a = 1; a <= 6; a += 1)
                        {
                            Console.WriteLine(a);
                            Thread.Sleep(10);
                            Console.Clear();
                        }
                    }
                    die1 = d6.Next(1, 7);

                    for (int i = 0; i < 3; i += 1)
                    {
                        for (int a = 1; a <= 6; a += 1)
                        {
                            Console.WriteLine(a);
                            Thread.Sleep(10);
                            Console.Clear();
                        }
                    }
                    die2 = d6.Next(1, 7);

                    for (int i = 0; i < 3; i += 1)
                    {
                        for (int a = 1; a <= 6; a += 1)
                        {
                            Console.WriteLine(a);
                            Thread.Sleep(10);
                            Console.Clear();
                        }
                    }
                    die3 = d6.Next(1, 7);

                    rollTotal = die1 + die2 + die3;

                    if (rollTotal < 6)
                    {
                        Console.WriteLine("You rolled a {0}, {1}, {2} for a total of {3}", die1, die2, die3, rollTotal);
                        Console.WriteLine("Unfortunately that's not enough to put into a stat, press enter to reroll");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("You rolled a {0}, {1}, {2} for a total of {3}", die1, die2, die3, rollTotal);
                        roll = false;
                    }

                }

                while (statPick)
                {
                    Console.WriteLine("Write the number for the stat you want to place your roll do you want to put it? \n" +
                        "1. Strength \n" +
                        "2. Dexterity \n" +
                        "3. Constitution \n" +
                        "4. Intelligence \n" +
                        "5. Wisdom \n" +
                        "6. Charisma");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (character.strength == 0)
                            {
                                character.strength = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                        case "2":
                            if (character.dexterity == 0)
                            {
                                character.dexterity = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                        case "3":
                            if (character.constitution == 0)
                            {
                                character.constitution = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                        case "4":
                            if (character.intelligence == 0)
                            {
                                character.intelligence = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                        case "5":
                            if (character.wisdom == 0)
                            {
                                character.wisdom = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                        case "6":
                            if (character.charisma == 0)
                            {
                                character.charisma = rollTotal;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                            }
                            break;
                    }


                }
            }
        }

    }

}
