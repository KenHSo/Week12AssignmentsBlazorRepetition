using System.ComponentModel.DataAnnotations;

namespace Week12AssignmentsBlazorRepetition
{
    public class Person
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; };

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }

}
