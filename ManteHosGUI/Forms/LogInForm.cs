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
    public partial class loginForm : ManteHosFormBase
    {
        public loginForm():base()
        {
            InitializeComponent();
        }

        public loginForm(IManteHosService service) : base(service)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //  Read what the user typed
            string username = textUser.Text.Trim();
            string password = textPassword.Text;

            try
            {
                //  Ask the service to log in
                service.LogIn(username, password);

                // 3. If no exception -> login OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ServiceException ex)
            {
                // 4. If the service throws ServiceException,
                // show the error message to the user
                MessageBox.Show(ex.Message,
                                "Login error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
