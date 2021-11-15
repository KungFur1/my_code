using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class DataBaseClass
    {
        public DataBaseClass(int id, string difficulty, string level)
        {
            Id = id;
            Difficulty = difficulty;
            Level = level;
        }

        public int Id { get; set; }
        public string Difficulty { get; set; }
        public string Level { get; set; }

        public void DrawData(int y)
        {
            int gap = 0;
            for (int yLocal = 0; yLocal < 9; yLocal++)
            {
                if (yLocal % 3 == 0 && yLocal != 0)
                {
                    gap++;
                }
                Console.SetCursorPosition(70, y + yLocal + gap);
                for (int x = 0; x < 9; x++)
                {
                    if (x % 3 == 0)
                    {
                        Console.Write("   ");
                    }
                    Console.Write(Level[x + yLocal * 9]);
                }
            }
            Console.SetCursorPosition(10, y + 10);
            Console.Write("Id:  " + Id + "     || " + "Difficulty:  " + Difficulty + "     || ");
            Console.SetCursorPosition(10, y + 12);
            for (int x = 0; x < 150; x++)
            {
                Console.Write('-');
            }
        }
    }
}
