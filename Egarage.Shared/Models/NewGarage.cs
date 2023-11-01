using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egarage.Shared.Models
{
    public record NewGarage( string? Name, string? Description, Guid? OrderId);
}
