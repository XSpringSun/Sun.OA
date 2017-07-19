using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sun.OA.Common
{
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();

        // public static delegate void WriteLogDelegate(string txt);

        public static List<ILogWriter> logWriterList = new List<ILogWriter>();
        static LogHelper()
        {
            //WriteLogDelegate writeLogFun = new WriteLogDelegate(txt =>
            //{
            //    //写入文件 
            //});
            //writeLogFun += (str) =>
            //{
            //    //写入数据库
            //};

            //logWriterList.Add(new TextFileWriter());
            //logWriterList.Add(new SqlServerWriter());
            logWriterList.Add(new log4netWriter());

            //把从队列中获取的错误消息写入日志文件
            ThreadPool.QueueUserWorkItem(o =>
            {
                lock (ExceptionStringQueue)
                {
                    string str = ExceptionStringQueue.Dequeue();
                    //处理日志（变化点：写到日志文件，写到数据库，有可能都写......）

                    //1、（委托，事件）也是观察者模式
                    //writeLogFun(str);

                    //2、更高级的面向对象观察者模式 .Net 2.0这么写
                    //3、log4Net框架用观察者实现日志处理
                    foreach (var logWriter in logWriterList)
                    {
                        logWriter.WriteLogInfo(str);
                    }
                }
            });
        }

        public static void WriteLog(string exceptionString)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionString);
            }
        }
    }
}
