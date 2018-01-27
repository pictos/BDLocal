using System.IO;
using System.Collections.Generic;
using SQLite;

namespace BDLocal.DataBase
{
    public class ToDoDatabase
    {
        SQLiteConnection Connection { get; }
        public static string Root { get; set; } = string.Empty;
        public ToDoDatabase()
        {
            var location = "tododb.db3";
            location = Path.Combine(Root, location);
            Connection = new SQLiteConnection(location);
            Connection.CreateTable<ToDoItem>();
        }

        #region Consultas

        

        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            var query = Connection.Table<T>().FirstOrDefault(c => c.Id == id);
            return query;
        }

        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            return (from i in Connection.Table<T>()
                    select i);
        }

        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            if(item.Id !=0)
            {
                Connection.Update(item);
                return item.Id;
            }
            return Connection.Insert(item);
        }

        public void SaveItens<T>(IEnumerable<T> items) where T: IBusinessEntity
        {
            Connection.BeginTransaction();

            foreach (T item in items)
            {
                SaveItem(item);
            }

            Connection.Commit();
        }

        public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
        {
            return Connection.Delete(item);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
        #endregion
    }
}
