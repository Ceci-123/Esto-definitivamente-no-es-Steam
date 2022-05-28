using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmAlta : Form
    {
        int codigoJuego = 0;
        public FrmAlta(int codigoJuego) : this()
        {
            btnGuardar.Text = "Modificar";
            nupPrecio.Maximum = 10000;
            PintarForm();
            this.codigoJuego = codigoJuego;
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
            cmbUsuarios.DataSource = UsuarioDao.Leer();
        }

        protected virtual void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Juego aux = new Juego(Convert.ToInt32(this.cmbUsuarios.Text), this.txtNombre.Text, this.txtGenero.Text, Convert.ToDouble(this.nupPrecio.ToString()));
                if (codigoJuego > 0)
                {
                    JuegoDao.Modificar(aux);
                }
                else
                {
                    JuegoDao.Guardar(aux);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ocurrio un error", "Guardado o modificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
