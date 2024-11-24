using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NotHyperCam_.Net_Framework
{
    public partial class Form1 : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 1u;
        private const uint SWP_NOMOVE = 2u;
        private const uint TOPMOST_FLAGS = 3u;
        
        public static Form1 form1Instance;

        public Label lbl;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private IniFile iniFile;

        public Form1()
        {
            //assigns Ini File
            iniFile = new IniFile("Settings.ini");

            //Creates window
            MinimumSize = new Size(base.Width, base.Height);
            AutoSize = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(2560, 16);
            this.MinimumSize = new System.Drawing.Size(0, 16);
            base.Size = new Size(0, 16);
            SetWindowPos(base.Handle, HWND_TOPMOST, 0, 0, 0, 0, 3u);
            form1Instance = this;

            //Reads the Text value from .ini File
            string section = "Text";
            string key = "NotHyperCam Settings";
            string value = iniFile.Read(section, key);
            label1.Text = $"{value}"; 
            label1.Refresh(); 
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void helkpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}