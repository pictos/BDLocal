using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BDLocal.DataBase
{
    public class BusinessEntityBase : IBusinessEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
