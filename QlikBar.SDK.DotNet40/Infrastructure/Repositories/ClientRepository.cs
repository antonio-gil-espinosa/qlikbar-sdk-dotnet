using System;
using System.Collections;
using System.Collections.Generic;
using Agile.Collections;
using QlikBar.SDK.DTOs;

namespace QlikBar.SDK.DotNet40.Infrastructure.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly IdentityMap _identityMap;
        private readonly LocalWebServices _localWebServices;
         public ClientRepository(int localId, string apiKey, IdentityMap identityMap)
         {
             _identityMap = identityMap;
             _localWebServices = new LocalWebServices(localId,apiKey);
         }

        public IEnumerator<Client> GetEnumerator() { return new List<Client>(List()).GetEnumerator(); }
        private Client[] List() { return _localWebServices.GetClients().Data; }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public void Add(Client item) { throw new NotImplementedException(); }
        public void Clear() { throw new NotImplementedException(); }
        public bool Contains(Client item) { throw new NotImplementedException(); }
        public void CopyTo(Client[] array, int arrayIndex) { throw new NotImplementedException(); }
        public bool Remove(Client item) { throw new NotImplementedException(); }
        public int Count { get { return List().Length; } }
        public bool IsReadOnly { get { return true; } }
        public void Remove(int value) { throw new NotImplementedException(); }
        public void Update(Client value) { throw new NotImplementedException(); }
        public Client Get(int id) { return _localWebServices.GetClient(id).Data; }
    }
}
