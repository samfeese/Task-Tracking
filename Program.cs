using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace classProject_JUL22
{
    public class Program
    {


        static public void Main(string[] args)
        {
            Console.WriteLine("Welcome to the long list assistant:");

            Program start = new Program();
            start.MenuLoop();

        }


        public void MenuLoop()
        {

            Console.WriteLine("Press <Enter> to continue or <Esc> quit");
            var quit = Console.ReadKey().Key;
            int menuInput;
            while (quit != ConsoleKey.Escape)
            {
                Console.Clear();

                menuInput = MainMenuSelection();

                MainMenuOption(menuInput);



                Console.WriteLine("Press <Enter> to continue to menu or <Esc> quit");
                quit = Console.ReadKey().Key;


            }
        }
        public int MainMenuSelection()
        {
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("\n1.  View active task");
            Console.WriteLine("2.  Add Item to the List");
            Console.WriteLine("3.  View All Items in list");
            Console.WriteLine("4.  View Pages");
            Console.WriteLine("\nEnter Menu Number to Continue");

            int menuInput = int.Parse(Console.ReadLine());

            return menuInput;
        }

        void MainMenuOption(int menuInput)
        {
            switch (menuInput)
            {
                case 1:
                    Console.WriteLine();
                    FirstTaskList();
                    break;

                case 2:
                    Console.WriteLine();
                    
                    WriteMyList();
                    break;

                case 3:
                    Console.WriteLine();
                    ReadMyList();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("What page would you like to view?");
                    Console.WriteLine("\n1: Page 1");
                    Console.WriteLine("2: Page 2");
                    Console.WriteLine("3: Page 3");
                    int pageView = int.Parse(Console.ReadLine())
;

                    JumpToClass(pageView);
                    break;


               

                
                case 5:
                    Console.WriteLine("Return to menu press ENTER");
                    Console.ReadLine();
                    MenuLoop();
                    break;

            }

        }

        int FirstTaskList()
        {
            ModifyList pullList = new ModifyList();
            int i = 0;
            List<string> orderedList = pullList.CompileTxt();
            string modifyFirst;
            bool complete = orderedList[i].Contains(" -c");
            Console.WriteLine("_____________________________________________________________________");
            do
            {

                if (i == 0 && complete == true)
                {
                    orderedList.RemoveAt(i);


                    StreamWriter saveList = new StreamWriter("LongList.txt", false);

                    foreach (string j in orderedList)
                    {
                        saveList.WriteLine(j);
                    }
                    saveList.Close();



                }
                if (complete == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\n\n{orderedList[i]}");

                }
                if (complete == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n\n{orderedList[i]}");

                }
               


                Console.WriteLine("\n\nWould you like to modify or skip this task?");
                Console.WriteLine("Enter 'Y' or 'N' or <esc> to quit");
              

                modifyFirst = Console.ReadLine();
                if (String.IsNullOrEmpty(modifyFirst))
                {
                    MenuLoop();
                }
                if (modifyFirst != "Y")
                {
                    i++;
                }
            } while (modifyFirst != "Y");

            ModifyFirst(i);
            return (i);

        }

        public int ModifyFirst(int i)
        {
            Console.WriteLine("Select what you would like to modify : ");

            Console.WriteLine("\n1: Crossout item.");

            Console.WriteLine("\n2: ReWrite item to list.");

            Console.WriteLine("\n3: Skip item");

            int userInput = int.Parse(Console.ReadLine());

            Modify(userInput, i);
            return userInput;

        }

        void Modify(int userInput, int i)
        {
            ModifyList redo = new ModifyList();


            if (userInput == 1)
            {

                if (i == 0)
                {
                    List<string> orderedList = redo.CompileTxt();

                    orderedList.RemoveAt(i);

                    StreamWriter saveList = new StreamWriter("LongList.txt", false);

                    foreach (var j in orderedList)
                    {
                        saveList.WriteLine(j);
                    }
                    saveList.Close();


                }
                if (i > 0)
                {
                    List<string> orderedList = redo.CompileTxt();

                    string temp = orderedList[i];

                    int index = orderedList.IndexOf(temp);
                    orderedList[index] = temp + " -c";

                    StreamWriter saveList = new StreamWriter("LongList.txt", false);

                    foreach (var j in orderedList)
                    {
                        saveList.WriteLine(j);
                    }
                    saveList.Close();



                }

            }
            if (userInput == 2)
            {


                List<string> orderedList = redo.CompileTxt();

                string temp = orderedList[i];
                string crossout = temp + " -c";
                orderedList[i] = crossout;

                orderedList.Add(temp);

                StreamWriter saveList = new StreamWriter("LongList.txt", false);

                foreach (var j in orderedList)
                {
                    saveList.WriteLine(j);
                }
                saveList.Close();


            }
            if (userInput == 3)
            {

                string modifyFirst;
                do
                {
                    List<string> orderedList = redo.CompileTxt();

                    Console.WriteLine(orderedList[i]);

                    Console.WriteLine("\n\nWould you like to modify this task?");
                    Console.WriteLine("Enter 'Y' or 'N'");
                    modifyFirst = Console.ReadLine();
                    i++;

                } while (modifyFirst == "N");



                if (modifyFirst == "Y")
                {
                    ModifyFirst(i);
                }
                else
                {


                    Console.WriteLine("Return to menu press ENTER");
                    Console.ReadLine();
                    MenuLoop();
                }

            }
        }
        void WriteMyList()
        {
            List<string> longList = new List<string> { };
            Console.WriteLine("Would you like to add to an exsisting list?");
            Console.WriteLine("ENTER 'Y' or 'N' ");
            string rewrite = Console.ReadLine();
            if (rewrite == "Y")
            {



                string addItem;
                do
                {
                    Console.WriteLine("\nWhen you are done making list entries press ENTER");

                    Console.WriteLine("Add item : ");

                    Console.WriteLine();

                    addItem = Console.ReadLine();
                    if (!String.IsNullOrEmpty(addItem))
                    {
                        longList.Add(addItem);
                    }

                } while (!String.IsNullOrEmpty(addItem));


                StreamWriter saveList = new StreamWriter("LongList.txt", true);

                foreach (string i in longList)
                {
                    saveList.WriteLine(i);
                }
                saveList.Close();

                Console.WriteLine("Return to menu press ENTER");
                Console.ReadLine();
                MenuLoop();

            }
            if (rewrite == "N")
            {
                Console.WriteLine("Are you sure you want to delete EVERYTHING in your list and start a new one?");
                Console.WriteLine("ENTER 'Y' or 'N' : ");
                string userDelete = Console.ReadLine();
                if (userDelete == "Y")
                {
                    string addItem;
                    do
                    {
                        Console.WriteLine("\nWhen you are done making list entries press ENTER");

                        Console.WriteLine("Add item : ");

                        Console.WriteLine();

                        addItem = Console.ReadLine();
                        if (addItem != "")
                        {
                            longList.Add(addItem);

                        }

                    } while (addItem != "");

                    StreamWriter saveList = new StreamWriter("LongList.txt", false);

                    foreach (string i in longList)
                    {
                        saveList.WriteLine(i);
                    }
                    saveList.Close();

                    Console.WriteLine("Return to menu press ENTER");
                    Console.ReadLine();
                    MenuLoop();

                }
                else
                {
                    MenuLoop();
                }

            }
            else
            {
                MenuLoop();
            }



        }

        void ReadMyList()
        {
            ModifyList redo = new ModifyList();

            List<string> orderedList = redo.CompileTxt();

            int i = 0;
            while (i<orderedList.Count)
            {
                
                bool star = orderedList[i].Contains(" -c");
                if (i == 0 && star == true)
                {
                    orderedList.RemoveAt(0);

                }


                if (i == 0)
                {


                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(orderedList[i]);

                }
                
                if (i > 0)
                {
                    if (star == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                      
                        Console.WriteLine(orderedList[i]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        Console.WriteLine(orderedList[i]);
                    }
                }
              i++;
            }
            
            Console.WriteLine("There were {0} lines.", i);

            Console.WriteLine("Return to menu press ENTER");
            Console.ReadLine();
            MenuLoop();

        }



        public void JumpToClass(int pageView)
        {
            ModifyList modList = new ModifyList();

            

            var wholeList = modList.CompileTxt();

            //foreach (string i in wholeList)
            //{
            //    Console.WriteLine(i);

            //}
            //Console.WriteLine("\n\n"); ;


            if (pageView == 1)
            {
                Console.WriteLine("\nPage 1 contains : ");
                modList.ReListAsPage1(wholeList);



            }
            if (pageView == 2)
            { 
                Console.WriteLine("\nPage 2 contains : ");
                modList.ReListAsPage2(wholeList);


            }
            if (pageView == 3)
            {
                Console.WriteLine("\nPage 3 contains : ");
                modList.ReListAsPage3(wholeList);


            }

           
        }

        //public int ItemEdit()
        //{


        //    Console.WriteLine("Welcome to the list Editor!");
        //    Console.WriteLine("Use <esc> when dont editing");
        //    Console.WriteLine("Select page to edit: ");

        //    Console.WriteLine("\n1. Page 1");
        //    Console.WriteLine("2. Page 2");
        //    Console.WriteLine("3. Page 3");

        //    int pageChange = int.Parse(Console.ReadLine());
        //    return pageChange;

        //}



    }

   
    public class ModifyList
    {

   

        public void ModifyMenu(List<string> idPage)
        {
            Console.Clear();
            Console.WriteLine("Page Contents: ");
            Console.WriteLine();
            foreach (var i in idPage)
            {
                Console.WriteLine($"\n{i}");
            }
            Console.WriteLine("Select what you would like to modify : ");

            Console.WriteLine("\n1: Crossout item.");

            Console.WriteLine("\n2: ReWrite item to list.");

            Console.WriteLine();

      

        }

        public List<string> CompileTxt()
        {

            StreamReader newList = new StreamReader("LongList.txt");

            var orderedList = new List<string> { };

            int counter = 0;

            string line;

            while ((line = newList.ReadLine()) != null)
            {

                orderedList.Add(line);
                counter++;
            }

           
            newList.Close();

            //Console.WriteLine("There are {0} items on this list.", counter);

            return orderedList;
        }

      


        public List<string> ReListAsPage1(List<string> orderedList)

        {
            //now items are all numbered, seperated into pages 20 items each

            Program backToTop = new Program();
            int i = 0;
            bool star = orderedList[i].Contains(" -c");
            if (orderedList.Count < 20)
            {

                List<string> page1 = orderedList.GetRange(0, orderedList.Count);

                while (i <= orderedList.Count)
                {



                    if (i == 0 && star == true)
                    {
                        orderedList.RemoveAt(0);

                    }


                    if (i == 0)
                    {


                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(orderedList[i]);

                    }

                    if (i > 0)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }

                    i++;

                }




                return page1;
            }
            if (orderedList.Count >= 20)
            {
                List<string> page1 = orderedList.GetRange(0, 19);
                while (i < 20)
                {



                    if (i == 0 && star == true)
                    {
                        orderedList.RemoveAt(0);

                    }


                    if (i == 0)
                    {


                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(orderedList[i]);

                    }

                    if (i > 0)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }

                    i++;

                }
                return page1;

            }
            else
            {
                Console.WriteLine("There are no items on this page .");
                backToTop.MenuLoop();
                return null;
            }




        }
        public List<string> ReListAsPage2(List<string> orderedList)

        {
            //now items are all numbered, seperated into pages 20 items each

            Program backToTop = new Program();
            int i = 0;
            bool star = orderedList[i].Contains(" -c");
            var max = orderedList.Count;
            if (orderedList.Count < 40)
            {
               
                while (i < orderedList.Count)
                {



                    if (i == 0 && star == true)
                    {
                        orderedList.RemoveAt(0);

                    }


                    if (i == 0)
                    {


                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(orderedList[i]);

                    }

                    if (i > 20)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }
                 
                    i++;

                }
                return null;
            }
            if (orderedList.Count >= 40)
            {
                List<string> page2 = orderedList.GetRange(20, 39);

                while (i < 40)
                {

                    if (i > 20)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }

                    i++;

                }
                return page2;
            }
            else
            {
                Console.WriteLine("There are no items on this page .");
                backToTop.MenuLoop();
                return null;
            }




        }
        public List<string> ReListAsPage3(List<string> orderedList)

        {
            //now items are all numbered, seperated into pages 20 items each

            Program backToTop = new Program();

            int i = 0;
            bool star = orderedList[i].Contains(" -c");
            if (orderedList.Count < 60)
            {
                //List<string> page3 = orderedList.GetRange(20, orderedList.Count);
                while (i < orderedList.Count)
                {


                    if (i > 40)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }

                    i++;

                }

                return null;
            }
            if (orderedList.Count >= 60)
            {
                List<string> page3 = orderedList.GetRange(40, 59);

                while (i < 60)
                {
                                       
                    if (i >= 60)
                    {
                        if (star == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                            Console.WriteLine(orderedList[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine(orderedList[i]);
                        }
                    }

                    i++;

                }
                return page3;
            }
            else
            {
                Console.WriteLine("There are no items on this page .");
                backToTop.MenuLoop();
                return null;
            }




        }






    }



}

