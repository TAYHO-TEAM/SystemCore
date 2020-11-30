using Services.Common.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class StaffTayHo : EntityBase
    {
        #region Fields
        private string _userName;
        private string _accountName;
        private byte[] _avatarImg;
        #endregion Fields
        #region Constructors

        private StaffTayHo()
        {
        }

        public StaffTayHo(string UserName,
                        string AccountName,
                        byte[] AvatarImg) : this()
        {
            _userName = UserName;
            _accountName = AccountName;
            _avatarImg = AvatarImg;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(200, ErrorMessage = nameof(ErrorCodeInsert.IErr200))] public string UserName { get => _userName; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string AccountName { get => _accountName; }
        public byte[] AvatarImg { get => _avatarImg; }
        #endregion Properties

        #region Behaviours
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
