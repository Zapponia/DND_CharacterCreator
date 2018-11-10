using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();
            character.CharacterNaming(character);
        }
    }


    class Character
    {
        string name;
        int strength;
        int dexterity;
        int constitution;
        int intelligence;
        int wisdom;
        int charisma;

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

        public void DiceRoll(Character character)
        {

        }
    }

}
