using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            PrintSeparatorLine();
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuItemSelected = Console.ReadLine();
            return Convert.ToInt32(menuItemSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                //Mostrar la lista de tareas
                ShowTaskList();

                string idTaskSelected = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(idTaskSelected) - 1;
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string taskSelected = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskSelected + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                TaskList.Add(newTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            ShowTaskList();
        }

        /// <summary>
        /// Mostrar lista de tareas registradas
        /// </summary>
        public static void ShowTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                PrintSeparatorLine();

                var indexTask = 1;
                TaskList.ForEach(t => { Console.WriteLine($"{indexTask++}. {t}");});

                PrintSeparatorLine();
            }
        }

        /// <summary>
        /// Imprimir Linea separadora
        /// </summary>
        public static void PrintSeparatorLine()
        {
             Console.WriteLine("----------------------------------------");
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}