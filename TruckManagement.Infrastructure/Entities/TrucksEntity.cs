using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TruckManagement.Domain.Enums;

namespace TruckManagement.Infrastructure.Entities;

[Table("Trucks")]
public class TrucksEntity
{
    public TrucksEntity(string description, string name, string code)
    {
        Description = description;
        Name = name;
        Code = code;
        
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Code { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    
    [StringLength(1000)]
    public string Description { get; set; }
    
    public StatusEnum Status { get; set; }
}