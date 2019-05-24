using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buffer = new byte[100];
            /*PictureBox a;
            for (int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i] as PictureBox != null)
                {
                    a = (PictureBox)Controls[i];
                    a.Image = Caselle.Images[0];
                    a.Tag = null;
                    a.Enabled = true;
                }
            }*/
        }

        int fine = 0;
        int turn;
        bool turno = false;
        bool v = false;
        byte[] buffer;                  //Il meassaggio è costruito così:     NomePictureBox.name | Vittoria(true/false) 
        //1==true== giocatore giallo          2==false== giocatore rosso
        string buffer_string;
        TcpClient player;
        NetworkStream stream;

        private void btnconnetti_Click(object sender, EventArgs e)
        {
            player = new TcpClient(txtConnetti.Text, 4444);
            stream = player.GetStream();
            stream.Read(buffer, 0, buffer.Length);
            buffer_string = Encoding.ASCII.GetString(buffer);

            btnconnetti.Enabled = false;
            txtConnetti.Enabled = false;
            Player1();
        }
        private void Player1()
        {
            turn =int.Parse(buffer_string);
            if(buffer_string.Substring(0,1) == "1")
            {
                turno = true;
                lblTurno.Text = "Turno dell'avversario";
                stream.Read(buffer, 0, buffer.Length);
            }
            else
            {
                turno = false;
                lblTurno.Text = "giocatore" + turno;
                Receive();
            }
        }
        private void Send(string pos)
        {
            buffer_string = pos + "|" + v.ToString();
            buffer = Encoding.ASCII.GetBytes(buffer_string);
            stream.Write(buffer, 0, buffer.Length);
            lblTurno.Text = "Turno dell'avversario";
        }
        private void Receive()
        {
            System.Threading.Thread.Sleep(1000);
            stream.Read(buffer, 0, buffer.Length);
            buffer_string = Encoding.ASCII.GetString(buffer);
            if (buffer_string == "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
            {
                stream.Read(buffer, 0, buffer.Length);
                buffer_string = Encoding.ASCII.GetString(buffer);
            }
            string picture = buffer_string.Split('|')[0];
            int index =-1;
            Controls.IndexOfKey(picture);
            for (int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i] is PictureBox)
                {
                    if(Controls[i].Name == picture)
                    {
                        index = i;
                        break;
                    }
                }
            }
            PictureBox a;
            if (index != -1)
            {
                a = (PictureBox)Controls[index];
                if (buffer_string.Split('|')[1].ToLower() == "true")
                {
                    v = true;
                }

                if (turn != 1)
                {
                    if ((a.Name.Substring(10) == 1.ToString())|| (a.Name.Substring(10) == 8.ToString()) || (a.Name.Substring(10) == 15.ToString())
                        || (a.Name.Substring(10) == 22.ToString()) || (a.Name.Substring(10) == 29.ToString()))
                    {
                        Colonna1(a);
                        
                    }
                    if ((a.Name.Substring(10) == 2.ToString()) || (a.Name.Substring(10) == 9.ToString()) || (a.Name.Substring(10) == 16.ToString())
                        || (a.Name.Substring(10) == 23.ToString()) || (a.Name.Substring(10) == 30.ToString()))
                    {
                        Colonna2(a);
                        
                    }
                    if ((a.Name.Substring(10) == 3.ToString()) || (a.Name.Substring(10) == 10.ToString()) || (a.Name.Substring(10) == 17.ToString())
                        || (a.Name.Substring(10) == 24.ToString()) || (a.Name.Substring(10) == 31.ToString()))
                    {
                        Colonna3(a);
                        
                    }
                    if ((a.Name.Substring(10) == 4.ToString()) || (a.Name.Substring(10) == 11.ToString()) || (a.Name.Substring(10) == 18.ToString())
                        || (a.Name.Substring(10) == 24.ToString()) || (a.Name.Substring(10) == 32.ToString()))
                    {
                        Colonna4(a);
                        
                    }
                    if ((a.Name.Substring(10) == 5.ToString()) || (a.Name.Substring(10) == 12.ToString()) || (a.Name.Substring(10) == 19.ToString())
                        || (a.Name.Substring(10) == 25.ToString()) || (a.Name.Substring(10) == 33.ToString()))
                    {
                        Colonna5(a);
                        
                    }
                    if ((a.Name.Substring(10) == 6.ToString()) || (a.Name.Substring(10) == 13.ToString()) || (a.Name.Substring(10) == 20.ToString())
                        || (a.Name.Substring(10) == 26.ToString()) || (a.Name.Substring(10) == 34.ToString()))
                    {
                        Colonna6(a);
                        
                    }
                    if ((a.Name.Substring(10) == 7.ToString()) || (a.Name.Substring(10) == 14.ToString()) || (a.Name.Substring(10) == 21.ToString())
                        || (a.Name.Substring(10) == 27.ToString()) || (a.Name.Substring(10) == 35.ToString()))
                    {
                        Colonna7(a);
                        
                    }
                }
                else
                {
                    if ((a.Name.Substring(10) == 1.ToString()) || (a.Name.Substring(10) == 8.ToString()) || (a.Name.Substring(10) == 15.ToString())
                        || (a.Name.Substring(10) == 22.ToString()) || (a.Name.Substring(10) == 29.ToString()))
                    {
                        Colonna1(a);
                        
                    }
                    if ((a.Name.Substring(10) == 2.ToString()) || (a.Name.Substring(10) == 9.ToString()) || (a.Name.Substring(10) == 16.ToString())
                        || (a.Name.Substring(10) == 23.ToString()) || (a.Name.Substring(10) == 30.ToString()))
                    {
                        Colonna2(a);
                        
                    }
                    if ((a.Name.Substring(10) == 3.ToString()) || (a.Name.Substring(10) == 10.ToString()) || (a.Name.Substring(10) == 17.ToString())
                        || (a.Name.Substring(10) == 24.ToString()) || (a.Name.Substring(10) == 31.ToString()))
                    {
                        Colonna3(a);
                        
                    }
                    if ((a.Name.Substring(10) == 4.ToString()) || (a.Name.Substring(10) == 11.ToString()) || (a.Name.Substring(10) == 18.ToString())
                        || (a.Name.Substring(10) == 24.ToString()) || (a.Name.Substring(10) == 32.ToString()))
                    {
                        Colonna4(a);
                        
                    }
                    if ((a.Name.Substring(10) == 5.ToString()) || (a.Name.Substring(10) == 12.ToString()) || (a.Name.Substring(10) == 19.ToString())
                        || (a.Name.Substring(10) == 25.ToString()) || (a.Name.Substring(10) == 33.ToString()))
                    {
                        Colonna5(a);
                        
                    }
                    if ((a.Name.Substring(10) == 6.ToString()) || (a.Name.Substring(10) == 13.ToString()) || (a.Name.Substring(10) == 20.ToString())
                        || (a.Name.Substring(10) == 26.ToString()) || (a.Name.Substring(10) == 34.ToString()))
                    {
                        Colonna6(a);
                        
                    }
                    if ((a.Name.Substring(10) == 7.ToString()) || (a.Name.Substring(10) == 14.ToString()) || (a.Name.Substring(10) == 21.ToString())
                        || (a.Name.Substring(10) == 27.ToString()) || (a.Name.Substring(10) == 35.ToString()))
                    {
                        Colonna7(a);
                        
                    }
                }
            }
            else
            {
                lblTurno.Text = "Something went wrong";
            }

        }
        private void Finito(string vincitore)
        {

        }
        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {

        }

        /*
            private void btnconnetti_Click(object sender, EventArgs e)
            {
                player = new TcpClient(txtConnetti.Text, 4444);
                stream = player.GetStream();
                stream.Read(buffer, 0, buffer.Length);
                turn = Convert.ToInt32(Encoding.ASCII.GetString(buffer));
                btnconnetti.Enabled = false;
                btnconnetti.Visible = false;
                txtConnetti.Enabled = false;
                txtConnetti.Visible = false;
                if (turn == 1)
                {
                    lblTurno.Text = "Gioca come: " + turn;
                    turno = true;
                    waitingToStart();
                }
            }

            private void Send(string pos)
            {

                stream.Write(Encoding.ASCII.GetBytes(pos+"|"+v),0,Encoding.ASCII.GetBytes(pos + "|" + v).Length);
                turn = 2;
                turno = false;
                Receive();
            }
           private void waitingToStart()
            {

                MessageBox.Show("Waiting for the other player");
                stream.Read(buffer,0,buffer.Length);
                Receive();

            }
            private void Receive()
            {
                stream.Read(buffer, 0, buffer.Length);
                buffer_string = Encoding.ASCII.GetString(buffer);

               // v = Convert.ToBoolean(buffer_string.Split()[1]);

                PictureBox a = (PictureBox) Controls[Controls.IndexOfKey(buffer_string.Split()[0])];
                //Ricerca della picturebox da cambiare 
                if (turno)
                {
                    a.Image = Caselle.Images[1];
                    a.Tag = "giallo";
                    lblTurno.Text = "Turno di: " + turno + "\t" + a.Tag; 
                }
                else
                {
                    a.Image = Caselle.Images[2];
                    a.Tag = "rosso";
                    lblTurno.Text = "Turno di: " + turno + "\t" + a.Tag;
                }
                turn = 1;
                turno = true;
            }


            private void Finito(string vincitore)
            {
                if (v)
                {
                    MessageBox.Show("partita terminata");
                    //stream.Write(Encoding.ASCII.GetBytes(vincitore + "|" + v), 0, Encoding.ASCII.GetBytes(vincitore + "|" + v).Length);
                    //stream.Close();
                    //player.Close();
                   // Player.Program.
                }
            }*/

        #region AggiuntaColonna

        public void Colonna1(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox29.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox29.Image = Caselle.Images[1];
                    pictureBox29.Tag = "giallo";
                }
                else
                {
                    pictureBox29.Image = Caselle.Images[2];
                    pictureBox29.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox22.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox22.Image = Caselle.Images[1];
                    pictureBox22.Tag = "giallo";
                }
                else
                {
                    pictureBox22.Image = Caselle.Images[2];
                    pictureBox22.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox15.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox15.Image = Caselle.Images[1];
                    pictureBox15.Tag = "giallo";
                }
                else
                {
                    pictureBox15.Image = Caselle.Images[2];
                    pictureBox15.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox8.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox8.Image = Caselle.Images[1];
                    pictureBox8.Tag = "giallo";
                }
                else
                {
                    pictureBox8.Image = Caselle.Images[2];
                    pictureBox8.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox1.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox1.Image = Caselle.Images[1];
                    pictureBox1.Tag = "giallo";
                }
                else
                {
                    pictureBox1.Image = Caselle.Images[2];
                    pictureBox1.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox1.Enabled = false;
                pictureBox8.Enabled = false;
                pictureBox15.Enabled = false;
                pictureBox22.Enabled = false;
                pictureBox29.Enabled = false;

            }
        }

        public void Colonna2(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox30.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox30.Image = Caselle.Images[1];
                    pictureBox30.Tag = "giallo";
                }
                else
                {
                    pictureBox30.Image = Caselle.Images[2];
                    pictureBox30.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox23.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox23.Image = Caselle.Images[1];
                    pictureBox23.Tag = "giallo";
                }
                else
                {
                    pictureBox23.Image = Caselle.Images[2];
                    pictureBox23.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox16.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox16.Image = Caselle.Images[1];
                    pictureBox16.Tag = "giallo";
                }
                else
                {
                    pictureBox16.Image = Caselle.Images[2];
                    pictureBox16.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox9.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox9.Image = Caselle.Images[1];
                    pictureBox9.Tag = "giallo";
                }
                else
                {
                    pictureBox9.Image = Caselle.Images[2];
                    pictureBox9.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox2.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox2.Image = Caselle.Images[1];
                    pictureBox2.Tag = "giallo";
                }
                else
                {
                    pictureBox2.Image = Caselle.Images[2];
                    pictureBox2.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox2.Enabled = false;
                pictureBox9.Enabled = false;
                pictureBox16.Enabled = false;
                pictureBox23.Enabled = false;
                pictureBox30.Enabled = false;

            }
        }

        public void Colonna3(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox31.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox31.Image = Caselle.Images[1];
                    pictureBox31.Tag = "giallo";
                }
                else
                {
                    pictureBox31.Image = Caselle.Images[2];
                    pictureBox31.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox24.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox24.Image = Caselle.Images[1];
                    pictureBox24.Tag = "giallo";
                }
                else
                {
                    pictureBox24.Image = Caselle.Images[2];
                    pictureBox24.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox17.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox17.Image = Caselle.Images[1];
                    pictureBox17.Tag = "giallo";
                }
                else
                {
                    pictureBox17.Image = Caselle.Images[2];
                    pictureBox17.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox10.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox10.Image = Caselle.Images[1];
                    pictureBox10.Tag = "giallo";
                }
                else
                {
                    pictureBox10.Image = Caselle.Images[2];
                    pictureBox10.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox3.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox3.Image = Caselle.Images[1];
                    pictureBox3.Tag = "giallo";
                }
                else
                {
                    pictureBox3.Image = Caselle.Images[2];
                    pictureBox3.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox3.Enabled = false;
                pictureBox10.Enabled = false;
                pictureBox17.Enabled = false;
                pictureBox24.Enabled = false;
                pictureBox31.Enabled = false;
            }
        }

        public void Colonna4(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox32.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox32.Image = Caselle.Images[1];
                    pictureBox32.Tag = "giallo";
                }
                else
                {
                    pictureBox32.Image = Caselle.Images[2];
                    pictureBox32.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox25.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox25.Image = Caselle.Images[1];
                    pictureBox25.Tag = "giallo";
                }
                else
                {
                    pictureBox25.Image = Caselle.Images[2];
                    pictureBox25.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox18.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox18.Image = Caselle.Images[1];
                    pictureBox18.Tag = "giallo";
                }
                else
                {
                    pictureBox18.Image = Caselle.Images[2];
                    pictureBox18.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox11.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox11.Image = Caselle.Images[1];
                    pictureBox11.Tag = "giallo";
                }
                else
                {
                    pictureBox11.Image = Caselle.Images[2];
                    pictureBox11.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox4.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox4.Image = Caselle.Images[1];
                    pictureBox4.Tag = "giallo";
                }
                else
                {
                    pictureBox4.Image = Caselle.Images[2];
                    pictureBox4.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox4.Enabled = false;
                pictureBox11.Enabled = false;
                pictureBox18.Enabled = false;
                pictureBox25.Enabled = false;
                pictureBox32.Enabled = false;
            }
        }

        public void Colonna5(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox33.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox33.Image = Caselle.Images[1];
                    pictureBox33.Tag = "giallo";
                }
                else
                {
                    pictureBox33.Image = Caselle.Images[2];
                    pictureBox33.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox26.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox26.Image = Caselle.Images[1];
                    pictureBox26.Tag = "giallo";
                }
                else
                {
                    pictureBox26.Image = Caselle.Images[2];
                    pictureBox26.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox19.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox19.Image = Caselle.Images[1];
                    pictureBox19.Tag = "giallo";
                }
                else
                {
                    pictureBox19.Image = Caselle.Images[2];
                    pictureBox19.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox12.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox12.Image = Caselle.Images[1];
                    pictureBox12.Tag = "giallo";
                }
                else
                {
                    pictureBox12.Image = Caselle.Images[2];
                    pictureBox12.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox5.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox5.Image = Caselle.Images[1];
                    pictureBox5.Tag = "giallo";
                }
                else
                {
                    pictureBox5.Image = Caselle.Images[2];
                    pictureBox5.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox5.Enabled = false;
                pictureBox12.Enabled = false;
                pictureBox19.Enabled = false;
                pictureBox26.Enabled = false;
                pictureBox33.Enabled = false;
            }
        }

        public void Colonna6(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox34.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox34.Image = Caselle.Images[1];
                    pictureBox34.Tag = "giallo";
                }
                else
                {
                    pictureBox34.Image = Caselle.Images[2];
                    pictureBox34.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox27.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox27.Image = Caselle.Images[1];
                    pictureBox27.Tag = "giallo";
                }
                else
                {
                    pictureBox27.Image = Caselle.Images[2];
                    pictureBox27.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox20.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox20.Image = Caselle.Images[1];
                    pictureBox20.Tag = "giallo";
                }
                else
                {
                    pictureBox20.Image = Caselle.Images[2];
                    pictureBox20.Tag = "rosso";
                }

                turno = !turno;

            }
            else if (pictureBox13.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox13.Image = Caselle.Images[1];
                    pictureBox13.Tag = "giallo";
                }
                else
                {
                    pictureBox13.Image = Caselle.Images[2];
                    pictureBox13.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox6.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox6.Image = Caselle.Images[1];
                    pictureBox6.Tag = "giallo";
                }
                else
                {
                    pictureBox6.Image = Caselle.Images[2];
                    pictureBox6.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox6.Enabled = false;
                pictureBox13.Enabled = false;
                pictureBox20.Enabled = false;
                pictureBox27.Enabled = false;
                pictureBox34.Enabled = false;
            }
        }

        public void Colonna7(object a)
        {
            PictureBox pictureBox = (PictureBox)a;

            if (pictureBox35.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox35.Image = Caselle.Images[1];
                    pictureBox35.Tag = "giallo";
                }
                else
                {
                    pictureBox35.Image = Caselle.Images[2];
                    pictureBox35.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox28.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox28.Image = Caselle.Images[1];
                    pictureBox28.Tag = "giallo";
                }
                else
                {
                    pictureBox28.Image = Caselle.Images[2];
                    pictureBox28.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox21.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox21.Image = Caselle.Images[1];
                    pictureBox21.Tag = "giallo";
                }
                else
                {
                    pictureBox21.Image = Caselle.Images[2];
                    pictureBox21.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox14.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox14.Image = Caselle.Images[1];
                    pictureBox14.Tag = "giallo";
                }
                else
                {
                    pictureBox14.Image = Caselle.Images[2];
                    pictureBox14.Tag = "rosso";
                }

                turno = !turno;
            }
            else if (pictureBox7.Tag == null)
            {
                if (turno == true)
                {
                    pictureBox7.Image = Caselle.Images[1];
                    pictureBox7.Tag = "giallo";
                }
                else
                {
                    pictureBox7.Image = Caselle.Images[2];
                    pictureBox7.Tag = "rosso";
                }

                turno = !turno;

                // Disabilita colonna

                pictureBox7.Enabled = false;
                pictureBox14.Enabled = false;
                pictureBox21.Enabled = false;
                pictureBox28.Enabled = false;
                pictureBox35.Enabled = false;
            }
        }

        #endregion


        #region Click

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox1.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox2.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox3.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox4.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;

            pictureBox5.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox6.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox7.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox8.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox9.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox10.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox11.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox12.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox13.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox14.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox15.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox16.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox17.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox18.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox19.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox20.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox21.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox22.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox23.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox24.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox25.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox26.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox27.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox28.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox29.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox30.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox31.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox32.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox33.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox34.Enabled = false;
            Send(a.Name);Receive();
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
            PictureBox a = (PictureBox)sender;
            pictureBox35.Enabled = false;
            Send(a.Name);Receive();
        }
        #endregion


        #region Vittoria

        public void vincita()
        {
            //verifico se la casella più alta è vuota
                // Orizzontale
                if ((pictureBox1.Tag == pictureBox2.Tag) && (pictureBox2.Tag == pictureBox3.Tag) && (pictureBox3.Tag == pictureBox4.Tag)&&(pictureBox1.Tag!=null))
                {
                    if (pictureBox1.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox2.Tag == pictureBox3.Tag) && (pictureBox3.Tag == pictureBox4.Tag) && (pictureBox4.Tag == pictureBox5.Tag) && (pictureBox2.Tag != null))
                {
                    if (pictureBox2.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox2.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox3.Tag == pictureBox4.Tag) && (pictureBox4.Tag == pictureBox5.Tag) && (pictureBox5.Tag == pictureBox6.Tag) && (pictureBox3.Tag != null))
                {
                    if (pictureBox3.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox5.Tag) && (pictureBox5.Tag == pictureBox6.Tag) && (pictureBox6.Tag == pictureBox7.Tag) && (pictureBox4.Tag != null))
                {
                    if (pictureBox4.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 2
                if ((pictureBox8.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox11.Tag) && (pictureBox8.Tag != null))
                {
                    if (pictureBox8.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox12.Tag) && (pictureBox9.Tag != null))
                {
                    if (pictureBox9.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox9.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox13.Tag) && (pictureBox10.Tag != null))
                {
                    if (pictureBox10.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox10.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox14.Tag) && (pictureBox11.Tag != null))
                {
                    if (pictureBox11.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 3
                if ((pictureBox15.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox18.Tag) && (pictureBox15.Tag != null))
                {
                    if (pictureBox15.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox15.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox16.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox19.Tag) && (pictureBox16.Tag != null))
                {
                    if (pictureBox16.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox16.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox17.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox20.Tag) && (pictureBox17.Tag != null))
                {
                    if (pictureBox17.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox17.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox18.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox21.Tag) && (pictureBox18.Tag != null))
                {
                    if (pictureBox18.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox18.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 4
                if ((pictureBox22.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox25.Tag) && (pictureBox22.Tag != null))
                {
                    if (pictureBox22.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox22.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox23.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox26.Tag) && (pictureBox23.Tag != null))
                {
                    if (pictureBox23.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox23.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox24.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox27.Tag) && (pictureBox24.Tag != null))
                {
                    if (pictureBox24.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox24.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox25.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox28.Tag) && (pictureBox25.Tag != null))
                {
                    if (pictureBox25.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox25.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 5
                if ((pictureBox29.Tag == pictureBox30.Tag) && (pictureBox30.Tag == pictureBox31.Tag) && (pictureBox31.Tag == pictureBox32.Tag) && (pictureBox29.Tag != null))
                {
                    if (pictureBox29.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox29.Tag == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox30.Tag == pictureBox31.Tag) && (pictureBox31.Tag == pictureBox32.Tag) && (pictureBox32.Tag == pictureBox33.Tag) && (pictureBox30.Tag != null))
                {
                    if (pictureBox30.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox30.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox31.Tag == pictureBox32.Tag) && (pictureBox32.Tag == pictureBox33.Tag) && (pictureBox33.Tag == pictureBox34.Tag) && (pictureBox31.Tag != null))
                {
                    if (pictureBox31.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox31.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox32.Tag == pictureBox33.Tag) && (pictureBox33.Tag == pictureBox34.Tag) && (pictureBox34.Tag == pictureBox35.Tag) && (pictureBox32.Tag != null))
                {
                    if (pictureBox32.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox32.Tag == "giallo") { v=true;  Finito("giallo"); }
                }

                // Verticale
                if ((pictureBox1.Tag == pictureBox8.Tag) && (pictureBox8.Tag == pictureBox15.Tag) && (pictureBox15.Tag == pictureBox22.Tag) && (pictureBox1.Tag != null))
                {
                    if (pictureBox1.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox8.Tag == pictureBox15.Tag) && (pictureBox15.Tag == pictureBox22.Tag) && (pictureBox22.Tag == pictureBox29.Tag) && (pictureBox8.Tag != null))
                {
                    if (pictureBox8.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 2
                if ((pictureBox2.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox23.Tag) && (pictureBox2.Tag != null))
                {
                    if (pictureBox1.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox30.Tag) && (pictureBox9.Tag != null))
                {
                    if (pictureBox8.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 3
                if ((pictureBox3.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox24.Tag) && (pictureBox3.Tag != null))
                {
                    if (pictureBox3.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox31.Tag) && (pictureBox10.Tag != null))
                {
                    if (pictureBox8.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 4
                if ((pictureBox4.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox25.Tag) && (pictureBox4.Tag != null))
                {
                    if (pictureBox4.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox32.Tag) && (pictureBox11.Tag != null))
                {
                    if (pictureBox11.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 5
                if ((pictureBox5.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox26.Tag) && (pictureBox5.Tag != null))
                {
                    if (pictureBox5.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox5.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox12.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox33.Tag) && (pictureBox12.Tag != null))
                {
                    if (pictureBox12.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox12.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 6
                if ((pictureBox6.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox27.Tag) && (pictureBox6.Tag != null))
                {
                    if (pictureBox6.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox6.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox13.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox34.Tag) && (pictureBox13.Tag != null))
                {
                    if (pictureBox13.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox13.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 7
                if ((pictureBox7.Tag == pictureBox14.Tag) && (pictureBox14.Tag == pictureBox21.Tag) && (pictureBox21.Tag == pictureBox28.Tag) && (pictureBox7.Tag != null))
                {
                    if (pictureBox7.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox7.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox28.Tag == pictureBox21.Tag) && (pictureBox21.Tag == pictureBox28.Tag) && (pictureBox28.Tag == pictureBox35.Tag) && (pictureBox21.Tag != null))
                {
                    if (pictureBox21.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox21.Tag == "giallo") { v=true;  Finito("giallo"); }
                }

                // Diagonale
                if ((pictureBox14.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox32.Tag) && (pictureBox14.Tag != null))
                {
                    if (pictureBox14.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox14.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox13.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox21.Tag) && (pictureBox13.Tag != null))
                {
                    if (pictureBox13.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox13.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox7.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox25.Tag) && (pictureBox7.Tag != null))
                {
                    if (pictureBox7.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox7.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox12.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox30.Tag) && (pictureBox12.Tag != null))
                {
                    if (pictureBox12.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox12.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox6.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox24.Tag) && (pictureBox6.Tag != null))
                {
                    if (pictureBox6.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox6.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox29.Tag) && (pictureBox11.Tag != null))
                {
                    if (pictureBox11.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox5.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox23.Tag) && (pictureBox5.Tag != null))
                {
                    if (pictureBox5.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox5.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox22.Tag) && (pictureBox4.Tag != null))
                {
                    if (pictureBox4.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                // - diagonale 2
                if ((pictureBox8.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox32.Tag) && (pictureBox8.Tag != null))
                {
                    if (pictureBox8.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox1.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox25.Tag) && (pictureBox1.Tag != null))
                {
                    if (pictureBox1.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox33.Tag) && (pictureBox9.Tag != null))
                {
                    if (pictureBox9.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox9.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox2.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox26.Tag) && (pictureBox2.Tag != null))
                {
                    if (pictureBox2.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox2.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox34.Tag) && (pictureBox10.Tag != null))
                {
                    if (pictureBox10.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox10.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox3.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox27.Tag) && (pictureBox3.Tag != null))
                {
                    if (pictureBox3.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox35.Tag) && (pictureBox11.Tag != null))
                {
                    if (pictureBox11.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox28.Tag) && (pictureBox4.Tag != null))
                {
                    if (pictureBox4.Tag == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag == "giallo") { v=true;  Finito("giallo"); }
                }
                if (fine == 35)
                {
                    if (!v)
                    {
                         MessageBox.Show("Parita finita in parità");
                        Finito("Parità");
                    }
                    
                }       
            
            
        }


        #endregion

        
    }
}
