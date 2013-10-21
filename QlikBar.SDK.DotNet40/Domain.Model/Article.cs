

using System.Collections.Generic;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class Article : IEntity
    {
        public virtual IEnumerable<ComboList> Parts { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Visibility { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual string Name { get; set; }
        public virtual string RemoteId { get; set; }
        public virtual Category Parent { get; set; }

        public virtual int Id
        {
            get; set;
        }
    }
}