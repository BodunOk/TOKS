using System.IO.Ports;

namespace lab2TOKSIK
{
    public class Port
    {
        private SerialPort serialPort;
        
        public Port()
        {
            serialPort = new SerialPort();

            SerialPort.BaudRate = 9600;
            SerialPort.Parity = Parity.None;
            SerialPort.DataBits = 8;
            SerialPort.StopBits = StopBits.One;

            SerialPort.ReadTimeout = 500;
            SerialPort.WriteTimeout = 500;
            
        }

        public int BaudeRate { get => SerialPort.BaudRate; set => SerialPort.BaudRate = value;}
        public string PortName { get => SerialPort.PortName; set => SerialPort.PortName = value;}
        public SerialPort SerialPort { get => serialPort; set => serialPort = value; }


        public void OpenPort()
        {
            serialPort.Open();
        }

        public void ClosePort()
        {
            SerialPort.Close();
        }

        public void WriteMessage(string message)
        {
            SerialPort.Write(message.ToCharArray(), 0, message.Length);
        }

        public string ReadMessage()
        {
            return SerialPort.ReadExisting();
        }

        public bool IsOpen()
        {
            return SerialPort.IsOpen;
        }
    }
}
