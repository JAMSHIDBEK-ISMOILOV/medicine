using System;
namespace Medicine.WebApi.Entities
{
	public class Medicine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Structure { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

