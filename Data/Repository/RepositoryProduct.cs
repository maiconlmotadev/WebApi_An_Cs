using System;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repository
{
    public class RepositoryProduct : RepositoryGenerics<Product>, IProduct
    {
        public Task<List<Product>> CustomList()
        {
            throw new NotImplementedException();
        }
    }
}


