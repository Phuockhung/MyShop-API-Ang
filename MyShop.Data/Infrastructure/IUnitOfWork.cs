namespace MyShop.Data.Infrastructure
{
    internal interface IUnitOfWork
    {
        void Commit();
    }
}