using GoSell.API.Domains.Elastics;
using Nest;

namespace GoSell.API.Service
{
    public class QuickSearchServices(IServiceProvider serviceProvider, ILogger<QuickSearchServices> logger)
    {
        public ILogger<QuickSearchServices> Logger = logger;
        public readonly IServiceProvider ServiceProvider = serviceProvider;
    }
        //public QuickSearchServices()
        //{
        //    _serviceProvider = serviceProvider;
        //    _logger = logger;            
        //}
        
        //public async Task CreateIndexIfNotExists(string indexName)
        //{
        //    if (!_client.Indices.Exists(indexName).Exists)
        //    {
        //        await _client.Indices.CreateAsync(indexName, c => c.Map<dynamic>(m => m.AutoMap()));
        //    }
        //    Index(indexName);
        //}
        //public async Task<bool> AddOrUpdateBulk<T>(IEnumerable<T> documents) where T : class
        //{
        //    var indexResponse = await _client.BulkAsync(b => b
        //           .Index(_indexName)
        //           .UpdateMany(documents, (ud, d) => ud.Doc(d).DocAsUpsert(true))
        //       );
        //    return indexResponse.IsValid;
        //}
        //public async Task<bool> AddOrUpdate<T>(T document) where T : class
        //{
        //    var indexResponse = await _client.IndexAsync(document, idx => idx.Index(_indexName).OpType(OpType.Index));
        //    return indexResponse.IsValid;
        //}
        //public async Task<bool> Remove<T>(string key) where T : class
        //{
        //    var response = await _client.DeleteAsync<T>(key, d => d.Index(_indexName));
        //    return response.IsValid;
        //}
        //public async Task<long> RemoveAll<T>() where T : class
        //{
        //    var response = await _client.DeleteByQueryAsync<T>(d => d.Index(_indexName).Query(q => q.MatchAll()));
        //    return response.Deleted;
        //}
        //    public async Task<T> Get<T>(string key) where T : class
        //    {
        //        var response = await client.GetAsync<T>(key, g => g.Index(_indexName));
        //        return response.Source;
        //    }
        //    public async Task<List<T>> GetAll<T>() where T : class
        //    {
        //        var searchResponse = await client.SearchAsync<T>(s => s.Index(_indexName).Query(q => q.MatchAll()));
        //        return searchResponse.IsValid ? searchResponse.Documents.ToList() : default;
        //    }
        //    public async Task<List<T>> Query<T>(QueryContainer predicate) where T : class
        //    {
        //        var searchResponse = await client.SearchAsync<T>(s => s.Index(_indexName).Query(q => predicate));
        //        return searchResponse.IsValid ? searchResponse.Documents.ToList() : default;
        //    }
        //    public async Task<ISearchResponse<T>> QueryByIndex<T>(ISearchRequest<T> request) where T : class
        //    {
        //        return await client.SearchAsync<T>(request);            
        //    }

        //public async Task<List<GosellOrderModel>> SearchAllOrderOfStore(long storeId)
        //{
        //    var client = _serviceProvider.GetKeyedService<IElasticClient>("gosell_order");
        //    var results = await client
        //        .SearchAsync<GosellOrderModel>(s => s.Index("gosell_order").Query(q =>
        //        q.Terms(c => c.Field(f => f.StoreId).Terms(storeId))
        //    ));
        //    return results.IsValid ? results.Documents.ToList() : default;
        //}
    //}
}
