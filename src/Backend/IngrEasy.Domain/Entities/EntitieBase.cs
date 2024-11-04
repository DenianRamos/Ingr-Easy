using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IngrEasy.Domain.Entities;

public class EntitieBase
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


    public int id { get; set; }

    public bool Active { get; set; } = true;

}