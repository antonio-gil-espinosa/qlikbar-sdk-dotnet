using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agile;
using Agile.Collections;
using QlikBar.SDK.DotNet40.Domain.Model;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.Results;
using Article = QlikBar.SDK.DotNet40.Domain.Model.Article;
using Category = QlikBar.SDK.DotNet40.Domain.Model.Category;

namespace QlikBar.SDK.DotNet40.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly LocalWebServices _localWebServices;
        public CategoryRepository(int localId, string apiKey, RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _localWebServices = new LocalWebServices(localId, apiKey);
        }

        public IEnumerator<Category> GetEnumerator() { return List().AsEnumerable().GetEnumerator(); }
        private Category[] List()
        {
            return _repositoryFactory.MappingEngine.Map<Category[]>(_localWebServices.GetMenu());
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public void Add(Category item)
        {
            Response<CreateCategoryResult> response = _localWebServices.CreateCategory(item.Name, null, item.Image, item.Visible, item.RemoteId, item.Parent.Id);
            item.Id = response.Data.Id;
            item.Image = response.Data.Image;
        }
        public void Clear()
        {
            foreach (Category category in this)
            {
                foreach (Article article in category.Articles)
                    _localWebServices.DeleteArticle(article.Id);

                _localWebServices.DeleteCategory(category.Id);
            }
        }
        public bool Contains(Category item) { throw new InvalidOperationException(); }
        public void CopyTo(Category[] array, int arrayIndex) { List().CopyTo(array, arrayIndex); }
        public bool Remove(Category item)
        {
            Remove(item.Id);
            return true;
        }
        public int Count { get { return List().Length; } }
        public bool IsReadOnly { get { return false; } }
        public void Remove(int value) { _localWebServices.DeleteCategory(value); }
        public void Update(Category value) { _localWebServices.EditCategory(value.Id, value.Name, null, value.Image, value.Visible, value.RemoteId); }
        public Category Get(int id) { throw new NotImplementedException(); }
    }
}
