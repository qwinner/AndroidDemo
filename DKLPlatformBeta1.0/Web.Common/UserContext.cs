﻿using System;
using HYZK.Core.Cache;
using HYZK.Account.Contract;

namespace Web.Common
{
    public class UserContext
    {
        protected IAuthCookie authCookie;

        public UserContext(IAuthCookie authCookie)
        {
            this.authCookie = authCookie;
        }

        public LoginInfo LoginInfo
        {
            get
            {
                return CacheHelper.GetItem<LoginInfo>("LoginInfo", () =>
                {
                    if (authCookie.UserToken == Guid.Empty)
                        return null;

                    var LoginInfo = ServiceContext.Current.AccountService.GetLoginInfo(authCookie.UserToken);

                    if (LoginInfo != null && LoginInfo.UserID > 0 && LoginInfo.UserID != this.authCookie.UserId)
                        throw new Exception("非法操作，试图通过网站修改Cookie取得用户信息！");

                    return LoginInfo;
                });
            }
        }
    }
}
