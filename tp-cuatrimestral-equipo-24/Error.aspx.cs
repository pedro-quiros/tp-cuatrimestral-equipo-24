﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace tp_cuatrimestral_equipo_24
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Error"] != null)
            {
                lblmenssaje.Text = Session["Error"].ToString();
            }
            Session["Error"] = null;

        }

        protected void txtvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroLogin.aspx");
        }
    }
}
