using System;
using System.Collections.Generic;
using System.Linq;


namespace VacuumCleaner
{
    class program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30);
            Dictionary<string, int> roomState = new Dictionary<string, int>(2);
            roomState.Add("a", 0);
            roomState.Add("b", 0);

            Console.WriteLine("Hello World");
            string startFromRoom = "x";

            while (startFromRoom != "a" && startFromRoom != "b")
            {
                Console.WriteLine("Please choose a room : a or b, or press x to exit");
                startFromRoom = Console.ReadLine();
                Console.WriteLine("You have enetered : " + startFromRoom);
            }
                int x = 0;
                while (x == 0)
                {
                Console.WriteLine("Please choose a room : a or b, or press x to exit");
                var roomDirty = Console.ReadLine();
                    if (roomDirty == "a")
                    {
                        roomState["a"] = 1;
                    }
                    if (roomDirty == "b")
                    {
                        roomState["b"] = 1;
                    }
                    if (roomDirty == "x")
                    {
                        x += 1;
                    }
                }
                string actionRight = "Moving right.\n";
                string actionLeft = "Moving left.\n";
                string actionSuck = "Room is dirty, cleaning is in progress.\n";
                string clean = "The room is clean.\n";
                string roomA = "In the room A\n";
                string roomB = "In the room B\n";

                int countCleanRooms = 0;

                var startFrom = char.Parse(startFromRoom);
                while (countCleanRooms < 3)
                {
                    foreach (KeyValuePair<string, int> rstate in roomState.ToList())
                    {
                        Console.WriteLine("startFrom is {0}.", startFrom);
                        if (rstate.Key.Contains(startFrom.ToString()) && rstate.Value == 1)
                        {
                            Console.WriteLine("Entering to clean");
                            if (startFrom.Equals('a'))
                            {
                                Console.WriteLine(roomA + actionSuck + clean + actionRight);
                                roomState[startFrom.ToString()] = 0;
                                startFrom = 'b';
                            }
                            else
                            {
                                Console.WriteLine(roomB + actionSuck + clean + actionLeft);
                                roomState[startFrom.ToString()] = 0;
                                startFrom = 'a';
                            }
                        }
                        if (rstate.Key.Contains(startFrom.ToString()) && rstate.Value == 0)
                        {
                            Console.WriteLine("Entering to view clean rooms");
                            if (startFrom.Equals('b'))
                            {
                                Console.WriteLine(roomB + clean + actionLeft); //action
                                startFrom = 'a'; //moving to next room
                            }
                            else
                            {
                                Console.WriteLine(roomA + clean + actionRight); //action
                                startFrom = 'b'; //moving to next room
                            }
                            countCleanRooms++;
                        }
                    }
                }
                Console.WriteLine("Rooms are now cleaned.\n");
                Console.ReadLine();
            }
        }
    }