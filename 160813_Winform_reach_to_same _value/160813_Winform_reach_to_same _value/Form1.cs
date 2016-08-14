using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160813_Winform_reach_to_same__value
{
    public partial class Form1 : Form
    {
        Dictionary<int, Value> values =
         new Dictionary<int, Value>();
        
        Random rnd = new Random();
        Stack<Value> stackVal=new Stack<Value>();
        public Form1()
        {
            InitializeComponent();
        }
        public int intNmrcRepo;
        private void btnCatch_Click(object sender, EventArgs e)
        {
            values.Clear();
            intNmrcRepo=Convert.ToInt32(nmrcRePo.Value);
            ValueCheck();
            if (ValueCheckStatus())
                return;
            bool check=true;
            while (check)// dogruysa devam et degilse  çık
            {
                int temp = Smaller();
                values.ElementAt(temp - 1).Value.element++;
               foreach (KeyValuePair<int,Value> T in values)
               {
                   if (T.Key==temp)
                   {
                       T.Value.Increment(true, Convert.ToInt32(nmrcMaTaPo.Value), Convert.ToInt32(nmrcOtTaPo.Value));
                   }
                   else
                   {
                       T.Value.Increment(false, Convert.ToInt32(nmrcMaTaPo.Value),Convert.ToInt32(nmrcOtTaPo.Value));
                   }
                   
               }
                
                foreach (Value item in values.Values)
                {
                    if (!(item.Count >= intNmrcRepo)) { 
                        check = true;
                        break;
                    }
                    check = false;// bitti.
                }
            }
            string s="";
            foreach (var item in values.Values)
            {
               s+=item.Name+":\t"+ item.element.ToString()+" turn\t Value="+item.Count+"\n";
            }
            MessageBox.Show(s,"I Catched It");
           
        }
        private bool ValueCheckStatus()
        {
            if (intNmrcRepo == 0)
            {
                MessageBox.Show("Reach Point must be different from 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (Convert.ToInt32(nmrcMaTaPo.Value)==0)
            {
                MessageBox.Show("Main Task Point must be different from 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (Convert.ToInt32(nmrcOtTaPo.Value) == 0)
            {
                MessageBox.Show("Other's Task Point must be different from 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (values.Count < 2)
            {
                MessageBox.Show("At least two elements must be different from 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            foreach (Value item in values.Values)
            {
                if (item.Count >= intNmrcRepo) { 
                    MessageBox.Show("Values can not be greater than Reach Point!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
               }
            }
            return false;
        }
        private void ValueCheck()
        {
            var nmrcs = groupNmrc.Controls.OfType<NumericUpDown>();
            

            int counter=1;
            foreach (NumericUpDown rb in nmrcs)
            {
                if (rb.Value != 0)
                {
                    Value temp=new Value(Convert.ToInt32(rb.Value),"Value "+rb.Name.Split('l')[1]);
                    values.Add(counter++,temp );
                }
                else
                    rb.Tag = "bos";
            }
        }
        private int Smaller()
        {
            int buffer=1000000;
            int ret=-1;
            foreach (KeyValuePair<int,Value> item in values)
            {
                if (item.Value.Count < buffer){
                    buffer = item.Value.Count;
                    ret = item.Key;
                }
            }
            return ret;
        }
    } 
}
