using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 学生信息管理模块的功能接口
    /// </summary>
    public interface IStudentDataAccess
    {
        /// <summary>
        /// 获取单个学生对象
        /// </summary>
        /// <returns></returns>
        Student Get();
    }
}
