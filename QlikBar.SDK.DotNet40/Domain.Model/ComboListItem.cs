using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class ComboListItem
    {
        public virtual int Id { get; set; }
        public virtual Article Article { get; set; }
        public virtual decimal Price { get; set; }
    }
}
