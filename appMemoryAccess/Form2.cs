using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryEditor;
using System.Diagnostics;
using System.IO;

namespace appMemoryAccess
{
    public partial class Form1 : Form
    {

        bool noMap = true;
        bool noInter = true;
        bool noLogin = true;
        Memory mapSrv = new Memory();
        Memory intSrv = new Memory();
        Memory lgnSrv = new Memory();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("form loaded");
            timer1.Enabled = true;
            timer1.Interval = 50;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            foreach (Process process in Process.GetProcesses())
            {
                Debug.WriteLine("form loaded");
                if (process.ProcessName == "map")
                    noMap = false;        
                if (process.ProcessName == "inter")
                    noInter = false;
                if (process.ProcessName == "login")
                    noLogin = false;
            }

            if (noMap == false)
            {
                if (mapSrv.OpenProcess("map"))
                {
                    Debug.WriteLine("map open err");
                }

                Debug.WriteLine("map open suc");
                //mapSrv.Write(0x411E0C, "http://cu1763.dothome.co.kr", 0);
                //noMap = true;
            }
            
            if (noInter == false)
            {
                if (!intSrv.OpenProcess("inter"))
                    Debug.WriteLine("Inter open err");

                //intSrv.Write(0x411E0C, "http://cu1763.dothome.co.kr", 0);
                //noInter = true;
            }

            if(noLogin == false)
            {
                if (!lgnSrv.OpenProcess("login"))
                    Debug.WriteLine("lgn open err");

                //lgnSrv.Write(0x40BC98, "http://cu1763.dothome.co.kr", 0);
                //noLogin = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
