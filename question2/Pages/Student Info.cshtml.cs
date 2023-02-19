using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace question2.Pages
{
    public class Student_InfoModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-CNIBSBF\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";

            cnn = new SqlConnection(connetionString);

            cnn.Open();

            
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM Students";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "<br/>" + dataReader.GetValue(1) + "<br/>" + dataReader.GetValue(2) + "<br/>" + dataReader.GetValue(3) + "<br/>"+dataReader.GetValue(4) + "<br/>"+ dataReader.GetValue(5) + "<br/>";
            }

            Response.WriteAsync(Output);

            cnn.Close();
        }
    
    }
}
