using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.Web.Configuration;

namespace KMT.API.DAL
{
    public class SearchRepository : ISearchRepository
    {
        string searchServiceName = WebConfigurationManager.AppSettings["searchServiceName"];
        string apikey = WebConfigurationManager.AppSettings["apikey"];
        public DocumentSearchResult<Document> Search()
        {
            var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apikey));

            var indexClient = searchClient.Indexes.GetClient("azuresql-index");

            SearchParameters sp = new SearchParameters() { SearchMode = SearchMode.All };

            DocumentSearchResult<Document> docs = indexClient.Documents.Search("", sp);
            return docs;
        }

        public DocumentSearchResult<Document> Search(string filter)
        {
            var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apikey));

            var indexClient = searchClient.Indexes.GetClient("azuresql-index");

            SearchParameters sp = new SearchParameters() { SearchMode = SearchMode.All };

            DocumentSearchResult<Document> docs = indexClient.Documents.Search(filter, sp);
            return docs;
        }
    }
}