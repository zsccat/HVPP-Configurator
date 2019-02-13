using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace HVPP_Programmer
{
    public partial class frmMain : Form
    {
        private AtmelHighVoltageParallelProgrammer programmer = null;

        int pageSize = 0;
        int pages = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadPorts();
        }

        private void LoadPorts()
        {
            IEnumerable<string> ports = SerialPort.GetPortNames().OrderBy(n => n);

            cbx_Port.Items.Clear();
            
            foreach (string port in ports)
            {
                cbx_Port.Items.Add(port);
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (cbx_Chip.Text != "" && cbx_Port.Text != "")
            {
                if (programmer != null)
                    programmer.Close();

                switch (cbx_Chip.Text)
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

                programmer = new AtmelHighVoltageParallelProgrammer(cbx_Port.Text, cbx_Chip.Text);

                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.OPEN, "");

                if (result == "0")
                {
                    MessageBox.Show("HVPP mode has been enabled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select the chip and serial port before connect to the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Signature_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.READ_SIGNATURE, "");

                tbx_Signature.Text = result;
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.END, "");

                if (result == "0")
                {
                    MessageBox.Show("HVPP mode has ended successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ReadFuses_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.READ_FUSES, "");

                string[] fuses = result.Split(' ');

                tbx_LFuse.Text = fuses[0];
                tbx_HFuse.Text = fuses[1];
                tbx_EFuse.Text = fuses[2];
                tbx_Lock.Text = fuses[3];
            }
        }

        private void btn_Calibration_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.READ_CALIBRATION_BYTE, "");

                tbx_Calibration.Text = result;
            }
        }

        private void btn_WriteLowFuse_Click(object sender, EventArgs e)
        {
            if (programmer != null && tbx_LFuse.Text != "")
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.WRITE_LFUSE, tbx_LFuse.Text);

                if (result == "0")
                {
                    MessageBox.Show("Low fuse has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Low fuse cannot empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_WriteHighFuse_Click(object sender, EventArgs e)
        {
            if (programmer != null && tbx_HFuse.Text != "")
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.WRITE_HFUSE, tbx_HFuse.Text);

                if (result == "0")
                {
                    MessageBox.Show("High fuse has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("High fuse cannot empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_WriteExtendedFuse_Click(object sender, EventArgs e)
        {
            if (programmer != null && tbx_EFuse.Text != "")
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.WRITE_EXT_FUSE, tbx_EFuse.Text);

                if (result == "0")
                {
                    MessageBox.Show("Extended fuse has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Extended communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Low fuse cannot empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Erase_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.CHIP_EARSE, "");

                if (result == "0")
                {
                    MessageBox.Show("Chip has been earsed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.WRITE_LOCK_BYTE, "");

                if (result == "0")
                {
                    MessageBox.Show("Lock byte has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error communicating the programmer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.END, "");
                //programmer.Close();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (programmer != null)
            {
                string result = programmer.ProgrammerCommunicate(HVPP_COMMAND.END, "");
                //programmer.Close();
            }

            Application.Exit();
        }
    }
}
