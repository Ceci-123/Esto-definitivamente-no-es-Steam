using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmBiblioteca : Form
    {
        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarBiblioteca();
        }

        private void RefrescarBiblioteca()
        {
            dtgvBiblioteca.DataSource = JuegoDao.Leer();
            dtgvBiblioteca.Update();
            dtgvBiblioteca.Refresh();
            
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (this.dtgvBiblioteca.SelectedRows.Count > 0)
            {
                Juego auxJuego = ((Juego)dtgvBiblioteca.CurrentRow.DataBoundItem);
                aux = auxJuego.CodigoJuego;
            }
            JuegoDao.Eliminar(aux); 
            RefrescarBiblioteca();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmAlta frm = new FrmAlta();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
              MessageBox.Show("Creado correctamente", "Creacion de juego", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefrescarBiblioteca();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (this.dtgvBiblioteca.SelectedRows.Count > 0)
            {
              Juego auxJuego = ((Juego)dtgvBiblioteca.CurrentRow.DataBoundItem);
              aux = auxJuego.CodigoJuego;
            }
           
            FrmAlta frm = new FrmAlta(aux);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
              MessageBox.Show("Modificado correctamente", "Modificacion de juego", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefrescarBiblioteca();
        }

    }
}
