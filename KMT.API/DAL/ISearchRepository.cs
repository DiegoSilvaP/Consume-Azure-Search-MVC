using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMT.API.DAL
{
    internal interface ISearchRepository
    {
        DocumentSearchResult<Document> Search();
        DocumentSearchResult<Document> Search(string filter);
    }
}
