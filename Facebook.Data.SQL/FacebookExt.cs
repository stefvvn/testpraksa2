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
            public static int GetIntValue(this string NazivKolone)
            {
                return (int)SqlDataReader.GetValue(SqlDataReader.GetOrdinal(NazivKolone));
            }
        }
}
