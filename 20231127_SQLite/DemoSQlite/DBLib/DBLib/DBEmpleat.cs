using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
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
        private DBEmpleat em;

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

        public DBEmpleat(DBEmpleat em)
        {
            this.EmpNo = em.EmpNo;
            this.Cognom = em.Cognom;
            this.Ofici = em.Ofici;
            this.Cap = em.Cap;
            this.DataAlta = em.DataAlta;
            this.Salari = em.Salari;
            this.Comissio = em.Comissio;
            this.DeptNo = em.DeptNo;
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


        public static long getNumeroEmpleats(String pCognom = "", DateTime? dt = null)
        {
            long numeroEmpleats = 0;

            using (var context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    using (var consulta = connexio.CreateCommand())
                    {

                        DBUtils.createParam(consulta, "p_cognom", "%" + pCognom + "%", System.Data.DbType.String);
                        DBUtils.createParam(consulta,
                                                "p_data_alta",
                                                dt == null ? DateTime.MinValue : dt,
                                                System.Data.DbType.DateTime);

                        consulta.CommandText = @"
                            select count(1) from emp
                               where 
                                    (cognom like @p_cognom) and 
                                    ( data_alta>@p_data_alta);
                        ";
                        numeroEmpleats = (long)consulta.ExecuteScalar();
                    }
                }
            }
            return numeroEmpleats;
        }

        public static List<DBEmpleat> getEmpleats(long paginaActual, long elementsPerPagina, String pCognom = "", DateTime? dt = null)
        {
            using (var context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    using (var consulta = connexio.CreateCommand())
                    {


                        //String dataString = "";
                        //dataString = dt?.ToString("yyyy-MM-dd");
                        //consulta.CommandText = $@"
                        //    select * from emp
                        //       where 
                        //            ('{pCognom}'='' or  cognom like '%{pCognom}%') and 
                        //            ('{dataString}'='' or data_alta>'{dataString}');
                        //";
                        //---------------------
                        // Creació de paràmetres

                        DBUtils.createParam(consulta, "p_cognom", "%" + pCognom + "%", System.Data.DbType.String);
                        DBUtils.createParam(consulta,
                                                "p_data_alta",
                                                dt == null ? DateTime.MinValue : dt,
                                                System.Data.DbType.DateTime);
                        DBUtils.createParam(consulta, "p_limit", elementsPerPagina, System.Data.DbType.Int64);
                        DBUtils.createParam(consulta, "p_emp_inicial", elementsPerPagina* paginaActual, System.Data.DbType.Int64);

                        consulta.CommandText = @"
                            select * from emp
                               where 
                                    (cognom like @p_cognom) and 
                                    ( data_alta>@p_data_alta) ";
                        if (elementsPerPagina > 0)
                        {
                            consulta.CommandText += "LIMIT @p_limit OFFSET @p_emp_inicial;";
                        }
                        DbDataReader reader = consulta.ExecuteReader();
                        List<DBEmpleat> empleats = new List<DBEmpleat>();
                        while (reader.Read())
                        {
                            int empNo = reader.GetInt32(reader.GetOrdinal("EMP_NO"));
                            String cognom = reader.GetString(reader.GetOrdinal("COGNOM"));
                            String ofici = reader.GetString(reader.GetOrdinal("OFICI"));
                            int cap = reader.IsDBNull(reader.GetOrdinal("CAP")) ? 0 : reader.GetInt32(reader.GetOrdinal("CAP"));
                            DateTime dataAlta = reader.GetDateTime(reader.GetOrdinal("DATA_ALTA"));
                            int salari = reader.GetInt32(reader.GetOrdinal("SALARI"));
                            int comissio = reader.IsDBNull(reader.GetOrdinal("COMISSIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("COMISSIO"));
                            int deptNo = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            empleats.Add(new DBEmpleat(empNo, cognom, ofici, cap, dataAlta, salari, comissio, deptNo));
                        }
                        return empleats;
                    }

                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is DBEmpleat empleat &&
                   EmpNo == empleat.EmpNo;
        }

        public override int GetHashCode()
        {
            return 1626872650 + EmpNo.GetHashCode();
        }

        public static void update(DBEmpleat e)
        {
            using (var context = new SQLiteDBContext())
            {
                using (var connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    // Comencem una transacció dins de la que volem executar updates
                    DbTransaction transaccio = connexio.BeginTransaction();

                    using (var consulta = connexio.CreateCommand())
                    {
                        consulta.Transaction = transaccio; // Associem la consulta a la transacció



                        DBUtils.createParam(consulta, "cognom", e.Cognom, System.Data.DbType.String);
                        DBUtils.createParam(consulta, "ofici", e.Ofici, System.Data.DbType.String);
                        DBUtils.createParam(consulta, "cap", e.Cap, System.Data.DbType.Int32);
                        DBUtils.createParam(consulta, "salari", e.Salari, System.Data.DbType.Int32);
                        DBUtils.createParam(consulta, "comissio", e.Comissio, System.Data.DbType.Int32);
                        DBUtils.createParam(consulta, "dept_no", e.DeptNo, System.Data.DbType.Int32);
                        DBUtils.createParam(consulta, "data_alta", e.DataAlta, System.Data.DbType.DateTime);
                        DBUtils.createParam(consulta, "emp_no", e.EmpNo, System.Data.DbType.Int32);

                        consulta.CommandText =
                            @"update emp set                             
                                COGNOM      = @cognom,
                                OFICI       = @ofici,
                                CAP         = @cap,
                                DATA_ALTA   = @data_alta,
                                SALARI      = @salari,
                                COMISSIO    = @comissio,
                                DEPT_NO     = @dept_no
                                where
                                    EMP_NO  = @emp_no
                                ";
                        int filesModificades = consulta.ExecuteNonQuery();
                        if (filesModificades != 1)
                        {
                            //// ARGH ! ROLLBACK PERO YA !!!!!!!
                            transaccio.Rollback();
                        }
                        else
                        {
                            transaccio.Commit();
                        }
                    }
                }
            }
        }
    }
}