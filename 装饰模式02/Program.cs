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
        }
    }
    //每个人当月业务奖金 = 当月销售额×3%
    //每个人累计奖金 = 总的回款额×0.1%
    //团队奖金 = 团队总销售额×1%
    //一个一个方法的实现可以，但是如果奖金每个月都有调整就比较麻烦了，使用装饰模式

    /// <summary>
    /// 定义接口，组件对象的接口，可一个这些对象动态的添加职责
    /// </summary>
    public abstract class Component
    {
        public abstract void operation();
    }




}
