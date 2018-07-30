using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        StreamReader file= new StreamReader(@"C:\Users\user\Desktop\Lupta.txt");

        StringBuilder aux = new StringBuilder();
       
        string[] Script = new string[1000];
        int[] lungime = new int[1000];
        public int n = 0,i;

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            aux.Append(file.ReadLine());
            while (aux.ToString() != "Stop")
            {
                n++;


                Script[n] = aux.ToString();
                lungime[n] = aux.Length;


                aux.Clear();
                aux.Append(file.ReadLine());
            }


            MessageBox.Show(Script[1]);

        }

     
        
    }
}
