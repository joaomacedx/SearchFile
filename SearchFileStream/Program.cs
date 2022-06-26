using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace SearchFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string disco = GetDiscoFileStream();
            Console.WriteLine(disco);
        }
        public static string GetDiscoFileStream()
        {
            string caminho = "";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<string> listaDisco = new List<string>();
            foreach (DriveInfo d in allDrives)
            {
                //Console.WriteLine("Drive {0}", d.Name);
                listaDisco.Add(d.Name);
            }

            foreach (string disco in listaDisco)
            {
                foreach (string diretorio in Directory.GetDirectories(disco))
                {
                    string dirBusca = diretorio.Remove(0, disco.Length);
                    if (dirBusca == "Drives compartilhados")
                    {
                        caminho = disco + dirBusca;
                        //Console.WriteLine("O file stream foi encontrado no disco: " + disco);
                        //Console.WriteLine(caminho);
                        return disco;

                    }
                }
            }
            return "Disco não encontrado!";
        }
    }
}
