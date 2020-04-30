using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSQLServer
{
    /// <summary>
    /// SQLServer版 学生信息数据管理类
    /// </summary>
    public class StudentService : IStudentDataAccess
    {
        public Student Get()
        {
            return new Student { Sid = "ST001", Sname = "从SQLServer查询的学生：张三" };
        }
    }
}
