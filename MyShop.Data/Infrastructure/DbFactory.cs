namespace MyShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MyShopDbContext dbContext;

        public MyShopDbContext Init() //Kiểm tra Init, nếu nó null thì tạo 1 cái mới
        {
            return dbContext ?? (dbContext = new MyShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}