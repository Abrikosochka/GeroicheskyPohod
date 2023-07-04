using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroicheskyPohod
{
    internal class ConsoleMenu
    {
        string[] menuItems;
        int counter = 1;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }
        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            string[] offers = menuItems[0].Split(new char[] { '.', '!', '?' });
            foreach (string proposal in offers)
            {              
                foreach (char j in proposal)
                {
                    Console.Write(j);
                    Thread.Sleep(10);
                }
                Console.Write('.');
                Console.WriteLine();
            }
            do
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i && counter != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i != 0)
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 1;
                }
                int currentLine = Console.CursorTop; // Получаем текущую позицию курсора (строку)
                int targetLine = currentLine - (menuItems.Length - 1); // Вычисляем позицию, на которую нужно переместить курсор

                // Перемещаем курсор на нужную позицию
                Console.SetCursorPosition(0, targetLine);

                // Записываем пустые строки для очистки
                Console.Write(new string(' ', Console.WindowWidth)); // Пустая строка
                Console.Write(new string(' ', Console.WindowWidth)); // Пустая строка

                // Возвращаем курсор на исходную позицию
                Console.SetCursorPosition(0, currentLine - (menuItems.Length - 1));
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
