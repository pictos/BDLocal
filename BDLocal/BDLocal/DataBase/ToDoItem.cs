using BDLocal.ViewModels;
using SQLite;
using System;

namespace BDLocal.DataBase
{
    public class ToDoItem : BusinessEntityBase
    {

        public string Nome { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public bool Done { get; set; } = false;

        [Ignore]
        public string CreatedDisplay
        {
            get { return Created.ToLocalTime().ToString("f",BaseViewModel.culture); }
        }
    }
}
