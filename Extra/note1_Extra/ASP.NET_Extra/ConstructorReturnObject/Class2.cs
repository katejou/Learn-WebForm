using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructorReturnDiffrenceObject_Test
{

    public class ConstructorTest : ClassT
    {
        public ConstructorTest(string which)
        {
            switch (which)
            {
                case "a":
                    new Class1();
                    break;
                case "b":
                    new Class2();
                    break;
            }
        }
    }

    abstract public class ClassT
    {
        public virtual string str
        {
            get
            {
                return "ClassT";
            }
        }
    }

    public class Class2 : ClassT
    {
        //public new string str = "Class2";   // 屬性不能 virtual , 無法 override , 所以轉為父型時，無法保持自己。

        public override string str
        {
            get
            {
                return "Class222222222222";
            }
        }
    }


    public class Class1 : ClassT
    {
        public override string str
        {
            get
            {
                return "Class111111111111111111";
            }
        }
    }

    public class ClassA
    {
        public virtual string str
        {
            get
            {
                return "ClassA";
            }
        }
    }

    public class ClassB : ClassA
    {
        public override string str
        {
            get
            {
                return "ClassB";
            }
        }
    }


}