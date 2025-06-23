using System.Linq.Expressions;
using DigiDish.BusinessModels.Users;
using DigiDish.Entities;

namespace DigiDish.Mappers
{
    public class UserMapper
    {
        public static Expression<Func<User, UserBiz>> SelectUserBizFromUserEntity => (userEntity) => new UserBiz()
        {
            ID = userEntity.ID,
            Name = userEntity.Name,
            UserCreatorID = userEntity.UserCreatorID,
            LastUserModifiedID = userEntity.LastUserModifiedID,
            CreationDate = userEntity.CreationDate,
            LastModifiedDate = userEntity.LastModifiedDate,
            IsDeleted = userEntity.IsDeleted,
            Password = userEntity.Password,
            Email = userEntity.Email,
            UserName = userEntity.UserName,
            ProfilePhoto = userEntity.ProfilePhoto,
            PhoneNumber = userEntity.PhoneNumber,
            LastPasswordModifiedDate = userEntity.LastPasswordModifiedDate,
            UserPermission = userEntity.UserPermissions,
        };

        public static void MapUserEntityFromUserBiz(ref User userEntity, ref UserBiz userBiz)
        {
            userEntity.ID = userBiz.ID;
            userEntity.Name = userBiz.Name;
            userEntity.UserCreatorID = userBiz.UserCreatorID;
            userEntity.LastUserModifiedID = userBiz.LastUserModifiedID;
            userEntity.CreationDate = userBiz.CreationDate.ToUniversalTime();
            userEntity.LastModifiedDate = userBiz.LastModifiedDate.ToUniversalTime();
            userEntity.IsDeleted = userBiz.IsDeleted;
            userEntity.Password = userBiz.Password;
            userEntity.Email = userBiz.Email;
            userEntity.UserName = userBiz.UserName;
            userEntity.ProfilePhoto = userBiz.ProfilePhoto;
            userEntity.PhoneNumber = userBiz.PhoneNumber;
            userEntity.LastPasswordModifiedDate = userBiz.LastPasswordModifiedDate?.ToUniversalTime();
            userEntity.UserPermissions = BusinessModels.ENUMS.PERMISSIONS.User;
        }

        public static User MapUserEntityFromUserBiz(UserBiz userBiz)
        {
            return new User()
            {
                ID = userBiz.ID,
                Name = userBiz.Name,
                UserCreatorID = userBiz.UserCreatorID,
                LastUserModifiedID = userBiz.LastUserModifiedID,
                CreationDate = userBiz.CreationDate.ToUniversalTime(),
                LastModifiedDate = userBiz.LastModifiedDate.ToUniversalTime(),
                IsDeleted = userBiz.IsDeleted,
                Password = userBiz.Password,
                Email = userBiz.Email,
                UserName = userBiz.UserName,
                PhoneNumber = userBiz.PhoneNumber,
                ProfilePhoto = userBiz.ProfilePhoto,
                LastPasswordModifiedDate = userBiz.LastPasswordModifiedDate?.ToUniversalTime(),
                UserPermissions = BusinessModels.ENUMS.PERMISSIONS.User,
            };
        }

        public static User MapUserEntityWithAdminFromUserBiz(UserBiz userBiz)
        {
            return new User()
            {
                ID = userBiz.ID,
                Name = userBiz.Name,
                UserCreatorID = userBiz.UserCreatorID,
                LastUserModifiedID = userBiz.LastUserModifiedID,
                CreationDate = userBiz.CreationDate.ToUniversalTime(),
                LastModifiedDate = userBiz.LastModifiedDate.ToUniversalTime(),
                IsDeleted = userBiz.IsDeleted,
                Password = userBiz.Password,
                Email = userBiz.Email,
                UserName = userBiz.UserName,
                PhoneNumber = userBiz.PhoneNumber,
                ProfilePhoto = userBiz.ProfilePhoto,
                LastPasswordModifiedDate = userBiz.LastPasswordModifiedDate?.ToUniversalTime(),
                UserPermissions = BusinessModels.ENUMS.PERMISSIONS.Admin,
            };
        }

        public static UserBiz MapUserBizFromUserEntity(User userEntity)
        {
            return new UserBiz()
            {
                ID = userEntity.ID,
                Name = userEntity.Name,
                UserCreatorID = userEntity.UserCreatorID,
                LastUserModifiedID = userEntity.LastUserModifiedID,
                CreationDate = userEntity.CreationDate.ToUniversalTime(),
                LastModifiedDate = userEntity.LastModifiedDate.ToUniversalTime(),
                IsDeleted = userEntity.IsDeleted,
                Password = userEntity.Password,
                Email = userEntity.Email,
                UserName = userEntity.UserName,
                LastPasswordModifiedDate = userEntity.LastPasswordModifiedDate?.ToUniversalTime(),
                PhoneNumber = userEntity.PhoneNumber,
                ProfilePhoto = userEntity.ProfilePhoto,
                UserPermission = userEntity.UserPermissions,
            };
        }
    }
}
