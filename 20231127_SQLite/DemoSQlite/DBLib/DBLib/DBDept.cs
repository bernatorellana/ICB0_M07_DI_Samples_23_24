using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DBLib
{
    public class DBDept
    {
        private int dept_no;
        private String dnom;
        private String loc;

        public DBDept(int dept_no, string dnom, string loc)
        {
            Dept_no = dept_no;
            Dnom = dnom;
            Loc = loc;
        }
        #region propietats

        public int Dept_no { get => dept_no; set => dept_no = value; }
        public string Dnom { get => dnom; set => dnom = value; }
        public string Loc { get => loc; set => loc = value; }
        #endregion



        public static List<DBDept> getDepartaments()
        {
            using (var context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    using (var consulta = connexio.CreateCommand())
                    {
                        consulta.CommandText = @"
                            select * from dept
                        ";
                        DbDataReader reader = consulta.ExecuteReader();
                        List<DBDept> depts = new List<DBDept>();
                        while (reader.Read())
                        {
                            int deptNo = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            String dnom = reader.GetString(reader.GetOrdinal("DNOM"));
                            String loc = reader.GetString(reader.GetOrdinal("LOC"));
                            
                            depts.Add(new DBDept(deptNo,dnom,loc));
                        }
                        return depts;
                    }

                }
            }
        }

    }
}
