List<string> TaskList = new();

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


/// <summary>
/// Show the options for Tasks
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    PrintSeparatorLine();
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    // Read line
    string menuItemSelected = Console.ReadLine() ?? string.Empty;
    return Convert.ToInt32(menuItemSelected);
}

/// <summary>
/// Show the remove Menu
/// </summary>
/// <returns>Returns option indicated by user</returns>
void ShowMenuRemove()
{
    try
    {
        ShowTaskList();
        string idTaskSelected = Console.ReadLine() ?? string.Empty;

        // Remove one position because the array start in 0
        int indexToRemove = Convert.ToInt32(idTaskSelected) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            Console.WriteLine("Numero de tarea fuera de rango");
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskSelected = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskSelected} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine($"Ha ocurrido un error al eliminar la tarea");
    }
}

/// <summary>
/// Show the add task menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine() ?? string.Empty;
        TaskList.Add(newTask);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar registrar la nueva tarea");
    }
}

void ShowMenuTaskList()
{
    ShowTaskList();
}

/// <summary>
/// Mostrar lista de tareas registradas
/// </summary>
void ShowTaskList()
{
    if (TaskList?.Count > 0)
    {
        PrintSeparatorLine();

        var indexTask = 1;
        TaskList.ForEach(t => { Console.WriteLine($"{indexTask++}. {t}"); });

        PrintSeparatorLine();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

/// <summary>
/// Imprimir Linea separadora
/// </summary>
void PrintSeparatorLine()
{
    Console.WriteLine("----------------------------------------");
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
