using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleArkaAPI
{
    public class ArkaAPI
    {
        static StreamReader reader;
        static StreamWriter writer;
        static NamedPipeClientStream client;
        static string pipeName = "arka";

        public static void Init()
        {
            client = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut);
            reader = new StreamReader(client);
            writer = new StreamWriter(client);

            StartInjector();
            client.Connect();
            writer.AutoFlush = true;
            writer.WriteLine("auth:" + Process.GetCurrentProcess().Id);
        }

        public static string Inject()
        {
            writer.WriteLine("inject");
            string response = reader.ReadLine();
            return response;
        }

        public static void Execute(string script)
        {
            File.WriteAllText("temp.lua", script);
            writer.WriteLine("exec:temp.lua");
        }

        private static void StartInjector()
        {
            if (!File.Exists("ArkaInjectorV3.exe"))
            {
                MessageBox.Show("injector is missing");
                return;
            }

            Process.Start("ArkaInjectorV3.exe");
        }
    }
}
