namespace Shielf.Infrastruct
{
    public interface IServiceModel<T> where T : class
    {
        IEnumerable<T> Get();
        T Upd<C>(C Id, T Enty);
        T Add(T Enty);
        T Get<C>(C Id);
    }
}
