

// File: FileIOProject.cs
using System;
using System.Collections;

// TODO: Add new namespaces
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Menu
{
    private string[] menuItems;
    private readonly int maxItems;
    private int currentOption;

    public Menu()
    {
        menuItems = new string[]
        {
 "Add an item",
 "Change an item",
 "Delete an item",
 "List all items",
 "Quit"
        };

        maxItems = menuItems.Length;
    }

    public bool GetOption()
    {
        DisplayMenu();
        string str = Console.ReadLine();

        currentOption = 0;
        try
        {
            currentOption = int.Parse(str);

            // The last item (maxItems) is the Quit option.
            return currentOption == maxItems;
        }
        catch
        {
            // Just eat any exception
        }

        return false;
    }

    public void DisplayMenu()
    {
        int itemNumber = 1;

        Console.WriteLine("\n\n\n\n\n\n\n\n\n");

        foreach (string str in menuItems)
        {
            Console.WriteLine("{0}. {1}",
            itemNumber, str);

            itemNumber++;
        }
    }

    public int CurrentOption
    {
        get
        {
            return currentOption;
        }
    }

}

// TODO: Make the structure serializable
[Serializable]
struct InvItem
{
    public int ItemNumber;
    public string Description;
    public double Price;
    public int Quantity;

    public override bool Equals(object o)
    {
        InvItem item = (InvItem)o;

        return ItemNumber == item.ItemNumber;
    }
}

class Inventory
{
    ArrayList items = new ArrayList();

    public Inventory()
    {
    }

    private string FileName = "inventory.dat";

    // TODO: Create a formatter object
    private BinaryFormatter formatter = new BinaryFormatter();

    public void LoadFile()
    {
        // TODO: Check if the file exists and load the file
        if (File.Exists(FileName))
        {
            FileStream stream = File.Open(FileName, FileMode.Open);
            items = (ArrayList)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    public void SaveFile()
    {
        // TODO: Save the file
        FileStream stream = File.Create(FileName);
        formatter.Serialize(stream, items);
        stream.Close();
    }

    public void Add()
    {
        InvItem item;
        string str;

        Console.Write("Enter item #:");
        str = Console.ReadLine();
        item.ItemNumber = int.Parse(str);

        Console.Write("Enter description:");
        item.Description = Console.ReadLine();

        Console.Write("Enter price:");
        str = Console.ReadLine();
        item.Price = double.Parse(str);

        Console.Write("Enter quantity:");
        str = Console.ReadLine();
        item.Quantity = int.Parse(str);

        bool found = items.Contains(item);

        if (found)
        {
            Console.WriteLine("item already exists");
            return;
        }

        items.Add(item);
    }

    public void Change()
    {
        InvItem item;
        string str;

        Console.Write("Enter item #:");
        str = Console.ReadLine();
        item.ItemNumber = int.Parse(str);
        item.Description = "";
        item.Price = 0;
        item.Quantity = 0;

        int index = items.IndexOf(item);

        if (index < 0)
        {
            Console.WriteLine("item not found");
            return;
        }

        item = (InvItem)items[index];

        Console.WriteLine("Old description :" + item.Description);
        Console.Write("Enter description:");
        item.Description = Console.ReadLine();

        Console.WriteLine("Old price :" + item.Price);
        Console.Write("Enter price:");
        str = Console.ReadLine();
        item.Price = double.Parse(str);

        Console.WriteLine("Old quantity :" + item.Quantity);
        Console.Write("Enter quantity:");
        str = Console.ReadLine();
        item.Quantity = int.Parse(str);

        items[index] = item;
    }

    public void Delete()
    {
        InvItem item;
        string str;

        Console.Write("Enter item #:");
        str = Console.ReadLine();
        item.ItemNumber = int.Parse(str);
        item.Description = "";
        item.Price = 0;
        item.Quantity = 0;

        int index = items.IndexOf(item);

        if (index >= 0)
        {
            items.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("item not found");
        }
    }

    public void ListAll()
    {
        foreach (InvItem item in items)
        {
            Console.WriteLine(
            "{0,4} {1} {2:c} {3,3}",
            item.ItemNumber,
            item.Description,
            item.Price,
            item.Quantity);
        }
    }
}

class ProjectMain
{
    static void Main()
    {
        Inventory inventory = new Inventory();
        Menu mainMenu = new Menu();

        // Load the c:\inventory.dat file.
        inventory.LoadFile();

        while (mainMenu.GetOption() != true)
        {
            switch (mainMenu.CurrentOption)
            {
                case 1: // Add
                    {
                        inventory.Add();
                        break;
                    }
                case 2: // Change
                    {
                        inventory.Change();
                        break;
                    }
                case 3: // Delete
                    {
                        inventory.Delete();
                        break;
                    }
                case 4: // List all
                    {
                        inventory.ListAll();
                        break;
                    }
                case 5: // Quit
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option");
                        break;
                    }
            } // switch
        } // while

        inventory.SaveFile();

    } // Main()
} // class ProjectMain
