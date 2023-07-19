using Gatherly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherly.Domain.Repositories;

public interface IMemberRepository
{
    Task<Member> GetByIdAsync(Guid memberId, CancellationToken cancellationToken);
}
