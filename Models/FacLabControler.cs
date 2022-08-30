using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFromSqlServer.Models
{
    public class FacLabControler
    {
        public ModelFact modelFact = new ModelFact();

        
        public DataTable xml()
        {
            return this.modelFact.xml();
        }
        
    }
}
