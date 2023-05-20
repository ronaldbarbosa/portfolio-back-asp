using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_back.Models;

public class Project
{
    [Column(TypeName = "TEXT")]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Frontend { get; set; }
    public string Backend { get; set; }
    public string DevOps { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
    public bool Finished { get; set; }
}