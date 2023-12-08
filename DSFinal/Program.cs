/***************************************************************
* Name : FinalProject
* Author: Michael Shindelar
* Created : 12/08/2023
* Course: CIS 152 - Data Structures
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 2022
* Copyright : This is my own original work 
* based on specifications issued by our instructor
* Description : This program is a mock inventory management system
*                   for a small guitar shop
*            Input: Menu Selections and guitar information
*            Ouput: User requested inventory queries
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/


using Final;
using System;

namespace Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();          // instantiate inventory
            inventory.createCurrentInventory(inventory);    // calls method in inventory to work with in the program

            GuitarsSold soldGuitars = new GuitarsSold();    // Create/instantiate GuitarsSold object

            makeSelection();                                // calls switch menu


            ////////////////////////////////////////////////// SWITCH STMT ///////////////////////////////////////////////
            void makeSelection()
            {
                Console.WriteLine("Please make a selection: Press 0 to cancel \n\t1: Print Inventory" +
                                                            "\n\t2: Create and Add Guitar to Inventory" +
                                                            "\n\t3: Remove Guitar from Inventory" +
                                                            "\n\t4: Place Guitar on Sale" +
                                                            "\n\t5: Override MSRP" +
                                                            "\n\t6: Print Guitar Stack" +
                                                            "\n\t7: Sell Guitar" +
                                                            "\n\t8: Return Guitar" +
                                                            "\n\t9: INTENTIONALLY LEFT BLANK" +
                                                            "\n\t10: **Call Unit Testing");
                int userSelection = 99;

                // ALL TRY/CATCH OR TRY/PARSE USED FOR INPUT VALIDATION
                if (userSelection == 99)
                {
                    try
                    {
                        userSelection = Convert.ToInt32(Console.ReadLine());    // need to convert to int for userSelection
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number");             // in invalid input, try again
                        makeSelection();
                    }
                }

                switch (userSelection)
                {
                    case 0:     // CASE 0 USED TO CANCEL AND CLOSE PROGRAM
                        Console.WriteLine("Operation Canceled");
                        break;

                    case 1:     // PRINT INVENTORY
                        Console.WriteLine("Inventory: " + inventory.printInventory());
                        makeAnotherSelection();                                             // makeAnotherSelection use in all cases to continue instead of breaking
                        break;


                    case 2:     // CREATE GUITAR
                        Guitar newGuitar = new Guitar();        // creates a new guitar
                        newGuitar.createGuitar(newGuitar);      // passes the new guitar into the method
                        inventory.addToInventory(newGuitar);    // adds the new guitar into the inventory list
                        makeAnotherSelection();
                        break;


                    case 3:     // REMOVE EXISTING GUITAR FROM INVENTORY
                        Console.WriteLine("Please enter the ID for the guitar you wish to remove from inventory: ");    // need to locate the guitar in inventory
                        int tempID = 0;
                        while (!int.TryParse(Console.ReadLine(), out tempID))
                        {
                            Console.WriteLine("Please enter a number representing the guitar ID");
                            tempID = int.Parse(Console.ReadLine());
                        }
                        inventory.removeGuitarFromInventory(tempID);                                                    // method to remove the guitar with selected id
                        makeAnotherSelection();
                        break;


                    case 4:     // PLACE GUITAR ON SALE                     
                        Console.WriteLine("Please enter the ID for the guitar you wish to place on sale: ");        // locate guitar in inventory
                        string tmpID = Console.ReadLine();
                        while (!int.TryParse(tmpID, out var convertedTempID))
                        {
                            Console.WriteLine("Please enter a number representing the guitar ID");
                            tmpID = Console.ReadLine();
                        }
                        tempID = Convert.ToInt32(tmpID);

                        Console.WriteLine("Please enter the new sales percentage");                                 // input the sales percentage
                        string salePercentage = Console.ReadLine();
                        while (!int.TryParse(salePercentage, out int convertedSalePercentage))
                        {
                            Console.WriteLine("Please enter number for sales percentage");
                            salePercentage = Console.ReadLine();
                        }
                        double salePct = Convert.ToInt32(salePercentage);

                        inventory.placeGuitarOnSale(tempID, salePct);                                               // call method to place on sale with correct pct
                        makeAnotherSelection();
                        break;


                    case 5:     // MODIFY MSRP
                        Console.WriteLine("Please enter the ID for the guitar you wish override MSRP: ");   // locate guitar in inventory
                        tmpID = Console.ReadLine();
                        while (!int.TryParse(tmpID, out var convertedTempID))
                        {
                            Console.WriteLine("Please enter a number representing the guitar ID");
                            tmpID = Console.ReadLine();
                        }
                        tempID = Convert.ToInt32(tmpID);

                        Console.WriteLine("Please enter the new MSRP");                                     // user inputs new price
                        string nwMSRP = Console.ReadLine();
                        while (!double.TryParse(nwMSRP, out double convertedMSRP))
                        {
                            Console.WriteLine("Please enter a number");
                            nwMSRP = Console.ReadLine();
                        }
                        double newMSRP = Convert.ToDouble(nwMSRP);
                        inventory.overrideMSRP(tempID, newMSRP);                                            // calls method to change price of guitar

                        makeAnotherSelection();
                        break;


                    case 6:     // PRINT GUITAR STACK
                        Console.WriteLine("Printing Sold Guitars: ");                   // prints the stack of sold guitars
                        Console.WriteLine(soldGuitars.printGuitarsSoldStack());

                        makeAnotherSelection();
                        break;


                    case 7:     // SELL GUITAR (remove from inventory and add to guitar sold stack)
                        Console.WriteLine("Adding sold guitar");
                        Console.WriteLine("Please enter the ID for the guitar you are selling: ");      // locates guitar in inventory
                        tmpID = Console.ReadLine();
                        while (!int.TryParse(tmpID, out var convertedTempID))
                        {
                            Console.WriteLine("Please enter a number representing the guitar ID");
                            tmpID = Console.ReadLine();
                        }
                        tempID = Convert.ToInt32(tmpID);

                        Guitar tempGuitar = inventory.findGuitarInventory(tempID);
                        Guitar soldGuitar = soldGuitars.addToStack(tempID, inventory);                  // before deleting from inventory, copy into sold stack
                        inventory.removeGuitarFromInventory(tempID);                                    // remove from inventory
                        Console.WriteLine("Guitars sold: " + soldGuitars.printGuitarsSoldStack());      // prints guitar information for confirmation
                        makeAnotherSelection();
                        break;
                    case 8:     // RETURN LAST GUITAR SOLD FROM STACK
                        Console.WriteLine("Note: All sales are final. If sale made in error, may return the last guitar that was sold. \nPlease enter guitar ID");
                        tmpID = Console.ReadLine();
                        while (!int.TryParse(tmpID, out var convertedTempID))
                        {
                            Console.WriteLine("Please enter a number representing the guitar ID");
                            tmpID = Console.ReadLine();
                        }
                        tempID = Convert.ToInt32(tmpID);


                        Guitar tempGuitar1 = soldGuitars.findGuitarStack(tempID);                       // create temp guitar and find guitar in stack
                        inventory.addToInventory(tempGuitar1);                                          // add guitar to inventory
                        inventory.sort();                                                               // sort the inventory list with guitar added with smaller ID
                        string result = soldGuitars.removeFromStack();                                  // remove guitar from the sold stack
                        Console.WriteLine(result);
                        makeAnotherSelection();
                        break;

                    case 9:
                        makeAnotherSelection();                                                         // 9 is left blank b/c I wanted ten to be the unit test
                        break;
                    // THIS UNIT TESTING DESCRIBES THE ACTION TAKING PLACE ON THE CONSOLE
                    // YOU CAN RUN CASE 10 AND READ THROUGH WITH ALL THE METHODS CALLED WITH VALID INPUT
                    // INVALID USER INPUT IS ALL HANDLED WITHIN THE CASE STATEMENTS / METHODS
                    case 10:
                        // create guitar
                        Console.WriteLine("RUNNING METHOD TESTS FOR CORRECT INPUT");
                        Console.WriteLine("CREATING NEW GUITAR");
                        Guitar newGuitar99 = new Guitar(839.99, "PRS", "Electric", "Paul's Guitar", false, 0, 839.99);
                        Console.WriteLine("NEW GUITAR CREATED: " + newGuitar99.guitarToString());

                        // addToInventory
                        Console.WriteLine("\nADDING GUITAR TO INVENTORY");
                        inventory.addToInventory(newGuitar99);
                        Console.WriteLine("GUITAR ADDED TO INVENTORY");

                        // overrideMSRP
                        Console.WriteLine("\nOVERWRITING MSRP");
                        inventory.overrideMSRP(newGuitar99.ID, 999.99);
                        Console.WriteLine("NEW MSRP: " + newGuitar99.guitarToString());

                        // placeGuitarOnSale
                        Console.WriteLine("\nPLACING GUITAR ON SALE");
                        inventory.placeGuitarOnSale(newGuitar99.ID, 30);

                        // printInventory
                        Console.WriteLine("\nPRINTING INVENTORY");
                        Console.WriteLine(inventory.printInventory());
                        Console.WriteLine("\nFINISHED PRINTING INVENTORY");

                        ///////SELLING GUITAR
                        Console.WriteLine("\nSELLING GUITAR");

                        // findGuitarInventory
                        Console.WriteLine("\nFINDING GUITAR IN INVENTORY");
                        inventory.findGuitarInventory(newGuitar99.ID);
                        Console.WriteLine("\nGUITAR FOUND");

                        // addToStack
                        Console.WriteLine("\nADDING GUITAR TO THE SOLD STACK");
                        soldGuitars.addToStack(newGuitar99.ID, inventory);
                        Console.WriteLine("\nPRINTING THE SOLD GUITAR STACK");
                        Console.WriteLine("Guitars sold: " + soldGuitars.printGuitarsSoldStack());

                        // removeGuitarFromInventory
                        Console.WriteLine("REMOVING GUITAR FROM INVENTORY");
                        inventory.removeGuitarFromInventory(newGuitar99.ID);
                        Console.WriteLine("GUITAR REMOVED FROM INVENTORY");

                        // printInventory
                        Console.WriteLine("PRINTING INVENTORY");
                        Console.WriteLine(inventory.printInventory());
                        Console.WriteLine("FINISHED PRINTING INVENTORY");

                        ///////RETURNING THE GUITAR 
                        // findGuitarStack
                        Console.WriteLine("\nTESTING RETURNING THE GUITAR LAST SOLD");
                        Console.WriteLine("FINDING SOLD GUITAR");
                        Guitar testGuitar = soldGuitars.findGuitarStack(newGuitar99.ID);
                        Console.WriteLine("GUITAR FOUND: " + testGuitar.guitarToString());
                        Console.WriteLine("END FIND GUITAR");

                        // addToInventory
                        Console.WriteLine("\nADDING GUITAR BACK TO INVENTORY");
                        inventory.addToInventory(testGuitar);
                        Console.WriteLine("FINISHED ADDING TO INVENTORY. \nPRINTING INVENTORY NOW");
                        Console.WriteLine(inventory.printInventory());
                        Console.WriteLine("FINISHED ADDING GUITAR BACK INTO INVENTORY");


                        // testing sort
                        // SELL GUITAR (remove from inventory and add to guitar sold stack)
                        Console.WriteLine("SELLING GUITAR 3 TO DEMONSTRATE SORT");
                        Guitar sldGuitar = soldGuitars.addToStack(3, inventory);
                        inventory.removeGuitarFromInventory(3);

                        // RETURN LAST GUITAR SOLD FROM STACK       
                        Guitar tmpGuitar1 = soldGuitars.findGuitarStack(3);                             // CREATE TEMP GUITAR
                        Console.WriteLine(" TEST " + tmpGuitar1.guitarToString());
                        inventory.addToInventory(tmpGuitar1);                                           // ADD TO INVENTORY
                        inventory.sort();                                                               // NEED TO CALL SORT ON INVENTORY HERE
                        result = soldGuitars.removeFromStack();
                        Console.WriteLine("PRINTING FINAL INVENTORY");
                        Console.WriteLine(inventory.printInventory());
                        Console.WriteLine("INVENTORY SORTED");
                        break;
                }
            }
            ////////////////// METHODS ////////////////////
            // makeAnotherSelection() is used after each menu item to allow user to either close program or continue
            void makeAnotherSelection()
            {
                string choice = "yes";                                                      // yes default to call makeSelection() switch menu
                Console.WriteLine("Make another selection?");
                choice = Console.ReadLine().ToLower();                                      // to lower to handle uppercase letters
                if (choice == "yes" || choice == "y")
                {
                    makeSelection();
                }
                if (choice == "no" || choice == "n")                                        // no to close
                {
                    Console.WriteLine("Thank you");
                }
                if (choice != "yes" && choice != "y" && choice != "no" && choice != "n")    // if user inputs anything else, ask them again
                {
                    Console.WriteLine("Please type \"yes\" or \"no\"");
                    makeAnotherSelection();
                }

            }

        }
    }
}

