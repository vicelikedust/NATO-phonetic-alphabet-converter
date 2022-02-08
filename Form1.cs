using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATO
{
    public partial class Form1 : Form
    {
        IDictionary<string, string> AlphabetList = new Dictionary<string, string>() {
            {"a","alfa"},{"b","bravo"},{"c","charlie"},{"d","delta"},{"e","echo"},{"f","foxtrot"},{"g","golf"},{"h","hotel"},{"i","india"},
            {"j","juliett"},{"k","kilo"},{"l","lima"},{"m","mike"},{"n","november"},{"o","oscar"},{"p","papa"},{"q","quebec"},{"r","romeo"},
            {"s","sierra"},{"t","tango"},{"u","uniform"},{"v","victor"},{"w","whiskey"},{"x","x-ray"},{"y","yankee"},{"z","zulu"},
            {"A","Alfa"},{"B","Bravo"},{"C","Charlie"},{"D","Delta"},{"E","Echo"},{"F","Foxtrot"},{"G","Golf"},{"H","Hotel"},{"I","India"},
            {"J","Juliett"},{"K","Kilo"},{"L","Lima"},{"M","Mike"},{"N","November"},{"O","Oscar"},{"P","Papa"},{"Q","Quebec"},{"R","Romeo"},
            {"S","Sierra"},{"T","Tango"},{"U","Uniform"},{"V","Victor"},{"W","Whiskey"},{"X","X-ray"},{"Y","Yankee"},{"Z","Zulu"},
            {" "," "}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            await Task.Run(() => UpdateUI());
        }
        private async void UpdateUI()
        {
            textBox2.Invoke(new MethodInvoker(async delegate {
                textBox2.Text = await Task.Run(() => ConvertText());
            }));
        }
        private string ConvertText()
        {
            string newString = "";
            foreach (char c in textBox1.Text)
            {
                if (AlphabetList.ContainsKey(c.ToString()))
                {
                    newString += $"{AlphabetList[c.ToString()]} ";
                }
                else
                {
                    newString += c.ToString();
                }
            }
            return newString;
        }
    }
}
