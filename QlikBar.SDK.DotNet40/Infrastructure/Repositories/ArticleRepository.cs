using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agile;
using Agile.Collections;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.DotNet40.Domain.Model;
using Article = QlikBar.SDK.DotNet40.Domain.Model.Article;
using Category = QlikBar.SDK.DTOs.Category;

namespace QlikBar.SDK.DotNet40.Infrastructure.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        public RepositoryFactory RepositoryFactory { get; private set; }

        private readonly LocalWebServices _localWebServices;
         public ArticleRepository(int localId, string apiKey,RepositoryFactory repositoryFactory)
         {
             RepositoryFactory = repositoryFactory;

             _localWebServices = new LocalWebServices(localId,apiKey);
         }

        public IEnumerator<Article> GetEnumerator()
         {
             return List().AsEnumerable().GetEnumerator();
         }

         private Article[] List()
        {
            IEnumerable<Domain.Model.Category> categories = new CategoryRepository(_localWebServices.Id, _localWebServices.ApiKey, RepositoryFactory).ToArray();
            Article[] articles = categories.SelectMany(x => x.Articles).ToArray();

         

            return articles;
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public void Add(Article item) { _localWebServices.CreateArticle(item.Name, null, null, item.Price, item.Parent.Id, item.Visibility, item.RemoteId, 0, false); }
        public void Clear() {
            foreach (Article article in this)
                _localWebServices.DeleteArticle(article.Id);
        }
        public bool Contains(Article item) { throw new System.InvalidOperationException(); }
        public void CopyTo(Article[] array, int arrayIndex) { throw new System.NotImplementedException(); }
        public bool Remove(Article item)
        {
            _localWebServices.DeleteArticle(item.Id);
            return true;
        }
        public int Count { get { return List().Length; } }
        public bool IsReadOnly { get { return false; } }
        public void Remove(int value) { _localWebServices.DeleteArticle(value); }
        public void Update(Article value) { _localWebServices.EditArticle(value.Id, value.Name, null, null, value.Price, value.Visibility, value.RemoteId, 0, false); }
        public Article Get(int id) { return RepositoryFactory.MappingEngine.Map<Article>(_localWebServices.GetClient(id)); }
    }
}
