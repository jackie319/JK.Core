using System;
using System.Collections.Generic;
using System.Text;

namespace JK.CommonApi.Services.IServices
{
    public interface IAppVersion
    {
        int GetAppVersionCount();

        int GetAppVersionCountOld();
    }
}
