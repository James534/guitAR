using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;


namespace DetectPixel
{
    class Program
    {
        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("user32.dll")]
        static extern int FindWindow(string lpClassName, string lpWindowName);

        static Socket soc;

        static void initSocket()
        {
            try
            {
                soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse("10.20.5.156");
                System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 1234);
                soc.Connect(remoteEP);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        static void Main(string[] args)
        {
            //List of 4 integers: # of intervals, startx, starty, width
            List<int> pixelInfo = new List<int>() {52, 325, 274, 6 };
            List<uint> prev = new List<uint>();
            for (int i =0; i < pixelInfo[0]; i++)
            {
                prev.Add(0);
            }
            /*
            int prevx = 0;
            int prevy = 0;
            while (true)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                if (x != prevx || y != prevy)
                    Console.WriteLine("{0}, {1}", x, y);
                prevx = x;
                prevy = y;
            }
            */
            IntPtr winHandle = Process.GetProcessesByName("MIDIGuitar2-64bit")[0].MainWindowHandle;
            IntPtr hDC = GetWindowDC(winHandle);
            Console.WriteLine("Success");
            //int count = 0;
            Dictionary<int, string> notes = new Dictionary<int, string>()
            {
                {28, "1,0;" },
                {29, "1,1;" },
                {30, "1,2;" },
                {31, "1,3;" },
                {24, "2,1;" },
                {23, "2,0;" },
                {26, "2,3;" },
                {19, "3,0;" },
                {20, "3,1;4,4;" },
                {18, "4,2;" },
                {16, "5,4;" },
                {12, "5,0;" },
                {21, "3,2;" }

            }
                ;
            //Stopwatch timer = new Stopwatch();
            initSocket();
            soc.Send(System.Text.Encoding.ASCII.GetBytes("Input\n"));
            while (true) {
                //timer.Restart();
                foreach (KeyValuePair<int, string> pair in notes)
                //for (int i = 0; i < 52; i++)
                {
                    uint pixel = GetPixel(hDC, pixelInfo[1] + pair.Key*pixelInfo[3] + 3, pixelInfo[2]);
                    if (pixel != prev[pair.Key] && pixel == 4270440)
                    {
                        Console.WriteLine(pair.Value);
                        string s = pair.Value + "\n";
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(s);
                        foreach(Byte by in byData)
                            Console.WriteLine(by);
                        soc.Send(byData);
                    }
                    prev[pair.Key] = pixel;
                }
                //Console.WriteLine(timer.Elapsed);
                //count++;

                soc.Send(System.Text.Encoding.ASCII.GetBytes("Input\n"));

            };
            ReleaseDC(winHandle, hDC);
        }


    }
}
