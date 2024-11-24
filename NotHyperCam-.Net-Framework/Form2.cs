using System;
using System.Windows.Forms;

namespace NotHyperCam_.Net_Framework
{
    public partial class Form2 : Form
    {
        private IniFile iniFile;

        public Form2()
        {
            InitializeComponent();

            //assigns Ini File
            iniFile = new IniFile("Settings.ini");

            //Reads the Text value from .ini File
            string Readsection = "Text";
            string Readkey = "NotHyperCam Settings";
            string Readvalue = iniFile.Read(Readsection, Readkey);
            textBoxValue.Text = $"{Readvalue}"; // Sets value to the TextBox
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            //Writes changed to .ini file
            string section = "Text";
            string key = textBoxValue.Text;
            string value = "NotHyperCam Settings";
            iniFile.Write(section, key, value);

            //Loads changes of the .ini file to the label in Form1
            Form1.form1Instance.label1.Text = textBoxValue.Text; // Sets value to label1 in Form1
            Form1.form1Instance.label1.Refresh(); 
        }

    }
}