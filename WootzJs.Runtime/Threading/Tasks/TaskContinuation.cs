namespace System.Threading.Tasks
{
    internal abstract class TaskContinuation
    {
        protected TaskContinuation()
        {
        }

        internal abstract void Run(Task completedTask, bool bCanInlineContinuationTask);

/*
        protected static void InlineIfPossibleOrElseQueue(Task task, bool needsProtection)
        {
            if (needsProtection)
            {
                if (!task.MarkStarted())
                    return;
            }
            else
                task.m_stateFlags |= 65536;
            try
            {
                if (task.m_taskScheduler.TryRunInline(task, false))
                    return;
                task.m_taskScheduler.QueueTask(task);
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException && (task.m_stateFlags & 134217728) != 0)
                    return;
                var schedulerException = new TaskSchedulerException(ex);
                task.AddException((object) schedulerException);
                task.Finish(false);
            }
        }
*/
    }
}