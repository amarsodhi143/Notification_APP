using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using SQLite;

namespace NotificationApp.Lib
{
    public class DBHelper
    {
        public static string GetDBPath()
        {
            var pathToNewFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/database";
            Directory.CreateDirectory(pathToNewFolder);
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Notification.db3");

            //var folderPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("NotificationApp.dll", "");
            //var path = Path.Combine(folderPath, "Notification.db3");
            //return path;
        }

        public static void RestoreDatabase()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var files = Directory.GetFiles(Path.GetDirectoryName(location)).Where(x => x.Contains(".db")).ToList().FirstOrDefault();
            var bytes = File.ReadAllBytes(files);

            if (File.Exists(GetDBPath()))
            {
                File.Delete(GetDBPath());
            }

            File.WriteAllBytes(GetDBPath(), bytes);
        }
    }

    public class SqlHelper
    {
        private SQLiteConnection _sqlConnection;

        public SqlHelper()
        {
            var dbPath = DBHelper.GetDBPath();
            _sqlConnection = new SQLiteConnection(dbPath);
        }

        public string CreateTable<T>()
        {
            try
            {
                _sqlConnection.CreateTable<T>();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return message;
            }
            return string.Empty;
        }

        public string InsertData<T>(T obj)
        {
            try
            {
                _sqlConnection.RunInTransaction(() =>
                {
                    _sqlConnection.Insert(obj);
                });
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return message;
            }

            return string.Empty;
        }

        public string InsertData<T>(List<T> obj)
        {
            try
            {
                _sqlConnection.RunInTransaction(() =>
                {
                    _sqlConnection.InsertAll(obj);
                });
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return message;
            }

            return string.Empty;
        }

        public string DropTable<T>()
        {
            try
            {
                _sqlConnection.DropTable<T>();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return message;
            }
            return string.Empty;
        }

        public string DeleteTableData<T>()
        {
            try
            {
                _sqlConnection.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return message;
            }
            return string.Empty;
        }

        public TableQuery<T> GetAllData<T>() where T : class, new()
        {
            return _sqlConnection.Table<T>();
        }

        public TableQuery<T> GetAllData<T>(Expression<Func<T, bool>> prdicate) where T : class, new()
        {
            return _sqlConnection.Table<T>().Where(prdicate);
        }
    }
}