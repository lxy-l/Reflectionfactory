using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DALFactory
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factory
    {
        /*
            通过反射调用数据实现类（SQLServer、Oracle、MySQL、。。。。）
            对数据实现类不用添加引用
            使用数据访问接口（IDAL.IStudentDataAccess） 与数据实现类之间解耦
         */

        // 工厂方法Create需要调用的参数通过配置实现（Web.Config文件）
        //static string dll = "DALOracle";    // 数据实现类的命名空间的名称
        static string dll = WebConfigurationManager.AppSettings["DataAccess"];
        // 上面的内容需要在web.config里面加入 <appSettings> 节点


        public static IStudentDataAccess  Create()
        {
            /* 
                基本的调用方法：
                // 反射加载dll文件
                Assembly assembly = Assembly.Load(dll);
                // 反射初始化dll文件里面的类, 完整的类名是： 命名空间的名称.类名
                return  (IStudentDataAccess)assembly.CreateInstance($"{dll}.StudentService");
            */

            /*
                Assembly.Load(dll) 每次调用都会执行，导致文件操作频繁降低性能
                采用缓存机制解决此问题：
            */

            // 缓存的键
            string key = $"{dll}.StudentService";
            // 从缓存中获取反射对象
            var cache = CacheHelper.GetCache(key);
            // 如果反射对象为null，需要先反射初始化该对象
            if (cache == null)
            {
                Assembly assembly = Assembly.Load(dll);
                cache = assembly.CreateInstance(key);
                // 将上面反射初始化的结果存放到缓存
                CacheHelper.SetCache(key, cache);
            }

            // 将缓存中的反射对象返回
            return cache as IStudentDataAccess;
        }
    }
}
