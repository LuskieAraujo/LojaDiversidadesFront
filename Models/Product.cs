using System.ComponentModel.DataAnnotations;

namespace LojaDiversidadesFront.Models;
public class Product
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	[Required]
	public string Description { get; set; }
	[Required]
	public float Price { get; set; }
	[Required]
	public int Quantity { get; set; }
	[Required]
	public string Code { get; set; }
	public bool IsActive { get; set; }
}
