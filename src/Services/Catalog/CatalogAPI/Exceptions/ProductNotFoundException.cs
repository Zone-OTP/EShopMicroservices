using BuildingBlocks.Exceptions;
using System;

public class ProductNotFoundException : NotFoundException
{
	public ProductNotFoundException(Guid Id):base("Product",Id)
	{
	}
}
