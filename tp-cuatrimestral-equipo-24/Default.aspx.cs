﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx");
        }

        protected void btnRecuperarPass_Click(object sender, EventArgs e)
        {

            Response.Redirect("Soporte.aspx");
        }
    }
}