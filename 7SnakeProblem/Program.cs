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


                Combinations<SnakePart> combinations = new Combinations<SnakePart>(snakeList, 7, GenerateOption.WithoutRepetition);
                Console.WriteLine("Making valid sets of 7 seven linked numbers...");

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

                        if(   (snake.X == prevX - 1 && snake.Y == prevY)
                           || (snake.X == prevX + 1 && snake.Y == prevY)
                           || (snake.X == prevX && snake.Y == prevY - 1)
                           || (snake.X == prevX && snake.Y == prevY + 1))                        
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
                Console.WriteLine("Searching for a valid pair...");
                foreach (List<SnakePart> c in snakeListFinal)
                {
                    List<SnakePart> listA = c;
                    int sumA = listA[0].value + listA[1].value + listA[2].value + listA[3].value + listA[4].value + listA[5].value + listA[6].value;                    
                    count2 = snakeListFinal.Where(o => o[0].value + o[1].value + o[2].value + o[3].value + o[4].value + o[5].value + o[6].value == sumA).Count();

                    List<List<SnakePart>> filteredSnakeList = new List<List<SnakePart>>();
                    if (count2 > 0)
                    {
                        List<List<SnakePart>> listTemp = snakeListFinal.Where(o => o[0].value + o[1].value + o[2].value + o[3].value + o[4].value + o[5].value + o[6].value == sumA).ToList();
                        foreach(List<SnakePart> filterSnakeList in listTemp)
                        {
                            foreach(SnakePart filterSnakePart in filterSnakeList)
                            {
                                if (   (listA[0].X == filterSnakePart.X && listA[0].Y == filterSnakePart.Y)
                                    || (listA[1].X == filterSnakePart.X && listA[1].Y == filterSnakePart.Y)
                                    || (listA[2].X == filterSnakePart.X && listA[2].Y == filterSnakePart.Y)
                                    || (listA[3].X == filterSnakePart.X && listA[3].Y == filterSnakePart.Y)
                                    || (listA[4].X == filterSnakePart.X && listA[4].Y == filterSnakePart.Y)
                                    || (listA[5].X == filterSnakePart.X && listA[5].Y == filterSnakePart.Y)
                                    || (listA[6].X == filterSnakePart.X && listA[6].Y == filterSnakePart.Y))
                                {
                                    goto NextIteration;
                                }
                            }
                            filteredSnakeList.Add(filterSnakeList);
                            NextIteration:;
                        }
                    }

                    if (filteredSnakeList.Count > 0)
                    {
                        Console.WriteLine("Valid pair found. Now loading...");

                        List<SnakePart> listB = filteredSnakeList.First();                                                                    
                                                       
                        Console.WriteLine("The pair values are listed below...");

                        Console.WriteLine("7 Snakes A: " + listA[0].value + " + " +
                                          listA[1].value + " + " +
                                          listA[2].value + " + " +
                                          listA[3].value + " + " +
                                          listA[4].value + " + " +
                                          listA[5].value + " + " +
                                          listA[6].value + " = " + sumA);
                        Console.WriteLine("7 Snakes B: " + listB[0].value + " + " +
                                          listB[1].value + " + " +
                                          listB[2].value + " + " +
                                          listB[3].value + " + " +
                                          listB[4].value + " + " +
                                          listB[5].value + " + " +
                                          listB[6].value + " = " + sumA);
                        Console.WriteLine("Please press ENTER to exit...");
                        Console.ReadLine();
                        Environment.Exit(0);

                    }
                }

                if (count2 == 0)
                {
                    Console.WriteLine("FAIL! Any valid pair found. Please try again with another values!");
                    Console.WriteLine("Please press ENTER to exit...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }  
        }        
    }
}
