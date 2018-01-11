using System;
using System.Data.SqlClient;
using System.Web.UI;


namespace OneTimeCode {
    public partial class SignIn : Page {

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=Randombase;Trusted_Connection=True";
        private SqlConnection connection;

        protected void Page_Load(object sender, EventArgs e) {
            connection = new SqlConnection(connectionString);
        }

        /* When user submits name and phone number, an access code is generated, 
         * and user is redirected to a new page for submitting the received access code */
        protected void submit_Click(object sender, EventArgs e) {
            setAccessCode();
            Response.Redirect("SubmitCodeForm.aspx");
        }


        /* Generate a new access code, store it as a record in the WiFiAccess table, along
         * with name and phone number of the user  */
        private void setAccessCode() {
            int accessCode = new Random().Next(1, Int32.MaxValue);
            string queryString = "insert into WiFiAccess "+
                "(Firstname, Lastname, Phonenumber, Accesscode, Activated) " +
                "values (@firstname, @lastname, @phonenumber, "+accessCode+", 0)";
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@firstname", firstName.Text);
            command.Parameters.AddWithValue("@lastname", lastName.Text);
            command.Parameters.AddWithValue("@phonenumber", phoneNumber.Text);
            command.ExecuteNonQuery();
        }
    }
}