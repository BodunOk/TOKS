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

namespace lab2TOKSIK
{
    public partial class COM_CHAT_Form : Form
    {

        private string package;
        private Packager packager;
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
                try
                {
                    string message = port.ReadMessage();
                    if(message != null)
                    {
                        message = packager.unpackage(message);
                        if (message == "/quit")
                        {
                            Application.Exit();
                            return;
                        }
                        string portNameMes = "COM";
                        portNameMes += StringComparer.OrdinalIgnoreCase.Equals(port.PortName, "COM1") ? "2" : "1";
                        printInWindow(portNameMes + ":" + message);
                    }
                }
                catch(TimeoutException)
                {

                }
        }

        private void commandRun(string command)
        {
            var devCommand = command.ToLower().Split(' ');
            switch (devCommand[0])
            {
                case "connect":

                    chatWindow.Clear();

                    if (devCommand.Length < 2)
                    {
                        printInWindow("Input \"/connect\" + NAME");
                        break;
                    }

                    if (!(devCommand[1].ToUpper().StartsWith("COM")))
                    {
                        printInWindow("You may connect only to COM ports");
                        break;
                    }

                    try
                    {
                        port.PortName = devCommand[1];
                        port.OpenPort();
                        packager = StringComparer.OrdinalIgnoreCase.Equals(port.PortName, "COM1") ? new Packager(2, 1) : new Packager(1, 2);
                    }
                    catch (Exception e)
                    {
                        printInWindow(e.Message);
                        break;
                    }

                    printInWindow("You connected to " + devCommand[1]);
                    break;

                case "rate":

                    chatWindow.Clear();
                    if (!port.IsOpen())
                    {
                        printInWindow("Firstly using \"/connect\"");
                    }
                    else
                    {
                        printInWindow($"Currently rate of {port.PortName.ToUpper()}: {port.BaudeRate} bod");
                    }

                    break;
                case "change":
                    chatWindow.Clear();

                    if (!port.IsOpen())
                    {
                        printInWindow("Firstly using \"/connect\"");
                        break;
                    }

                    if (devCommand.Length < 2)
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
                        port.BaudeRate = newValue;
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
            else if (port.IsOpen())
            {
                string tmpMes = port.PortName.ToUpper() + ":" + msgWindow.Text;
                package = packager.getPackage(msgWindow.Text);
                port.WriteMessage(package);
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
            if(port.IsOpen())
            {
                var message = packager.getPackage("/quit"); 
                port.WriteMessage(message);
                port.ClosePort();
            }
        }
    }
}