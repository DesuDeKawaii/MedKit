namespace top_medkit_models.Models
{
    public class Transaction : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public virtual Client Client { get; set; } = null!;
        public virtual Drug Drug { get; set; } = null!;
        public double Amount { get; set; }
    }
}