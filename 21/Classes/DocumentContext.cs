using _21.Interfaces;
using _21.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _21.Classes
{
    public class DocumentContext : Document, IDocument
    {
        public List<Document> AllDocuments()
        {
            List<Document> allDocuments = new List<Document>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataDocuments = Common.DBConnection.Query("SELECT * FROM [Документы]", connection);
            while (dataDocuments.Read())
            {
                allDocuments.Add(new Document() {
                    Id = dataDocuments.GetInt32(0),
                    Src = dataDocuments.GetString(1),
                    Name = dataDocuments.GetString(2),
                    User = dataDocuments.GetString(3),
                    IdDocument = dataDocuments.GetInt32(4),
                    Date = dataDocuments.GetDateTime(5),
                    Status = dataDocuments.GetInt32(6),
                    Direction = dataDocuments.GetInt32(7)

                });
            }
            Common.DBConnection.CloseConnection(connection);
            return allDocuments;
        }

        public void Delete()
        {
        }

        public void Save(bool Update = false)
        {

            if (Update) 
            {
                OleDbConnection connection = Common.DBConnection.connection();
                Common.DBConnection.sql("UPDATE [Документы] " +
                    "SET " +
                    $"[Изображение] = '{this.Src}', ") +
            }

        }
    }
}
