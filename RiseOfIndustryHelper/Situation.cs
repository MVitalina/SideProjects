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
            //TODO add check for ProductName
            Product = FormROI.ProductsDictionary[ProductName];
            Nested = nested;
         }

        public string ProductName { get; set; }
        public int NeededQuantity { get; set; }
        public int NeededWorkdays { get; set; }
        public Product Product { get; set; }
        public bool Nested { get; set; }

        public void CalculateBruteForce(ref Dictionary<string, Result> resultDict)
        {
            //string result = "";
            int factoriesNeeded = CalculateFactories(Product.Workdays, Product.OutputQuantity);

            //if (!Nested)
            //{
            //    result += $"{ProductName.ToUpper()}:\n";
            //}

            resultDict[ProductName] = new Result()
            {
                Building = Product.Building,
                BuildingCountToAdd = factoriesNeeded,
                ProductName = ProductName
            };

            CalculateInputProduct(ref resultDict, 
                Product.Input1Quantity * factoriesNeeded, 
                Product.Input1);
            
            CalculateInputProduct(ref resultDict,
                Product.Input2Quantity * factoriesNeeded,
                Product.Input2);
            
            CalculateInputProduct(ref resultDict,
                Product.Input3Quantity * factoriesNeeded,
                Product.Input3);
        }

        void CalculateInputProduct(ref Dictionary<string, Result> resultDict, int inputQuantityNeeded, string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                return;
            }

            //TODO add check for product contains in dict
            if (FormROI.ProductsDictionary[product].Level == "Raw Resource")
            {
                resultDict[product] = new Result()
                {
                    IsRaw = true,
                    BuildingCountToAdd = inputQuantityNeeded,
                    ProductName = product
                };
                return;
            }

            Situation inputSituation = new(product, inputQuantityNeeded, NeededWorkdays, true);
            inputSituation.CalculateBruteForce(ref resultDict);
        }

        private int CalculateFactories(int workdays, int quantity) 
        {
            return (int)Math.Floor((double)NeededQuantity * workdays / NeededWorkdays / quantity);
        }

    }
}
