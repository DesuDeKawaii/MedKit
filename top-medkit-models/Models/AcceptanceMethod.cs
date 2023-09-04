namespace top_medkit_models.Models
{
    public class AcceptanceMethod : IEntity
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;

        public override string ToString() => Name;  
    }
}