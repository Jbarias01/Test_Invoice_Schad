using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.Controllers;

namespace Test_Invoice_Schad.Views.Customers
{
    public partial class Frm_CustomersDetails : Form
    {
        CustomersController _customersController = new CustomersController();
        public Frm_CustomersDetails()
        {
            InitializeComponent();
        }

        public int customerId = 0;
        public bool fromInvoice = false;

        private void Frm_CustomersDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // *********************************************
                    // ** LLAMAMOS EL METODO PARA OBTENER TODOS LOS
                    // CLIENTES Y CARGARLOS AL DATA GRID VIEW.
                // *********************************************
                GetAllCustomers();

                // *********************************************
                // ** VALIDAMOS LA OPERACION:
                    // 1 - VISUALIZANDO LA LISTA DE CLIENTE DESDE (GESTION DE CLIENTES)
                    // 2 - REALIZANDO BUSQUEDA DESDE EL MODULO DE FACTURACION.
                // *********************************************
                switch (fromInvoice)
                {
                    case true:
                        BtnAddCustomers.Enabled = false;
                        BtnViewCustomers.Enabled = false;
                        BtnEditCustomers.Enabled = false;
                        BtnDeleteCustomers.Enabled = false;
                        break;
                    default:
                        break;
                }
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
        public void GetAllCustomers()
        {
            dataGridView1.DataSource = _customersController.GetAllCustomers();
            decimal CantRegistroData = dataGridView1.Rows.Count;
            LbCantItem.Text = string.Concat("Cantidad De Clientes: " + CantRegistroData);
        }

        private void BtnAddCustomers_Click(object sender, EventArgs e)
        {
            // *********************************************
                // ** INSERTAT NUEVO CLIENTE.
            // *********************************************
            var frm = new Views.Customers.Frm_Customers();
            frm.modo = 1;
            frm.ShowDialog();

            GetAllCustomers();
        }

        
        private void BtnViewCustomers_Click(object sender, EventArgs e)
        {
            // *********************************************
                // ** VISUALIZAR CLIENTE EXISTENTE.
            // *********************************************
            if (dataGridView1.Rows.Count > 0)
            {
                var frm = new Views.Customers.Frm_Customers();
                frm.customerId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;
                frm.modo = 2;
                frm.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void BtnEditCustomers_Click(object sender, EventArgs e)
        {
            // *********************************************
                // ** EDITAR CLIENTE EXISTENTE.
            // *********************************************
            if (dataGridView1.Rows.Count > 0)
            {
                var frm = new Views.Customers.Frm_Customers();
                frm.customerId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;
                frm.modo = 3;
                frm.ShowDialog();

                GetAllCustomers();
            }
            else
            {
                return;
            }
        }

        private void BtnDeleteCustomers_Click(object sender, EventArgs e)
        {
            // *********************************************
                // ** ELIMINAR CLIENTE EXISTENTE (INHABILITAR).
            // *********************************************
            if (dataGridView1.Rows.Count > 0)
            {
                var id = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;

                DialogResult dialogResult2 = MessageBox.Show("¿ESTA SEGURO QUE DESEA INHABILITAR ESTE CLIENTE?"
                    , "E X I T O !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult2 == DialogResult.Yes)
                {
                    _customersController.DeleteCustomer(id);
                    GetAllCustomers();
                }
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
            dataGridView1.DataSource = _customersController.GetCustomersByCustName(TxtBusqueda.Text.Trim());
            decimal CantRegistroData = dataGridView1.Rows.Count;
            LbCantItem.Text = string.Concat("Cantidad De Clientes: " + CantRegistroData);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // *********************************************
                    // ** DEVOLVEMOS EL ID DEL CLIENTE AL FORMULARIO DE 
                    // FACTURACION.
                // *********************************************
                if (dataGridView1.Rows.Count == 0)
                    return;

                int customerId = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;
                var customer = _customersController.GetCustomersByID(customerId);

                if (customer == null)
                    return;

                if (customer.Status == false)
                {
                    MessageBox.Show("¡¡ ESTE CLIENTE ESTA EN ESTADO INACTIVO. !!"
                        , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.customerId = customerId;
                this.Close();
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }
    }
}
