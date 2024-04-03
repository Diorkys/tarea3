using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Atributos;
using Dominio.Crud;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //variables
        CPersonas personas = new CPersonas();
        AtributosPersona atributos = new AtributosPersona();
        bool edit = false;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DvgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void ClearTextBoxs()
        {
            txtId.Text = "ID";
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtDireccion.Text = "Direccion";
            dateFecha.Value = DateTime.Now;
            txtCelular.Text = "Celular";

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }


        private void getData()
        { 
            CPersonas cPersonas = new CPersonas();
            DvgDatos.DataSource = cPersonas.Mostrar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getData();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtCelular.Text)) 
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método si hay campos vacíos
                }

                // Asignar valores a los atributos

                atributos.Nombre = txtNombre.Text;
                atributos.Apellido = txtApellido.Text;
                atributos.Direccion = txtDireccion.Text;
                atributos.Fecha_nacimiento = dateFecha.Value;
                atributos.Celular = txtCelular.Text;

                if (edit == false)
                {
                    // INSERTAR
                    personas.Insertar(atributos);
                    MessageBox.Show("INSERTADO", "SE GUARDÓ UN REGISTRO DE FORMA EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODIFICAR
                    atributos.Id1 = Convert.ToInt32(txtId.Text);
                    personas.Modificar(atributos);
                    edit = false;
                    MessageBox.Show("MODIFICADO", "SE MODIFICÓ UN REGISTRO DE FORMA EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearTextBoxs();
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", $"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnModificar_Click(object sender, EventArgs e)
        {


          
            if (DvgDatos.SelectedRows.Count > 0)
            {
                txtId.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //cargar datos
                txtId.Text = DvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DvgDatos.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = DvgDatos.CurrentRow.Cells[3].Value.ToString();
                dateFecha.Text = DvgDatos.CurrentRow.Cells[4].Value.ToString();
                txtCelular.Text = DvgDatos.CurrentRow.Cells[5].Value.ToString();


       

            }
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DvgDatos.SelectedRows.Count > 0)
            { 
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("DESEAS ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    try 
                    {
                        atributos.Id1 = Convert.ToInt32(DvgDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(atributos);
                        getData();
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Error", $"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            CPersonas cPersonas = new CPersonas();  
            DvgDatos.DataSource = cPersonas.Buscar(txtBuscar.Text);
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void txtCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
