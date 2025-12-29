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
    public partial class Formlogout : Form
    {

        private IManteHosService service;

        public Formlogout(IManteHosService service)
        {
            InitializeComponent();

            this.service = service; 
        }

        private void Formlogout_Load(object sender, EventArgs e)
        {
            // We center the form to the parent (PlaceHolder, could be changed later)

            this.CenterToParent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // "YES" Button Accepts the Logout, executes the service method to complete the action and closes the dialog
        private void yes_logout_Click(object sender, EventArgs e)
        {
            try
            {
                // Calling the service to clear the Logger user
                service.LogOut();

                // Sends an ok if there is no exception
                this.DialogResult = DialogResult.OK;
                this.Close();

                //The logic to tell the program that we have to returnto the Login Form and not the main one will be done in main 
            }
            catch (Exception ex)
            {
                //We show the exception

                MessageBox.Show(ex.Message, "Error");
            }         
        }
    
        private void no_logout_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
