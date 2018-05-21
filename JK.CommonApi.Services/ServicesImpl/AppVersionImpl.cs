using JK.CommonApi.Services.IServices;
using JK.Core.Core.Data;
using JK.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JK.CommonApi.Services.ServicesImpl
{
    public class AppVersionImpl : IAppVersion
    {
        private IRepository<AppVersion> _AppVersionRepository;

        public AppVersionImpl(IRepository<AppVersion> appVersionRepository)
        {
            _AppVersionRepository = appVersionRepository;
        }
        public int GetAppVersionCount()
        {
            return _AppVersionRepository.Table.Where(q => !q.IsDeleted).Count();
        }

        public int GetAppVersionCountOld()
        {
            //    using (JKDataContext context=new JKDataContext())
            //    {
            //        return context.AppVersion.Count();
            //    }
            return 1;
        }
          
    }
}
