using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Davalibi_173311084


{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        int sayici2 = 0;
        int sure = 0;
        bool[] ctrl = new bool[25];
     
        public void btn_hazirla()
        { 
          
            Random random = new Random();

            int num = (int)nud_1.Value;
            int[] array = new int[num];
            int[] btn_id = new int[25];


            for (int i = 0; i < num; i++)
            {
                array[i] = random.Next(1, 25);
            }
            for (int i = 0; i < 25 ; i++)
            {
                btn_id[i] = i+1;
            }
            for (int i = 0; i < 25; i++)
            {
                ctrl[i] = false;
            }


            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (array[j] == btn_id[i])
                    {
                        ctrl[i] = true; 
                    }

                }

            }
       
        }

        private void btn_basla_Click(object sender, EventArgs e)
        { 
            if (timer1.Enabled)
            {
                sifirla("Yeniden başla");
            }

            btn_hazirla();
            foreach (var item in panel1.Controls)
            {
                Button button = (Button)item;
                button.BackColor = Color.DimGray;
                button.Text = "";
            }
            sure = (int)nud_2.Value + 1;
            
 
            timer1.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {         
            if (sure <= 0)
            {
                timer1.Stop();

               MessageBox.Show("Sure bitti");
                sure = (int)nud_2.Value;
            }
            sure--;
            lbl_sanye.Text = sure.ToString();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id1 = -1;
            Button btn = (Button)sender;
            id1 = int.Parse(btn.Name.Substring(6));
            Button[] komşu = komşularGetir(id1);
            komsularKontrulEt(id1, komşu , btn);
        }
          
        
        private Button[] komşularGetir(int id)
        {
            Button[] komşu = new Button[8];

            komşu[0] = id >= 6 ? (Button)(this.Controls.Find("button" + (id - 5), true)[0]) : null;//up
            komşu[1] = id >= 6 && id % 5 != 0 ? (Button)(this.Controls.Find("button" + (id - 4), true)[0]) : null;//up rigth
            komşu[2] = id >= 7 && id % 5 != 1 ? (Button)(this.Controls.Find("button" + (id - 6), true)[0]) : null;//up left
            komşu[3] = id <= 20 ? (Button)(this.Controls.Find("button" + (id + 5), true)[0]) : null; //down
            komşu[4] = id <= 19 && id % 5 != 0 ? (Button)(this.Controls.Find("button" + (id + 6), true)[0]) : null; //down rigth            
            komşu[5] = id <= 20 && id % 5 != 1 ? (Button)(this.Controls.Find("button" + (id + 4), true)[0]) : null;//down left     
            komşu[6] = id % 5 != 1 ? (Button)(this.Controls.Find("button" + (id - 1), true)[0]) : null; //left
            komşu[7] = id % 5 != 0 ? (Button)(this.Controls.Find("button" + (id + 1), true)[0]) : null; //rigth


            return komşu; 
        }
    
        
        private void komsularKontrulEt(int id , Button[] komşu , Button btn)
        {
            int sayici = 0;
            if (komşu[0] != null && ctrl[id - 6] == true) 
            {
                sayici++;
            }
            if (komşu[1] != null && ctrl[id - 5] == true)
            {
                sayici++;
            }
            if (komşu[2] != null && ctrl[id - 7] == true)
            {
                sayici++;
            }
            if (komşu[3] != null && ctrl[id + 4] == true)
            {
                sayici++;
            }
            if (komşu[4] != null && ctrl[id + 5] == true)
            {
                sayici++;
            }
            if (komşu[5] != null && ctrl[id + 3] == true)
            {
                sayici++;
            }
            if (komşu[6] != null && ctrl[id - 2] == true)
            {
                sayici++;
            }
            if (komşu[7] != null && ctrl[id] == true)
            {
                sayici++;
            }
            

            if (ctrl[id - 1])
            {
                btn.BackColor = Color.Red;
                btn.Text = sayici.ToString();
                string str = "Oyun bitti ";
               MessageBox.Show(str);
            }
            else
            {
                btn.BackColor = Color.Green;
                btn.Text = sayici.ToString();
                lbl_sanye.Text = nud_2.Value.ToString();
                sayici2++;
                if ( 25 - sayici2 == nud_1.Value)
                {
                    DialogResult result = MessageBox.Show("teprikler kazandınız yeniden başlatmak istermisiniz ? ","yeni başlamak ", MessageBoxButtons.YesNo );
                    if (result ==DialogResult.Yes)
                    {
                        sifirla("yeni başlamak");
                      
                    }
                }
            }

        }

       
        private void sifirla(string str)
        {
            timer1.Stop();
            string message = "“yeni olun başlatmak istediğinizden emin misiniz?";
            string title = str;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                btn_hazirla();
                foreach (var item in panel1.Controls)
                {
                    Button button = (Button)item;
                    button.BackColor = Color.DimGray;
                    button.Text = "";
                }
                sayici2 = 0;
                sure = (int)nud_2.Value +1;
                timer1.Start();
            }
        }

        // 2.soru
        private void btn_bul_Click(object sender, EventArgs e)
        {
            if (txt_alt.Text == "" || txt_ust.Text == "")
            {
                MessageBox.Show("Alt Sınır ve Üst Sınırı  belirleyiniz !!!");
            }

            else
            {

                listBox1.Items.Clear();
                int alt, ust;
                alt = Convert.ToInt32(txt_alt.Text);
                ust = int.Parse(txt_ust.Text);

                for (int i = alt; i <= ust; i++)
                {
                    string num_str = i.ToString();
                    int basamak = num_str.Length;
                    int toplam = 0;

                    for (int j = 0; j < basamak; j++)
                    {
                        double taban = double.Parse(num_str[j].ToString());
                        toplam += (int)Math.Pow(taban, basamak);
                    }
                    if (i == toplam)
                    {
                        listBox1.Items.Add(i);
                    }
                }
            }
        }


        
        private void txt_alt_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(txt_alt.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen yalnızca rakam girin.");
                txt_alt.Text = txt_alt.Text.Remove(txt_alt.Text.Length - 1);
            }
        }

        
        private void txt_ust_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_ust.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen yalnızca rakam girin.");
                txt_ust.Text = txt_ust.Text.Remove(txt_ust.Text.Length - 1);
            }
        }

        private void nud_mayin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nud_2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void grp_parametre_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_sure_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
