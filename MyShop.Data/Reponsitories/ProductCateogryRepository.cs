using MyShop.Data.Infrastructure;
using MyShop.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Data.Reponsitories
{
    //Định nghĩa các phương thức mà chúng ta cần phải thêm
    public interface IProductCateogryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCateogryRepository : RepositoryBase<ProductCategory>, IProductCateogryRepository //Sử dụng RepositoryBase thay vì sử dung IRepository vì RepositoryBase kế thừa và đã viết hết rồi.
    {
        //tạo 1 constructor truyền vào 1 base mà kế thừa từ DbFacetory
        public ProductCateogryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}