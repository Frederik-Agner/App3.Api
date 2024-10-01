using App3.Api.Data.Interface;

namespace App3.Api.Data.Repository;

public class DataRepository : IDataRepository {
    public Task<List<object>> GetData() {
        throw new NotImplementedException();
    }
}
