using System;
using Data.Entities;

namespace Data.Interfaces
{
	public interface IProduct : IGeneric<Product>
	{
		Task<List<Product>> CustomList();
	}
}

