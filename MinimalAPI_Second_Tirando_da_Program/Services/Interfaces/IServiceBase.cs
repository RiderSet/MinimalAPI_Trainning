namespace MinimalAPI_Second_Tirando_da_Program.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<IResult> Create(TEntity entity);
        Task<IResult> Update(Guid cod, TEntity entity);
        Task<IResult> Remove(Guid cod);
    }
}
