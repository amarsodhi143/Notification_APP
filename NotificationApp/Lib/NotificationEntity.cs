using System;
using System.Linq;
using NotificationApp.Model;

namespace NotificationApp.Lib
{
    public class NotificationEntity
    {
        public void CreateDefaultTable()
        {
            var sqlHelper = new SqlHelper();
            //sqlHelper.DropTable<NotificationModel>();
            sqlHelper.CreateTable<NotificationModel>();
            //sqlHelper.DropTable<NotificationLog>();
            sqlHelper.CreateTable<NotificationLog>();

            //var range = Enumerable.Range(1, 10).Select(x => new NotificationModel
            //{
            //    Name = "Name " + x,
            //    Description = "Description " + x,
            //    Date = DateTime.Now.AddDays(x)
            //}).ToList();

            //sqlHelper.InsertData(range);
        }
    }
}