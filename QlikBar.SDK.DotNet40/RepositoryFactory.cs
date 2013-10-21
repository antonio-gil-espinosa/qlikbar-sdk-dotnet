
using System.Linq;
using Agile.Collections;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Mappers;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.DotNet40.Domain.Model;
using QlikBar.SDK.DotNet40.Infrastructure;
using QlikBar.SDK.DotNet40.Infrastructure.Repositories;
using Article = QlikBar.SDK.DTOs.Article;
using Category = QlikBar.SDK.DotNet40.Domain.Model.Category;

namespace QlikBar.SDK.DotNet40
{
    public class RepositoryFactory
    {
        public int LocalId { get; private set; }
        public string ApiKey { get; private set; }
        internal AutoMapper.MappingEngine MappingEngine { get; private set; }

        internal IdentityMap IdentityMap { get; private set; }



        public RepositoryFactory(int localId, string apiKey)
        {
            IdentityMap = new IdentityMap();
            LocalId = localId;
            ApiKey = apiKey;

            //ProxyGenerator proxyGenerator = new ProxyGenerator();

            ConfigurationStore mappingConfiguration = new ConfigurationStore((ITypeMapFactory)new TypeMapFactory(), PlatformAdapter.Resolve<IMapperRegistry>()
                                                                                                                  .GetMappers());
            
            mappingConfiguration.CreateMap<DTOs.Article, Domain.Model.Article>()
                                .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.Article>(x.Id))
                                 .ForMember(x => x.Parent, x => x.ResolveUsing(y => _EntityFromIdentityMapOrCreate<Domain.Model.Category>(y.Parent)));

            //.AfterMap((source, dest) => IdentityMap.SetEntity(source.Id, dest));


            mappingConfiguration.CreateMap<ComboPart, ComboList>()
                 .ForMember(x => x.Items, x => x.MapFrom(y => y.Candidates))
               
                                .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.ComboList>(x.Id));


            mappingConfiguration.CreateMap<Candidate, ComboListItem>()
                                .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.ComboListItem>(x.Id))
                                .ForMember(x => x.Article, x => x.ResolveUsing(y => _EntityFromIdentityMapOrCreate<Domain.Model.Article>(y.Article)));
            

            mappingConfiguration.CreateMap<DTOs.Category, Category>()
                                                 .ForMember(x => x.Parent, x => x.ResolveUsing(y => _EntityFromIdentityMapOrCreate<Domain.Model.Category>(y.Parent)))
                  .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.Category>(x.Id));

            mappingConfiguration.CreateMap<DTOs.Table, Domain.Model.Table>()
                                 .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.Table>(x.Id));

            mappingConfiguration.CreateMap<DTOs.CheckIn, Domain.Model.CheckIn>()
                                  .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.CheckIn>(x.Id));

            mappingConfiguration.CreateMap<DTOs.Order, Domain.Model.Order>()
                                   .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.Order>(x.Id))
                                   .ForMember(x => x.Article, x => x.ResolveUsing(y => _EntityFromIdentityMapOrCreate<Domain.Model.Article>(y.Article)));

            mappingConfiguration.CreateMap<DTOs.OrderPart, Domain.Model.OrderPart>()
                                  .ConstructUsing(x => _EntityFromIdentityMapOrCreate<Domain.Model.OrderPart>(x.Id))
                                  .ForMember(x => x.Article, x => x.ResolveUsing(y => _EntityFromIdentityMapOrCreate<Domain.Model.Article>(y.Article)));

            mappingConfiguration.AssertConfigurationIsValid();

            MappingEngine = new MappingEngine(mappingConfiguration);
        }

        private T _EntityFromIdentityMapOrCreate<T>(object id) where T : class,new()
        {
            if (id == null)
                return null;

            T item = IdentityMap.GetEntity<T>(id);
            if (item == null)
            {
                item = new T();
                IdentityMap.AddEntity(id, item);
            }
            return item;
        }

        public IRepository<Domain.Model.Article> GetArticleRepository()
        {
            return new ArticleRepository(LocalId, ApiKey, this);
        }

        public IRepository<Domain.Model.Category> GetCategoryRepository()
        {
            return new CategoryRepository(LocalId, ApiKey, this);
        }

        public IRepository<Client> GetClientRepository()
        {
            return new ClientRepository(LocalId, ApiKey, IdentityMap);
        }
        public IRepository<Domain.Model.Table> GetTableRepository()
        {
            return new TableRepository(LocalId, ApiKey, this);
        }
    }
}
