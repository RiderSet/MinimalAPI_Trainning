namespace MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        IResult Create(TEntity entity);
        Task<IResult> Update(Guid cod, TEntity entity);
        Task<IResult> Remove(Guid cod);
    }
}