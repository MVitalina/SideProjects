using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfIndustryHelper
{
    public class Situation
    {
        public Situation(string product, int quantity, int workdays, bool nested = false)
        {
            ProductName = product;
            NeededQuantity = quantity;
            NeededWorkdays = workdays;
            Product = FormROI.ProductsDictionary[ProductName];
            Nested = nested;
         }

        public string ProductName { get; set; }
        public int NeededQuantity { get; set; }
        public int NeededWorkdays { get; set; }
        public Product Product { get; set; }
        public bool Nested { get; set; }

        public string CalculateBruteForce()
        {
            string result = "";
            //TODO autocomplete
            //TODO check if ProductName from input contains in dict
            int factoriesNeeded = CalculateFactories(Product.Workdays, Product.OutputQuantity);

            if (!Nested)
            {
                result += $"{ProductName.ToUpper()}:\n";
            }

            result += $"{factoriesNeeded} {Product.Building} ({ProductName})\n";
            string rawResult = "";
            //TODO list/dictionary as return

            CalculateInputProduct(ref result, ref rawResult, 
                Product.Input1Quantity * factoriesNeeded, 
                Product.Input1);

            CalculateInputProduct(ref result, ref rawResult,
                Product.Input2Quantity * factoriesNeeded,
                Product.Input2);

            CalculateInputProduct(ref result, ref rawResult,
                Product.Input3Quantity * factoriesNeeded,
                Product.Input3);

            return result + rawResult;
        }

        void CalculateInputProduct(ref string result, ref string rawResult, int inputQuantityNeeded, string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                return;
            }

            if (FormROI.ProductsDictionary[product].Level == "Raw Resource")
            {
                rawResult += $"{inputQuantityNeeded} {product}\n";
                return;
            }

            Situation input1Situation = new(product, inputQuantityNeeded, NeededWorkdays, true);
            result += input1Situation.CalculateBruteForce();
        }

        private int CalculateFactories(int workdays, int quantity) 
        {
            return (int)Math.Floor((double)NeededQuantity * workdays / NeededWorkdays / quantity);
        }

    }
}
