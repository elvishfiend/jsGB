using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csGB
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            LOG.OnLog += LOG_OnLog;

            this.FormClosing += (s, args) => { LOG.OnLog -= LOG_OnLog; };
        }

        private void LOG_OnLog(string log)
        {
            this.MessageBox.AppendText(log);
            if (!log.EndsWith(Environment.NewLine))
                MessageBox.AppendText(Environment.NewLine);
        }
    }
}
