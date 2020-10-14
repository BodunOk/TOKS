using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab2TOKSIK
{
    class Packager
    {
        public const char ESC = (char)111;
        public const char ESCChange = (char)94;
        public const char flag = (char)101;
        private const byte headerSize = 3;
        private const byte dataSize = 100;
        private const byte trailerSize = 1;
        public const byte packageSize = headerSize + dataSize + trailerSize;

        private byte destinationAddress { get; set; }
        private byte sourceAddress { get; set; }

        public Packager(byte destinationAddress, byte sourceAddress)
        {
            this.destinationAddress = destinationAddress;
            this.sourceAddress = sourceAddress;
        }

        public string getPackage(string data)
        {
            
            if (data.Length > dataSize + 1) throw new Exception("Too large data");
            string msg = "";
            msg += flag;
            msg += destinationAddress;
            msg += sourceAddress;
            msg += byteStuffing(data);
            return msg;
        }

        public string unpackage(string message)
        {
            if (message.Length > packageSize) throw new Exception("Too large data");
            return unByteStuffing(message.Substring(headerSize));
        }

        private string byteStuffing(string message)
        {
            if (message.Length >= dataSize + 1) 
            throw new Exception("Invalid message");
            string msg = "";
            foreach (char symbol in message)
            {
                switch (symbol)
                {
                    case flag:
                        msg += ESC;
                        break;
                    case ESC:
                        msg += ESCChange;
                        break;
                    default:
                        msg += symbol;
                        break;
                }
            }

            return msg;
        }

        private string unByteStuffing(string message)
        {
            string msg = "";
            foreach (char symbol in message)
            {
                switch (symbol)
                {
                    case ESC:
                        msg += flag;
                        break;
                    case ESCChange:
                        msg += ESC;
                        break;
                    default:
                        msg += symbol;
                        break;
                }
            }

            return msg;
        }

    }
}
