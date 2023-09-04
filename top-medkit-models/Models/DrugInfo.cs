namespace top_medkit_models.Models
{
    public class DrugInfo : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Dosage { get; set; }
        public string Contraindications { get; set; } = null!;

        public virtual ICollection<AcceptanceMethod> AcceptanceMethod { get; set; } = null!;
        public virtual ICollection<Drug> Drugs { get; set; } = null!;
        public virtual ICollection<MedKit> MedKits { get; set; } = null!;
    }
}