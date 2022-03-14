using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Facebook.Data.SQL
{
    public static class FacebookExt
    {
        public static int GetIntValue(this SqlDataReader dr, string NazivKolone)
        {
            return (int)dr.GetValue(dr.GetOrdinal(NazivKolone));
        }
    }
}

