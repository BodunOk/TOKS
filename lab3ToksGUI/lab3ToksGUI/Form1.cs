using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3ToksGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonToEncoding_Click(object sender, EventArgs e)
        {
            if(InputTextFild.Text.Length < 3)
            {
                OutputDecoding.Clear();
                OutputEncoding.Clear();
                OutputDecoding.Text = "Please,enter more then 3 symbols!";
                OutputEncoding.Text = "Please,enter more then 3 symbols!";
                InputTextFild.Clear();
            } else {

                string str = InputTextFild.Text;
                OutputEncoding.Text = Hamming.Code(str);
            }
            
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            OutputDecoding.Text = Hamming.Decode(OutputEncoding.Text);
        }
    }
}
