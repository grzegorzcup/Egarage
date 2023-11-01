using Egarage.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egarage.Shared.Models
{
    public record GarageModel(Guid Id,string Title, string? Description, Status Status ,Order? Order);
}
