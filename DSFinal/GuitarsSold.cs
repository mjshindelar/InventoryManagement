using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class GuitarsSold
    {
        // Create the quitar stack that will make up the stack of guitars
        Stack<Guitar> guitarsSoldStack = new Stack<Guitar>();


        // FIND GUITAR
        public Guitar findGuitarStack(int ID)
        {
            foreach (Guitar g in guitarsSoldStack)      // iterate through the stack
            {
                if (g.ID == ID)                         // find match of ID
                {
                    return g;                           // return matched guitar obj
                }
            }
            return null;
        }


        // ADD TO STACK
        public Guitar addToStack(int id, Inventory inventory)
        {
            Guitar foundGuitar = inventory.findGuitarInventory(id);     // find guitar with id in stack
            guitarsSoldStack.Push(foundGuitar);                         // push onto stack

            return foundGuitar;                                         // return the guitar for confirmation
        }


        // REMOVE FROM STACK
        public string removeFromStack()
        {
            guitarsSoldStack.Pop();                                     // removes the last added guitar for guitar return
            return "Guitar returned";
        }



        // String to Print Stack
        public string printGuitarsSoldStack()
        {
            if(guitarsSoldStack.Count == 0)                             // if empty, acknowledge with statement
            {
                return "You haven't sold any Guitars";
            }
            string result = "";
            foreach (Guitar item in guitarsSoldStack)                   // print guitars in stack
            {
                result += item.guitarToString();
            }

            return result;
        }


    }
}
