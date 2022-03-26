using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquerRegion
{
    public partial class Game : Form
    {
        public Game(bool isHost, string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (isHost)
            {
                PlayerSign = " ";
                OpponentSign = "  ";
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else
            {
                PlayerSign = "  ";
                OpponentSign = " ";
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            FreezeBoard();
            label1.Text = "Opponent's Turn!";
            label1.BackColor = Color.Red;
            ReceiveMove();
            label1.Text = "Your Trun!";
            label1.BackColor = Color.Green;
            if (!CheckState())
                UnfreezeBoard();
        }

        private string PlayerSign;
        private string OpponentSign;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        private bool CheckState()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);
            buttons.Add(button21);
            buttons.Add(button22);
            buttons.Add(button23);
            buttons.Add(button24);
            buttons.Add(button25);
            buttons.Add(button26);
            buttons.Add(button27);
            buttons.Add(button28);
            buttons.Add(button29);
            buttons.Add(button30);
            buttons.Add(button31);
            buttons.Add(button32);
            buttons.Add(button33);
            buttons.Add(button34);
            buttons.Add(button35);
            buttons.Add(button36);
            buttons.Add(button47);
            buttons.Add(button48);
            buttons.Add(button50);
            buttons.Add(button51);
            buttons.Add(button53);
            buttons.Add(button54);


            int playerLandCount = 0;
            int opponentLandCount = 0;
            foreach (var item in buttons)
            {
                if (item.Text == " ")
                    playerLandCount++;
                else if (item.Text == "  ")
                    opponentLandCount++;
            }

        
            return false;
        }
        private void FreezeBoard()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
            button29.Enabled = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button47.Enabled = false;
            button48.Enabled = false;
            button50.Enabled = false;
            button51.Enabled = false;
            button53.Enabled = false;
            button54.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
            button47.Enabled = true;
            button48.Enabled = true;
            button50.Enabled = true;
            button51.Enabled = true;
            button53.Enabled = true;
            button54.Enabled = true;

        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
            {
                button1.Text = OpponentSign.ToString();
                button1.BackColor = Color.Black;
            }
            if (buffer[0] == 2)
            {
                button2.Text = OpponentSign.ToString();
                button2.BackColor = Color.Black;
            }
            if (buffer[0] == 3)
            {
                button3.Text = OpponentSign.ToString();
                button3.BackColor = Color.Black;
            }
            if (buffer[0] == 4)
            {
                button4.Text = OpponentSign.ToString();
                button4.BackColor = Color.Black;
            }
            if (buffer[0] == 5)
            {
                button5.Text = OpponentSign.ToString();
                button5.BackColor = Color.Black;
            }
            if (buffer[0] == 6)
            {
                button6.Text = OpponentSign.ToString();
                button6.BackColor = Color.Black;
            }
            if (buffer[0] == 7)
            {
                button7.Text = OpponentSign.ToString();
                button7.BackColor = Color.Black;
            }
            if (buffer[0] == 8)
            {
                button8.Text = OpponentSign.ToString();
                button8.BackColor = Color.Black;
            }
            if (buffer[0] == 9)
            {
                button9.Text = OpponentSign.ToString();
                button9.BackColor = Color.Black;
            }
            if (buffer[0] == 9)
            {
                button9.Text = OpponentSign.ToString();
                button9.BackColor = Color.Black;
            }
            if (buffer[0] == 10)
            {
                button10.Text = OpponentSign.ToString();
                button10.BackColor = Color.Black;
            }
            if (buffer[0] == 11)
            {
                button11.Text = OpponentSign.ToString();
                button11.BackColor = Color.Black;
            }
            if (buffer[0] == 12)
            {
                button12.Text = OpponentSign.ToString();
                button12.BackColor = Color.Black;
            }
            if (buffer[0] == 13)
            {
                button13.Text = OpponentSign.ToString();
                button13.BackColor = Color.Black;
            }
            if (buffer[0] == 14)
            {
                button14.Text = OpponentSign.ToString();
                button14.BackColor = Color.Black;
            }
            if (buffer[0] == 15)
            {
                button15.Text = OpponentSign.ToString();
                button15.BackColor = Color.Black;
            }
            if (buffer[0] == 16)
            {
                button16.Text = OpponentSign.ToString();
                button16.BackColor = Color.Black;
            }
            if (buffer[0] == 17)
            {
                button17.Text = OpponentSign.ToString();
                button17.BackColor = Color.Black;
            }
            if (buffer[0] == 18)
            {
                button18.Text = OpponentSign.ToString();
                button18.BackColor = Color.Black;
            }
            if (buffer[0] == 19)
            {
                button19.Text = OpponentSign.ToString();
                button19.BackColor = Color.Black;
            }
            if (buffer[0] == 20)
            {
                button20.Text = OpponentSign.ToString();
                button20.BackColor = Color.Black;
            }
            if (buffer[0] == 21)
            {
                button21.Text = OpponentSign.ToString();
                button21.BackColor = Color.Black;
            }
            if (buffer[0] == 22)
            {
                button22.Text = OpponentSign.ToString();
                button22.BackColor = Color.Black;
            }
            if (buffer[0] == 23)
            {
                button23.Text = OpponentSign.ToString();
                button23.BackColor = Color.Black;
            }
            if (buffer[0] == 24)
            {
                button24.Text = OpponentSign.ToString();
                button24.BackColor = Color.Black;
            }
            if (buffer[0] == 25)
            {
                button25.Text = OpponentSign.ToString();
                button25.BackColor = Color.Black;
            }
            if (buffer[0] == 26)
            {
                button26.Text = OpponentSign.ToString();
                button26.BackColor = Color.Black;
            }
            if (buffer[0] == 27)
            {
                button27.Text = OpponentSign.ToString();
                button27.BackColor = Color.Black;
            }
            if (buffer[0] == 28)
            {
                button28.Text = OpponentSign.ToString();
                button28.BackColor = Color.Black;
            }
            if (buffer[0] == 29)
            {
                button29.Text = OpponentSign.ToString();
                button29.BackColor = Color.Black;
            }
            if (buffer[0] == 30)
            {
                button30.Text = OpponentSign.ToString();
                button30.BackColor = Color.Black;
            }
            if (buffer[0] == 31)
            {
                button31.Text = OpponentSign.ToString();
                button31.BackColor = Color.Black;
            }
            if (buffer[0] == 32)
            {
                button32.Text = OpponentSign.ToString();
                button32.BackColor = Color.Black;
            }
            if (buffer[0] == 33)
            {
                button33.Text = OpponentSign.ToString();
                button33.BackColor = Color.Black;
            }
            if (buffer[0] == 34)
            {
                button34.Text = OpponentSign.ToString();
                button34.BackColor = Color.Black;
            }
            if (buffer[0] == 35)
            {
                button35.Text = OpponentSign.ToString();
                button35.BackColor = Color.Black;
            }
            if (buffer[0] == 36)
            {
                button36.Text = OpponentSign.ToString();
                button36.BackColor = Color.Black;
            }
            if (buffer[0] == 47)
            {
                button47.Text = OpponentSign.ToString();
                button47.BackColor = Color.Black;
            }
            if (buffer[0] == 48)
            {
                button48.Text = OpponentSign.ToString();
                button48.BackColor = Color.Black;
            }
            if (buffer[0] == 50)
            {
                button50.Text = OpponentSign.ToString();
                button50.BackColor = Color.Black;
            }
            if (buffer[0] == 51)
            {
                button51.Text = OpponentSign.ToString();
                button51.BackColor = Color.Black;
            }
            if (buffer[0] == 53)
            {
                button53.Text = OpponentSign.ToString();
                button53.BackColor = Color.Black;
            }
            if (buffer[0] == 54)
            {
                button54.Text = OpponentSign.ToString();
                button54.BackColor = Color.Black;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            button1.Text = PlayerSign.ToString();
            button1.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            button2.Text = PlayerSign.ToString();
            button2.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            button3.Text = PlayerSign.ToString();
            button3.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            button4.Text = PlayerSign.ToString();
            button4.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            button5.Text = PlayerSign.ToString();
            button5.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            button6.Text = PlayerSign.ToString();
            button6.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            button7.Text = PlayerSign.ToString();
            button7.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            button8.Text = PlayerSign.ToString();
            button8.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            button9.Text = PlayerSign.ToString();
            button9.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            byte[] num = { 10 };
            sock.Send(num);
            button10.Text = PlayerSign.ToString();
            button10.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            byte[] num = { 11 };
            sock.Send(num);
            button11.Text = PlayerSign.ToString();
            button11.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            byte[] num = { 12 };
            sock.Send(num);
            button12.Text = PlayerSign.ToString();
            button12.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            byte[] num = { 13 };
            sock.Send(num);
            button13.Text = PlayerSign.ToString();
            button13.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            byte[] num = { 14 };
            sock.Send(num);
            button14.Text = PlayerSign.ToString();
            button14.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            byte[] num = { 15 };
            sock.Send(num);
            button15.Text = PlayerSign.ToString();
            button15.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            byte[] num = { 16 };
            sock.Send(num);
            button16.Text = PlayerSign.ToString();
            button16.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            byte[] num = { 17 };
            sock.Send(num);
            button17.Text = PlayerSign.ToString();
            button17.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            byte[] num = { 18 };
            sock.Send(num);
            button18.Text = PlayerSign.ToString();
            button18.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            byte[] num = { 19 };
            sock.Send(num);
            button19.Text = PlayerSign.ToString();
            button19.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            byte[] num = { 20 };
            sock.Send(num);
            button20.Text = PlayerSign.ToString();
            button20.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            byte[] num = { 21 };
            sock.Send(num);
            button21.Text = PlayerSign.ToString();
            button21.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button22_Click(object sender, EventArgs e)
        {
            byte[] num = { 22 };
            sock.Send(num);
            button22.Text = PlayerSign.ToString();
            button22.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button23_Click(object sender, EventArgs e)
        {
            byte[] num = { 23 };
            sock.Send(num);
            button23.Text = PlayerSign.ToString();
            button23.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            byte[] num = { 24 };
            sock.Send(num);
            button24.Text = PlayerSign.ToString();
            button24.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button25_Click(object sender, EventArgs e)
        {
            byte[] num = { 25 };
            sock.Send(num);
            button25.Text = PlayerSign.ToString();
            button25.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button26_Click(object sender, EventArgs e)
        {
            byte[] num = { 26 };
            sock.Send(num);
            button26.Text = PlayerSign.ToString();
            button26.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button27_Click(object sender, EventArgs e)
        {
            byte[] num = { 27 };
            sock.Send(num);
            button27.Text = PlayerSign.ToString();
            button27.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button28_Click(object sender, EventArgs e)
        {
            byte[] num = { 28 };
            sock.Send(num);
            button28.Text = PlayerSign.ToString();
            button28.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button29_Click(object sender, EventArgs e)
        {
            byte[] num = { 29 };
            sock.Send(num);
            button29.Text = PlayerSign.ToString();
            button29.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button30_Click(object sender, EventArgs e)
        {
            byte[] num = { 30 };
            sock.Send(num);
            button30.Text = PlayerSign.ToString();
            button30.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button31_Click(object sender, EventArgs e)
        {
            byte[] num = { 31 };
            sock.Send(num);
            button31.Text = PlayerSign.ToString();
            button31.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button32_Click(object sender, EventArgs e)
        {
            byte[] num = { 32 };
            sock.Send(num);
            button32.Text = PlayerSign.ToString();
            button32.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button33_Click(object sender, EventArgs e)
        {
            byte[] num = { 33 };
            sock.Send(num);
            button33.Text = PlayerSign.ToString();
            button33.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button34_Click(object sender, EventArgs e)
        {
            byte[] num = { 34 };
            sock.Send(num);
            button34.Text = PlayerSign.ToString();
            button34.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button35_Click(object sender, EventArgs e)
        {
            byte[] num = { 35 };
            sock.Send(num);
            button35.Text = PlayerSign.ToString();
            button35.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button36_Click(object sender, EventArgs e)
        {
            byte[] num = { 36 };
            sock.Send(num);
            button36.Text = PlayerSign.ToString();
            button36.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button47_Click(object sender, EventArgs e)
        {
            byte[] num = { 47 };
            sock.Send(num);
            button47.Text = PlayerSign.ToString();
            button47.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button48_Click(object sender, EventArgs e)
        {
            byte[] num = { 48 };
            sock.Send(num);
            button48.Text = PlayerSign.ToString();
            button48.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button50_Click(object sender, EventArgs e)
        {
            byte[] num = { 50 };
            sock.Send(num);
            button50.Text = PlayerSign.ToString();
            button50.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button51_Click(object sender, EventArgs e)
        {
            byte[] num = { 51 };
            sock.Send(num);
            button51.Text = PlayerSign.ToString();
            button51.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button53_Click(object sender, EventArgs e)
        {
            byte[] num = { 53 };
            sock.Send(num);
            button53.Text = PlayerSign.ToString();
            button53.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void button54_Click(object sender, EventArgs e)
        {
            byte[] num = { 54 };
            sock.Send(num);
            button54.Text = PlayerSign.ToString();
            button54.BackColor = Color.Green;
            MessageReceiver.RunWorkerAsync();
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }
    }

}
