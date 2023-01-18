
using System.Runtime.InteropServices;
using Data.Interfaces;
using Microsoft.Win32.SafeHandles;

namespace Data.Repository
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        public RepositoryGenerics()
        {

        }

        public async Task Add(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public async Task Update(T objeto)
        {
            throw new NotImplementedException();
        }


        // copiado:padrão

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}

