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

        

        public OpenFileDialog filePathing = new OpenFileDialog();


        


            string[] Script = new string[1000];
            string[] store1= new string[1000];
            string[] store2= new string[1000];
            int[] stop = new int[1000];
            int[] start = new int[1000];
            int[] final = new int[1000];
            int[] lungime = new int[1000];

       
        int cod;
        public int n,i,j=0;
        int checking; // verific daca datele sunt corecte
        int counter;

        StringBuilder aux = new StringBuilder();


        private void TheFilePath_Click(object sender, EventArgs e)
        {

            if (filePathing.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("The file path has been accepted");
            }
            else
                MessageBox.Show("Something went wrong, try again");
             

    }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  


            for(i=1;i<=n;i++)
            {
                Script[n] = "";
                store1[n] = "";
                store2[n] = "";
                start[n] = 0;
                stop[n] = 0;
            }

            n = 0;

            if (filePathing.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Choose the file first");
                return;
            }
         
                StreamReader fileScript = new StreamReader(filePathing.FileName);
              

            //   MessageBox.Show(filePathing.FileName.ToString());

            aux.Append(fileScript.ReadLine());
                while (aux.ToString() != "Stop;")
                {
                   
                    n++;
                    cod = 1;
                     
                    lungime[n] = aux.Length;

                    for (i = 0; i < lungime[n] && cod == 1; i++)
                    {
                        if (aux[i].ToString() == ";")
                        {
                            cod = 0;
                            j = i + 1;
                        }
                        else
                            Script[n] = Script[n] + aux[i].ToString();   // am si numarul de ordine (ex:001,002);

                        if(n==500)
                    {
                        MessageBox.Show("You forgot to put Stop; at the end of the file ");
                        return;
                    }


                    }

                   // MessageBox.Show(Script[n]);

                    cod = 1; // cod=1 inseamna inceput si cod =2 inseamna sfarsit; 
                    checking = 1; //verificam daca datele sunt validate sau nu;
                    counter = 0;

                   // MessageBox.Show("J=" + aux[j].ToString());

                    for (i = j; i < lungime[n] && cod != 3 && checking == 1; i++)
                    {


                        if (aux[i].ToString() != " " && aux[i].ToString() != "-" && aux[i].ToString() != ";")
                        {
                            if (cod == 1)
                                store1[n] = store1[n] + aux[i].ToString();
                            else
                                store2[n] = store2[n] + aux[i].ToString();

                            counter++; // criteriul ca minutele sa fie in ordine corecta

                            if (counter < 3 || counter > 3)
                            {
                                if (cod == 1 && store1[n] == ":")
                                    checking = 0;
                                else
                                    if (cod == 2 && store2[n]==":")
                                    checking = 0;

                            

                            }
                            else
                            if(counter==3)
                               if (cod == 1 && aux[i].ToString() != ":")
                                checking = 0;
                               else
                                if (cod == 2 && aux[i].ToString() != ":")
                                checking = 0;
                            
                        }
                        else
                              if (aux[i].ToString() == "-")
                        {
                            cod = 2;
                            counter = 0;
                        }
                        else
                            if (aux[i].ToString() == ";")
                            cod = 3;


                    }

                    aux.Clear();
                    aux.Append(fileScript.ReadLine());
                }

            aux.Clear();

            //MessageBox.Show(aux.ToString());
           

            if (checking == 0)
            {
                MessageBox.Show("Data is not validated, correct the script");
                fileScript.Close();
                return;
            }
           

                for (i = 1; i <= n; i++)
                {

                    if (store1[i] != null)
                    {
                        start[i] = Convert.ToInt32(store1[i].Substring(0, 2));
                        start[i] = start[i] * 60 + Convert.ToInt32(store1[i].Substring(3, 2));

                       MessageBox.Show(start[i].ToString());

                    }

                    if (store2[i] != null)
                    {
                        stop[i] = Convert.ToInt32(store2[i].Substring(0, 2));
                        stop[i] = stop[i] * 60 + Convert.ToInt32(store2[i].Substring(3, 2));

                       MessageBox.Show(stop[i].ToString());
                    }
                }



                checking = 1; // mai verificam inca odata validitatea datelor

                for (i = 1; i <= n && checking == 1; i++)
                {
                    if (start[i] > stop[i])
                    {
                        checking = 0;
                        MessageBox.Show("The minutes at line " + i + " are not in a correct order, correct that please");

                    }
                    else
                    if (checking == 1 && i < n)
                        if (stop[i] > start[i + 1])
                        {
                            checking = 0;
                            MessageBox.Show("The minutes at lines " + i + " and " + (i + 1) + " are not in a correct order, correct that please");


                        }


                }

                if (checking == 1)
                 MessageBox.Show("The script has been saved with success");  
                

                


            fileScript.Close();
            

        }

     
        
    }
}
