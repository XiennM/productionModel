using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace produ
{
    public partial class Form1 : Form
    {
        bool isForward = true;
        Parser parser;
        ProductionModel productionModel;

        public Form1()
        {
            InitializeComponent();
            string filePath = @"C:\Users\kseny\Desktop\bd.txt";
            parser = new Parser(); 
            parser.Parse(filePath);

            for (int i = 0; i < parser.firstFacts; i++) {
                factsComboBox.Items.Insert(i, parser.facts[i]);
            }

            for (int i = 0; i < parser.finalFacts.Count; i++)
            {
                finalFactsComboBox.Items.Insert(i, parser.finalFacts[i]);
            }

            productionModel = new ProductionModel(parser);
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
            List<string> initialFacts = new List<string>();

            for (int i = 0; i < factsComboBox.Items.Count; i++)
            {
                if(factsComboBox.GetItemChecked(i))
                {
                    initialFacts.Add(factsComboBox.Items[i].ToString());
                }
            }

            string finalFact = "";

            for (int i = 0; i < finalFactsComboBox.Items.Count; i++)
            {
                if (finalFactsComboBox.GetItemChecked(i))
                {
                    finalFact = finalFactsComboBox.Items[i].ToString();
                }
            }

            if (isForward) {

                var finalFacts = productionModel.ComputeFinalFacts(initialFacts);
                textBox1.Text += "Финальные факты: " + string.Join(", ", finalFacts);
            }
            else
            {
                var requiredFacts = productionModel.ComputeRequiredFacts(finalFact);
                textBox1.Text += $"Необходимые аксиомы для {finalFact}: " + string.Join(", ", requiredFacts);
            }
        }
    }
}
