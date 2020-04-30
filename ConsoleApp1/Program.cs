using IOper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                反射：
                    作用：发现一个类型的所有成员（对类型的内部执行遍历查询）
                          为了实现对类型的 动态化调用

                    关键字：Type 类型
                            MemberInfo 成员
                            Assembly 程序集(指已经打包编译的exe或dll文件)
             */

            #region 通过反射发现类Class1的成员

            Console.WriteLine("发现Class1类型:");
            Type type = typeof(Class1);         // 获取Class1的类型
            Console.WriteLine(type);            // ConsoleApp1.Class1
            Console.WriteLine(type.Assembly);   // ConsoleApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
            Console.WriteLine($"是否是类：{type.IsClass}");  // True
            Console.WriteLine("Class1的所有成员:");
            MemberInfo[] memberInfos = type.GetMembers();    // 获取Class1的所有成员(包括父类成员和构造函数)
            foreach (var item in memberInfos)
            {
                Console.WriteLine($"{item.MemberType},{item}");
            }

            #endregion

            #region 通过反射动态调用类型的基本用法

            /* 对比:调用类型的普通方式:
                Class1 class1 = new Class1();
                class1.Fun();
               上面的调用方式的前提是:
                    Class1必须添加引用到当前项目,无法实现动态化的切换调用,如:
                            Main可以调用A.dll里面的Class1,也可以调用B.dll的Class1, ..... N.dll的Class1

               而反射调用,不需要添加引用,可以自动调用,实现不同dll的识别和调用,而且不用编译原始调用代码
            */

            Console.WriteLine("\r\n反射调用DLLa.dll文件的Fun方法:");
            // 反射调用DLLa的Class1(不引用的情况)
            // 由于要调用dll文件,要使用Assembly类, 使用LoadFrom从Debug或Release目录的路径中加载dll文件
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "DLLa.dll");
            // 通过Type发现DLLa里面的Class1类型, 要指定Class1的完整名称
            Type type2 = assembly.GetType("DLLa.Class1");
            // 调用Class1,先做初始化, 通过上面发现的type2完成初始化. obj就是Class1初始化后的对象
            object class1 = Activator.CreateInstance(type2);
            // 上面Class1初始化成功后,可以调用里面的方法, 通过GetMethod找到Fun方法
            MethodInfo fun = type2.GetMethod("Fun");
            // 找到Fun方法的内容后,通过委托调用
            fun.Invoke(class1, null);
            // Invoke委托调用Fun, 参数是Class1对象, null的位置是Fun的参数,没有参数用null

            #endregion

            #region 反射动态调用不同dll文件

            /*
                Main方法通过反射动态调用不同的dll文件:
                    1.IOper 接口(规范化dll文件的内容, Main的解耦)
                    2.DLLa.dll 文件, 实现IOper接口
                      DLLb.dll 文件, 实现IOper接口
                      ....更多的dll文件
                    3.Factory 工厂类, 封装反射调用

             */
            Console.WriteLine("\r\n反射调用不同的dll文件：");

            // 加载dll文件
            Console.WriteLine("选择功能模块：DLLa 或 DLLb");
            string input = Console.ReadLine();
            Assembly assembly2 = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + $"{input}.dll");
            // 反射发现dll文件里面的类型
            Type type3 = assembly2.GetType($"{input}.Class1");
            // 通过工厂创建类型的对象（初始化）
            Ioper oper = Factory.Create(type3.AssemblyQualifiedName);
            // 通过接口调用方法
            oper.Fun();

            #endregion
        }
    }
}
