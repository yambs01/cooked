using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Progress progress = new Progress();
            progress.Play();
        }
    }

    class Progress
    {
        public Design design = new Design();
        public Calendar calendar = new Calendar();
        private int currentMonth = 0;
        private List<List<string>> allMonths;
        private List<string> monthNames;

        public Progress()
        {
            // Initialize all months
            allMonths = new List<List<string>>
            {
                Calendar.january,
                Calendar.february,
                Calendar.march,
                Calendar.april,
                Calendar.may,
                Calendar.june,
                Calendar.july,
                Calendar.august,
                Calendar.september,
                Calendar.october,
                Calendar.november,
                Calendar.december
            };

            monthNames = new List<string>
            {
                "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE",
                "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"
            };
        }

        public void Play()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            design.ShowWelcomeScreen();

            bool running = true;
            while (running)
            {
                DisplayCurrentMonth();

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (currentMonth < 11)
                            currentMonth++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currentMonth > 0)
                            currentMonth--;
                        break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.Q:
                        running = false;
                        break;
                }
            }

            design.ShowExitScreen();
            Console.CursorVisible = true;
        }

        private void DisplayCurrentMonth()
        {
            Console.Clear();
            design.ShowMonthHeader(monthNames[currentMonth], currentMonth + 1);

            foreach (var line in allMonths[currentMonth])
            {
                Console.WriteLine("  " + line);
            }

            design.ShowNavigation(currentMonth, 11);
        }
    }

    class Design
    {
        public void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║       📅 2025 CALENDAR VIEWER 📅          ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\n  Use ◄ LEFT and RIGHT ► arrow keys to navigate");
            Console.WriteLine("  Press ESC or Q to exit");
            Console.WriteLine("\n  Press any key to start...");
            Console.ReadKey(true);
        }

        public void ShowMonthHeader(string monthName, int monthNumber)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine($"║         {monthName} 2025 ({monthNumber}/12)".PadRight(45) + "║");
            Console.WriteLine("╚════════════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public void ShowNavigation(int current, int max)
        {
            Console.WriteLine("\n" + new string('─', 46));
            Console.ForegroundColor = ConsoleColor.Gray;

            string leftArrow = current > 0 ? "◄ LEFT" : "       ";
            string rightArrow = current < max ? "RIGHT ►" : "       ";
            string position = $"[{current + 1}/{max + 1}]";

            Console.WriteLine($"  {leftArrow}     {position}     {rightArrow}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Press ESC or Q to exit");
            Console.ResetColor();
        }

        public void ShowExitScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║    Thank you for viewing the calendar!     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝\n");
            Console.ResetColor();
            Console.WriteLine("  Press any key to exit...");
            Console.ReadKey();
        }
    }

    class Calendar
    {
        // January 2025
        public static List<string> january = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                  1    2    3    4",
            "   5    6    7    8    9   10   11",
            "  12   13   14   15   16   17   18",
            "  19   20   21   22   23   24   25",
            "  26   27   28   29   30   31"
        };

        // February 2025
        public static List<string> february = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                                  1",
            "   2    3    4    5    6    7    8",
            "   9   10   11   12   13   14   15",
            "  16   17   18   19   20   21   22",
            "  23   24   25   26   27   28"
        };

        // March 2025
        public static List<string> march = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                                  1",
            "   2    3    4    5    6    7    8",
            "   9   10   11   12   13   14   15",
            "  16   17   18   19   20   21   22",
            "  23   24   25   26   27   28   29",
            "  30   31"
        };

        // April 2025
        public static List<string> april = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "             1    2    3    4    5",
            "   6    7    8    9   10   11   12",
            "  13   14   15   16   17   18   19",
            "  20   21   22   23   24   25   26",
            "  27   28   29   30"
        };

        // May 2025
        public static List<string> may = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                       1    2    3",
            "   4    5    6    7    8    9   10",
            "  11   12   13   14   15   16   17",
            "  18   19   20   21   22   23   24",
            "  25   26   27   28   29   30   31"
        };

        // June 2025
        public static List<string> june = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "   1    2    3    4    5    6    7",
            "   8    9   10   11   12   13   14",
            "  15   16   17   18   19   20   21",
            "  22   23   24   25   26   27   28",
            "  29   30"
        };

        // July 2025
        public static List<string> july = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "             1    2    3    4    5",
            "   6    7    8    9   10   11   12",
            "  13   14   15   16   17   18   19",
            "  20   21   22   23   24   25   26",
            "  27   28   29   30   31"
        };

        // August 2025
        public static List<string> august = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                            1    2",
            "   3    4    5    6    7    8    9",
            "  10   11   12   13   14   15   16",
            "  17   18   19   20   21   22   23",
            "  24   25   26   27   28   29   30",
            "  31"
        };

        // September 2025
        public static List<string> september = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "        1    2    3    4    5    6",
            "   7    8    9   10   11   12   13",
            "  14   15   16   17   18   19   20",
            "  21   22   23   24   25   26   27",
            "  28   29   30"
        };

        // October 2025
        public static List<string> october = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                  1    2    3    4",
            "   5    6    7    8    9   10   11",
            "  12   13   14   15   16   17   18",
            "  19   20   21   22   23   24   25",
            "  26   27   28   29   30   31"
        };

        // November 2025
        public static List<string> november = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "                                  1",
            "   2    3    4    5    6    7    8",
            "   9   10   11   12   13   14   15",
            "  16   17   18   19   20   21   22",
            "  23   24   25   26   27   28   29",
            "  30"
        };

        // December 2025
        public static List<string> december = new List<string>
        {
            "  Sun  Mon  Tue  Wed  Thu  Fri  Sat",
            "        1    2    3    4    5    6",
            "   7    8    9   10   11   12   13",
            "  14   15   16   17   18   19   20",
            "  21   22   23   24   25   26   27",
            "  28   29   30   31"
        };
    }
}