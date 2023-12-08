using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Guitar
    {
        // Guitar Members
        private int _iD = 0;
        public static int _nextID = 0;              // needed static int to automatically increment when new guitar created
        private double _msrp = 0.00;
        private string _brand = "n/a";
        private string _model = "n/a";
        private string _type = "n/a";
        private bool _onSale = false;
        private double _salePercentage = 0.00;
        private double _finalPrice = 0;


        // Guitar Attributes
        public Guitar()
        {
            ID = NextID;
            MSRP = _msrp;
            Brand = _brand;
            Model = _model;
            Type = _type;
            OnSale = _onSale;
            SalePercentage = _salePercentage;
            FinalPrice = _finalPrice;
            NextID++;                               // increment when new object instantiated
        }
        public Guitar(double msrp, string brand, string type, string model, bool onSale, double salePercentage, double finalPrice)
        {
            ID = NextID;
            MSRP = msrp;
            Brand = brand;
            Model = model;
            Type = type;
            OnSale = onSale;
            SalePercentage = salePercentage;
            FinalPrice = finalPrice;
            NextID++;                               // increment when new object instantiated
        }

        // Guitar Properties
        public static int NextID { get; set; }
        public int ID { get => _iD; set => _iD = value; }
        public double MSRP { get => _msrp; set => _msrp = value; }
        public string Brand { get => _brand; set => _brand = value; }
        public string Model { get => _model; set => _model = value; }
        public string Type { get => _type; set => _type = value; }
        public bool OnSale { get => _onSale; set => _onSale = value; }
        public double SalePercentage { get => _salePercentage; set => _salePercentage = value; }
        public double FinalPrice { get => _finalPrice; set => _finalPrice = value; }


        // Methods
        // Create Guitar with user input to be placed in inventory
        public Guitar createGuitar(Guitar newGuitar)
        {
            Console.WriteLine("Adding new guitar: ");

            // ID increment if not 0
            newGuitar.ID = NextID;

            // Price
            Console.WriteLine("\tPlease input price: ");
            string strPrice = Console.ReadLine();
            while (!int.TryParse(strPrice, out var convertedPrice))                 // need to identify int from string
            {
                Console.WriteLine("Please enter a number for price");
                strPrice = Console.ReadLine();
            }
            newGuitar.MSRP = Convert.ToDouble(strPrice);                            // need to convert to double for msrp

            // Brand
            Console.WriteLine("\tPlease input brand: ");                            // takes any string
            newGuitar.Brand = Console.ReadLine();

            // Model
            Console.WriteLine("\tPlease input model");                              // takes any string
            newGuitar.Model = Console.ReadLine();

            // Type
            Console.WriteLine("\tPlease enter type (i.e. acoustic or electric): "); // takes any string
            newGuitar.Type = Console.ReadLine();

            // OnSale
            Console.WriteLine("\tIs Guitar on sale? (true/false)");                 // can place on sale when creating 
            string onSale = Console.ReadLine();
            while(!bool.TryParse(onSale, out var sale))                             // try parse for invalid input
            {
                Console.WriteLine("Please enter true or false");
                onSale = Console.ReadLine();
            }
            newGuitar.OnSale = Convert.ToBoolean(onSale);                           // converts to bool from input string

            // Final Price
            if (newGuitar.OnSale == true)                                           // if on sale, performs math for final price
            {
                Console.WriteLine("\tPlease enter sale percentage: ");
                string salePercentage = Console.ReadLine();
                while (!double.TryParse(salePercentage, out var percentage))
                {
                    Console.WriteLine("Please enter sale percentage");
                    salePercentage = Console.ReadLine();
                }
                newGuitar.SalePercentage = Convert.ToDouble(salePercentage);
                newGuitar.FinalPrice = newGuitar.MSRP * (1 - (newGuitar.SalePercentage / 100));
            }
            else                                                                    // if not on sale, set final price to msrp
            {
                newGuitar.FinalPrice = newGuitar.MSRP;
            }
            Console.WriteLine("New guitar created." + "\n");

            return newGuitar;
        }

        // GUITAR TO STRING
        public string guitarToString()
        {
            string result;
            result = "\nGuitar " + ID + ": "
                + "\n\tID: " + ID
                + "\n\tMSRP: " + MSRP
                + "\n\tBrand: " + Brand
                + "\n\tType: " + Type
                + "\n\tModel: " + Model
                + "\n\tOn Sale: " + OnSale
                + "\n\tSale Pct: " + SalePercentage + "%"
                + "\n\tFinal Price: $" + FinalPrice;
            return result;
        }

    }
}
