using BDLocal.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace BDLocal.ViewModels
{
    public class ToDoViewModel : BaseViewModel
    {
        private string _item;

        public string Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged(); }
        }

        ToDoDatabase database;
        public ObservableCollection<ToDoItem> ToDos { get; set; }

        public Command AddCommand { get; }

        public ToDoViewModel()
        {
            AddCommand = new Command(ExecuteAddCommand);
            database = new ToDoDatabase();
            ToDos = new ObservableCollection<ToDoItem>();
            RefreshList();
        }

        void ExecuteAddCommand()
        {
            database.SaveItem(new ToDoItem { Nome = Item });
            Item = string.Empty;
            RefreshList();
           
        }

        private void RefreshList()
        {
            ToDos.Clear();
            var query = database.GetItems<ToDoItem>().OrderByDescending(c => c.Created);
            foreach (var item in query)
            {
                ToDos.Add(item);
            }
        }
    }
}
