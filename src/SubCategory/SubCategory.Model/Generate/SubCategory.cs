using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SubCategory.Model.Generate;
[Table("SubCategory")]
public class SubCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("Name", TypeName = "varchar(255)")]
    public string Name { get; set; }
    [Column("Price", TypeName = "decimal(17,2)")]
    public decimal Price { get; set; }
    [Column("CreatedBy", TypeName = "varchar(255)")]
    public string CreatedBy { get; set; }
    [Column("CreatedAt", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    [Column("UpdatedBy", TypeName = "varchar(255)")]
    public string? UpdatedBy { get; set; }
    [Column("UpdatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
    [Column("DeletedBy", TypeName = "varchar(255)")]
    public string? DeletedBy { get; set; }
    [Column("DeletedAt", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }
}
