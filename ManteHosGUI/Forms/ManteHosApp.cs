using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManteHos.Presentation.Forms;
using ManteHos.Services;

namespace ManteHos.Presentation
{
    public partial class ManteHosApp : ManteHosFormBase
    {
        private loginForm loginForm;
        private Formlogout formlogout;
        private AssignWorkOrder assignWorkOrder;
        private ReportIncidentForm reportIncidentForm;
        private ReviewIncidentForm reviewIncidentForm;
        private CloseWorkOrderForm closeWorkOrderForm;  // Case 7: Close Work Order

        public ManteHosApp() : base()
        {
            InitializeComponent();
        }

        public ManteHosApp(IManteHosService service) : base(service)
        {
            InitializeComponent();
            this.service = service;
            service.DBInitialization();

            this.reportIncidentForm = new ReportIncidentForm(service);
            this.formlogout = new Formlogout(service);
            this.loginForm = new loginForm(service);
            this.assignWorkOrder = new AssignWorkOrder(service);
            this.reviewIncidentForm = new ReviewIncidentForm(service);
            this.closeWorkOrderForm = new CloseWorkOrderForm(service);  // Case 7
        }

        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            loginForm.ShowDialog();
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            formlogout.ShowDialog();
        }

        private void reportMenuItem_Click(object sender, EventArgs e)
        {
            reportIncidentForm.ShowDialog();
        }

        private void reviewMenuItem_Click(object sender, EventArgs e)
        {
            reviewIncidentForm.ShowDialog();
        }

        private void assignMenuItem_Click(object sender, EventArgs e)
        {
            assignWorkOrder.ShowDialog();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            closeWorkOrderForm.ShowDialog();  // Show the Close Work Order form (modal)
        }

        private void ManteHosApp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManteHosApp_Activated(object sender, EventArgs e)
        {
            if (service.IsLogged())
            {
                label1.Text = "Welcome " + service.GetUser();
                label1.Left = (this.ClientSize.Width - label1.Width) / 2;
                label1.Top = (this.ClientSize.Height - label1.Height) / 2;
            }
            else
            {
                label1.Text = "";
            }
        }
    }
}