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

namespace Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buffer = new byte[25];
        }

        int fine = 0;
        int colore;
        int turn;
        bool turno = false;
        bool v = false;
        byte[] buffer;                  //Il meassaggio è costruito così:      NomePictureBox.name | Vittoria(true/false) 
        //0== giocatore giallo          1== giocatore rosso
        string buffer_string;
        TcpClient player;
        NetworkStream stream;

        private void btnconnetti_Click(object sender, EventArgs e)
        {
            player = new TcpClient(txtConnetti.Text, 4444);
            stream = player.GetStream();
            stream.Read(buffer, 0, buffer.Length);
            turn = Convert.ToInt32(Encoding.ASCII.GetString(buffer));
            if (turn == 1)
            {
                Receive();
            }
        }
            
        private void Send(string pos)
        {
            stream.Write(Encoding.ASCII.GetBytes(pos+"|"+v),0,Encoding.ASCII.GetBytes(pos + "|" + v).Length);
            turn = 2;
        }

        private void Receive()
        {
            stream.Read(buffer, 0, buffer.Length);
            buffer_string = Encoding.ASCII.GetString(buffer);
            v = Convert.ToBoolean(buffer_string.Split()[1]);

            //Ricerca della picturebox da cambiare 

            turn = 1;

        }


        private void Finito(string vincitore)
        {
            if (v)
            {
                stream.Write(Encoding.ASCII.GetBytes(vincitore + "|" + v), 0, Encoding.ASCII.GetBytes(vincitore + "|" + v).Length);
                stream.Close();
                player.Close();
               // Player.Program.
            }
        }

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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            Colonna1(sender);
            fine++;
            vincita();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            Colonna2(sender);
            fine++;
            vincita();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            Colonna3(sender);
            fine++;
            vincita();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Colonna4(sender);
            fine++;
            vincita();
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            Colonna5(sender);
            fine++;
            vincita();
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            Colonna6(sender);
            fine++;
            vincita();
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            Colonna7(sender);
            fine++;
            vincita();
        }
        #endregion

        #region Vittoria

        public void vincita()
        {
                // Orizzontale
                if ((pictureBox1.Tag == pictureBox2.Tag) && (pictureBox2.Tag == pictureBox3.Tag) && (pictureBox3.Tag == pictureBox4.Tag))
                {
                    if (pictureBox1.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox2.Tag == pictureBox3.Tag) && (pictureBox3.Tag == pictureBox4.Tag) && (pictureBox4.Tag == pictureBox5.Tag))
                {
                    if (pictureBox2.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox2.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox3.Tag == pictureBox4.Tag) && (pictureBox4.Tag == pictureBox5.Tag) && (pictureBox5.Tag == pictureBox6.Tag))
                {
                    if (pictureBox3.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox5.Tag) && (pictureBox5.Tag == pictureBox6.Tag) && (pictureBox6.Tag == pictureBox7.Tag))
                {
                    if (pictureBox4.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 2
                if ((pictureBox8.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox11.Tag))
                {
                    if (pictureBox8.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox12.Tag))
                {
                    if (pictureBox9.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox9.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox13.Tag))
                {
                    if (pictureBox10.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox10.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox14.Tag))
                {
                    if (pictureBox11.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 3
                if ((pictureBox15.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox18.Tag))
                {
                    if (pictureBox15.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox15.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox16.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox19.Tag))
                {
                    if (pictureBox16.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox16.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox17.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox20.Tag))
                {
                    if (pictureBox17.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox17.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox18.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox21.Tag))
                {
                    if (pictureBox18.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox18.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 4
                if ((pictureBox22.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox25.Tag))
                {
                    if (pictureBox22.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox22.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox23.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox26.Tag))
                {
                    if (pictureBox23.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox23.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox24.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox27.Tag))
                {
                    if (pictureBox24.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox24.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox25.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox28.Tag))
                {
                    if (pictureBox25.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox25.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                // - riga 5
                if ((pictureBox29.Tag == pictureBox30.Tag) && (pictureBox30.Tag == pictureBox31.Tag) && (pictureBox31.Tag == pictureBox32.Tag))
                {
                    if (pictureBox29.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox29.Tag.ToString() == "giallo") { v=true; Finito("giallo"); }
                }
                if ((pictureBox30.Tag == pictureBox31.Tag) && (pictureBox31.Tag == pictureBox32.Tag) && (pictureBox32.Tag == pictureBox33.Tag))
                {
                    if (pictureBox30.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox30.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox31.Tag == pictureBox32.Tag) && (pictureBox32.Tag == pictureBox33.Tag) && (pictureBox33.Tag == pictureBox34.Tag))
                {
                    if (pictureBox31.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox31.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox32.Tag == pictureBox33.Tag) && (pictureBox33.Tag == pictureBox34.Tag) && (pictureBox34.Tag == pictureBox35.Tag))
                {
                    if (pictureBox32.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox32.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }

                // Verticale
                if ((pictureBox1.Tag == pictureBox8.Tag) && (pictureBox8.Tag == pictureBox15.Tag) && (pictureBox15.Tag == pictureBox22.Tag))
                {
                    if (pictureBox1.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox8.Tag == pictureBox15.Tag) && (pictureBox15.Tag == pictureBox22.Tag) && (pictureBox22.Tag == pictureBox29.Tag))
                {
                    if (pictureBox8.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 2
                if ((pictureBox2.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox23.Tag))
                {
                    if (pictureBox1.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox30.Tag))
                {
                    if (pictureBox8.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 3
                if ((pictureBox3.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox24.Tag))
                {
                    if (pictureBox3.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox31.Tag))
                {
                    if (pictureBox8.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 4
                if ((pictureBox4.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox25.Tag))
                {
                    if (pictureBox4.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox32.Tag))
                {
                    if (pictureBox11.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 5
                if ((pictureBox5.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox26.Tag))
                {
                    if (pictureBox5.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox5.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox12.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox33.Tag))
                {
                    if (pictureBox12.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox12.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 6
                if ((pictureBox6.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox27.Tag))
                {
                    if (pictureBox6.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox6.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox13.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox34.Tag))
                {
                    if (pictureBox13.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox13.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - colonna 7
                if ((pictureBox7.Tag == pictureBox14.Tag) && (pictureBox14.Tag == pictureBox21.Tag) && (pictureBox21.Tag == pictureBox28.Tag))
                {
                    if (pictureBox7.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox7.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox28.Tag == pictureBox21.Tag) && (pictureBox21.Tag == pictureBox28.Tag) && (pictureBox28.Tag == pictureBox35.Tag))
                {
                    if (pictureBox14.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox14.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }

                // Diagonale
                if ((pictureBox14.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox32.Tag))
                {
                    if (pictureBox14.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox14.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox13.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox21.Tag))
                {
                    if (pictureBox13.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox13.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox7.Tag == pictureBox13.Tag) && (pictureBox13.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox25.Tag))
                {
                    if (pictureBox7.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox7.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox12.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox30.Tag))
                {
                    if (pictureBox12.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox12.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox6.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox24.Tag))
                {
                    if (pictureBox6.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox6.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox23.Tag) && (pictureBox23.Tag == pictureBox29.Tag))
                {
                    if (pictureBox11.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox5.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox23.Tag))
                {
                    if (pictureBox5.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox5.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox22.Tag))
                {
                    if (pictureBox4.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                // - diagonale 2
                if ((pictureBox8.Tag == pictureBox16.Tag) && (pictureBox16.Tag == pictureBox24.Tag) && (pictureBox24.Tag == pictureBox32.Tag))
                {
                    if (pictureBox8.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox8.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox1.Tag == pictureBox9.Tag) && (pictureBox9.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox25.Tag))
                {
                    if (pictureBox1.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox1.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox9.Tag == pictureBox17.Tag) && (pictureBox17.Tag == pictureBox25.Tag) && (pictureBox25.Tag == pictureBox33.Tag))
                {
                    if (pictureBox9.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox9.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox2.Tag == pictureBox10.Tag) && (pictureBox10.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox26.Tag))
                {
                    if (pictureBox2.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox2.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox10.Tag == pictureBox18.Tag) && (pictureBox18.Tag == pictureBox26.Tag) && (pictureBox26.Tag == pictureBox34.Tag))
                {
                    if (pictureBox10.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox10.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox3.Tag == pictureBox11.Tag) && (pictureBox11.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox27.Tag))
                {
                    if (pictureBox3.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox3.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox11.Tag == pictureBox19.Tag) && (pictureBox19.Tag == pictureBox27.Tag) && (pictureBox27.Tag == pictureBox35.Tag))
                {
                    if (pictureBox11.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox11.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if ((pictureBox4.Tag == pictureBox12.Tag) && (pictureBox12.Tag == pictureBox20.Tag) && (pictureBox20.Tag == pictureBox28.Tag))
                {
                    if (pictureBox4.Tag.ToString() == "rosso") { v=true;  Finito("rosso"); }
                    else if (pictureBox4.Tag.ToString() == "giallo") { v=true;  Finito("giallo"); }
                }
                if (fine == 35)
                {
                    if (!v)
                    {
                         MessageBox.Show("Parita finita in parità");
                    }
                    
                }       
                MessageBox.Show("Partita conclusa");
            
            
        }
        #endregion


    }
}
