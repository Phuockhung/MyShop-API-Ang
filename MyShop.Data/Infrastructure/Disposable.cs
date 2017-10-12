using System;

namespace MyShop.Data.Infrastructure
{
    public class Disposable : IDisposable // kế thừa từ IDisposable, IDisposable là 1 interface có sẵn của c# cho phép những ai kế thừa từ nó để tự động hủy cài đặt các phương thức để tự động hủy
    {
        private bool isDisposed;

        //khi hủy Disposable thì nó sẽ không Dispose
        ~Disposable()
        {
            Dispose(false);
        }

        //Còn khi Dispose thì nó sẽ thu hoạch bộ nhớ, dọn rác
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}