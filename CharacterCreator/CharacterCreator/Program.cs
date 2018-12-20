using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;

namespace CharacterCreator
{
    class Program
    {
        static void Main(string[] args)
        {


            bool isRunning = true;
            List<Character> CharacterList = new List<Character>();

            while (isRunning)
            {
                Character character = new Character();

                character.ShowNamesFromDataBase();
                Console.Clear();

                character.RaceSelector(character);

                character.CharacterNaming(character);

                Console.WriteLine("All right {0} now its time to roll your stats", character.name);
                Thread.Sleep(1000);
                character.StatSelectorAndRolling(character);
                Console.Clear();

                character.ClassSelector(character);

                character.AlignmentSelector(character);

                Console.WriteLine("YOUR CHARACTER \n" +
                    "Name: " + character.name + "\n" +
                    "Race: " + character.race + "\n" +
                    "Class: " + character.characterClass + "\n" +
                    "Alignment: " + character.alignment + "\n" +
                    "\n" +
                    "Strength: " + character.strength + "\n" +
                    "Dexterity: " + character.dexterity + "\n" +
                    "Constitution: " + character.constitution + "\n" +
                    "Intelligence: " + character.intelligence + "\n" +
                    "Wisdom: " + character.wisdom + "\n" +
                    "Charisma: " + character.charisma + "\n");
                Console.ReadKey();
                character.WriteToTxtDocument(character);
                Console.Clear();
                CharacterList.Add(character);
                character.AddToDatabase(character);
                character.ListShowing(CharacterList);
            }
        }
    }

    public enum Alignment
    {
        Lawful_Good,
        Neutral_Good,
        Chaotic_Good,
        Lawful_Neutral,
        True_Neutral,
        Chaotic_Neutral,
        Lawful_Evil,
        Neutral_Evil,
        Chaotic_Evil

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
        public Alignment alignment;
        public string name;
        public int strength = 0;
        public int dexterity = 0;
        public int constitution = 0;
        public int intelligence = 0;
        public int wisdom = 0;
        public int charisma = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characters"></param>
        public void ListShowing(List<Character> characters)
        {
            Console.WriteLine("Would you like to see the stored characters? (If build is before SQL join then you can only see characters made this session) \n" +
                   "(yes/no)");
            string input = Console.ReadLine();
            Console.Clear();
            if (input.ToLower() == "yes")
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    Character temp = characters[i];
                    Console.WriteLine((i+1) + ". " + temp.name);
                }
                Console.WriteLine("Would you like to select one of the characters to see the full stats? (write the number of the character you would like to see, otherwise write no)");
                input = Console.ReadLine();
                Console.Clear();
                if (input.ToLower() == "no")
                {
                    Console.Clear();
                    return;
                }

                try
                {
                    int index = Convert.ToInt32(input) - 1;
                    Character character = characters[index];

                    Console.WriteLine("YOUR CHARACTER \n" +
                        "Name: " + character.name + "\n" +
                        "Race: " + character.race + "\n" +
                        "Class: " + character.characterClass + "\n" +
                        "Alignment: " + character.alignment + "\n" +
                        "\n" +
                        "Strength: " + character.strength + "\n" +
                        "Dexterity: " + character.dexterity + "\n" +
                        "Constitution: " + character.constitution + "\n" +
                        "Intelligence: " + character.intelligence + "\n" +
                        "Wisdom: " + character.wisdom + "\n" +
                        "Charisma: " + character.charisma + "\n");
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("You wrote something incorrectly");
                }
                Console.Clear();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void WriteToTxtDocument(Character character)
        {
            Console.WriteLine("Would you like to save your character in a text document? (Yes/No)");
            string input = Console.ReadLine();

            if (input.ToLower() == "yes")
            {
                string path = @"C:\Users\Bruger.DESKTOP-7TQE051\Desktop\" + character.name + "CharacterSheet.txt";
                string text = "YOUR CHARACTER \r\n" +
                    "Name: " + character.name + "\r\n" +
                    "Race: " + character.race + "\r\n" +
                    "Class: " + character.characterClass + "\r\n" +
                    "Alignment: " + character.alignment + "\r\n" +
                    "\r\n" +
                    "Strength: " + character.strength + "\r\n" +
                    "Dexterity: " + character.dexterity + "\r\n" +
                    "Constitution: " + character.constitution + "\r\n" +
                    "Intelligence: " + character.intelligence + "\r\n" +
                    "Wisdom: " + character.wisdom + "\r\n" +
                    "Charisma: " + character.charisma;
                File.WriteAllText(path, text);
                Console.WriteLine("Your file should be saved on your desktop now, thank you");
            }
            else
                Console.WriteLine("Okay that's fine!");
            Thread.Sleep(1000);
            Console.Clear();
        }

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
            int die4;
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

                    for (int i = 0; i < 3; i += 1)
                    {
                        for (int a = 1; a <= 6; a += 1)
                        {
                            Console.WriteLine(a);
                            Thread.Sleep(10);
                            Console.Clear();
                        }
                    }
                    die4 = d6.Next(1, 7);

                    rollTotal = DieSelect(die1, die2, die3, die4);

                    if (rollTotal < 6)
                    {
                        Console.WriteLine("You rolled a {0}, {1}, {2}, {3}, and removing the smallest number you have a total of {4}", die1, die2, die3, die4, rollTotal);
                        Console.WriteLine("Unfortunately that's not enough to put into a stat, press enter to reroll");
                        Thread.Sleep(1000);
                    }

                    else
                    {
                        Console.WriteLine("You rolled a {0}, {1}, {2}, {3} and removing the smallest number you have a total of {4}", die1, die2, die3, die4, rollTotal);
                        Thread.Sleep(1000);
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
                                character.strength = rollTotal + character.strength;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                        case "2":
                            if (character.dexterity < 6)
                            {
                                character.dexterity = rollTotal + character.dexterity;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                        case "3":
                            if (character.constitution < 6)
                            {
                                character.constitution = rollTotal + character.constitution;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                        case "4":
                            if (character.intelligence < 6)
                            {
                                character.intelligence = rollTotal + character.intelligence;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                        case "5":
                            if (character.wisdom < 6)
                            {
                                character.wisdom = rollTotal + character.wisdom;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                        case "6":
                            if (character.charisma < 6)
                            {
                                character.charisma = rollTotal + character.charisma;
                                statPick = false;
                            }
                            else
                            {
                                Console.WriteLine("That has already been picked, pick a different stat");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Selecting which die to use for the total
        /// </summary>
        /// <param name="a">die 1</param>
        /// <param name="b">die 2</param>
        /// <param name="c">die 3</param>
        /// <param name="d">die 4</param>
        /// <returns></returns>
        public int DieSelect(int a, int b, int c, int d)
        {
            int total = 0;
            int lowest = a;

            if (b < lowest)
                lowest = b;
            if (c < lowest)
                lowest = c;
            if (d < lowest)
                lowest = d;

            if (lowest == a)
                total = b + c + d;
            if (lowest == b)
                total = a + c + d;
            if (lowest == c)
                total = b + a + d;
            if (lowest == d)
                total = b + c + a;

            return total;
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

        /// <summary>
        /// Selecting class for your character
        /// </summary>
        /// <param name="character">Character to select class for</param>
        public void ClassSelector(Character character)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Now that you have your stats, please select your class \n" +
                    "1. Barbarian                          Strength         {0}\n" +
                    "2. Bard                               Dexterity        {1}\n" +
                    "3. Cleric                             Constitution     {2}\n" +
                    "4. Druid                              Intelligence     {3}\n" +
                    "5. Fighter                            Wisdom           {4}\n" +
                    "6. Monk                               Charisma         {5}\n" +
                    "7. Paladin \n" +
                    "8. Ranger \n" +
                    "9. Rogue \n" +
                    "10. Sorcerer \n" +
                    "11. Wizard", character.strength, character.dexterity, character.constitution, character.intelligence, character.wisdom, character.charisma);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        character.characterClass = Class.Barbarian;
                        isRunning = false;
                        break;
                    case "2":
                        character.characterClass = Class.Bard;
                        isRunning = false;
                        break;
                    case "3":
                        character.characterClass = Class.Cleric;
                        isRunning = false;
                        break;
                    case "4":
                        character.characterClass = Class.Druid;
                        isRunning = false;
                        break;
                    case "5":
                        character.characterClass = Class.Fighter;
                        isRunning = false;
                        break;
                    case "6":
                        character.characterClass = Class.Monk;
                        isRunning = false;
                        break;
                    case "7":
                        character.characterClass = Class.Paladin;
                        isRunning = false;
                        break;
                    case "8":
                        character.characterClass = Class.Ranger;
                        isRunning = false;
                        break;
                    case "9":
                        character.characterClass = Class.Rogue;
                        isRunning = false;
                        break;
                    case "10":
                        character.characterClass = Class.Sorcerer;
                        isRunning = false;
                        break;
                    case "11":
                        character.characterClass = Class.Wizard;
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("I'm sorry I didn't understand that, please try again");
                        break;

                }
                Console.Clear();
            }
        }

        /// <summary>
        /// Selecting alignment for your character
        /// </summary>
        /// <param name="character"></param>
        public void AlignmentSelector(Character character)
        {
            bool isRunning = true;
            if (character.characterClass == Class.Paladin)
            {
                Console.WriteLine("Since you're playing Paladin, your alignment has been set as Lawful Good");
                Console.ReadKey();
                Console.Clear();
                character.characterClass = Class.Paladin;
            }
            else if (character.characterClass == Class.Monk)
            {
                while (isRunning)
                {
                    Console.WriteLine("Since you're a monk you can only play as a Lawful aligned character \n" +
                        "1. LAWFUL GOOD \n" +
                        "2. LAWFUL NEUTRAL \n" +
                        "3. LAWFUL EVIL");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            character.alignment = Alignment.Lawful_Good;
                            isRunning = false;
                            break;
                        case "2":
                            character.alignment = Alignment.Lawful_Neutral;
                            isRunning = false;
                            break;
                        case "3":
                            character.alignment = Alignment.Lawful_Evil;
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("I'm sorry I don't understand");
                            break;
                    }
                }
            }
            else
            {
                while (isRunning)
                {
                    Console.WriteLine("Which alignment does {0} have? \n" +
                        "1. LAWFUL GOOD           2. NEUTRAL GOOD          3. CHAOTIC GOOD \n\n" +
                        "4. LAWFUL NEUTRAL        5. TRUE NEUTRAL          6. CHAOTIC NEUTRAL \n\n" +
                        "7. LAWFUL EVIL           8. NEUTRAL EVIL          9. CHAOTIC EVIL", character.name);
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            character.alignment = Alignment.Lawful_Good;
                            isRunning = false;
                            break;
                        case "2":
                            character.alignment = Alignment.Neutral_Good;
                            isRunning = false;
                            break;
                        case "3":
                            character.alignment = Alignment.Chaotic_Good;
                            isRunning = false;
                            break;
                        case "4":
                            character.alignment = Alignment.Lawful_Neutral;
                            isRunning = false;
                            break;
                        case "5":
                            character.alignment = Alignment.True_Neutral;
                            isRunning = false;
                            break;
                        case "6":
                            character.alignment = Alignment.Chaotic_Neutral;
                            isRunning = false;
                            break;
                        case "7":
                            character.alignment = Alignment.Lawful_Evil;
                            isRunning = false;
                            break;
                        case "8":
                            character.alignment = Alignment.Neutral_Evil;
                            isRunning = false;
                            break;
                        case "9":
                            character.alignment = Alignment.Chaotic_Evil;
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("I don't understand, try again");
                            break;
                    }

                    Console.WriteLine("You have selected {0} as your alignment", character.alignment);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void AddToDatabase(Character character)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=characterdatabase;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
             string query = "INSERT INTO characters (Name, Class, Race, Alignment, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) VALUES" +
              " ('" + character.name +"', '"+ character.characterClass + "', '" + character.race + "', '" + character.alignment + "', '" + character.strength + "','" + character.dexterity + "','" + character.constitution + "','" + character.intelligence + "','" + character.wisdom + "','" + character.charisma + "')";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            
            databaseConnection.Open();

            
            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowNamesFromDataBase()
        {
            Console.WriteLine("CHARACTERS FROM THE DATABASE");

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=characterdatabase;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM characters";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            databaseConnection.Open();


            reader = commandDatabase.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + ". " + reader.GetString(1));
            }
            databaseConnection.Close();
            databaseConnection.Open();
            
            bool inputRun = true;
            int IDNumber = 0;
            while (inputRun)
            {
                Console.WriteLine("Write the number of the character you want more information about");

                string input = Console.ReadLine();
                try
                {
                    IDNumber = Convert.ToInt32(input);
                    inputRun = false;
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                    return;
                }
            }
            Console.Clear();
            query = "SELECT * FROM characters WHERE ID = '" + IDNumber + "'";
            MySqlCommand commandDatabase2 = new MySqlCommand(query, databaseConnection);

            reader = commandDatabase2.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Name: " + reader.GetString(1) + "\n" +
                    "Class: " + reader.GetString(2) + "\n" +
                    "Race: " + reader.GetString(3) + "\n" +
                    "Alignment: " + reader.GetString(4) + "\n" +
                    "\n" +
                    "Strength: " + reader.GetString(5) + "\n" +
                    "Dexterity: " + reader.GetString(6) + "\n" +
                    "Constitution: " + reader.GetString(7) + "\n" +
                    "Intelligence: " + reader.GetString(8) + "\n" +
                    "Wisdom: " + reader.GetString(9) + "\n" +
                    "Charisma: " + reader.GetString(10) + "\n");
            }
            Console.ReadKey();
            databaseConnection.Close();
        }

    }
}