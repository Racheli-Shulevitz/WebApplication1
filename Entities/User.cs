using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
   
    public int Id { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; } = null!;
    [StringLength(15, ErrorMessage = "firstName can be up to 15 letters")]
    public string FirstName { get; set; } = null!;
    [StringLength(15, ErrorMessage = "lastName can be up to 15 letters")]
    public string? LastName { get; set; }
    [Required]
    public string Password { get; set; } = null!;
}
