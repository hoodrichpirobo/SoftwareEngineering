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
namespace ManteHos.Presentation.Forms
{
    public partial class ReportIncidentForm : ManteHosFormBase
    {
        public ReportIncidentForm()
        {
            InitializeComponent();
        }

        public ReportIncidentForm(IManteHosService service) : base(service)
        {
            InitializeComponent();
            dateField.MaxDate = DateTime.Now;
        }

        private bool AllFieldsValid()
        {
            return !string.IsNullOrEmpty(serviceField.Text) && !string.IsNullOrEmpty(descriptionField.Text);
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            if (AllFieldsValid())
            {
                try
                {
                    service.ReportIncident(dateField.Value, serviceField.Text, descriptionField.Text);
                    MessageBox.Show("Incident reported. Your report will be reviewed by a service head.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (ServiceException ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(this, "Missing fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ReportIncidentForm_Load(object sender, EventArgs e)
        {
            if (!(service.IsLogged()))
            {
                MessageBox.Show(this, "Employee must be logged in to report an incident", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }
    }
}
