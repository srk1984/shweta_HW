//Assignment #6

//Copy this block into your Visual Studio.

// Review and Redo this code line by line at home.  

// Place comments on each line and describe what the code is doing

using System;

namespace ConsoleApplication1
{


    //Structure definintion with two fields
    public struct Pet  
    {
        public string Name; 
        public string TypeOfPet;
    }

    class Program
    {
        static void Main()
        {
            var numberOfPets = 0;   //To keep track of number of pets
            var pets = new Pet[10];  //To store the pet info an array of structure Pet is declared
            int exit = 0; //Added to exit out of the while loop
            while (true)
            {

                if (exit == 1)
                {
                    break;
                }
                
                
                Console.Write("A)dd D)elete L)ist E)xit pets:"); //Displays the options  Add ,Delete and List
                var choice = Console.ReadLine();             //Read the user option and is stored in variable choice


                //Case in the switch statement executes based on the choice

                switch (choice)
                {

                    //Add the pet info
                    case "A":
                    case "a":
                        {
                            Console.Write("Name :");
                            var name = Console.ReadLine();  //Read the name

                            Console.Write("Type of pet :");
                            var typeOfPet = Console.ReadLine(); //Read the Type of pet

                            // Always add the pet at the end of the array
                            //Store the read data in the array declared starting at index 0 and increment it..
                            //Store the name read in the Name feild of the Pet Structure array
                            //Store the typeOfPet in the typeOfPet field of the pet Structure array

                            pets[numberOfPets].Name = name;        
                            pets[numberOfPets].TypeOfPet = typeOfPet;

                            numberOfPets++; //increment index 
                            break;
                        }

                    case "D":
                    case "d":
                        {

                            //Checks if pets are available before deletion
                            if (numberOfPets == 0)
                            {
                                Console.WriteLine("No pets");
                                break;
                            }

                            //Displays the pets info.Starting at index 0 of the array uptill it reaches end (numberofpets-1)
                            for (var index = 0; index < numberOfPets; index++)
                            {
                                Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                            }

                            //Asks for the pet number to be deleted
                            Console.Write("Which pet to remove (1-{0})", numberOfPets);

                            var petNumberToDelete = Console.ReadLine();
                            var indexToDelete = int.Parse(petNumberToDelete);

                            // Squish the array from index to the end
                            //After deletion shifts the remaining pet info backwards one position till it reacjes the end of the array

                            for (var index = indexToDelete - 1; index < numberOfPets; index++)
                            {
                                // Just copy the pet from the next index into the current index
                                pets[index] = pets[index + 1];
                            }

                            // We have one less pet
                            numberOfPets--;

                            break;
                        }

                    case "L":
                    case "l":
                        {
                            if (numberOfPets == 0) //No pets to display
                            {
                                Console.WriteLine("No pets");
                            }

                            //Displays the pets info starting from index =0 to the end of array
                            for (int index = 0; index < numberOfPets; index++)
                            {
                                Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                            }

                            break;

                        }
                      case "E":
                      case "e":
                        {
                            exit = 1;
                            break;
                        }
                        
                    default:
                        {
                            Console.WriteLine("Invalid option [{0}]", choice);
                            break;
                        }
                }
            }
        }
    }
}
