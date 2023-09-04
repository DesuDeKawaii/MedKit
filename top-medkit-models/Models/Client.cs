using System.Text.Json.Serialization;

namespace top_medkit_models.Models
{
    public class Client : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;
        [Required] public Gender Gender { get; set; } 
        public DateTime Birthday { get; set; }
        [Required] public double Weight { get; set; }

        [JsonIgnore]public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Drug> Drugs { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<MedKit> MedKits { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Transaction> Transactions { get; set; } = null!;
    }
}