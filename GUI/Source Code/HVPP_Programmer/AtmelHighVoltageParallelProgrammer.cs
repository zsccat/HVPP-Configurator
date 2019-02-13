using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace HVPP_Programmer
{
    public class AtmelHighVoltageParallelProgrammer
    {
        const int BUAD_RATE = 57600;

        private SerialPort sp = null;
        private string inString = "";
        private HVPP_COMMAND command = HVPP_COMMAND.NONE;

        private int pageSize = 0;
        private int pages = 0;

        private bool dataReceivedReady = false;

        public bool DataReceivedReady
        {
            get { return dataReceivedReady; }
        }

        public string ReceivedData
        {
            get { return inString; }
        }

        public AtmelHighVoltageParallelProgrammer(string port, string chip)
        {
            switch (chip)
            {
                case "ATMEGA8(A)(L)":
                    pageSize = 32;
                    pages = 128;
                    break;
                case "ATMEGA48":
                    pageSize = 32;
                    pages = 64;
                    break;
                case "ATMEGA168(P)(PA)":
                    pageSize = 64;
                    pages = 128;
                    break;
                case "ATMEGA328(P)":
                    pageSize = 64;
                    pages = 256;
                    break;
            }

            try
            {
                sp = new SerialPort(port, BUAD_RATE, Parity.None, 8, StopBits.One);
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                sp.Open();
            }
            catch (Exception ex)
            {
                if (sp.IsOpen)
                    sp.Close();
            }
        }

        public void Close()
        {
            if (sp.IsOpen)
                sp.Close();

            sp.Dispose();
        }

        public string ProgrammerCommunicate(HVPP_COMMAND cmd, string parameters)
        {
            string result = "";

            command = cmd;

            switch (cmd)
            {
                case HVPP_COMMAND.OPEN:
                    result = SendCommand("00", "", 1);
                    break;
                case HVPP_COMMAND.READ_SIGNATURE:
                    result = SendCommand("01", "", 6);
                    break;
                case HVPP_COMMAND.READ_FUSES:
                    result = SendCommand("02", "", 11);
                    break;
                case HVPP_COMMAND.WRITE_LFUSE:
                    result = SendCommand("03", parameters, 1);
                    break;
                case HVPP_COMMAND.WRITE_HFUSE:
                    result = SendCommand("04", parameters, 1);
                    break;
                case HVPP_COMMAND.WRITE_EXT_FUSE:
                    result = SendCommand("05", parameters, 1);
                    break;
                case HVPP_COMMAND.WRITE_LOCK_BYTE:
                    result = SendCommand("06", "", 1);
                    break;
                case HVPP_COMMAND.CHIP_EARSE:
                    result = SendCommand("07", "", 1);
                    break;
                case HVPP_COMMAND.READ_CALIBRATION_BYTE:
                    result = SendCommand("08", "", 2);
                    break;
                case HVPP_COMMAND.END:
                    result = SendCommand("99", "", 1);
                    break;
            }


            return result;
        }

        private string SendCommand(string cmd, string data, int expectedLength)
        {
            dataReceivedReady = false;
            inString = "";

            SendData(cmd + data);

            int count = 0;

            if (expectedLength == 0)
            {
                while (!dataReceivedReady && count < 5)
                {
                    ++count;
                    Thread.Sleep(300);
                }
            }
            else
            {
                while (!dataReceivedReady && inString.Length < expectedLength)
                {
                    Thread.Sleep(5);
                }
            }

            return inString;
        }

        private void SendData(string data)
        {
            try
            {
                sp.Write(data);
            }
            catch (Exception ex) { }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort s = (SerialPort)sender;
            string inData = s.ReadExisting();

            inString += inData;

            if (inString.IndexOf("\r\n") > 0)
            {
                inString = inString.Replace("\0", "").Replace("\r\n", "");

                dataReceivedReady = true;
            }
        }
    }

    public enum HVPP_COMMAND
    {
        NONE = -1,
        OPEN = 0,
        READ_SIGNATURE = 1,
        READ_FUSES = 2,
        WRITE_LFUSE = 3,
        WRITE_HFUSE = 4,
        WRITE_EXT_FUSE = 5,
        WRITE_LOCK_BYTE = 6,
        CHIP_EARSE = 7,
        READ_CALIBRATION_BYTE = 8,
        END = 99
    }
}
