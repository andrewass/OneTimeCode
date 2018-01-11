using System;
using System.Data.SqlClient;
using System.Web.UI;


namespace OneTimeCode {
    public partial class SubmitCodeForm : Page {

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=Randombase;Trusted_Connection=True";
        private SqlConnection connection;

        protected void Page_Load(object sender, EventArgs e) {
            connection = new SqlConnection(connectionString);
        }


        /* When the submit button is clicked, activate the submitted code, unless it is
         * previously activated or incorrect */
        protected void submit_Click(object sender, EventArgs e) {
            if(ActivationCodeExists()) {
                if(GetActivationStatus() == 0) {
                    ActivateCode();
                    Response.Redirect("ReceipeForm.aspx");
                }
                else {
                    Response.Write("<script>alert('Submitted code is previously activated')</script>");
                }
            }
            else {
                Response.Write("<script>alert('Incorrect activation code')</script>");
            }
        }


        /* Activate the submitted code by setting Activated to 1 in the corresponding record 
         * in the WiFiAccess table */
        private void ActivateCode() {
            connection.Open();
            string queryString = "update WiFiAccess " +
                "set Activated = 1 " +
                "where Accesscode = @accesscode";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@accesscode", activationCode.Text);
            command.ExecuteNonQuery();
            connection.Close();

        }


        //Return 0 if the activation code is not previously activated, else return 1 */
        private int GetActivationStatus() {
            int status = 0;
            connection.Open();
            string queryString = "select Activated from WiFiAccess where Accesscode = @accesscode";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@accesscode", activationCode.Text);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) {
                status = (int)reader["Activated"];
            }
            reader.Close();
            connection.Close();
            return status;
        }



        /* Returns true if the activation code in the textbox exists in the database,
         * else false is returned */
        private bool ActivationCodeExists() {
            bool result = false;
            connection.Open();
            string queryString = "select count(1) from WiFiAccess where Accesscode = @accesscode";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@accesscode", activationCode.Text);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) {
                if((int)reader[0] == 1) {
                    result = true;
                }
            }
            reader.Close();
            connection.Close();
            return result;
        }

    }
}