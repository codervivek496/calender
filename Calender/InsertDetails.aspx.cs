using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calender
{
    public partial class Infopage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=HYDSQLDMO01\TRN01; Database=WI_Training_VivekKumar; Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_XX_PROJECTDETAILS", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter pKey1 = new SqlParameter("@aEMPID", Request.Form["EMPID"]);
            SqlParameter pKey2 = new SqlParameter("@aLOGINTIME", Request.Form["LOGINTIME"]);
            SqlParameter pKey3 = new SqlParameter("@aLOGOUTTIME", Request.Form["LOGOUTTIME"]);
            SqlParameter pKey4 = new SqlParameter("@aPROJECTNAME", Request.Form["PROJECTNAME"]);
            SqlParameter pKey5 = new SqlParameter("@aDESCRIPTION", Request.Form["DESCRIPTION"]);
            cmd.Parameters.Add(pKey1);
            cmd.Parameters.Add(pKey2);
            cmd.Parameters.Add(pKey3);
            cmd.Parameters.Add(pKey4);
            cmd.Parameters.Add(pKey5);

            string str = cmd.ExecuteNonQuery().ToString();
            con.Close();
            
            Response.Write(str);
        }
    }
}