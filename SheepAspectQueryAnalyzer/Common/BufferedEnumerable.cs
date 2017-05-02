using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SheepAspectQueryAnalyzer.Common
{
    //public class BufferedEnumerable<T>: IEnumerable<T>
    //{
    //    private readonly Queue<T> _queue = new Queue<T>();
    //    private bool _finished = false;

    //    public BufferedEnumerable(IEnumerable<T> enumerable)
    //    {
    //        Action act = () =>
    //        {
    //            lock (_queue)
    //            {
    //                foreach (var item in enumerable)
    //                {
    //                    _queue.Enqueue(item);
    //                    Monitor.Pulse(_queue);
    //                }
    //                _finished = true;
    //                Monitor.Pulse(_queue);
    //            }
    //        };
    //        act.BeginInvoke(null, null);

    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    { 
    //        lock (_queue)
    //        {
    //            while(true)
    //            {
    //                while (_queue.Count > 0)
    //                {
    //                    yield return _queue.Dequeue();
    //                }

    //                if (!_finished)
    //                    Monitor.Wait(_queue);
    //                else if (_queue.Count == 0)
    //                    break;
    //            }
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}
}