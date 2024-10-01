namespace App3.Api.Data.Interface;

public interface IDataRepository {
    Task<List<object>> GetData();
}
