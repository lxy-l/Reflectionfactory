using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        // 调用业务层
        StudentManager manager = new StudentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 获取学生数据
            Student student = manager.GetStudent();
            Response.Write($"{student.Sid}, {student.Sname}");
        } 
    }
}