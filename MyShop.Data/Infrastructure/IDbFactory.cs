using System;

namespace MyShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable //
    {
        MyShopDbContext Init(); //Chỉ cần 1 phương thức để Init DbContext
    }
}