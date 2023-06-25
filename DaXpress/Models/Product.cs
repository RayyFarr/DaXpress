namespace DaXpress.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public int Price { get; set; }
		public string UserName { get; set; }
		public DateTime CreatedDate { get; set; }

		public Product()
		{

		}

	}
}
