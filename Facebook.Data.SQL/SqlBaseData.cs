﻿using Facebook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Data.SQL
{
    public class SqlBaseData
    {
        public string connectionstring = "Data Source=DESKTOP-ORJTLLV\\SQLEXPRESS;" +
                 "Initial Catalog=praksaDrustvenaMreza;" +
                 "Integrated Security=SSPI;";
        protected SqlConnection Connections { get; set; }
        protected SqlCommand Command { get; set; }
        protected SqlConnection GetConnection()
        {
            Connections = new SqlConnection(connectionstring);
            if (Connections.State != ConnectionState.Open)
            {
                Connections.Open();
            }
            return Connections;
        }
        protected void AddParameterWithValue(string vparam, SqlDbType SqlType, object ParamValue)
        {
            Command.Parameters.Add(vparam, SqlType);
            Command.Parameters[vparam].Value = ParamValue;
        }
        protected void CloseConnection()
        {
            Connections.Close();
            Command = null;
        }
        protected SqlCommand GetCommand(string StoredProcedureName)
        {
            Command = new SqlCommand(StoredProcedureName, GetConnection());
            Command.CommandType = CommandType.StoredProcedure;
            return Command;
        }
    }
    public static class FacebookExt
    {
        public static int GetIntValue(this string NazivKolone)
        {
            return (int)SqlDataReader.GetValue(SqlDataReader.GetOrdinal(NazivKolone));
        }
        //public static int GetIntValue(this SqlDataReader dr, string NazivKolone)
        //{
        //    object columnValue = dr[NazivKolone];
        //    int returnValue = default(int);
        //    if (!(columnValue is DBNull))
        //    {
        //        returnValue = (int)Convert.ChangeType(columnValue, typeof(int));
        //    }
        //    return returnValue;
        //}
    }
}
