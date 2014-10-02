using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class SafeQueue<T> where T : class
    {
        private SyncEvents _syncEvents;
        private Queue<T> _queue = new Queue<T>();

        public SafeQueue(SyncEvents syncEvents)
        {
            _syncEvents = syncEvents;
        }

        private SafeQueue()
        {

        }


        public void Enqueue(T item)
        {
            lock (((ICollection) _queue).SyncRoot)
            {
                _queue.Enqueue(item);
                _syncEvents.NewItemEvent.Set();
            }
        }

        public T Dequeue()
        {
            lock (((ICollection) _queue).SyncRoot)
            {
                var item = _queue.First();
                if (WaitHandle.WaitAll(_syncEvents.DoneEvents.ToArray(), 0, false))
                {
                    _queue.Dequeue();
                }

                return item;
            }
        }
        
        public int Count
        {
            get { return _queue.Count; }
        }
    }
}
