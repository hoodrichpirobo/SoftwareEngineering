using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ManteHos.Entities;
using ManteHos.Services;

namespace ManteHos.Presentation.Forms
{
    public partial class CloseWorkOrderForm : ManteHosFormBase
    {
        public CloseWorkOrderForm() { InitializeComponent(); }

        public CloseWorkOrderForm(IManteHosService service) : base(service) { InitializeComponent(); }

        // Load work orders automatically when the form is shown
        private void CloseWorkOrderForm_Shown(object sender, EventArgs e)
        {
            LoadWorkOrders();
        }

        private void LoadWorkOrders()
        {
            try
            {
                var workOrders = service.GetOpenWorkOrdersForLoggedOperator();

                var bindingList = new BindingList<object>();
                foreach (var wo in workOrders)
                {
                    bindingList.Add(new
                    {
                        ds_Id = wo.Id,
                        ds_StartDate = wo.StartDate.ToString("dd/MM/yyyy HH:mm"),
                        ds_IncidentDescription = wo.Incident?.Description ?? "N/A",
                        ds_Department = wo.Incident?.Department ?? "N/A"
                    });
                }

                workOrdersBindingSource.DataSource = bindingList;
                repairReportTextBox.Clear();

                if (!workOrders.Any())
                    MessageBox.Show("No open work orders found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void closeWorkOrderButton_Click(object sender, EventArgs e)
        {
            if (workOrdersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a work order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string repairReport = repairReportTextBox.Text.Trim();
            if (string.IsNullOrEmpty(repairReport))
            {
                MessageBox.Show("Please enter a repair report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int workOrderId = (int)workOrdersDataGridView.SelectedRows[0].Cells["colId"].Value;

            try
            {
                service.CloseWorkOrder(workOrderId, repairReport);
                MessageBox.Show("Work order closed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkOrders(); // Reload the list
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) { Close(); }
    }
}