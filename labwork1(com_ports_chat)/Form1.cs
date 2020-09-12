using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Net.Configuration;

namespace lab1TOKSIK
{
    public partial class COM_CHAT_Form : Form
    {
        public COM_CHAT_Form()
        {
            InitializeComponent();
            printStartInstruction();
           
        }

        private void printStartInstruction()
        {
            printInWindow("For connect to COM port using \"/connect\"");
            printInWindow("For check budeRate using \"/rate\"");
            printInWindow("For change baudRate using \"/change\"");
            printInWindow("For exit write \"/quit\"");
        }   

        private void COM_Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = Port.ReadExisting();

            if(data == "/quit")
            {
                Application.Exit();
                return;
            }

            printInWindow(data);
            
        }

        private void commandRun(string command)
        {
            var devCommand = command.ToLower().Split(' ');
            switch(devCommand[0])
            {
                case "connect":

                    chatWindow.Clear();

                    if (devCommand.Length < 2)
                    {
                        printInWindow("Input \"/connect\" + NAME");
                        break;
                    }

                    if(!(devCommand[1].ToUpper().StartsWith("COM")))
                    {
                        printInWindow("You may connect only to COM ports");
                        break;
                    }

                    try
                    {
                        Port.PortName = devCommand[1];
                        Port.Open();
                    }
                    catch(Exception e)
                    {
                        printInWindow(e.Message);
                        break;
                    }

                    printInWindow("You connected to " + devCommand[1]);
                    break;

                case "rate":

                    chatWindow.Clear();
                    if (!Port.IsOpen)
                    {
                        printInWindow("Firstly using \"/connect\"");    
                    }
                    else
                    {
                        printInWindow($"Currently rate of {Port.PortName.ToUpper()}: {Port.BaudRate} bod");
                    }

                    break;
                case "change":
                    chatWindow.Clear();

                    if(!Port.IsOpen)
                    {
                        printInWindow("Firstly using \"/connect\"");
                        break;
                    }

                    if(devCommand.Length < 2)
                    {
                        printInWindow("using:\"/change\" + NEW_NUMBER");
                        break;
                    }
                    if (int.TryParse(devCommand[1], out int newValue))
                    {
                        if (newValue < 0 || newValue > 115200)
                        {
                            printInWindow("Error!");
                            break;
                        }
                        Port.BaudRate = newValue;
                    }
                    else printInWindow("Invalid new value!");
                    break;
                default:
                    printInWindow($"Unknown command: \"/{devCommand[0]}\"");
                    break;
            }
        }

        private void autMessage() 
        {

            if (msgWindow.Text.Length == 0) return;
            if (msgWindow.Text.StartsWith("/"))
            {
                commandRun(msgWindow.Text.Substring(1));

            }
            else if (Port.IsOpen)
            {
                string tmpMes = Port.PortName + ": " + msgWindow.Text;
                Port.Write(tmpMes.ToCharArray(), 0, tmpMes.Length);
                printInWindow(tmpMes);
            }
            else
                printInWindow("Port is not open, using \"/connect\"");

            msgWindow.Clear();
        }

        private void msgWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                autMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void printInWindow(string text)
        {
            chatWindow.AppendText(text);
            chatWindow.AppendText(Environment.NewLine);
        }

        private void COM_CHAT_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Port.IsOpen)
            {
                Port.Write("/quit".ToCharArray(), 0, 5);
                Port.Close();
            }
        }
    }
}

