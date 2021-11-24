using survivor.api.Accessor.Contract;
using survivor.api.Entity;
using survivor.api.Mapper;
using survivor.api.Model;
using System;

namespace survivor.api.Accessor
{
    public class UserAccessor : AccessorBase<UserSurvivorModel, UserSurvivor, IRepository<UserSurvivor, Guid>, Guid>, IUserAccessor
    {
        public UserAccessor(IRepository<UserSurvivor, Guid> repository, IMapper<UserSurvivorModel, UserSurvivor, Guid> mapper) : base(repository, mapper)
        {
        }
    }
}
