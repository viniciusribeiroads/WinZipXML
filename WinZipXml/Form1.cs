using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinZipXml
{
    public partial class FrmCompress : Form
    {
        OpenFileDialog dialogOrigem = new OpenFileDialog();
        public FrmCompress()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblPastaOrigem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dialogOrigem.InitialDirectory = @"C;";
            dialogOrigem.Multiselect = false;

            dialogOrigem.ShowDialog();
            if (dialogOrigem.FileName != "")
            {
                lblPastaOrigem.Text = Path.GetFullPath(dialogOrigem.FileName);
            }
        }

        // chamando a funcao descompactar
        private void btnDescompactar_Click(object sender, EventArgs e)
        {
                if (dialogOrigem.FileName == "")
                {
                    MessageBox.Show("Selecione o(s) arequivos para descompactar");
                }
                else
                {
                    string destino = lblPastaDestino.Text;
                    // criando pasta de arquivos temporarios
                    DirectoryInfo temp = Directory.CreateDirectory(@"C:\\temp\\");
                    // chamando funcao para descompactar o arquivo principal e mandar para arquivos temporarios
                    ZipFile.ExtractToDirectory(dialogOrigem.FileName, @"C:\\temp\\");
                    // Declaração do diretorio do destino 
                    DirectoryInfo dir = new DirectoryInfo(destino);
                    // descompactando tudo e mandando pra pasta final
                    Descompactar.BuscaArquivos(temp, destino);
                    // mensagem de sucesso
                    MessageBox.Show("Arquivos extraido com sucesso!");
            }
        }

        // validando formulario
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var pastaDestino = new FolderBrowserDialog())
                
            {
                DialogResult resposta = pastaDestino.ShowDialog();

                if (resposta == DialogResult.OK && !string.IsNullOrWhiteSpace(pastaDestino.SelectedPath))
                {

                    lblPastaDestino.Text = pastaDestino.SelectedPath;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblPastaDestino_Click(object sender, EventArgs e)
        {

        }

        private void btnMoverXML_Click(object sender, EventArgs e)
        {
            string destino = lblPastaDestino.Text;
            DirectoryInfo temp = new DirectoryInfo(@"C:\\temp\\");
            MoveXML.BuscaMoveArquivos(temp, destino);
            Directory.Delete(@"C:\\temp\\");
            // mensagem de sucesso
            MessageBox.Show("Arquivo movidos com sucesso!");
        }
    }
}
