using System;
using System.Windows.Forms;

namespace ComPort
{
    public partial class MainForm : Form
    {
        private int attemptCount;
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            attemptCount = int.Parse(attemptCountTextBox.Text);
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            
        }        
        private void clearInput()
        {
            inputTextBox.Text = string.Empty;
        }
        private void sendChar(char a)
        {
            addControlDebugSymbol("~ ");//MY ADDING!!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < attemptCount; i++)
            {
                long ticks = carrierSense();
                if(collisionDetect(ticks))
                {
                    addControlDebugSymbol("try ");
                    waitNextAttempt(i);
                }
                else
                {
                    addControlDebugSymbol("OK\n");
                    addOutputSymbol(a);
                    waitCollisionWindow();
                    return;
                }                
            }
            addControlDebugSymbol("\n");
            waitCollisionWindow();//Для визуального отображения
            //TODO : write error
        }

        private long carrierSense()
        {
            return DateTime.UtcNow.Ticks;
        }

        private void delay(int ticks)
        {
            var startTicks = DateTime.UtcNow.Ticks;
            while (DateTime.UtcNow.Ticks < startTicks + ticks);
        }
        private void waitNextAttempt(int n)
        {
            Random r = new Random();
            delay(30*r.Next(0, Convert.ToInt32(Math.Pow(2, n))));            
        }
        private void waitCollisionWindow()
        {
            delay(1234);
        }
        private bool collisionDetect(long ticks)
        {
            if (((ticks / 100 % 31)* (ticks / 100 % 17)) % 3 == 0) //1 tick = 100 nanoseconds = 0.1 microseconds
                return false;
            return true;
        }
        private void addLine()
        {
            for (int i = 0; i < 10; i++)
                addControlDebugSymbol("-");//MY ADDING!!!!!!!!!!!!!!!!!!!!
            addControlDebugSymbol("\n");//MY ADDING!!!!!!!!!!!!!!!!!!!!
        }
        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                TextBox inputTextBox = (TextBox)sender;
                string input = inputTextBox.Text;
                foreach (char a in input)
                    sendChar(a);
                addOutputSymbol('\n');
                addLine();
                clearInput();
            }            
        }
        public void addOutputSymbol(char message)
        {
            outputLabel.BeginInvoke((MethodInvoker)(delegate { outputLabel.Text += message; }));
        }
        public void addControlDebugSymbol(string message)
        {
            controlLabel.BeginInvoke((MethodInvoker)(delegate { controlLabel.Text += message; }));
        }
        private void errorMes(string message)
        {
            MessageBox.Show(message, "ERROR");
            throw new FormatException("");
        }
        private void checkAttemptCount(object sender)
        {
            TextBox number = (TextBox)sender;
            try
            {
                attemptCount = int.Parse(number.Text);
                if (attemptCount > 10)
                {
                    errorMes("Too large count of attempt(max = 10)");
                }
                if (attemptCount < 1)
                {
                    errorMes("Too small count of attempt(min = 1)");
                }
            }
            catch (FormatException)
            {
                number.Text = "10";
                attemptCount = 10;
            }
            ActiveControl = null;
        }
        private void attemptCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                checkAttemptCount(sender);   
            }
        }

        private void attemptCountTextBox_Leave(object sender, EventArgs e)
        {
            checkAttemptCount(sender);
        }

        private void controlGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void attemptCountTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
