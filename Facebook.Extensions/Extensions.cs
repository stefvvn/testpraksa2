using Facebook.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Facebook.Extensions
{
    public static class FacebookExt
    {
        public static int GetIntValue(this string NazivKolone)
        {
            return (int)SqlDataReader.GetValue(SqlDataReader.GetOrdinal(NazivKolone));
        }
    }
}