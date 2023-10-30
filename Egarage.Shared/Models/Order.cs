using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egarage.Shared.Models
{
    public record Order(Guid Id, string Name, string Color);
}
