using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralizarJanela
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void centroDaTelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmJanelaSecundaria();

            // Screen.FromHandle pega o tamanho da tela do Windows
            // Left é o tamanho da Tela menos o tamanho da janela dividido por 2 para achar o centro
            // Top é a altura da tela menos a altura janela e o -30 é para subir um pouco a janela e nao ficar colado na barra
            var telaWindows = Screen.FromHandle(this.Handle);
            form.Left = (telaWindows.Bounds.Width - form.Width) / 2;
            form.Top = (telaWindows.Bounds.Height - form.Height) - 30;
            form.ShowDialog();
        }

        private void centroDaJanelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmJanelaSecundaria();
            
            // a conta aqui é mais simples, mas temos que considerar a posição da janela principal, por isto a soma de this.Left e this.Top
            form.Left = ((this.Width - form.Width) / 2) + this.Left;
            form.Top = (this.Height - form.Height) - 30 + this.Top;
            form.ShowDialog();
        }
    }
}
