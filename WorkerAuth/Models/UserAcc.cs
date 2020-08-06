using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerAuth
{
    //summary
    //the table of the application
    //summary

    public class UserAcc
    {
        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        public string PasswordHashed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string PhoneNumber { get; set; }

       
        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        
        [Column(TypeName = "nvarchar(255)")]
        public string PermanentAddress { get; set; }

        
        [Column(TypeName = "nvarchar(255)")]
        public string TemporaryAddress { get; set; }

        
        [Column(TypeName = "nvarchar(10)")]
        public string Sex { get; set; }

      
        [Column(TypeName = "nvarchar(255)")]
        public string Citizenship { get; set; }

        
        [Column(TypeName = "nvarchar(255)")]
        public string CV { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool InactiveUsers { get; set; }


    }
}
