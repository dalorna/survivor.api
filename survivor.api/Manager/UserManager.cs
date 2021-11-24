using survivor.api.Accessor.Contract;
using survivor.api.Manager.Contract;
using survivor.api.Model;
using System;

namespace survivor.api.Manager
{
    public class UserManager : ManagerBase<UserSurvivorModel, IUserAccessor, Guid>, IUserManager
    {
        public UserManager(IUserAccessor accessor) : base(accessor)
        {
        }
    }
}
