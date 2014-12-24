using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyStatusRepository : IGenericRepository<Status>
    {
        private readonly ICollection<Status> _status;
        public DummyStatusRepository()
        {
            _status = new List<Status>
            {
                new Status
                {
                    Status1 = "Incompleet"
                },
                new Status
                {
                    Status1 = "Nieuw"
                },
                new Status
                {
                    Status1 = "Compleet(gecontroleerd)"
                },
                new Status
                {
                    Status1 = "Compleet(ongecontroleerd)"
                }
            };
        }

        public IEnumerable<Status> GetAll()
        {
            return _status;
        }

        public Status GetOne(string key)
        {
            return (_status.Where(status => status.Status1.Equals(key))).First();
        }

        public bool Create(Status entity)
        {
            if (_status != null)
            {
                _status.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Status entity)
        {
            return _status.Remove(entity);
        }

        public bool Edit(Status entity)
        {
            Status oldStatus = (_status.Where(status => status.Status1.Equals(entity.Status1))).First();
            if (Delete(oldStatus))
            {
                return Create(entity);
            }
            return false;
        }
    }
}
