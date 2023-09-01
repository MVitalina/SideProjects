namespace MemriseHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string[] inList = rtbIn.Text.Split('\n');
            string result = "";
            Dictionary<string, string> dict = new();

            for (int i = 0; i < inList.Length; i += 3)
            {
                if (!dict.ContainsKey(inList[i + 1]))
                {
                    dict[inList[i + 1]] = inList[i + 2];
                }
            }

            foreach(var pair in dict)
            {
                result += pair.Key + "," + pair.Value + "\n";
            }

            rtbOut.Text = result;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbOut.Text);
        }
    }
}