using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManteHos.Services;

namespace ManteHos.Presentation
{
    public partial class ManteHosFormBase : Form
    {
        protected IManteHosService service;
        public ManteHosFormBase(IManteHosService service)
        {
            InitializeComponent();
            this.service = service;
        }
        public ManteHosFormBase()
        {
            InitializeComponent();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ManteHosFormBase_Load(object sender, EventArgs e)
        {

        }
    }
}
