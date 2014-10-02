using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestProject
{
    public class SyncEvents
    {
        private readonly EventWaitHandle _newItemEvent;
        private readonly EventWaitHandle _exitThreadEvent;
        private readonly List<WaitHandle> _doneEvents;

        public SyncEvents()
        {
            _newItemEvent = new AutoResetEvent(false);
            _exitThreadEvent = new ManualResetEvent(false);
            _doneEvents = new List<WaitHandle>();
        }

        public EventWaitHandle ExitThreadEvent
        {
            get { return _exitThreadEvent; }
        }

        public EventWaitHandle NewItemEvent
        {
            get { return _newItemEvent; }
        }

        public IEnumerable<WaitHandle> DoneEvents
        {
             get { return _doneEvents; } 
        }

        public void AddDoneEvent(WaitHandle waitHandle)
        {
            _doneEvents.Add(waitHandle);
        }
    }
}