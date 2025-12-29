using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace ManteHos.Presentation.Forms
{
    public partial class ReviewIncidentForm : ManteHosFormBase
    {
        public ReviewIncidentForm() : base()
        {
            InitializeComponent();
        }
        public ReviewIncidentForm(IManteHosService service) : base(service)
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ReviewIncidentForm_Load(object sender, EventArgs e)
        {


            LoadIncidents();
            InitPriorityCombo();
        }
        //filling the priority Combo
        private void InitPriorityCombo()
        {
            comboPriority.Items.Clear();
            comboPriority.Items.Add(Priority.High);
            comboPriority.Items.Add(Priority.Medium);
            comboPriority.Items.Add(Priority.Low);
            comboPriority.SelectedItem = Priority.Medium;
        }
        private void LoadIncidents()
        {
            try
            {
                var incidents = service.GetIncidentsPendingAcceptance();
                IncidentsbindingSource.DataSource = new BindingList<Incident>(incidents.ToList());
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message,
                               "Error loading incidents",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Close();
            }
        }


        private void dataGridViewIncidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RejButton_Click(object sender, EventArgs e)
        {
            //1) know which incident we are selecting 
            var incident = IncidentsbindingSource.Current as Incident;
            if (incident == null)
                return;


            string reason = textReason.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Please enter a rejection reason.",
                                "Missing data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            try
            {
                service.RejectIncident(incident.Id, reason);
                LoadIncidents();
                textReason.Clear();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message,
                       "Error rejecting incident",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }

        }

        private void AccpButton_Click(object sender, EventArgs e)
        {
            //1) know which incident we are selecting 
            var incident = IncidentsbindingSource.Current as Incident;
            if (incident == null)
                return;

            //2)read Area 
            string areaName = textArea.Text.Trim();
            if (string.IsNullOrWhiteSpace(areaName))
            {
                MessageBox.Show("Please enter an area name.",
                                "Missing data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            //3)Read priority 
            if (comboPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority.",
                                "Missing data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            Priority priority = (Priority)comboPriority.SelectedItem;

            try
            {
                //llamar al servicio
                service.AcceptIncident(incident.Id, areaName, priority);

                LoadIncidents();           // refresh the  list
                textArea.Clear();
                textReason.Clear();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message,
                                "Error accepting incident",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }



    }
}