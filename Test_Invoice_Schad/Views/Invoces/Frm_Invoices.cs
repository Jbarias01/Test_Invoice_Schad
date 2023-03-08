using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.Controllers;
using Test_Invoice_Schad.Infrastructure.DTOs;
using Test_Invoice_Schad.Views.Customers;

namespace Test_Invoice_Schad.Views.Invoces
{
    public partial class Frm_Invoices : Form
    {
        private delegate void ActualizarTotales(List<InvoicesDetailsDTO> InvoicesDetailsDTO);
        private CustomersController _customersController = new CustomersController();
        private InvoicesController _invoicesController = new InvoicesController();
        private List<InvoicesDetailsDTO> _invoicesDetail = new List<InvoicesDetailsDTO>();

        public Frm_Invoices()
        {
            InitializeComponent();
        }

        public int invoicesId = 0;
        public int modo = 0;    

        private void Frm_Invoices_Load(object sender, EventArgs e)
        {
            TxtCustomerID.Select();
            TxtCustomerID.Focus();

            // ********************************************
            //SE VALIDA EL TIPO DE OPERACION:
            //(1 - INSERTAR 
            // 2 - VISUALIZAR
            // 3 - EDITAR (DEFAULT)
            // ********************************************
            switch (modo)
            {
                case 2: // VISUALIZAR
                    ViewInvoices();
                    TxtCustomerID.Enabled= false;
                    TxtCustName.Enabled = false;
                    TxtAdress.Enabled = false;

                    TxtQty.Enabled = false;
                    TxtPrice.Enabled = false;
                    TxtSubTotal.Enabled = false;
                    TxtImpuesto.Enabled = false;
                    TxtTotal.Enabled = false;

                    TxtImporte.Enabled = false;
                    TxtItbis.Enabled = false;
                    TxtNeto.Enabled = false;

                    BtnCustomersList.Enabled = false;
                    BtnGuardar.Enabled = false;
                    BtnAdd.Enabled = false;
                    break;
                default: // EDITAR
                    break;
            }
        }

        private void BtnCustomersList_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Frm_CustomersDetails();
                frm.fromInvoice = true;
                frm.ShowDialog();
                int customerId = Convert.ToInt32(frm.customerId);

                if (string.IsNullOrEmpty(customerId.ToString()))
                    return;

                var customer = _customersController.GetCustomersByID(customerId);

                if (customer == null)
                    return;

                if (customer.Status == false)
                {
                    MessageBox.Show("¡¡ ESTE CLIENTE ESTA EN ESTADO INACTIVO. !!"
                        , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TxtCustomerID.Text = customer.Id.ToString();
                TxtCustName.Text = customer.CustName.ToString().ToUpper().Trim();
                TxtAdress.Text = customer.Adress.ToString().ToUpper().Trim();

                TxtQty.Select();
                TxtQty.Focus();
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }

        private void TxtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    if (!(SoloNumeros(TxtCustomerID.Text)))
                    {
                        MessageBox.Show("¡¡ SOLO SE PERMITEN NUMEROS. !!"
                            , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TxtCustomerID.Focus();
                        TxtCustomerID.Select();
                        return;
                    }

                    int customerId = int.Parse(TxtCustomerID.Text);
                    var customer = _customersController.GetCustomersByID(customerId);

                    if (customer == null)
                    {
                        MessageBox.Show("!! NO SE ENCONTRO NINGUN CLIENTE CON ESTA REFERENCIA, " +
                            "VAYA A LA LISTA DE CLIENTES Y VEREFICIQUE SI LA REFERENCIA ES LA CORRECTA. !!"
                            , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TxtCustomerID.Text = customerId.ToString();
                        TxtCustomerID.Focus();
                        TxtCustomerID.Select();
                        return;
                    }

                    if (customer.Status == false)
                    {
                        MessageBox.Show("¡¡ ESTE CLIENTE ESTA EN ESTADO INACTIVO. !!"
                            , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    TxtCustomerID.Text = customer.Id.ToString();
                    TxtCustName.Text = customer.CustName.ToString().ToUpper().Trim();
                    TxtAdress.Text = customer.Adress.ToString().ToUpper().Trim();

                    TxtQty.Select();
                    TxtQty.Focus();
                }
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }

        public static Boolean SoloNumeros(string Campo)
        {
            decimal Result = 0;
            if (!decimal.TryParse(Campo, out Result))
            {
                return false;
            }
            return true;
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (!(SoloNumeros(TxtQty.Text)))
                {
                    MessageBox.Show("¡¡ SOLO SE PERMITEN NUMEROS. !!"
                        , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtQty.Focus();
                    TxtQty.Select();
                    return;
                }

                //decimal Cant = Convert.ToDecimal(TxtQty.Text);
                //TxtQty.Text = Cant.ToString("###,##0.00");

                TxtPrice.Focus();
                TxtPrice.Select();
            }
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (!(SoloNumeros(TxtPrice.Text)))
                {
                    MessageBox.Show("¡¡ SOLO SE PERMITEN NUMEROS. !!"
                        , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPrice.Focus();
                    TxtPrice.Select();
                    return;
                }

                double qty = Convert.ToDouble(TxtQty.Text);
                double price = Convert.ToDouble(TxtPrice.Text);

                double subTotal = 0;
                double total = qty * price;

                double itbis = 1.18;
                itbis = (itbis * total);
                itbis = itbis - total;

                total = total + itbis;
                subTotal = total - itbis;

                TxtPrice.Text = price.ToString("###,##0.00");
                TxtSubTotal.Text = subTotal.ToString("###,##0.00");
                TxtImpuesto.Text = itbis.ToString("###,##0.00");
                TxtTotal.Text = total.ToString("###,##0.00");

                BtnAdd.Select();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(CustomersFormValidationsDetail()))
                    return;

                _invoicesDetail.Add(new InvoicesDetailsDTO()
                {
                    Qty = int.Parse(TxtQty.Text),
                    Price = Convert.ToDecimal(TxtPrice.Text),
                    SubTotal = Convert.ToDecimal(TxtTotal.Text) - Convert.ToDecimal(TxtImpuesto.Text),
                    TotalItbis = Convert.ToDecimal(TxtImpuesto.Text),
                    Total = Convert.ToDecimal(TxtTotal.Text)
                });

                BindingSource source = new BindingSource();
                source.DataSource = _invoicesDetail;
                dataGridView1.DataSource = source;

                CalcularTotal(_invoicesDetail);

                TxtQty.Clear();
                TxtPrice.Clear();
                TxtSubTotal.Clear();
                TxtImpuesto.Clear();
                TxtTotal.Clear();

                TxtQty.Focus();
                TxtQty.Select();
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }

        public Boolean CustomersFormValidationsDetail()
        {
            if (string.IsNullOrEmpty(TxtQty.Text))
            {
                MessageBox.Show("¡¡ DEBE ASIGNAR UNA CANTIDAD PARA PROCEDER CON LA FACTURA. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQty.Text = "0.00";
                TxtQty.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtPrice.Text))
            {
                MessageBox.Show("¡¡ DEBE ASIGNAR UN PRECIO PARA PROCEDER CON LA FACTURA. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPrice.Text = "0.00";
                TxtPrice.Focus();
                return false;
            }

            if (TxtQty.Text.Equals("0.00"))
            {
                MessageBox.Show("¡¡ LA CANTIDAD DEBE SER DIFERENTE A CERO (0.00) PARA PROCEDER CON LA FACTURA. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQty.Text = "0.00";
                TxtQty.Focus();
                return false;
            }

            if (TxtPrice.Text.Equals("0.00"))
            {
                MessageBox.Show("¡¡ EL PRECIO DEBE SER DIFERENTE A CERO (0.00) PARA PROCEDER CON LA FACTURA. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPrice.Text = "0.00";
                TxtPrice.Focus();
                return false;
            }

            return true;
        }

        public void CalcularTotal(List<InvoicesDetailsDTO> InvoicesDetailsDTO)
        {
            if (InvoicesDetailsDTO == null)
                return;

            double subTotal = Convert.ToDouble(InvoicesDetailsDTO.Sum(c => c.SubTotal));
            TxtImporte.Text = subTotal.ToString("###,##0.00");

            double impuesto = Convert.ToDouble(InvoicesDetailsDTO.Sum(c => c.TotalItbis));
            TxtItbis.Text = impuesto.ToString("###,##0.00");

            double total = Convert.ToDouble(InvoicesDetailsDTO.Sum(c => c.Total));
            TxtNeto.Text = total.ToString("###,##0.00");
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(CustomersFormValidations()))
                    return;

                var customersDTO = new InvoicesDTO()
                {
                    CustomerId = int.Parse(TxtCustomerID.Text),
                    TotalItbis = Convert.ToDecimal(TxtItbis.Text),
                    SubTotal = Convert.ToDecimal(TxtImporte.Text),
                    Total = Convert.ToDecimal(TxtNeto.Text),
                    InvoicesDetails = _invoicesDetail
                };

                _invoicesController.AddInvoices(customersDTO);

                MessageBox.Show("¡¡ FACTURA REGISTRADA SATISFACTORIAMENTE. !!"
                    , "E X I T O !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _invoicesDetail = null;

                BindingSource source = new BindingSource();
                source.DataSource = _invoicesDetail;
                dataGridView1.DataSource = source;

                TxtCustomerID.Text = string.Empty;
                TxtCustName.Text = string.Empty;
                TxtAdress.Text = string.Empty;

                TxtQty.Text = "0.00";
                TxtPrice.Text = "0.00";
                TxtSubTotal.Text = "0.00";
                TxtImpuesto.Text = "0.00";
                TxtTotal.Text = "0.00";

                TxtImporte.Text = "0.00";
                TxtItbis.Text = "0.00";
                TxtNeto.Text = "0.00";
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. ha ocurrido un error en la aplicación: {_error.ToString()}");
            }
        }

        public Boolean CustomersFormValidations()
        {
            if (string.IsNullOrEmpty(TxtCustomerID.Text))
            {
                MessageBox.Show("¡¡ DEBE ASIGNAR UN CLIENTE PARA PROCEDER CON LA FACTURA. !!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCustomerID.Text = string.Empty;
                TxtCustomerID.Select();
                TxtCustomerID.Focus();
                return false;
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        public void ViewInvoices()
        {
            try
            {
                // ********************************************
                // ** OBTENEMOS LOS DATOS DE LA FACTURA DESDE EL CONTROLADOR
                // ********************************************
                var invoices = _invoicesController.GetInvoicesByID(invoicesId);
                if (invoices == null)
                    return;

                var customer = _customersController.GetCustomersByID(invoices.CustomerId);
                if (customer == null)
                    return;

                // ********************************************
                // ** ASIGNAMOS LOS DATOS OBTENIDOS A LOS TEXTBOX DEL FORMULARIO CLIENTE
                // ********************************************
                TxtCustomerID.Text = invoices.SubTotal.ToString();
                TxtCustName.Text = customer.CustName;
                TxtAdress.Text = customer.Adress;

                TxtImporte.Text = invoices.SubTotal.ToString("###,##0.00");
                TxtItbis.Text = invoices.TotalItbis.ToString("###,##0.00");
                TxtNeto.Text = invoices.Total.ToString("###,##0.00");

                dataGridView1.DataSource= _invoicesController.GetInvoicesDetailsByID(invoicesId);
            }
            catch (Exception _error)
            {
                MessageBox.Show($"Upsss.. Algo salio mal, error en la aplicación: {_error.Message}");
            }
        }
    }
}
