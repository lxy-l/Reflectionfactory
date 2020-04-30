using IOper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factory
    {
        public static Ioper Create(string typeName)
        {
            // 通过反射初始化对象，将对象转为Iopen
            return Activator.CreateInstance(Type.GetType(typeName)) as Ioper;
        }
    }
}
