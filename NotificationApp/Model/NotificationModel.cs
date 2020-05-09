using SQLite;
using System;

namespace NotificationApp.Model
{
    public class NotificationModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}