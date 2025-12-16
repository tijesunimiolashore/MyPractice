namespace MyPractice.Models.Entities
{
    public class MyPrac
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }
        
        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

		public decimal Salary { get; set; }
	}
}
