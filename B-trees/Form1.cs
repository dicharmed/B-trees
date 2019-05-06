using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_trees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowMenu()
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    //theory  
                    Help.ShowHelp(this, "helpTheory.chm", "b_trees.htm");
                    break;
                case 1:
                    //demonstration
                    break;
                case 2:
                    //test     
                    Form2 form2 = new Form2();
                    form2.Show();
                    break;
                case 3://exit
                    Application.Exit();
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMenu();
        }
    }
}
