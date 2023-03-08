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
using Test_Invoice_Schad.Infrastructure.DTOs;

namespace Test_Invoice_Schad.Views.Customers
{
    public partial class Frm_Customers : Form
    {
        private CustomersTypesController _customersTypesController = new CustomersTypesController();
        private CustomersController _customersController = new CustomersController();

        public Frm_Customers()
        {
            InitializeComponent();
        }

        public int customerId = 0;
        public int modo = 0;

        private void Frm_Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                // ********************************************
                    // ** CREACION DE DATATABLE  
                // ********************************************
                DataTable dsEstados = new DataTable("estados");
                dsEstados.Columns.Add("codigo", typeof(int));
                dsEstados.Columns.Add("descripcion", typeof(string));

                // ********************************************
                    // ** AGREGAR COLUMNAS AL DATATABLE (ACTIVO Y INACTIVO)
                // ********************************************
                dsEstados.Rows.Add(new object[] { 0, "INACTIVO" });
                dsEstados.Rows.Add(new object[] { 1, "ACTIVO" });

                // ********************************************
                    // ** AGREGAR DATOS DEL DATATABLE A COMBOBOX
                // ********************************************
                CbStatus.DataSource = dsEstados;
                CbStatus.ValueMember = "codigo";
                CbStatus.DisplayMember = "descripcion";
                CbStatus.SelectedIndex = 1;

                // ********************************************
                    // SE EJECUTA EL CONTROLADOR DE CUSTOMERS TYPES PAR OBTENER UN 
                    // LISTADO DE TIPOS DE CLIENTE Y AGREGARLOS AL COMBOBOX
                // ********************************************
                CbCustomerTypes.DataSource = _customersTypesController.GetAllCustomerTypes();
                CbCustomerTypes.DisplayMember = "Description";
                CbCustomerTypes.ValueMember = "Id";
                CbCustomerTypes.SelectedValue = 1;

                // ********************************************
                    //SE VALIDA EL TIPO DE OPERACION:
                    //(1 - INSERTAR 
                    // 2 - VISUALIZAR
                    // 3 - EDITAR (DEFAULT)
                // ********************************************
                switch (modo)
                {
                    case 1: // INSERTAR
                        CbStatus.Enabled = false;
                        break;
                    case 2: // VISUALIZAR
                        ViewCustomers();
                        BtnGuardar.Enabled = false;
                        TxtCustName.Enabled = false;
                        TxtAdress.Enabled = false;
                        CbCustomerTypes.Enabled = false;
                        CbStatus.Enabled = false;
                        break;
                    default: // EDITAR
                        EditCustomers();
                        BtnGuardar.Text = string.Concat("Editar Cliente");
                        break;
                }
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. Algo salio mal, error en la aplicación: {_error.Message}");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // ********************************************
                    // ** SE REALIZAN UNA VALIDACION DE QUE TODOS
                    // LOS CAMPOS REQUERIDOS FUERON LLENADOS.
                // ********************************************
                if (!(CustomersFormValidations()))
                    return;

                // ********************************************
                    // ** SE CREA EL DTO DE CLIENTE CON LA INFORMACION
                    // SUMINISTRADA DEL FORMULARIO CLIENTE.
                // ********************************************
                var customersDTO = new CustomersDTO()
                {
                    CustName = TxtCustName.Text.ToUpper().Trim(),
                    Adress = TxtAdress.Text.ToUpper().Trim(),
                    CustomerTypeId = (int)CbCustomerTypes.SelectedValue,
                    Status = (CbStatus.SelectedIndex == 1 ? true : false)
                };

                // ********************************************
                    // ** SE VALIDA LA OPERACION PARA DETERMINAR SI
                    // ES UN CLIENTE NUEVO O SE ESTA EDITANDO UN CLIENTE EXISTENETE.
                // ********************************************
                switch (modo)
                {
                    case 1:
                        _customersController.AddCustomer(customersDTO);
                        MessageBox.Show("¡¡ EL CLIENTES FUE REGISTRADO SATISFACTORIAMENTE. !!"
                            , "E X I T O !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TxtCustName.Clear();
                        TxtAdress.Clear();
                        CbCustomerTypes.SelectedValue = 1;

                        TxtCustName.Focus();
                        break;
                    default:
                        _customersController.UpdateCustomer(customerId, customersDTO);
                        MessageBox.Show("¡¡ EL CLIENTES FUE EDITADO SATISFACTORIAMENTE. !!"
                                , "E X I T O !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                        break;
                }
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. Algo salio mal, error en la aplicación: {_error.Message}");
            }
        }

        // ********************************************
            // ** METODO PARA VALIDAR LOS DATOS DEL FOMULARIO   
        // ********************************************
        public Boolean CustomersFormValidations()
        {
            if (string.IsNullOrEmpty(TxtCustName.Text))
            {
                MessageBox.Show("¡¡ DEBE ASIGNAR UN NOMBRE PARA ESTE CLIENTE. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCustName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtAdress.Text))
            {
                MessageBox.Show("¡¡ DEBE ASIGNAR UNA DIRECCION PARA ESTE CLIENTE. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAdress.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(CbCustomerTypes.Text))
            {
                MessageBox.Show("¡¡ DEBE ESPECIFICAR UN TIPO DE CLIENTE. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CbCustomerTypes.Focus();
                return false;
            }

            return true;
        }

        public void ViewCustomers()
        {
            try
            {
                // ********************************************
                    // ** OBTENEMOS LOS DATOS DEL CLIENTE DESDE EL CONTROLADOR
                // ********************************************
                var customer = _customersController.GetCustomersByID(customerId);
                if (customer == null)
                    return;

                // ********************************************
                    // ** ASIGNAMOS LOS DATOS OBTENIDOS A LOS TEXTBOX DEL FORMULARIO CLIENTE
                // ********************************************
                TxtCustName.Text = customer.CustName;
                TxtAdress.Text = customer.Adress;
                CbCustomerTypes.SelectedValue = customer.CustomerTypeId;
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. Algo salio mal, error en la aplicación: {_error.Message}");
            }
        }

        public void EditCustomers()
        {
            try
            {
                // ********************************************
                // ** OBTENEMOS LOS DATOS DEL CLIENTE DESDE EL CONTROLADOR
                // ********************************************
                var customer = _customersController.GetCustomersByID(customerId);
                if (customer == null)
                    return;

                // ********************************************
                // ** ASIGNAMOS LOS DATOS OBTENIDOS A LOS TEXTBOX DEL FORMULARIO CLIENTE
                // ********************************************
                TxtCustName.Text = customer.CustName;
                TxtAdress.Text = customer.Adress;
                CbCustomerTypes.SelectedValue = customer.CustomerTypeId;
                CbStatus.SelectedValue = (customer.Status == true ? 1 : 0);
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. Algo salio mal, error en la aplicación: {_error.Message}");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            // ********************************************
                // ** CERRAMOS EL FORMULARIO.
            // ********************************************
            this.Close();
        }
    }
}
