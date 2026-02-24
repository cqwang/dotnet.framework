using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class DbContextPreheater
    {
        public static void Preheat<T>() where T : DbContextBase
        {
            var context = Activator.CreateInstance(typeof(T)) as T;
            using (context)
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }

        public static void Preheat_Common<T>() where T : DbContext
        {
            var context = Activator.CreateInstance(typeof(T)) as T;
            using (context)
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
    }
}
