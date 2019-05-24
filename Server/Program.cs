using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main()
        {
            //idea dello scambio di messaggi
            //server prende il nome della casella lo invia all'altro giocatore e via così
            //il client verifica se un giovatore ha vinto
            // in caso di vincita tutto viene fermato e fatto ripartire

            byte[] buffer;                  //Il meassaggio è costruito così:      NomePictureBox.name | Vittoria(true/false)
            int turno;                      //1== giocatore giallo          2== giocatore rosso
            string buffer_string;
            bool v;
            TcpListener server;
            TcpClient player1;
            TcpClient player2;
            NetworkStream stream1;
            NetworkStream stream2;
            Random random;
            Stopwatch stopWatch;

            random = new Random();
            v = false;
            turno = random.Next(1, 2);
            buffer = new byte[100];
            buffer_string = null;
            server = new TcpListener(IPAddress.Loopback, 4444);
            stopWatch = new Stopwatch();

            try
            {
                server.Start();
                stopWatch.Start();
                Console.WriteLine("Server started: " + server.LocalEndpoint);

                player1 = server.AcceptTcpClient();
                stopWatch.Stop();
                stream1 = player1.GetStream();
                Console.WriteLine("player 1 Accettato dopo: " + stopWatch.Elapsed.TotalSeconds.ToString() + "s\nGiocherà come: " + turno);
                stream1.Write(Encoding.ASCII.GetBytes("1"), 0, Encoding.ASCII.GetBytes("1").Length);
                stopWatch.Restart();

                player2 = server.AcceptTcpClient();
                stopWatch.Stop();
                stream2 = player2.GetStream();
                Console.WriteLine("player 2 Accettato dopo: " + stopWatch.Elapsed.TotalSeconds.ToString() + "s\nGiocherà come: " + turno);
                stream2.Write(Encoding.ASCII.GetBytes("2"), 0, Encoding.ASCII.GetBytes("2").Length);
                stopWatch.Restart();

                stream1.Write(Encoding.ASCII.GetBytes("Start"), 0, Encoding.ASCII.GetBytes("Start").Length);
                Console.WriteLine("Start");
                while (true)
                {
                    switch (turno)
                    {
                        case 1:
                            stream1.Read(buffer, 0, buffer.Length);
                            Console.WriteLine("Tempo di attesa player 1: " + stopWatch.Elapsed.TotalSeconds.ToString());
                            stream2.Write(buffer, 0, buffer.Length);
                            stream2.Write(buffer, 0, buffer.Length);
                            buffer_string = Encoding.ASCII.GetString(buffer);
                            v = Convert.ToBoolean(buffer_string.Split('|')[1]);
                            Console.WriteLine(buffer_string);
                            if (v)
                            {
                                turno = 5;
                            }
                            turno = 2;
                            
                            break;
                        case 2:
                            stream2.Read(buffer, 0, buffer.Length);
                            Console.WriteLine("Tempo di attesa player 2: " + stopWatch.Elapsed.TotalSeconds.ToString());
                            stream1.Write(buffer, 0, buffer.Length);
                            stream1.Write(buffer, 0, buffer.Length);
                            buffer_string = Encoding.ASCII.GetString(buffer);
                            v = Convert.ToBoolean(buffer_string.Split('|')[1]);
                            Console.WriteLine(buffer_string);
                            if (v)
                            {
                                turno = 5;
                            }
                            turno = 1;
                            break;
                        case 5:
                            stream1.Close();
                            stream2.Close();
                            player1.Close();
                            player2.Close();
                            server.Stop();
                            Server.Program.Main();
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Problemi nella generazione del server o connessione dei giocatori");
                Console.WriteLine("Rilancio il server");
                server.Stop();
                Server.Program.Main();
            }

            Server.Program.Main();

           
        }


    }
}
