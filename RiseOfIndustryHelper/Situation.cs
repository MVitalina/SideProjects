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

        private enum Efficiency
        {
            Percent25,
            Percent50,
            Percent75,
            Percent100,
            Percent125,
            Percent175,
            Percent200,
            Count
        }

        private Dictionary<Efficiency, double> ProductionTimePercents = new()
        {
            { Efficiency.Percent25, 3 },
            { Efficiency.Percent50, 1 },
            { Efficiency.Percent75, 0.333 },
            { Efficiency.Percent100, 1 },
            { Efficiency.Percent125, 0.8 },
            { Efficiency.Percent175, 0.667 },
            { Efficiency.Percent200, 0.5 }
        };

        public string ProductName { get; set; }
        public int NeededQuantity { get; set; }
        public int NeededWorkdays { get; set; }
        public Product Product { get; set; }
        public bool Nested { get; set; }

        public void Calculate(ref Dictionary<string, Result> resultDict, CalculationType calculationType)
        {
            Tuple<Efficiency, int> factoriesNeededWithEfficiency = CalculateFactories(Product.Workdays, Product.OutputQuantity, calculationType);
            string efficiency = factoriesNeededWithEfficiency.Item1.ToString().Replace("Percent", "") + "%";
            int factoriesNeeded = factoriesNeededWithEfficiency.Item2;

            resultDict[ProductName] = new Result()
            {
                Building = Product.Building,
                BuildingCountToAdd = factoriesNeeded,
                ProductName = ProductName,
                Efficiency = efficiency
            };

            CalculateInputProduct(ref resultDict, 
                Product.Input1Quantity * factoriesNeeded, 
                Product.Input1, calculationType);
            
            CalculateInputProduct(ref resultDict,
                Product.Input2Quantity * factoriesNeeded,
                Product.Input2, calculationType);
            
            CalculateInputProduct(ref resultDict,
                Product.Input3Quantity * factoriesNeeded,
                Product.Input3, calculationType);
        }

        void CalculateInputProduct(ref Dictionary<string, Result> resultDict, int inputQuantityNeeded, string product, CalculationType calculationType)
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
            inputSituation.Calculate(ref resultDict, calculationType);
        }

        private Tuple<Efficiency, int> CalculateFactories(int workdays, int quantity, CalculationType calculationType)
        {
            int factoriesBest = -1;
            Efficiency efficiencyBest = Efficiency.Count;

            if (calculationType == CalculationType.BruteForce)
            {
                factoriesBest = CalculateFactoriesFormula(workdays, quantity);
                efficiencyBest = Efficiency.Percent100;
            }

            else if (calculationType == CalculationType.IncludeEfficiency)
            {
                for (int i = (int)Efficiency.Count - 1; i >= 0; i--)
                {
                    Efficiency efficiency = (Efficiency)i;
                    double currentWorkdays = workdays * ProductionTimePercents[efficiency];
                    int currentFactoriesNeeded = CalculateFactoriesFormula(currentWorkdays, quantity);

                    if (factoriesBest == -1 || efficiencyBest == Efficiency.Count)
                    {
                        factoriesBest = currentFactoriesNeeded;
                        efficiencyBest = efficiency;
                        continue;
                    }

                    if (currentFactoriesNeeded == factoriesBest)
                    {
                        efficiencyBest = efficiency;
                    }
                    else // bigger
                    {
                        break;
                    }
                }
            }

            return Tuple.Create(efficiencyBest, factoriesBest);
        }

        private int CalculateFactoriesFormula(double workdays, int quantity) 
        {
            double result = NeededQuantity * workdays;
            result /= NeededWorkdays;
            result /= quantity;
            result = Math.Ceiling(result);
            return (int)result;
            //return (int)Math.Floor(NeededQuantity * workdays / NeededWorkdays / quantity);
        }

    }
}
