using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.Result
{
    public enum ResultEnum
    {
        操作成功 = 200,
        操作失败 = 300,
        未登录 = 301,

        可授权 = 100,
        可访问 = 101,



    }
}
