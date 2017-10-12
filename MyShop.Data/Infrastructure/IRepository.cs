using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyShop.Data.Infrastructure
{
    public interface IRepository<T> where T : class //T có nghĩa là đại diện cho một kiểu mà chúng ta chưa biết
    {
        //Để tạo các IRepository thì cần phải định nghĩa ra các phương thức
        // Marks an entity as new
        T Add(T entity); //Những cái tương tự như vầy được gọi là Generic (generic nó là một kiểu dữ liệu "tự do")

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        T Delete(T entity);

        T Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int id
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}