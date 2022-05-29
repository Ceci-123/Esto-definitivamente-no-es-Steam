using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmAlta : Form
    {
        int codigoJuego;
        public FrmAlta(int codigoJuego) : this()
        {
            btnGuardar.Text = "Modificar";
            nupPrecio.Maximum = 10000;
            lblUsuarios.Text = string.Empty;
            this.codigoJuego = codigoJuego;
            PintarForm();
        }

        private void PintarForm()
        {
            Juego aux = JuegoDao.LeerPorId(codigoJuego);
            this.txtNombre.Text = aux.Nombre;
            this.txtGenero.Text = aux.Genero;
            this.nupPrecio.Value = (decimal)aux.Precio;
        }
        public FrmAlta()
        {
            InitializeComponent();
        }

        private void FrmAlta_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUsuarios.DataSource = UsuarioDao.Leer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected virtual void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnGuardar.Text != "Modificar")
                {
                    Juego nuevoJuego = new Juego(((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario, txtNombre.Text, txtGenero.Text, (double)nupPrecio.Value);

                    JuegoDao.Guardar(nuevoJuego);
                }
                else
                {
                    Juego nuevoJuego = new Juego(codigoJuego,((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario, txtNombre.Text, txtGenero.Text, (double)nupPrecio.Value);

                    JuegoDao.Modificar(nuevoJuego);
                }

                DialogResult = DialogResult.OK;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
