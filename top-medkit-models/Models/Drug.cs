namespace top_medkit_models.Models
{
    public class Drug : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        [NotMapped] public double Quantity => Transactions.Select(x=>x.Amount).Sum(); 

        public virtual DrugInfo DrugInfo { get; set; } = null!;
        public virtual MedKit MedKit { get; set; } = null!;
        public virtual AcceptanceMethod AcceptanceMethod { get; set; } = null!;


        public virtual ICollection<Transaction> Transactions { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; } = null!;
    }
}