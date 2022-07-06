using Masa.Webaligner.Core.Entities;
using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Infrastructure.Context;

namespace Masa.Webaligner.Infrastructure.Repositories
{
    public class AlignmentsRepository : EntityBaseRepository<Alignment>,
        IAlignmentsRepository
    {
        public AlignmentsRepository(MasaContext context) : base(context)
        {
            //
        }
    }
}
