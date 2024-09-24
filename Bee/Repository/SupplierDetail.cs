﻿using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using Microsoft.Data.SqlClient;
using Bee.Models;

namespace Bee.Repository
{
    public class SupplierDetail : ISupplier
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _webHostEnvironment;

        public SupplierDetail(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this._configuration = configuration;
            this._webHostEnvironment = webHostEnvironment;
        }

        public string DocumentUpload(IFormFile formFile)
        {
            string uploadPath = _webHostEnvironment.WebRootPath;
            string dest_path = Path.Combine(uploadPath, "uploaded_doc");
            if (!Directory.Exists(dest_path))
            {
                Directory.CreateDirectory(dest_path);
            }
            string sourceFile = Path.GetFileName(formFile.FileName);
            string path = Path.Combine(dest_path, sourceFile);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return path;
        }

        public void ImportSupplier(DataTable supplier)
        {
            var sqlConn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection sCon = new SqlConnection(sqlConn))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sCon))
                {
                    sqlBulkCopy.DestinationTableName = "Supplier";
                    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    sqlBulkCopy.ColumnMappings.Add("CNPJ", "CNPJ");
                    sqlBulkCopy.ColumnMappings.Add("ContactInfo", "ContactInfo");
                    sqlBulkCopy.ColumnMappings.Add("Address", "Address");
                    sCon.Open();

                    sqlBulkCopy.WriteToServer(supplier);
                    sCon.Close();
                }
            }
        }

        public DataTable SupplierDataTable(string path)
        {
            var connectionString = _configuration.GetConnectionString("excelConnection");
            DataTable dataTable = new DataTable();
            connectionString = string.Format(connectionString, path);
            using (OleDbConnection excelConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter adapterExcel = new OleDbDataAdapter())
                    {
                        excelConn.Open();
                        cmd.Connection = excelConn;
                        DataTable excelSchema;
                        excelSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        var sheetName = excelSchema.Rows[0]["Table_Name"].ToString();
                        excelConn.Close();

                        excelConn.Open();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        adapterExcel.SelectCommand = cmd;
                        adapterExcel.Fill(dataTable);
                        excelConn.Close();
                    }
                }
            }

            return dataTable;
        }
    }
}
