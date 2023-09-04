using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace top_medkit_models
{
    public class ModelController
    {
        private ModelController() { }
        public static Type[] GetModelTypes() =>
            Assembly.GetCallingAssembly()
                    .GetTypes()
                    .Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass)
                    .ToArray();
    }
}
