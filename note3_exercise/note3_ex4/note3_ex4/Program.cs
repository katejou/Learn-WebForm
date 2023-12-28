using System;
using System.Runtime.InteropServices;

namespace note3_ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ADODB.Connection cn = new ADODB.Connection();
            cn.Open(@"Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=pubs;user id=me;password='123kate*';",
                "","",-1);

            ADODB.Recordset rs = new ADODB.Recordset();
            rs.Open("seleet * from titles",
                     cn,
                     ADODB.CursorTypeEnum.adOpenStatic,
                     ADODB.LockTypeEnum.
                     adLockReadOnly, -1);

            while (!rs.EOF)
            {
                Console.WriteLine(rs.Fields[1].Value);
                rs.MoveNext();
            };

            rs.Close();
            cn.Close();

            Marshal.ReleaseComObject(rs);
            Marshal.ReleaseComObject(cn);

        }
    }
}
