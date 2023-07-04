using System;
using System.Net.Security;
using System.Numerics;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace GeroicheskyPohod
{
    public class GeroicheskyPohod
    {
        delegate void method(Сharacter character, Random random, Options options); 
        public static void Main(string[] args)
        {
            while (true)
            {
                int play;
                Random random = new Random();
                Options options = new Options(1, false);
                Сharacter character = new Сharacter();
                Dictionary<string, string> replikaDictionary = new Dictionary<string, string>
                {
                    { "начало", " Недавно вам исполнилось 15 лет, но вы не чувствуете праздничного духа, потому что ваши родители собираются разводиться, вы что бы отвлечься от этой новости решаете поразбирать вещи в отцовском гараже. В углу гаража вы находите пыльные вещи, это старые настольные игры, среди них вы обнаруживаете коробку с пестрыми цветами и нарисованным особняком. На коробке вырезано «Hexagon Passage». Вам хочется побыть одному, и вы достаете эту настольную игру, стряхиваете с неё пыль и открываете коробку. В коробке вы видите инструкцию, на которой можно еле разобрать выцветший текст и деревянную доску, на которой изображён особняк с коробки. Эта игра выглядит также, как и множество других настольных игр, но что-то в ней явно отличалось. На дверях  дома были знаки вопроса, а из окон выглядывали непонятные сущности,  рядом с каждой дверью стоял худощавый человек? с огромной сумкой за спиной. Вы вычитываете в инструкции, что для начала вам нужно бросить кубик. Вы берете шестигранник в руки и бросаете на доску. Резко потемнело в глазах и пропал звук окружения, через секунду вы очнулись в большом коридоре, похожем на картинную галерею. На картинах были люди из разных эпох. Позади вас дверь с огромным амбарным замком. У себя в кармане вы обнаруживаете тот самый шестигранник. В конце коридора вы видите дверь с знаком вопроса. Вы понимаете, что единственный способ от сюда выбраться, это сыграть в настольную игру"},
                    { "концовка_1", " Посмотрев на игру, вы решили, что уже выросли с настольных игр, и выбрасываете старые настолки на помойку. Проходит 5 лет, ваши родители давно развелись, вы давно живете своей не очень удачной жизнью, работая кассиром в Пятерочке :("},
                    { "концовка_2", " Вас объявили пропавшим без вести, единственной уликой по вашему делу была настольная игра, оставленная на полу гаража. Ваши родители начали винить друг друга в произошедшем, и вскоре развелись" },
                    { "победа", " Вам удалось пройти настольную игру, вы настроились на разговор с родителями, в следствии которого вы решили семейные проблемы, и они передумали разводиться"}
                };
                string[] start = { replikaDictionary["начало"], "играть", "не играть" };
                ConsoleMenu menu1 = new ConsoleMenu(start);
                play = menu1.PrintMenu();
                Console.Clear();
                while (true)
                {
                    if (play == 1)
                    {
                        string[] items = { $" (Уровень {options.level}) Выберите действие", "1. Сделать ход", "2. Магазин", "3. Статистика"};
                        method?[] methods = new method?[] {null, Method1, Method2, Method3};
                        ConsoleMenu menu2 = new ConsoleMenu(items);
                        int menuResult;
                        bool win = false;
                        do
                        {
                            menuResult = menu2.PrintMenu();
                            Console.Clear();
                            methods[menuResult](character, random, options);
                            Console.WriteLine("Для продолжения нажмите любую клавишу");
                            Console.ReadKey();
                            if (options.level > 20)
                            {
                                Console.Clear();
                                string[] end2 = { replikaDictionary["победа"], "начать заново", "выйти" };
                                ConsoleMenu menu5 = new ConsoleMenu(end2);
                                int next = menu5.PrintMenu();
                                if (next == 2)
                                {
                                    Exit();
                                }
                                if (next == 1)
                                {
                                    Console.Clear();
                                    win = true;
                                    break;  
                                }
                            }
                            items[0] = $" (Уровень {options.level}) Выберите действие";
                            if (win) break;
                            Console.Clear();
                        } while (!options.game_over);
                        if (win) break;
                        if (options.game_over)
                        {
                            string[] end1 = { replikaDictionary["концовка_2"], "начать заново", "выйти" };
                            ConsoleMenu menu4 = new ConsoleMenu(end1);
                            int next = menu4.PrintMenu();
                            if (next == 2)
                            {
                                Exit();
                            }
                            if (next == 1)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    if (play == 2)
                    {
                        string[] end = { replikaDictionary["концовка_1"], "начать заново", "выйти" };
                        ConsoleMenu menu3 = new ConsoleMenu(end);
                        int next = menu3.PrintMenu();
                        if (next == 2)
                        {
                            Exit();
                        }
                        if (next == 1)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
            }
        }
        static void Method1(Сharacter character, Random random, Options options)
        {
            int number = random.Next(1, 7);
            if (number % 2 == 0)
            {
                if (options.level > 0 && options.level <= 10)
                {
                    Goblin enemy = new Goblin();
                    while (enemy.health > 0)
                    {
                        enemy.Attack(character);
                        character.Attack(enemy);
                    }
                    if (character.health <= 0)
                    {
                        Console.WriteLine(" Вы были зарезаны гоблином :(");
                        options.game_over = true;
                    }
                    else
                    {
                        Console.WriteLine(" Вы победили гоблина, + 10 монет");
                        character.coins += 10;
                        options.level++;
                    }
                }
                else if (options.level > 10 && options.level <= 15)
                {
                    Catfish enemy = new Catfish();
                    while (enemy.health > 0)
                    {
                        enemy.Attack(character);
                        character.Attack(enemy);
                    }
                    if (character.health <= 0)
                    {
                        Console.WriteLine(" Вы были зарезаны морской кошкой :(");
                        options.game_over = true;
                    }
                    else
                    {
                        Console.WriteLine(" Вы победили морскую кошку, + 15 монет");
                        character.coins += 15;
                        options.level++;
                    }
                }
                else if(options.level > 15 && options.level <= 20)
                {
                    Yeti enemy = new Yeti();
                    while (enemy.health > 0)
                    {
                        enemy.Attack(character);
                        character.Attack(enemy);
                    }
                    if (character.health <= 0)
                    {
                        Console.WriteLine(" Вы были зарезаны йети :(");
                        options.game_over = true;
                    }
                    else
                    {
                        Console.WriteLine(" Вы победили йети, + 20 монет");
                        character.coins += 20;
                        options.level++;
                    }
                }
            }
            else if (number == 1)
            {
                character.health += 8;
                Console.WriteLine(" Вы встретили фонтан. Ваше здоровье увелиилось на 8");
                options.level++;
            }
            else if (number == 3)
            {
                character.coins += 15;
                Console.WriteLine(" Вы наши сундук. В нём было 15 монет");
                options.level++;
            }
            else if (number == 5)
            {
                character.health += 1;
                character.power += 1;
                Console.WriteLine(" Вы наши кристал улучшений. Ваше здоровье и атака + 1");
                options.level++;
            }
        }
        static void Method2(Сharacter character, Random random, Options options)
        {
            string[] magazine = {$" (Монет: {character.coins}) Выберите предмет", " палка цена: 30$ урон: 5", " короткий меч цена: 50$ урон: 10", " булава цена: 75$ урон: 15", " кожанная броня цена: 30$ здоровье: 5", " кольчужная броня цена: 50$ здоровье: 10", " эбонитовая броня 75$ здоровье: 15", " выход"};
            ConsoleMenu menu3 = new ConsoleMenu(magazine);
            int next = menu3.PrintMenu();
            switch (next) 
            {
                case 1:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 30)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 30;
                        character.power = 5;
                        character.power += 5;
                    }
                    catch (Exception ex)
                    {      
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 2:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 50)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 50;
                        character.power = 5;
                        character.power += 10;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                  
                    break;
                case 3:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 75)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 75;
                        character.power = 5;
                        character.power += 15;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                   
                    break;
                case 4:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 30)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 30;
                        character.health += 5;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 5:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 50)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 50;
                        character.health += 10;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 6:
                    Console.Clear();
                    try
                    {
                        if (character.coins < 75)
                        {
                            throw new Exception(" У вас нет столько монет");
                        }
                        character.coins -= 75;
                        character.health += 15;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine(" Спасибо, что посетили магазин");
                    break;
            }
        }
        static void Method3(Сharacter character, Random random, Options options)
        {
            Console.WriteLine($" Здоровье: {character.health}, Сила: {character.power}"); ;
        }
        static void Exit()
        {
            Environment.Exit(0);
        }
    }
}