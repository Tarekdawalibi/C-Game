using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vize_odev
{
    public partial class Form2 : Form
    {
       
        public Form2(Panel p )
        {
            InitializeComponent();

            foreach (var item in p.Controls)
            {
                Button button = (Button)item;
                panel2.Controls.Add(button);
            }
        }

      
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
    }
 }

