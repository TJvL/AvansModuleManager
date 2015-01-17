using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.DomainDAL.Repositories
{
    public class GenericRepo
    {
        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (var context = new DomainContext())
            {
                return context.Set<T>().IncludeMultiple(Test.GetNavigationPropertiesNameOfClass<T>()).ToList();
                //return context.Set<T>();
                //return context.Module;
            }
        }

        public IEnumerable<Fase> GetAllIncludeMultiple()
        {
            using (var context = new DomainContext())
            {
                return context.Set<Fase>().IncludeMultiple(Test.GetNavigationPropertiesNameOfClass<Fase>()).ToList();
                //return context.Set<T>();
                //return context.Module;
            }
        }

        public IEnumerable<Fase> GetAllInclude()
        {
            using (var context = new DomainContext())
            {
                //return context.Set<Fase>().IncludeMultiple(Test.GetPropertiesNameOfClass<Fase>()).Select(src => src).ToList();
                //return (from x in context.Set<Fase>().IncludeMultiple(Test.GetPropertiesNameOfClass<Fase>()) select x).ToList();
                return context.Fase.Include("FaseType1").ToList();
                //return context.Set<T>();
                //return context.Module;
            }
        }

        public IEnumerable<Fase> GetAllNormaal()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Fase.Include("FaseType1") select b).ToList();
            }
        }
    }
}
