using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Host=localhost;Port=5432;Database=weathersdb;Username=postgres;Password=1234";
        public static string CName
        {
            get => cName;
        }
    }
}
