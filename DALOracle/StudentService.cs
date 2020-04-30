using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALOracle
{
    /// <summary>
    /// Oracle版 学生信息数据管理类
    /// </summary>
    public class StudentService : IStudentDataAccess
    {
        public Student Get()
        {
            return new Student { Sid = "ST002", Sname = "从Oracle查询的学生：李四" };

        }
    }
}
