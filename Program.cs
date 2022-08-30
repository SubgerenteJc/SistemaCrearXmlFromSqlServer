using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlFromSqlServer.Models;

namespace XmlFromSqlServer
{
    public class Program
    {
        static storedProcedure sql = new storedProcedure("miConexion");
        public static FacLabControler facLabControler = new FacLabControler();
        static void Main(string[] args)
        {
            Program muobject = new Program();

            muobject.Extraer();
        }
        public void Extraer()
        {
            //CODIGO PARA GENERAR XML DESDE UNA CONSULTA SQL SERVER

            DataTable gxml = facLabControler.xml();
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement nodoRaiz = new XElement("Tractors");
            document.Add(nodoRaiz);

            foreach (DataRow iseg in gxml.Rows)
            {

                string economico = iseg["Economico"].ToString();
                string flota = iseg["flota"].ToString();

                XElement tractor = new XElement("Tractor");
                tractor.Add(new XElement("Economico", economico));
                tractor.Add(new XElement("flota", flota));
                nodoRaiz.Add(tractor);


            }


            document.Save(@"C:\Archivos\Xml\exml.xml");
        }
    }
}
