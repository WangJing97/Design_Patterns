using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式02
{
    class Program
    {
        static void Main(string[] args)
        {

            //很像递归
            Component c1 = new ConcreteComponent();

            //开始对奖金进行装饰
            Decorator d1 = new MonthPrizeDecorator(c1);
            Decorator d2 = new SumPrizeDecorator(d1);

            double z3 = d2.calPrize("张三");
            Console.WriteLine("张三获得" + z3);

            Decorator d3 = new GroupPrizeDecorator(d2);

            double w5 = d3.calPrize("王五");
            Console.WriteLine("王五获得" + w5);
            Console.ReadKey();

        }
    }
    //每个人当月业务奖金 = 当月销售额×3%
    //每个人累计奖金 = 总的回款额×0.1%
    //团队奖金 = 团队总销售额×1%
    //一个一个方法的实现可以，但是如果奖金每个月都有调整就比较麻烦了，使用装饰模式

    public static class Data
    {
        public static double MonthSaleMoney = 123.3;
    }


    /// <summary>
    /// 定义接口，组件对象的接口，可一个这些对象动态的添加职责
    /// 计算奖金的组件接口
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// 计算某人在某段时间内的奖金
        /// </summary>
        /// <param name="user"></param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        public abstract double calPrize(string user);
    }

    /// <summary>
    /// 具体实现组件对象接口的对象
    /// 基本实现计算奖金的类，也是被修饰器修饰的对象
    /// </summary>
    public class ConcreteComponent : Component
    {

        public override double calPrize(string user)
        {
            //相应的功能
            //只是一个默认的实现，默认没有奖金
            return 0;
        }
    }

    /// <summary>
    /// 装饰器接口，维持一个指向组件对象的接口对象，并定义一个与组件接口一致的接口
    /// 装饰器接口，需要和被修饰的对象实现同样的接口
    /// </summary>
    public abstract class Decorator : Component
    {
        //持有组件的对象
        //持有被修饰组件的对象
        protected Component c;

        //构造方法。传入组件对象
        //通过构造方法传入被修饰的对象
        public Decorator(Component c)
        {
            this.c = c;
        }

        public override double calPrize(string user)
        {
            //转发请求组件对象，可以在转发前后执行一些附加操作
            //转调组件对象的方法
            return c.calPrize(user);
            
        }
    }
    
    /// <summary>
    /// 装饰器的具体实现，向组件对象添加职责
    /// 装饰器对象，计算当月业务奖金
    /// </summary>
    public class MonthPrizeDecorator : Decorator
    {
        public MonthPrizeDecorator(Component c) : base(c) { }

        public override double calPrize(string user)
        {
            //1、获取前面运算出来的奖金
            double money = base.calPrize(user);
            //2、计算当月业务奖金，当月销售额×3%
            double prize = 100;
            Console.WriteLine(user + "当月业务奖金" + prize);
            return money + prize;
        }

    }
    /// <summary>
    /// 累计奖金
    /// </summary>
    public class SumPrizeDecorator : Decorator
    {
        public SumPrizeDecorator(Component c) : base(c) { }

        public override double calPrize(string user)
        {
            //1、获取前面运算出来的奖金
            double money = base.calPrize(user);
            //2、计算当月业务奖金，当月销售额×3%
            double prize = 1000;
            Console.WriteLine(user + "累计奖金" + prize);
            return money + prize;
        }
    }

    /// <summary>
    /// 团队
    /// </summary>
    public class GroupPrizeDecorator : Decorator
    {
        public GroupPrizeDecorator(Component c) : base(c) { }

        public override double calPrize(string user)
        {
            //1、获取前面运算出来的奖金
            double money = base.calPrize(user);
            //2、计算当月业务奖金，当月销售额×3%
            double prize = 10000;
            Console.WriteLine(user + "累计奖金" + prize);
            return money + prize;
        }
    }

}
