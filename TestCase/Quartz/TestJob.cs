using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Job
{
    [DisallowConcurrentExecution]
    [PersistJobDataAfterExecution]
    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine(context.JobDetail);
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                //log
            }
        }
    }
}
