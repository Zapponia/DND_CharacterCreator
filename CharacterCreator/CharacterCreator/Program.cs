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
            character.RaceSelector(character);
            character.CharacterNaming(character);
            Console.WriteLine("All right {0} now its time to roll your stats", character.name);
            Thread.Sleep(2000);
            character.StatSelectorAndRolling(character);
            Console.Clear();
            character.ClassSelector(character);
            Console.WriteLine(character.name + "\n" +
                character.characterClass + "\n" +
                "Strenght: " + character.strength + "\n" +
                "Dexterity: " + character.dexterity + "\n" +
                "Constitution: " + character.constitution + "\n" +
                "Intelligence: " + character.intelligence + "\n" +
                "Wisdom: " + character.wisdom + "\n" +
                "Charisma: " + character.charisma + "\n");
        }
    }

     public enum Race
     {
        Dwarf,
        Elf,
        Gnome,
        Halfling,
        HalfElf,
        HalfOrc,
        Human
     }
    
    public enum Class
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Wizard
    }

    class Character
    {
        public Class characterClass;
        public Race race;
        public string name;
        public int strength = 0;
        public int dexterity = 0;
        public int constitution = 0;
        public int intelligence = 0;
        public int wisdom = 0;
        public int charisma = 0;

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
                        Console.ReadKey();
                        roll = false;
                    }

                }

                while (statPick)
                {
                    Console.Clear();
                    Console.WriteLine("Write the number for the stat you want to place your roll ({6}) do you want to put it? \n" +
                        "1. Strength {0} \n" +
                        "2. Dexterity {1} \n" +
                        "3. Constitution {2} \n" +
                        "4. Intelligence {3} \n" +
                        "5. Wisdom {4} \n" +
                        "6. Charisma {5}", character.strength, character.dexterity, character.constitution, character.intelligence, character.wisdom, character.charisma, rollTotal);

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (character.strength < 6)
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
                            if (character.dexterity < 6)
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
                            if (character.constitution < 6)
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
                            if (character.intelligence < 6)
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
                            if (character.wisdom < 6)
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
                            if (character.charisma < 6)
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

        /// <summary>
        /// Selecting race for the character, also adds the race modifiers
        /// </summary>
        /// <param name="character">Character to select race for</param>
        public void RaceSelector(Character character)
        {
            Console.WriteLine("Please select your characters race \n" +
                "1. Dwarf \n" +
                "2. Elf \n" +
                "3. Gnome \n" +
                "4. Halfling \n" +
                "5. Half-Elf \n" +
                "6. Half-Orc \n" +
                "7. Human");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    character.race = Race.Dwarf;
                    character.constitution = character.constitution + 2;
                    character.charisma = character.charisma - 2;
                    break;
                case "2":
                    character.race = Race.Elf;
                    character.dexterity = character.dexterity + 2;
                    character.constitution = character.constitution - 2;
                    break;
                case "3":
                    character.race = Race.Gnome;
                    character.constitution = character.constitution + 2;
                    character.strength = character.strength - 2;
                    break;
                case "4":
                    character.race = Race.Halfling;
                    character.dexterity = character.dexterity + 2;
                    character.strength = character.strength - 2;
                    break;
                case "5":
                    character.race = Race.HalfElf;
                    break;
                case "6":
                    character.race = Race.HalfOrc;
                    character.strength = character.strength + 2;
                    character.intelligence = character.intelligence - 2;
                    character.charisma = character.charisma - 2;
                    break;
                case "7":
                    character.race = Race.Human;
                    break;
            }
            Console.Clear();
        }


        public void ClassSelector(Character character)
        {
            Console.WriteLine("Now that you have your stats, please select your class \n" +
                "1. Barbarian                 {0}\n" +
                "2. Bard                      {1}\n" +
                "3. Cleric                    {2}\n" +
                "4. Druid                     {3}\n" +
                "5. Fighter                   {4}\n" +
                "6. Monk                      {5}\n" +
                "7. Paladin \n" +
                "8. Ranger \n" +
                "9. Rogue \n" +
                "10. Sorcerer \n" +
                "11. Wizard", character.strength, character.dexterity, character.constitution, character.intelligence, character.wisdom, character.charisma);

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    character.characterClass = Class.Barbarian;
                    break;
                case "2":
                    character.characterClass = Class.Bard;
                    break;
                case "3":
                    character.characterClass = Class.Cleric;
                    break;
                case "4":
                    character.characterClass = Class.Druid;
                    break;
                case "5":
                    character.characterClass = Class.Fighter;
                    break;
                case "6":
                    character.characterClass = Class.Monk;
                    break;
                case "7":
                    character.characterClass = Class.Paladin;
                    break;
                case "8":
                    character.characterClass = Class.Ranger;
                    break;
                case "9":
                    character.characterClass = Class.Rogue;
                    break;
                case "10":
                    character.characterClass = Class.Sorcerer;
                    break;
                case "11":
                    character.characterClass = Class.Wizard;
                    break;


            }
        }
    }
}
