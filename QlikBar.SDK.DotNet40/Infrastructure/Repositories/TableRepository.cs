using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.Results;
using Table = QlikBar.SDK.DotNet40.Domain.Model.Table;

namespace QlikBar.SDK.DotNet40.Infrastructure.Repositories
{
    public class TableRepository : IRepository<Table>
    {
        private readonly RepositoryFactory _repositoryFactory;

        private readonly LocalWebServices _localWebServices;
         public TableRepository(int localId, string apiKey, RepositoryFactory repositoryFactory)
         {
             _repositoryFactory = repositoryFactory;

             _localWebServices = new LocalWebServices(localId,apiKey);
         }

        public IEnumerator<Table> GetEnumerator()
        {
            return new List<Table>(List()).GetEnumerator();
        }

        private Table[] List()
        {
            DTOs.Table[] tablesDTO = _localWebServices.GetTables();
            IEnumerable<Table> tables = _repositoryFactory.MappingEngine.Map<IEnumerable<Table>>(tablesDTO);

            IEnumerable<Order> flattenedOrderDTOS = tablesDTO.SelectMany(x => x.CheckIns).SelectMany(x => x.Orders).ToArray();
            IEnumerable<OrderPart> flattenedOrderPartsDTOs = flattenedOrderDTOS.SelectMany(x => x.Parts).ToArray();
            IEnumerable<Domain.Model.Order> flattenedOrders = tables.SelectMany(x => x.CheckIns).SelectMany(x => x.Orders).ToArray();
            IEnumerable<Domain.Model.OrderPart> flattenedORderParts = flattenedOrders.SelectMany(x => x.Parts).ToArray();


            foreach (var order in flattenedOrderDTOS)
            {
                flattenedORderParts.Single(x => x.Id == order.Id)
                                   .Article = _repositoryFactory.IdentityMap.GetEntity<Domain.Model.Article>(order.Article) ??
                                              _repositoryFactory.GetArticleRepository()
                                                                .Single(x => x.Id == order.Article);

            }



            foreach (var part in flattenedOrderPartsDTOs)
            {
                flattenedORderParts.Single(x => x.Id == part.Id)
                                   .Article = _repositoryFactory.IdentityMap.GetEntity<Domain.Model.Article>(part.Article) ??
                                              _repositoryFactory.GetArticleRepository()
                                                                .Single(x => x.Id == part.Article);

            }

            return tables.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public void Add(Table item)
        {
            Response<CreateTableResult> response = _localWebServices.CreateTable(item.Enabled,item.Name,item.RemoteId);
            item.Id = response.Data.Id;
            item.Qr = response.Data.Qr;
        }
        public void Clear()
        {
            foreach (Table table in this)
                Remove(table);
        }
        public bool Contains(Table item) { throw new InvalidOperationException(); }
        public void CopyTo(Table[] array, int arrayIndex) { throw new NotImplementedException(); }

        public bool Remove(Table item)
        {
            Remove(item.Id);
            return true;
        }
        public int Count { get { return List().Length; } } 
        public bool IsReadOnly { get { return false; } }
        public void Remove(int value) { _localWebServices.DeleteTable(value); }
        public void Update(Table value) { _localWebServices.EditTable(value.Id,value.Enabled,value.Name,value.RemoteId); }
        public Table Get(int id) { throw new NotImplementedException(); }
    }
}
