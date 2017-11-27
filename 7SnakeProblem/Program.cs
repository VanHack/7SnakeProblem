using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Combinatorics.Collections;

namespace SevenSnakeProblem
{
    class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int value { get; set; } 
        
        // Constructor
        public SnakePart()
        {
            X = 0;
            Y = 0;
            value = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            
            using (var reader = new StreamReader(@"C:\SevenSnakeProblem\7Snake.csv"))
            {
                List<SnakePart> snakeList = new List<SnakePart>();
                Random rand = new Random();

                Console.WriteLine("Reading CSV...");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    ++k;
                    for (int i = 0; i < values.Length; i++)
                    {
                        SnakePart snake = new SnakePart();
                        snake.X = k;
                        snake.Y = i + 1;
                        snake.value = int.Parse(values[i]);
                        snakeList.Add(snake);
                    }
                }

                Console.WriteLine("Searching for a valid pair...");

                Combinations<SnakePart> combinations = new Combinations<SnakePart>(snakeList, 7, GenerateOption.WithoutRepetition);
                Console.WriteLine("There are a total of " + combinations.Count.ToString("N") + " possible combinations. It can take a few minutes...");

                List<List<SnakePart>> snakeListFinal = new List<List<SnakePart>>();
                List<SnakePart> snakeListTempA = new List<SnakePart>();
                List<SnakePart> snakeListTempB = new List<SnakePart>();
                int prevX = 0;
                int prevY = 0;
                int count = 1;
                bool validList = false;
                foreach (List<SnakePart> snakeListTemp in combinations)
                {
                    foreach(SnakePart snake in snakeListTemp)
                    {
                        if(count == 1)
                        {
                            validList = true;
                            count++;
                            prevX = snake.X;
                            prevY = snake.Y;
                            continue;
                        }
                        if((snake.X == prevX + 1 || snake.X == prevX - 1 || snake.X == prevX) 
                            && (snake.Y == prevY + 1 || snake.Y == prevY - 1 || snake.Y == prevY))
                        {
                            validList = true;                            
                        }
                        else
                        {
                            validList = false;
                            break; 
                        }
                        count++;
                        prevX = snake.X;
                        prevY = snake.Y;
                    }
                    if (validList)
                    {
                        snakeListFinal.Add(snakeListTemp);
                    }
                    count = 1;
                }

                int count2 = 0;
                foreach (List<SnakePart> c in snakeListFinal)
                {

                    List<SnakePart> listA = c;
                    int sumA = listA[0].value + listA[1].value + listA[2].value + listA[3].value + listA[4].value + listA[5].value + listA[6].value;

                    count2 = snakeListFinal.Where(o => o[0].value + o[1].value + o[2].value + o[3].value + o[4].value + o[5].value + o[6].value == sumA
                                               && ( (o[0].X != listA[0].X && o[0].Y != listA[0].Y) && (o[0].X != listA[1].X && o[0].Y != listA[1].Y) && (o[0].X != listA[2].X && o[0].Y != listA[2].Y) && (o[0].X != listA[3].X && o[0].Y != listA[3].Y) && (o[0].X != listA[4].X && o[0].Y != listA[4].Y) && (o[0].X != listA[5].X && o[0].Y != listA[5].Y) && (o[0].X != listA[6].X && o[0].Y != listA[6].Y))
                                               && ( (o[1].X != listA[0].X && o[1].Y != listA[0].Y) && (o[1].X != listA[1].X && o[1].Y != listA[1].Y) && (o[1].X != listA[2].X && o[1].Y != listA[2].Y) && (o[1].X != listA[3].X && o[1].Y != listA[3].Y) && (o[1].X != listA[4].X && o[1].Y != listA[4].Y) && (o[1].X != listA[5].X && o[1].Y != listA[5].Y) && (o[1].X != listA[6].X && o[1].Y != listA[6].Y))
                                               && ( (o[2].X != listA[0].X && o[2].Y != listA[0].Y) && (o[2].X != listA[1].X && o[2].Y != listA[1].Y) && (o[2].X != listA[2].X && o[2].Y != listA[2].Y) && (o[2].X != listA[3].X && o[2].Y != listA[3].Y) && (o[2].X != listA[4].X && o[2].Y != listA[4].Y) && (o[2].X != listA[5].X && o[2].Y != listA[5].Y) && (o[2].X != listA[6].X && o[2].Y != listA[6].Y))
                                               && ( (o[3].X != listA[0].X && o[3].Y != listA[0].Y) && (o[3].X != listA[1].X && o[3].Y != listA[1].Y) && (o[3].X != listA[2].X && o[3].Y != listA[2].Y) && (o[3].X != listA[3].X && o[3].Y != listA[3].Y) && (o[3].X != listA[4].X && o[3].Y != listA[4].Y) && (o[3].X != listA[5].X && o[3].Y != listA[5].Y) && (o[3].X != listA[6].X && o[3].Y != listA[6].Y))
                                               && ( (o[4].X != listA[0].X && o[4].Y != listA[0].Y) && (o[4].X != listA[1].X && o[4].Y != listA[1].Y) && (o[4].X != listA[2].X && o[4].Y != listA[2].Y) && (o[4].X != listA[3].X && o[4].Y != listA[3].Y) && (o[4].X != listA[4].X && o[4].Y != listA[4].Y) && (o[4].X != listA[5].X && o[4].Y != listA[5].Y) && (o[4].X != listA[6].X && o[4].Y != listA[6].Y))
                                               && ( (o[5].X != listA[0].X && o[5].Y != listA[0].Y) && (o[5].X != listA[1].X && o[5].Y != listA[1].Y) && (o[5].X != listA[2].X && o[5].Y != listA[2].Y) && (o[4].X != listA[3].X && o[5].Y != listA[3].Y) && (o[5].X != listA[4].X && o[5].Y != listA[4].Y) && (o[5].X != listA[5].X && o[5].Y != listA[5].Y) && (o[5].X != listA[6].X && o[5].Y != listA[6].Y))
                                               && ( (o[6].X != listA[0].X && o[6].Y != listA[0].Y) && (o[6].X != listA[1].X && o[6].Y != listA[1].Y) && (o[6].X != listA[2].X && o[6].Y != listA[2].Y) && (o[6].X != listA[3].X && o[6].Y != listA[3].Y) && (o[6].X != listA[4].X && o[6].Y != listA[4].Y) && (o[6].X != listA[5].X && o[6].Y != listA[5].Y) && (o[6].X != listA[6].X && o[6].Y != listA[6].Y))
                                               ).Count();

                    if (count2 > 0)
                    {
                        Console.WriteLine("Valid pair found. Now loading...");
                        List<SnakePart> listB = snakeListFinal.Where(o => o[0].value + o[1].value + o[2].value + o[3].value + o[4].value + o[5].value + o[6].value == sumA
                                               && ((o[0].X != listA[0].X && o[0].Y != listA[0].Y) && (o[0].X != listA[1].X && o[0].Y != listA[1].Y) && (o[0].X != listA[2].X && o[0].Y != listA[2].Y) && (o[0].X != listA[3].X && o[0].Y != listA[3].Y) && (o[0].X != listA[4].X && o[0].Y != listA[4].Y) && (o[0].X != listA[5].X && o[0].Y != listA[5].Y) && (o[0].X != listA[6].X && o[0].Y != listA[6].Y))
                                               && ((o[1].X != listA[0].X && o[1].Y != listA[0].Y) && (o[1].X != listA[1].X && o[1].Y != listA[1].Y) && (o[1].X != listA[2].X && o[1].Y != listA[2].Y) && (o[1].X != listA[3].X && o[1].Y != listA[3].Y) && (o[1].X != listA[4].X && o[1].Y != listA[4].Y) && (o[1].X != listA[5].X && o[1].Y != listA[5].Y) && (o[1].X != listA[6].X && o[1].Y != listA[6].Y))
                                               && ((o[2].X != listA[0].X && o[2].Y != listA[0].Y) && (o[2].X != listA[1].X && o[2].Y != listA[1].Y) && (o[2].X != listA[2].X && o[2].Y != listA[2].Y) && (o[2].X != listA[3].X && o[2].Y != listA[3].Y) && (o[2].X != listA[4].X && o[2].Y != listA[4].Y) && (o[2].X != listA[5].X && o[2].Y != listA[5].Y) && (o[2].X != listA[6].X && o[2].Y != listA[6].Y))
                                               && ((o[3].X != listA[0].X && o[3].Y != listA[0].Y) && (o[3].X != listA[1].X && o[3].Y != listA[1].Y) && (o[3].X != listA[2].X && o[3].Y != listA[2].Y) && (o[3].X != listA[3].X && o[3].Y != listA[3].Y) && (o[3].X != listA[4].X && o[3].Y != listA[4].Y) && (o[3].X != listA[5].X && o[3].Y != listA[5].Y) && (o[3].X != listA[6].X && o[3].Y != listA[6].Y))
                                               && ((o[4].X != listA[0].X && o[4].Y != listA[0].Y) && (o[4].X != listA[1].X && o[4].Y != listA[1].Y) && (o[4].X != listA[2].X && o[4].Y != listA[2].Y) && (o[4].X != listA[3].X && o[4].Y != listA[3].Y) && (o[4].X != listA[4].X && o[4].Y != listA[4].Y) && (o[4].X != listA[5].X && o[4].Y != listA[5].Y) && (o[4].X != listA[6].X && o[4].Y != listA[6].Y))
                                               && ((o[5].X != listA[0].X && o[5].Y != listA[0].Y) && (o[5].X != listA[1].X && o[5].Y != listA[1].Y) && (o[5].X != listA[2].X && o[5].Y != listA[2].Y) && (o[4].X != listA[3].X && o[5].Y != listA[3].Y) && (o[5].X != listA[4].X && o[5].Y != listA[4].Y) && (o[5].X != listA[5].X && o[5].Y != listA[5].Y) && (o[5].X != listA[6].X && o[5].Y != listA[6].Y))
                                               && ((o[6].X != listA[0].X && o[6].Y != listA[0].Y) && (o[6].X != listA[1].X && o[6].Y != listA[1].Y) && (o[6].X != listA[2].X && o[6].Y != listA[2].Y) && (o[6].X != listA[3].X && o[6].Y != listA[3].Y) && (o[6].X != listA[4].X && o[6].Y != listA[4].Y) && (o[6].X != listA[5].X && o[6].Y != listA[5].Y) && (o[6].X != listA[6].X && o[6].Y != listA[6].Y))
                                                         ).First();
                        Console.WriteLine("The pair values are listed below...");

                        Console.WriteLine("7 Snakes A: " + listA[0] + " + " +
                                          listA[1].value + " + " +
                                          listA[2].value + " + " +
                                          listA[3].value + " + " +
                                          listA[4].value + " + " +
                                          listA[5].value + " + " +
                                          listA[6].value + " = " + sumA);
                        Console.WriteLine("7 Snakes B: " + listB[0] + " + " +
                                          listB[1].value + " + " +
                                          listB[2].value + " + " +
                                          listB[3].value + " + " +
                                          listB[4].value + " + " +
                                          listB[5].value + " + " +
                                          listB[6].value + " = " + sumA);
                        Console.WriteLine("Please press ENTER to exit...");
                        Console.ReadLine();
                        Console.Write("tete");
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("FAIL");
                    Console.WriteLine("Please press ENTER to exit...");
                    Console.ReadLine();
                }

                
                
            }  
        }        
    }
}
