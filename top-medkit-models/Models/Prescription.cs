namespace top_medkit_models.Models
{
    public class Prescription : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public virtual Client Client { get; set; } = null!;
        public virtual DrugInfo DrugInfo { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}