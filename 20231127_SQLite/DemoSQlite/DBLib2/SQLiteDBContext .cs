﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLib2
{
    public class SQLiteDBContext : DbContext
    {
        public static string DB_FILENAME { get { return "prova.db"; } }
        public static string DB_PATH { get { return "db"; } }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlite("Filename=db/prova.db");
            optionBuilder.UseSqlite($"Filename={DB_PATH}/{DB_FILENAME}");
        }
    }
}
