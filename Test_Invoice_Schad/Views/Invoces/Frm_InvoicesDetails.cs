using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice_Schad.Infrastructure.Controllers;

namespace Test_Invoice_Schad.Views.Invoces
{
    public partial class Frm_InvoicesDetails : Form
    {
        private InvoicesController _invoicesController = new InvoicesController();
        public Frm_InvoicesDetails()
        {
            InitializeComponent();
        }

        private void Frm_InvoicesDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // *********************************************
                // ** LLAMAMOS EL METODO PARA OBTENER TODOS LOS
                // CLIENTES Y CARGARLOS AL DATA GRID VIEW.
                // *********************************************
                GetAllInvoices();
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }

        // *********************************************
        // ** METODO PARA OBTENER TODOS LOS CLIENTES Y CARGARLOS 
        // AL DATA GRID VIEW.
        // *********************************************
        public void GetAllInvoices()
        {
            dataGridView1.DataSource = _invoicesController.GetAllInvoices();
            decimal CantRegistroData = dataGridView1.Rows.Count;
            LbCantItem.Text = string.Concat("Cantidad De Facturas: " + CantRegistroData);
        }
                
        private void BtnAddInvoices_Click(object sender, EventArgs e)
        {
            new Frm_Invoices().ShowDialog();
            GetAllInvoices();
        }

        private void BtnViewinvoices_Click(object sender, EventArgs e)
        {
            // *********************************************
            // ** VISUALIZAR FACTURA EXISTENTE.
            // *********************************************
            if (dataGridView1.Rows.Count > 0)
            {
                var frm = new Frm_Invoices();
                frm.invoicesId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;
                frm.modo = 2;
                frm.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            // *********************************************
            // ** LLAMAMOS AL CONTROLADOR Y HACEMOS UNA CONSULTA CON
            // EL NOMBRE DEL CLIENTE Y ACTUALIZAMOS EL DATA GRID VIEW.
            // *********************************************
            dataGridView1.DataSource = _invoicesController.GetInvoicesByCustName(TxtBusqueda.Text.Trim());
            decimal CantRegistroData = dataGridView1.Rows.Count;
            LbCantItem.Text = string.Concat("Cantidad De Clientes: " + CantRegistroData);
        }
    }
}
