using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using TestProject.Models;

namespace TestProject.Workers
{
    public class XmlWorker
    {
        private readonly SafeQueue<NodeInfo> _queue;
        private readonly SyncEvents _syncEvents;
        private readonly AutoResetEvent _doneEvent = new AutoResetEvent(false);

        public XmlWorker(SafeQueue<NodeInfo> queue, SyncEvents syncEvents)
        {
            _queue = queue;
            _syncEvents = syncEvents;
            _syncEvents.AddDoneEvent(_doneEvent);
        }

        public void WriteXml(object xmlPath)
        {
            var path = (string) xmlPath;
            var i = 0;

            while (!_syncEvents.ExitThreadEvent.WaitOne(0, false))
            {
                if (_queue.Count != 0)
                {
                    _doneEvent.Set();
                    var item = _queue.Dequeue();
                }
                
                // seems like we have handled all items
                // wait for new item event
                else
                {
                    _syncEvents.NewItemEvent.WaitOne();
                }
            }
        }
    }
}