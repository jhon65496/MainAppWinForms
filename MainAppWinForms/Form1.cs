using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.Integration;
using System.Windows;
using WpfControlLib;
using WpfControlLib.Views.Windows;

namespace MainAppWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
