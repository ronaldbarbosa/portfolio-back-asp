using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace portfolio_back.Models;

public class Project
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Frontend { get; set; }
    public string Backend { get; set; }
    public string Tools { get; set; }
    public string Url { get; set; }
    public string Code { get; set; }
    public string Image { get; set; }
    public bool Finished { get; set; }
}