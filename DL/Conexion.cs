using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return "Data Source=.;Initial Catalog=IvBetoCRUDWinForm;User ID=sa;Password=pass@word1";
        }
    }
}
