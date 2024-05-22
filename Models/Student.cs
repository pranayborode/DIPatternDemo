using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DIPatternDemo.Models
{

	[Table("std")]
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Phone { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Address { get; set; }

		[ScaffoldColumn(false)]
		public int IsActive { get; set; }
	}
}
