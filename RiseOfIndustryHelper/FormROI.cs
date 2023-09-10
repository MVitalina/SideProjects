using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiseOfIndustryHelper
{
    public partial class FormROI : Form
    {
        public static Dictionary<string, Product> ProductsDictionary = new(); //parsed in ctor

        public FormROI()
        {
            InitializeComponent();

            List<Product> products = ParseJson();
            foreach (Product product in products)
            {
                ProductsDictionary[product.ProductName] = product;
            }

            string[] autocomplete = ProductsDictionary.Keys.ToArray();
            cbProducts.Items.AddRange(autocomplete);

            Enabled = true;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            List<Situation> situations = ParseInput();

            string resultStr = "";
            foreach (Situation s in situations)
            {
                string currentStr = $"{s.ProductName.ToUpper()}:\n";
                string rawStr = "";

                Dictionary<string, Result> resultDict = new();
                s.CalculateBruteForce(ref resultDict);

                foreach (var item in resultDict.Values)
                {
                    if (item.IsRaw)
                        rawStr += $"{item.BuildingCountToAdd} {item.ProductName}\n";
                    else
                        currentStr += $"{item.BuildingCountToAdd} {item.Building} ({item.ProductName})\n";
                }

                resultStr += currentStr + rawStr + "\n";
            }

            rtbOut.Text = resultStr;
        }

        private List<Product> ParseJson()
        {
            try
            {
                string json = File.ReadAllText("database.json");
                List<Product> result = JsonConvert.DeserializeObject<List<Product>>(json);
                return result ?? new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Product>();
            }
        }

        private List<Situation> ParseInput()
        {
            List<Situation> result = new();

            try
            {
                string input = rtbIn.Text;
                using TextReader stringReader = new StringReader(input);
                using TextFieldParser textFieldParser = new(stringReader);
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(",");
                while (!textFieldParser.EndOfData)
                {
                    string[] cols = textFieldParser.ReadFields();
                    if (cols.Length != 3)
                    {
                        return result;
                    }

                    result.Add(new Situation(
                        cols[0],
                        int.Parse(cols[1]),
                        int.Parse(cols[2])));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            rtbIn.AppendText(cbProducts.Text + ",");
            rtbIn.Focus();
        }

        private void cbProducts_Click(object sender, EventArgs e)
        {
            cbProducts.DroppedDown = true;
        }
    }
}