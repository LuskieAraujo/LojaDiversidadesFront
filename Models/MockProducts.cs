namespace LojaDiversidadesFront.Models;

public class MockProduct
{
	public async Task<List<Product>> Products()
	{
		return new List<Product>
		{
			new Product
			{
				Id = 1,
				Name = "Papel A4",
				Description = "Folha de sulfite de tamanho A4.",
				Price = 1.25f,
				Quantity = 1000,
				IsActive = true
			},
			new Product
			{
				Id = 2,
				Name = "Fita Adesiva",
				Description = "Fita auto-colante.",
				Price = 2.5f,
				Quantity = 100,
				IsActive = false
			},
			new Product
			{
				Id = 3,
				Name = "Caneta Azul",
				Description = "Caneta esferográfica.",
				Price = 1.5f,
				Quantity = 50,
				IsActive = false
			},
			new Product
			{
				Id = 4,
				Name = "Lápis Preto",
				Description = "Lápis grafite Nº2B.",
				Price = 1,
				Quantity = 1500,
				IsActive = true
			}
		};
	}
}