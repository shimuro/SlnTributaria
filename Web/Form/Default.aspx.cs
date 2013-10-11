using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceTributario;

public partial class Form_Default : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}


    private void cargarGrilla()
    {
        using (TributarioClient Client = new TributarioClient())
        {
            List<deuda> lstdeuda = new List<deuda>(Client.deudaListarPaginadoBuscar(txtBusqueda.Text.Trim()));

            lvListado.DataSource = lstdeuda;
            lvListado.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cargarGrilla()
    }
}