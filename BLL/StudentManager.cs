using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 学生信息管理的业务功能类
    /// </summary>
    public class StudentManager
    {
        // 通过工厂类获取数据实现类
        IStudentDataAccess access = Factory.Create();

        /// <summary>
        /// 获取学生对象
        /// </summary>
        /// <returns></returns>

        public Student GetStudent()
        {
            // 对比：之前在业务层之间调用数据层
            // StudentService  service = new StudentService();
            // service.Get();
            //上面的内容直接使用SQLServer版本的实现，无法通过切换动态调用不同的实现版本

            // 调用的数据访问接口方法（实现业务层与数据层之间的解耦）
            return access.Get();
        }
    }
}
