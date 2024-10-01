namespace App3.Api.Data.DB;

public interface IDataAccess {
    Task<List<T>> LoadDataQuery<T, U>(string Query, string connectionStringName);
    Task<long> SaveDataQuery<T>(string Query, T Obj, string connectionStringName);
}
