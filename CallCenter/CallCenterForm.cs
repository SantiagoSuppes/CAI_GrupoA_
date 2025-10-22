using CAI_GrupoA_.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.CallCenter
{
    public partial class CallCenterForm : Form
    {
        public CallCenterForm()
        {
            InitializeComponent();

            cmbProvincia.Items.Clear();
            cmbProvincia.Items.AddRange(modelo.GetProvincias());

            cmbModalidad.Items.Clear();
            cmbModalidad.Items.AddRange(modelo.GetModalidades());

            cmbTipoCaja.Items.Clear();
            cmbTipoCaja.Items.AddRange(modelo.GetTiposCaja());

            // Estado inicial
            cmbCD.Enabled = false;
            cmbAgencia.Enabled = false;
            txtCalleYAltura.Enabled = false;
        }

        private readonly CallCenterModelo modelo = new();

        private void buscarClienteButton_Click(object sender, EventArgs e)
        {
            clienteListView.Items.Clear();
            DirSeleccionadaTextBox.Text = "";

            string raw = cuitTextBox.Text;
            string cuit = CallCenterModelo.NormalizarCuit(raw);

            if (!CallCenterModelo.EsCuitBasico(cuit))
            {
                MessageBox.Show("CUIT inválido. Debe tener 11 dígitos (puede ingresar con guiones).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = modelo.BuscarClientePorCuit(cuit);
            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado para el CUIT ingresado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar direcciones del cliente en la lista
            foreach (var dir in cliente.Direcciones)
            {
                string prov = dir.Provincia.ToString();
                string texto = $"{dir.CalleYAltura} - {dir.Localidad} ({prov})";
                var item = new ListViewItem(texto) { Tag = dir };
                clienteListView.Items.Add(item);
            }
        }

        private void clienteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clienteListView.SelectedItems.Count == 0)
            {
                DirSeleccionadaTextBox.Text = "";
                return;
            }

            var item = clienteListView.SelectedItems[0];
            DirSeleccionadaTextBox.Text = item.Text;
        }

        private void cmbProvincia_SelectedIndexChanged(object? sender, EventArgs e)
        {

            var prov = cmbProvincia.SelectedItem?.ToString();

            cmbCD.Items.Clear();
            cmbAgencia.Items.Clear();

            if (string.IsNullOrWhiteSpace(prov))
            {
                return;
            }

            var cds = modelo.GetCDs(prov);
            if (cds != null && cds.Length > 0)
                cmbCD.Items.AddRange(cds);

            var ags = modelo.GetAgencias(prov);
            if (ags != null && ags.Length > 0)
                cmbAgencia.Items.AddRange(ags);

            if (cmbAgencia.SelectedItem != null && !cmbAgencia.Items.Contains(cmbAgencia.SelectedItem))
                cmbAgencia.SelectedIndex = -1;

            if (cmbCD.SelectedItem != null && !cmbCD.Items.Contains(cmbCD.SelectedItem))
                cmbCD.SelectedIndex = -1;
        }

        private void cmbModalidad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var modalidad = cmbModalidad.SelectedItem?.ToString();
            if (string.Equals(modalidad, "Domicilio", StringComparison.OrdinalIgnoreCase))
            {
                txtCalleYAltura.Enabled = true;
                cmbAgencia.Enabled = false;
                cmbCD.Enabled = false;
            }
            else if (string.Equals(modalidad, "Agencia", StringComparison.OrdinalIgnoreCase))
            {
                txtCalleYAltura.Enabled = false;
                cmbAgencia.Enabled = true;
                cmbCD.Enabled = false;
            }
            else if (string.Equals(modalidad, "CD", StringComparison.OrdinalIgnoreCase))
            {
                txtCalleYAltura.Enabled = false;
                cmbAgencia.Enabled = false;
                cmbCD.Enabled = true;
            }
            else
            {
                // Default
                txtCalleYAltura.Enabled = true;
                cmbAgencia.Enabled = false;
                cmbCD.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipoCaja.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de caja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)nudCantidad.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Ingrese una cantidad mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoText = cmbTipoCaja.SelectedItem.ToString();

            TamañoCajaEnum tam = TamañoCajaEnum.S;
            try
            {
                tam = (TamañoCajaEnum)Enum.Parse(typeof(TamañoCajaEnum), tipoText, true);
            }
            catch
            {
            }

            var detalle = new CallCenterModelo.DetalleCaja { Tam = tam, Qty = qty };
            var item = new ListViewItem(new[] { tipoText, qty.ToString() }) { Tag = detalle };
            lvDetalle.Items.Add(item);

            // Reset campos de detalle
            nudCantidad.Value = 1;
            cmbTipoCaja.SelectedIndex = -1;
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            var dto = new CallCenterModelo.RegistroEnvioDto
            {
                Cuit = cuitTextBox.Text,
                DireccionCliente = DirSeleccionadaTextBox.Text,
                NombreApellido = txtNombreYApellido.Text,
                Dni = txtDNI.Text,
                Telefono = txtTelefono.Text,
                CodigoPostal = txtCodigoPostal.Text,
                Modalidad = cmbModalidad.SelectedItem?.ToString(),
                Provincia = cmbProvincia.SelectedItem?.ToString(),
                Localidad = txtLocalidad.Text,
                CalleYAltura = txtCalleYAltura.Text,
                Agencia = cmbAgencia.SelectedItem?.ToString(),
                CD = cmbCD.SelectedItem?.ToString()
            };

            var detalle = new List<CallCenterModelo.DetalleCaja>();
            foreach (ListViewItem it in lvDetalle.Items)
            {
                if (it.Tag is CallCenterModelo.DetalleCaja dc)
                {
                    detalle.Add(dc);
                }
                else
                {
                    // Fallback: intentar crear desde texto
                    var tipoText = it.SubItems[0].Text;
                    var qtyText = it.SubItems.Count > 1 ? it.SubItems[1].Text : "0";
                    if (int.TryParse(qtyText, out int q))
                    {
                        try
                        {
                            var tam = (TamañoCajaEnum)Enum.Parse(typeof(TamañoCajaEnum), tipoText, true);
                            detalle.Add(new CallCenterModelo.DetalleCaja { Tam = tam, Qty = q });
                        }
                        catch
                        {
                            // ignorar
                        }
                    }
                }
            }

            var errores = modelo.Validar(dto, detalle);
            if (errores != null && errores.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var guia = modelo.CrearGuia(dto, detalle);
            if (guia != null)
            {
                MessageBox.Show($"Guía creada: {guia.NumeroGuia}", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al crear la guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            cuitTextBox.Clear();
            clienteListView.Items.Clear();
            DirSeleccionadaTextBox.Clear();

            txtNombreYApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtCodigoPostal.Clear();
            cmbModalidad.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;
            txtLocalidad.Clear();
            txtCalleYAltura.Clear();
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();

            lvDetalle.Items.Clear();
        }
    }
}
