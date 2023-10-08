using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string edad = txtEdad.Text;
            string estatura = txtEstatura.Text;
            string telefono = txtTelefono.Text;

            string genero = "";

            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }

            if (EsEnteroValido(edad) && EsDecimalValido(estatura) && EsEnteroValidoDe10Digitos(telefono) &&
                EsTextoValido(nombres) && EsTextoValido(apellidos))
            {
                string datos = $"Nombres: {nombres}\nApellidos: {apellidos}\nEdad: {edad} años\nEstatura: {estatura} cm\nTelefono: {telefono}\nGenero: {genero}";

                using (StreamWriter archivo = File.AppendText("datos99.txt"))
                {
                    archivo.WriteLine(datos + "\n\n");
                }

                MessageBox.Show("Datos Guardados con éxito: \n\n" + datos, "Información");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos en los campos.", "Error");
            }
        }

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEdad.Clear();
            txtEstatura.Clear();
            txtTelefono.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }

        private bool EsEnteroValido(string valor)
        {
            return int.TryParse(valor, out _);
        }

        private bool EsDecimalValido(string valor)
        {
            return double.TryParse(valor, out _);
        }

        private bool EsEnteroValidoDe10Digitos(string valor)
        {
            return valor.Length == 10 && long.TryParse(valor, out _);
        }

        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, "^[a-zA-Z\\s]+$");
        }
    }
}
