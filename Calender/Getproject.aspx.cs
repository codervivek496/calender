using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calender
{
    public partial class Getproject1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Getproject2> list = new List<Getproject2>();
            SqlConnection con = new SqlConnection(@"Server=HYDSQLDMO01\TRN01; Database=WI_Training_VivekKumar; Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select projectname from projectdetails", con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                list.Add(new Getproject2()
                {
                    PROJECTNAME = Convert.ToString(dataReader["projectname"])
                });
            }

            string strproject = JsonConvert.SerializeObject(list);
            Response.Write(strproject);
            con.Close();



        }
    }
}