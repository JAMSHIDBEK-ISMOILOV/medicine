using System;
namespace Medicine.WebApi.DTOs
{
	public class MedicineViewModel
	{
		public string Name { get; set; }
		public string Structure { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

