using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHos.Presentation.Forms
{
    public partial class AssignWorkOrder : Form
    {

        private IManteHosService service;
        private Incident selectedIncident;
        private WorkOrder currentWorkOrder;
        private BindingSource incidentsBindingSource = new BindingSource();

        public AssignWorkOrder(IManteHosService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void AssignWorkOrder_Shown(object sender, EventArgs e)
        {
            LoadIncidents();
        }

        private void LoadIncidents()
        {
            try
            {
                // Case 5, Step 2: System searches and shows incidents assigned to the Master's area
                // This now uses the real ID passed from the parent form
                var incidents = service.GetPendingIncidentsForLoggedMaster();

                incidentsBindingSource.DataSource = incidents;
                dataGridView1.DataSource = incidentsBindingSource;

                // Format grid columns to hide internal objects if necessary
                if (dataGridView1.Columns["WorkOrder"] != null) dataGridView1.Columns["WorkOrder"].Visible = false;
                if (dataGridView1.Columns["Employee"] != null) dataGridView1.Columns["Employee"].Visible = false;
                if (dataGridView1.Columns["Area"] != null) dataGridView1.Columns["Area"].Visible = false;

                //Clear any previous selection
                ClearSelection();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0)
           {
               SelectIncident(e.RowIndex);
           }
        }

        private void SelectIncident(int rowIndex)
        {
            try
            {
                selectedIncident = dataGridView1.Rows[rowIndex].DataBoundItem as Incident;

                if (selectedIncident != null)
                {
                    // Shows the incident information (have to complete)
                    currentWorkOrder = service.GetWorkOrderRelatedToIncident(selectedIncident);

                    // If there is no workorder associated it asks if you want to create one
                    if (currentWorkOrder == null)
                    {
                        DialogResult result = MessageBox.Show(
                            "There is no Work Order for this incident. Do you want to create one?",
                            "Create Work Order",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            currentWorkOrder = service.CreateWorkOrder(selectedIncident);
                            RefreshOperatorLists();
                        }
                        else
                        {
                            ClearSelection();
                        }
                    }
                    else
                    {
                        RefreshOperatorLists();
                    }
                }
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOperatorLists()
        {
            if (currentWorkOrder == null) return;

            //Show assigned operators and available operators

            // 1. Assigned Operators ListBox
            listBoxAssignedOps.DataSource = null;
            listBoxAssignedOps.DataSource = currentWorkOrder.Operators.ToList();
            listBoxAssignedOps.DisplayMember = "FullName";
            listBoxAssignedOps.ValueMember = "Id";

            // 2. Available Operators ComboBox
            var availableOps = service.GetAvailableOperatorsForWorkOrder(currentWorkOrder);
            comboBoxAvailableOps.DataSource = null;
            comboBoxAvailableOps.DataSource = availableOps;
            comboBoxAvailableOps.DisplayMember = "FullName";
            comboBoxAvailableOps.ValueMember = "Id";
        }

        private void ClearSelection()
        {
            selectedIncident = null;
            currentWorkOrder = null;
            listBoxAssignedOps.DataSource = null;
            comboBoxAvailableOps.DataSource = null;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveOperator_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentWorkOrder != null && listBoxAssignedOps.SelectedItem != null)
                {
                    Operator opToRemove = listBoxAssignedOps.SelectedItem as Operator;
                    service.RemoveOperatorFromWorkOrder(currentWorkOrder, opToRemove.Id);
                    RefreshOperatorLists();
                }
                else
                {
                    MessageBox.Show("Please select an assigned Operator to remove.");
                }
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error Removing Operator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentWorkOrder != null && comboBoxAvailableOps.SelectedItem != null)
                {
                    Operator opToAdd = comboBoxAvailableOps.SelectedItem as Operator;

                   
                    service.AddOperatortoWorkOrder(currentWorkOrder, opToAdd.Id);
                    RefreshOperatorLists();
                }
                else
                {
                    MessageBox.Show("Please select a Work Order and an Operator first.");
                }
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error Adding Operator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}