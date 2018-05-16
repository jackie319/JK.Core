using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            LotteryHistory = new HashSet<LotteryHistory>();
            UserAccountWechat = new HashSet<UserAccountWechat>();
            UserDeliveryAddress = new HashSet<UserDeliveryAddress>();
            UserOperationRecords = new HashSet<UserOperationRecords>();
            UserShoppingCart = new HashSet<UserShoppingCart>();
            WithdrawCashOrder = new HashSet<WithdrawCashOrder>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Recommender { get; set; }
        public int Money { get; set; }
        public int LuckTotal { get; set; }
        public string AvatarImgUrl { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public bool IsEmailValidated { get; set; }
        public string MobilePhone { get; set; }
        public bool IsMobilePhoneValidated { get; set; }
        public string Status { get; set; }
        public int CountVisited { get; set; }
        public string Ipv4LastVisited { get; set; }
        public bool IsDeleted { get; set; }
        public string UserType { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastVisited { get; set; }

        public ICollection<LotteryHistory> LotteryHistory { get; set; }
        public ICollection<UserAccountWechat> UserAccountWechat { get; set; }
        public ICollection<UserDeliveryAddress> UserDeliveryAddress { get; set; }
        public ICollection<UserOperationRecords> UserOperationRecords { get; set; }
        public ICollection<UserShoppingCart> UserShoppingCart { get; set; }
        public ICollection<WithdrawCashOrder> WithdrawCashOrder { get; set; }
    }
}
