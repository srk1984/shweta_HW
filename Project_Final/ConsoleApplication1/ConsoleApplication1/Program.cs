/*Each item must have the following information associated with it (Hint: A array of structs might work well here.):
•Item # is a string with 6 characters
•Description is a string with 20 characters
•Price peritem is a double value 
•Value of item (price * quantity on hand) is double
•Quantity on hand is an integer
•Our cost per item is double
Inventory is of size 100

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{

    public struct Inventory
    {
        public string item_id;
        public string des_item;
        public double selling_price;
        public int quantity;
        public double cost_price;
        public double value;

    }




    class Program
    {


        //This method displays the Inventory items

        static bool display(Inventory[] inventory, int no_of_items)
        {

            int i = 0;
            if (no_of_items == 0)
            {
                Console.WriteLine("\n\nSORRY!! NO ITEMS FOUND IN THE INVENTORY\n\n");
                return false;
            }
            Console.WriteLine("\n\t\t\t ITEMS IN INVENTORY \n\n");
            Console.WriteLine(" ITEM# ITEM ID  DESCRIPTION            PRICE     QTY   COST PR   VALUE");
            Console.WriteLine(" ----- -------  -------------------    ------   -----  -------   ------\n");

            for (i = 0; i < no_of_items; i++)
            {
                Console.WriteLine("{0,5}. {1,6}   {2, -20}  {3,6}  {4,5}  {5,8}    {6,5}\n", i + 1, inventory[i].item_id, inventory[i].des_item, inventory[i].selling_price, inventory[i].quantity, inventory[i].cost_price, inventory[i].value);

            }
            return true;
        }


        //Checks for Duplicate Item ID

        static bool chk_dup_item_id(Inventory[] inventory, string item_id, int no_of_items)
        {
            for (int i = 0; i < no_of_items; i++)
            {
                if (inventory[i].item_id.Equals(item_id))
                {
                    return true;
                }
            }
            return false;
        }


        //This Method reads input  for the inventory
        static bool read_input(Inventory[] inventory, int no_of_items, char option)
        {

            string input;

            if (option == 'A')
            {
                Console.Write("\n\nEnter the item ID of the product (string 1 - 6 characters) :  ");
                input = read_string("Item ID", 6);
                //Check if the Item already exists and return if item exists already in the inventory
                if (chk_dup_item_id(inventory, input, no_of_items))
                {
                    Console.WriteLine("\n\nSORRY!!!!ITEM ID ALREADY EXISTS");
                    return false;
                }

                inventory[no_of_items].item_id = input;
            }

            //Read the description 
            Console.Write("\nEnter the description of the item (string 1 - 20 Characters ) : ");
            input = read_string("Item ID", 20);
            inventory[no_of_items].des_item = input;

            //Read the Seling price
            Console.Write("\nEnter the selling price of the item : ");
            double dblval = read_double("selling price");
            inventory[no_of_items].selling_price = dblval;

            //Read the Quantity
            Console.Write("\nEnter the Quantity of item :");
            int intval = read_int("Quantity of item");
            inventory[no_of_items].quantity = intval;

            //Read the Cost Price
            Console.Write("\nEnter the cost price of the item :");
            dblval = read_double("cost price");
            inventory[no_of_items].cost_price = dblval;

            //Compute the value
            inventory[no_of_items].value = inventory[no_of_items].quantity * inventory[no_of_items].selling_price;
            return true;
        }


        //Validate the read value is integer..Read until valid integer is entered by the user

        static int read_int(string field_name)
        {

            int intval;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out intval))
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Please enter the valid {0} :", field_name);
                input = Console.ReadLine();
            }

            return intval;

        }


        //Read the double and Validate whether a double value is entered

        static double read_double(string field_name)
        {

            double dblval;
            string input = Console.ReadLine();
            while (!Double.TryParse(input, out dblval))
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Please enter the valid {0} :", field_name);
                input = Console.ReadLine();
            }

            return dblval;

        }

        //Read the string and validate the length based on the field
        static string read_string(string field_name, int len)
        {
            string str;
            str = Console.ReadLine();
            while (!(str.Length <= len))
            {
                Console.WriteLine("INVALID INPUT : {0} should be of length {1}", field_name, len);
                Console.Write("Please enter the valid {0} : ", field_name);
                str = Console.ReadLine();
            }

            return str;

        }


        //Chk if Item id is present 

        static int chk_Item_ID(Inventory[] inventory, string item_id, int no_of_items)
        {

            int i = 0;

            while (!(inventory[i].item_id.Equals(item_id)))
            {
                i++;
                if (i == no_of_items)
                {
                    break;
                }

            }

            return i;
        }

        //Shift the items of the array after deletion

        static void copy(ref Inventory Inven_1, ref Inventory Inven_2)
        {
            Inven_1.item_id = Inven_2.item_id;
            Inven_1.des_item = Inven_2.des_item;
            Inven_1.selling_price = Inven_2.selling_price;
            Inven_1.quantity = Inven_2.quantity;
            Inven_1.selling_price = Inven_2.selling_price;
        }





        static void Main(string[] args)

        {
            Inventory[] inventory = new Inventory[100];
            int no_of_items = 0;
            while (true)
            {


                Console.WriteLine("\n\n\t\t\tPRODUCT INVENTORY");
                Console.WriteLine("\t\t\t_________________\n");
                Console.WriteLine("\t\t A. Add an item in the inventory\n");
                Console.WriteLine("\t\t C. Change an item in the inventory\n");
                Console.WriteLine("\t\t D .Delete an item from the inventory\n");
                Console.WriteLine("\t\t L. List all the items in the inventory\n");
                Console.WriteLine("\t\t Q. Quit\n\n");
                Console.Write("Enter your choice :");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "A":
                    case "a":
                        {
                            //Add item
                            if (no_of_items == 100)
                            {
                                Console.WriteLine("\n\nSORRY!!!! INVENTORY IS FULL\n\n");
                                break;
                            }

                            if (read_input(inventory, no_of_items, 'A'))
                            {
                                no_of_items++;
                            }
                            break;
                        }

                    case "C":
                    case "c":
                        {
                            //change item
                            if (!(display(inventory, no_of_items)))
                            {
                                break;
                            }

                            Console.Write("\n\nEnter the Item Id of the Item to be changed : ");

                            string item_id = read_string("ITEM_ID", 6);

                            int i = 0;

                            i = chk_Item_ID(inventory, item_id, no_of_items);

                            if (i < no_of_items)
                            {
                                Console.WriteLine("\n\nEnter the Item details of the item to be changed \n");
                                read_input(inventory, i, 'C');
                            }
                            else
                            {
                                Console.WriteLine("\n\n SORRY !!ITEM  NOT FOUND \n");
                            }

                            break;

                        }


                    case "D":
                    case "d":
                        {
                            //delete an item
                            //change item
                            if (!(display(inventory, no_of_items)))
                            {
                                break;
                            }
                            Console.Write("Enter the Item Id of the Item to be deleted : ");
                            string item_id = read_string("ITEM_ID", 6);
                            int i = 0;
                            i = chk_Item_ID(inventory, item_id, no_of_items);
                            if (i == no_of_items)
                            {
                                Console.WriteLine("\n\n SORRY !!ITEM  NOT FOUND \n");
                                break;
                            }

                            for (int j = i; j < no_of_items; j++)
                            {
                                copy(ref inventory[i], ref inventory[j]);
                            }

                            no_of_items--;

                            Console.WriteLine("\n\nDELETION SUCCESSFUL!!\n");

                            break;

                        }

                    case "L":
                    case "l":
                        {
                            //List items
                            display(inventory, no_of_items);
                            break;

                        }


                    case "Q":
                    case "q":
                        {

                            break;
                        }


                    default:
                        {
                            Console.WriteLine("Invalid Choice\n");
                            break;
                        }


                }

            }

        }



    }



}