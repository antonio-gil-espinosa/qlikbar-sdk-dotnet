using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class Category : IEntity
    {
        public Category Parent { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public string RemoteId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Article> Articles { get; set; }

        public bool Deleted { get; set; }

        public bool Visible { get; set; }

        public IEnumerable<Category> Subcategories { get; set; }
    }
}
