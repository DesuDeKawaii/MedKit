namespace top_medkit_models.Models
{
    public class MedKit : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Desc { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; } = null!;
        public virtual ICollection<DrugInfo> DrugInfos { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; } = null!;
    }
}
