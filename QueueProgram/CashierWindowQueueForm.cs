using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueProgram
{
    public partial class CashierWindowQueueForm : Form
    {

        private int _tick;

        public CashierWindowQueueForm()
        {
            InitializeComponent();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();

        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
                
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _tick++;
                label1.Text = _tick.ToString();
                if (_tick == 10)
                {
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                    timer1.Stop();
                    _tick = 0;
                }
            }
            catch (System.InvalidOperationException)
            {
                timer1.Stop();
                MessageBox.Show("No Remaining Queue Available.", "Message");
                _tick = 0;
            }
        }
    }
}
