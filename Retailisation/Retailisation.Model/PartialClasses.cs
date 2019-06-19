using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailisation.Model
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product: DomainObject
    {
    }

    [MetadataType(typeof(StoreMetadata))]
    public partial class Store : DomainObject
    {
    }

}
