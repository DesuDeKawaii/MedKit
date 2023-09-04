using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using top_medkit_models;

namespace top_medkit_dblayer
{
    public partial class EntityGateway : IDisposable
    {

        private DrugContext Context { get; init; } = new();
        public Guid AddOrUpdate(params IEntity[] entities)
        {
            var toAdd = entities.Where(x => x.Id == Guid.Empty).ToArray();
            var toUpdate = entities.Except(toAdd).ToArray();

            Context.UpdateRange(toUpdate);
            Context.AddRange(toAdd);
            Context.SaveChanges();

            if (entities.Length == 1)
                return entities[0].Id;
            else
                return Guid.Empty;
        }

        public bool Delete(params IEntity[] entities)
        {
            Context.RemoveRange(entities);
            return Context.SaveChanges() == entities.Length;
        }

        #region IDisposable implemention
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
