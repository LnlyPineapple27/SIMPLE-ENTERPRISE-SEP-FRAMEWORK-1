﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.DAO
{
    class SingletonDatabase
    {
        private static SingletonDatabase instance;
        public string connString;

        private SingletonDatabase() { }

        public static SingletonDatabase getInstance()
        {
            if (instance == null)
                instance = new SingletonDatabase();
            return instance;
        }

        public List<string> GetAllTablesName()
        {
            List<string> listTables = new List<string>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select name from sys.tables", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listTables.Add(reader[0].ToString());
                        }
                    }
                }
            }
            return listTables;
        }
    }
}
