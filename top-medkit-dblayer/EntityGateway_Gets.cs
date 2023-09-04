using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using top_medkit_models;
using top_medkit_models.Models;

namespace top_medkit_dblayer
{
    public partial class EntityGateway
    {
        public Client[] GetClients(Func<Client, bool> predicate) =>
            Context.Clients.Where(predicate).ToArray();

        public Client[] GetClients() =>
            Context.Clients.ToArray();
        
        public Drug[] GetDrugs(Func<Drug, bool> predicate) =>
            Context.Drugs.Where(predicate).ToArray();

        public Drug[] GetDrugs() =>
            Context.Drugs.ToArray();

        public DrugInfo[] GetDrugsInfo(Func<DrugInfo, bool> predicate) =>
           Context.DrugInfos.Where(predicate).ToArray();

        public DrugInfo[] GetDrugsInfo() =>
            Context.DrugInfos.ToArray();

        public MedKit[] GetMedKits(Func<MedKit, bool> predicate) =>
           Context.MedKits.Where(predicate).ToArray();
        
        public MedKit[] GetMedKits() =>
            Context.MedKits.ToArray();

        public T[] GetTable<T>(Func<T, bool> predicate) where T : class, IEntity => 
            Context.Set<T>().Where(predicate).ToArray();

        public T[] GetTable<T>() where T : class, IEntity =>
            Context.Set<T>().ToArray();
    }
}
