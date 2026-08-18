using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Doctors;

public class CreateUpdateDoctorDto
{
    [Required]
    [StringLength(64)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Specialty { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
}