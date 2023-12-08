using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Final
{
    public class Inventory
    {
        // MEMBERS
        private List<Guitar> guitarsList = new List<Guitar>();      // creates list of guitar objects

        // PROPERTIES
        public List<Guitar> GuitarsList { get => guitarsList; set => guitarsList = value; }     // properties for list




        // METHODS
        // ADD TO INVENTORY
        public void addToInventory(Guitar guitar)
        {
            GuitarsList.Add(guitar);        // add guitar to the list
        }

        // REMOVE FROM INVENTORY
        public void removeGuitarFromInventory(int ID)
        {
            int count = 0;                                              // count used for index
            int index = 0;
            foreach (Guitar g in GuitarsList)
            {
                if (g.ID == ID)
                {
                    index = count;
                }
                count++;
            }
            GuitarsList.RemoveAt(index);                                // after match is found, removes at that index
            GuitarsList.RemoveAll(item => item == null);                // removes null objects from list
            Console.WriteLine("Guitar removed from inventory");         
        }

        // FIND GUITAR
        public Guitar findGuitarInventory(int ID)                       // finds guitar in inventory based on id match
        {
            foreach (Guitar g in GuitarsList)
            {
                if (g.ID == ID)
                {
                    return g;                                           // returns guitar
                }
            }
            return null;
        }

        // SORT FOR WHEN A GUITAR IS RETURNED
        // Sorts inventory by guitar.id using string campare
        public void sort()              
        {
            GuitarsList.Sort((guitar1, guitar2) => string.Compare(guitar1.ID.ToString(), guitar2.ID.ToString(), true));
        }
        

        // PLACE GUITAR ON SALE
        public void placeGuitarOnSale(int ID, double salePct)
        {
            
            foreach (Guitar g in GuitarsList)                                   // find guitar
            {
                if (g.ID == ID)
                {
                    double calculation = g.MSRP * ((100 - salePct) / 100);      // calculation for final price
                    g.OnSale = true;                                            // set on sale bool
                    g.SalePercentage = salePct;                                 // set sale percentage
                    g.FinalPrice = calculation;                                 // set final price
                }
            }
            Console.WriteLine("Guitar placed on sale");
        }


        // MODIFY MSRP
        public void overrideMSRP(int ID, double newMSRP)
        {
            foreach (Guitar g in GuitarsList)                                               // find guitar in inventory
            {
                if (g.ID == ID)
                {
                    g.MSRP = newMSRP;                                                       // set MSRP
                    g.FinalPrice = newMSRP;                                                 // set final price
                }
            }
        }



        // PRINT INVENTORY
        public string printInventory()                      // iterates and prints through inventory list
        {
            string result = "";
            foreach (Guitar item in GuitarsList)
            {
                result += item.guitarToString();
            }

            return result;
        }


        // FACILITATE CREATING A CURRENT INVENTORY
        public void createCurrentInventory(Inventory inventory)
        {
            // CREATING GUITARS AND ADDING THEM TO INVENTORY
            Guitar newGuitar0 = new Guitar(2699.99, "Fender", "Electric", "American Ultra Luxe", false, 0, 2699.99);
            inventory.addToInventory(newGuitar0);
            Guitar newGuitar1 = new Guitar(2999.99, "Fender", "Electric", "Brent Mason Telecaster", false, 0, 2999.99);
            inventory.addToInventory(newGuitar1);
            Guitar newGuitar2 = new Guitar(2199.99, "Fender", "Electric", "American Vintage II", false, 0, 2199.99);
            inventory.addToInventory(newGuitar2);
            Guitar newGuitar3 = new Guitar(2799.99, "Gibson", "Electric", "Les Paul Standard 50's", false, 0, 2799.99);
            inventory.addToInventory(newGuitar3);
            Guitar newGuitar4 = new Guitar(2799.99, "Gibson", "Electric", "Les Paul Standard 60's", false, 0, 2799.99);
            inventory.addToInventory(newGuitar4);
            Guitar newGuitar5 = new Guitar(1799.99, "Gibson", "Electric", "Les Paul Special", false, 0, 1799.99);
            inventory.addToInventory(newGuitar5);
        }
    }
}
