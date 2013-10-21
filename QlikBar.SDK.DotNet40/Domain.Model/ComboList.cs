using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class ComboList
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<ComboListItem> Items { get; set; }
    }
}
