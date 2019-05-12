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
    public partial class Demonstration : Form
    {
        BinaryTree binaryTree = new BinaryTree();

        public Demonstration()
        {
            InitializeComponent();
        }             
       
        private void button1_Click(object sender, EventArgs e) //INSERT
        {           
            if (textBox1.Text != null)
            {
                int element = Convert.ToInt32(textBox1.Text);
                binaryTree.Insert(element);                           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            binaryTree.Print();
        }
    }
}
