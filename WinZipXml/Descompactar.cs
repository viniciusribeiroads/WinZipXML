using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinZipXml
{
    class Descompactar
    {
        public static void BuscaArquivos(DirectoryInfo dir, string _destino)
        {
            string destino = _destino;
            // lista arquivos do diretorio corrente
            
            foreach (FileInfo file in dir.GetFiles())
            {

                // aqui faço a extração do arquivo para a pasta de xml, logo apos deleto o arquivo zip
                if (file.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    ZipFile.ExtractToDirectory(file.FullName, destinationDirectoryName: destino);
                    File.Delete(file.FullName);
                }

            }

            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BuscaArquivos(subDir, destino);

            }
            
        }
    }
}
