<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h1>三层框架的扩展</h1>
        <pre>
            各层：
               UI：界面层
               BLL：业务层
               IDAL：数据接口层
               DALSQLServer：数据访问层（SQLServer版）
               DALOracle：数据访问层（Oralce版）
               DALFactory: 数据工厂
               Model：数据实体

            注意引用的关系：
                UI ——> BLL ——> IDAL
                BLL ——> DALFactory ——> IDAL
                DALOracle、DALFactory——> IDAL

            BLL不添加引用 DALOracle 或 DALFactory，通过反射调用dll文件执行对象和方法
            
            Web.config文件配置当前是使用 DALOracle 或 DALFactory 对象，实现动态切换
            
            使用HttpRuntime.Cache对象缓存反射结果，提升响应性能
        </pre>
    </form>
</body>
</html>
