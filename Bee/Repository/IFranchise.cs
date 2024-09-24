using Microsoft.AspNetCore.Http;
using System.Data;
using System.Globalization;

namespace Bee.Repository
{
    public interface IFranchise
    {
        // This method is used to upload a document to the server and return the path of the document.
        string DocumentUpload(IFormFile formFile);

        // This method is used to read the data from the document and return a DataTable.
        DataTable FranchiseDataTable(string path);

        // This method is used to import the data from the DataTable to the database.
        void ImportFranchise(DataTable franchise);
    }
}
