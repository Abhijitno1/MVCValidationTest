using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Infra
{
    public class DBDataInteract
    {
        public static int StoreFileData(FileModel fileModel)
        {
            int affectedRec = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var commandStr = "INSERT INTO [FilesTable] (FileName, ContentType, FileData) VALUES (@FileName, @ContentType, @FileData)";
                using (SqlCommand comm = new SqlCommand(commandStr, conn))
                {
                    comm.Parameters.AddWithValue("@FileName", fileModel.FileName);
                    comm.Parameters.AddWithValue("@ContentType", fileModel.ContentType);
                    comm.Parameters.AddWithValue("@FileData", fileModel.FileData);
                    affectedRec = comm.ExecuteNonQuery();
                }
                conn.Close();
            }
            return affectedRec;
        }

        public static FileModel GetFileData(int fileId)
        {
            FileModel model = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var commandStr = "SELECT * FROM [FilesTable] WHERE [Id] = @ID";
                using (SqlCommand comm = new SqlCommand(commandStr, conn))
                {
                    comm.Parameters.AddWithValue("@ID", fileId);
                    var reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        model = new FileModel()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            ContentType = reader["ContentType"].ToString(),
                            FileName = reader["FileName"].ToString(),
                            FileData = (byte[])reader["FileData"]
                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return model;
        }

        public static IEnumerable<FileModel> GetFilesList()
        {
            List<FileModel> filesList = new List<FileModel>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var commandStr = "SELECT * FROM [FilesTable]";
                using (SqlCommand comm = new SqlCommand(commandStr, conn))
                {
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        FileModel model = new FileModel()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            ContentType = reader["ContentType"].ToString(),
                            FileName = reader["FileName"].ToString()
                        };
                        filesList.Add(model);
                    }
                    reader.Close();
                }
                conn.Close();
            }

            return filesList;
        }

        private static string GetConnectionString()
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["SampleDatabase"].ConnectionString;
            connectionStr = connectionStr.Replace("|DataDirectory|", AppDomain.CurrentDomain.GetData("DataDirectory").ToString());
            return connectionStr;
        }
    }
}