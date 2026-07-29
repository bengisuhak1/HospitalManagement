using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Patients;

// Yeni hasta eklerken veya hastayı güncellerken alınacak bilgiler.
public class CreateUpdatePatientDto
{
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string IdentityNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
}
