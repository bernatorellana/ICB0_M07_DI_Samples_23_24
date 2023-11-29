using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DBLib
{
    public class DBEmpleat
    {
        private int empNo;
        private String cognom;
        private String ofici;
        private int cap;
        private DateTime dataAlta;
        private int salari;
        private int comissio;
        private int deptNo;

        public DBEmpleat(int empNo, string cognom, string ofici, int cap, DateTime dataAlta, int salari, int comissio, int deptNo)
        {
            EmpNo = empNo;
            Cognom = cognom;
            Ofici = ofici;
            Cap = cap;
            DataAlta = dataAlta;
            Salari = salari;
            Comissio = comissio;
            DeptNo = deptNo;
        }

        #region props
        public int EmpNo { get => empNo; set => empNo = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string Ofici { get => ofici; set => ofici = value; }
        public int Cap { get => cap; set => cap = value; }
        public DateTime DataAlta { get => dataAlta; set => dataAlta = value; }
        public int Salari { get => salari; set => salari = value; }
        public int Comissio { get => comissio; set => comissio = value; }
        public int DeptNo { get => deptNo; set => deptNo = value; }

        #endregion
    
        public static List<DBEmpleat> getEmpleats()
        {
            using(var context = new SQLiteDBContext()){
                using(var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    using(var consulta = connexio.CreateCommand()) {

                        consulta.CommandText = @"
                            select * from emp;
                        ";
                        DbDataReader reader = consulta.ExecuteReader();
                        List<DBEmpleat> empleats = new List<DBEmpleat>();
                        while(reader.Read())
                        {
                            int empNo = reader.GetInt32(reader.GetOrdinal("EMP_NO"));
                            String cognom = reader.GetString(reader.GetOrdinal("COGNOM"));
                            String ofici = reader.GetString(reader.GetOrdinal("OFICI"));
                            int cap =  reader.IsDBNull(reader.GetOrdinal("CAP")) ?0: reader.GetInt32(reader.GetOrdinal("CAP"));
                            DateTime dataAlta = reader.GetDateTime(reader.GetOrdinal("DATA_ALTA"));
                            int salari = reader.GetInt32(reader.GetOrdinal("SALARI"));
                            int comissio = reader.IsDBNull(reader.GetOrdinal("COMISSIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("COMISSIO"));
                            int deptNo = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            empleats.Add(new DBEmpleat(empNo, cognom, ofici, cap, dataAlta, salari, comissio,deptNo));  
                        }
                        return empleats;
                    }

                }
            }
        }
    
    }
}
