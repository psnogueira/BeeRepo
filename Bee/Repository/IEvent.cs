﻿using Microsoft.AspNetCore.Http;
using System.Data;
using System.Globalization;

namespace Bee.Repository
{
    public interface IEvent
    {
        // This method is used to upload a document to the server and return the path of the document.
        string DocumentUpload(IFormFile formFile);

        // This method is used to read the data from the document and return a DataTable.
        DataTable EventDataTable(string path);

        // This method is used to import the data from the DataTable to the database.
        void ImportEvent(DataTable f_event);
    }
}
