using Newtonsoft.Json;

namespace RiseOfIndustryHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Product> products = ParseJson();
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
    }
}