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
        private readonly Queue<NodeInfo> _queue;
        private readonly SyncEvents _syncEvents;

        public XmlWorker(Queue<NodeInfo> queue, SyncEvents syncEvents)
        {
            _queue = queue;
            _syncEvents = syncEvents;
        }

        public void WriteXml(object xmlPath)
        {
            var path = (string) xmlPath;
            var i = 0;

            while (!_syncEvents.ExitThreadEvent.WaitOne(0, false))
            {
                if (_queue.Any())
                {
                    lock (((ICollection) _queue).SyncRoot)
                    {
                        var item = _queue.Dequeue();
                        i++;
                    }
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