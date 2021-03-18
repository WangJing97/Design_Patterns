using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3();
            Console.ReadKey();
        }
        /// <summary>
        /// 建立对象，并对其进行两次装饰
        /// </summary>
        static void Test()
        {
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Console.WriteLine(text.Content);
        }
        /// <summary>
        /// 建立对象，只进行一次装饰
        /// </summary>
        static void Test1()
        {
            IText text = new TextObject();
            text = new ColorDecorator(text);
            Console.WriteLine(text.Content);
        }
        /// <summary>
        /// 建立装饰，撤销某些操作
        /// </summary>
        static void Test3()
        {
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            text = new BlockAllDecorator(text);
            text = new TextObject();
            Console.WriteLine(text.Content);
        }
    }

    //抽象部分
    public interface IText
    {
        string Content { get; }
    }
    public interface iDecorator : IText { }

    public abstract class DecoratorBase : iDecorator    //is a
    {
        //has a
        protected IText target;

        public DecoratorBase(IText target) { this.target = target; }

        public abstract string Content { get; }
    }

    //具体类型实现
    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target) { }

        public override string Content
        {
            get { return ChangeToBoldFont(target.Content); }
        }

        public string ChangeToBoldFont(string content)
        {
            return "<b>" + content + "</b>";
        }
    }

    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target) { }

        public override string Content
        {
            get { return AddColorTag(target.Content); }
        }

        public string AddColorTag(string content)
        {
            return "<Color>" + content + "</Color>";
        }
    }

    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BlockAllDecorator : DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target) { }

        public override string Content
        {
            get { return string.Empty; }
        }

    }

    /// <summary>
    /// 实体对象类
    /// </summary>
    public class TextObject : IText
    {
        public string Content { get { return "Hello"; } }
    }


}
