using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class NodeInfo : FileSystemInfo
    {
        private readonly FileSystemInfo _info;

        public NodeInfo(FileSystemInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException();
            }

            _info = info;
        }

        public override void Delete()
        {
            _info.Delete();
        }

        public override string Name
        {
            get { return _info.Name; }
        }

        public override bool Exists
        {
            get { return _info.Exists; }
        }
    }
}