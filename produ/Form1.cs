using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace produ
{
    public partial class Form1 : Form
    {
        bool isForward = true;

        public Form1()
        {
            InitializeComponent();
            string filePath = @"C:\Users\kseny\Desktop\bd.txt";
            Parser parser = new Parser(); 
            parser.Parse(filePath);

            for (int i = 0; i < parser.firstFacts; i++) {
                factsComboBox.Items.Insert(i, parser.facts[i]);
            }

            for (int i = 0; i < parser.finalFacts.Count; i++)
            {
                finalFactsComboBox.Items.Insert(i, parser.finalFacts[i]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isForward = !isForward;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < factsComboBox.Items.Count; i++)
            {
                factsComboBox.SetItemChecked(i, false);
                factsComboBox.SetSelected(i, false);
            }
            for (int i = 0; i < finalFactsComboBox.Items.Count; i++)
            {
                finalFactsComboBox.SetItemChecked(i, false);
                finalFactsComboBox.SetSelected(i, false);
            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(isForward) { 
            
            }
            else
            {

            }
        }
    }
}
