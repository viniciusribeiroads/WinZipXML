using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinZipXml
{
    class MoveXML
    {

        // funcao recursiva para ler todo repositorio e mover os xml
        public static void BuscaMoveArquivos(DirectoryInfo dir, string _destino)
        {
            string destino = _destino;
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {
                // aqui faço a verificacao para ver se é do tipo .xml, se for movemos para o repositorio XML
                if (file.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {

                    try
                    {
                        if (File.Exists(Path.Combine(destino, file.Name)))
                        {
                            File.Delete(file.FullName);
                            
                        }

                        else
                            File.Move(file.FullName, Path.Combine(destino, file.Name));

                    }
                       

                    catch
                    {

                        //File.Delete(file.FullName);
                    }

                }
            }


            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BuscaMoveArquivos(subDir, destino);

            }

        }

    }
}
