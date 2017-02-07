﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using HYZK.FrameWork.Web;
using HYZK.FrameWork.Common;
using HYZK.Core.Log;
using HYZK.Account.Contract;
using DKLManager.Contract;


namespace Web.Common
{
    public abstract class ControllerBase : HYZK.FrameWork.Web.ControllerBase
    {
        public virtual IAccountService AccountService
        {
            get
            {
                return ServiceContext.Current.AccountService;
            }
        }

        public virtual IDKLManager IDKLManagerService
        {
            get
            {
                return ServiceContext.Current.DKLManagerService;
            }
        }

        //public virtual ICrmService CrmService
        //{
        //    get
        //    {
        //        return ServiceContext.Current.CrmService;
        //    }
        //}

        //public virtual IOAService OAService
        //{
        //    get
        //    {
        //        return ServiceContext.Current.OAService;
        //    }
        //}

        protected override void LogException(Exception exception, 
            WebExceptionContext exceptionContext = null)
        {
            base.LogException(exception);

            var message = new
            {
                exception = exception.Message,
                exceptionContext = exceptionContext,
            };

            Log4NetHelper.Error(LoggerType.WebExceptionLog, message, exception);
        }

        public IDictionary<string, object> CurrentActionParameters { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
