using System;
using System.Collections.Generic;
using System.Text;

namespace REvernus.Utilities
{
    public class StatusHandle : Status, IDisposable
    {

        public new string StatusText { get; set; } = "";
        public int NumActivities { get; set; } = 0;

        private void ReleaseUnmanagedResources()
        {
        }

        public void Dispose()
        {
            DisposeHandle(this);
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~StatusHandle()
        {
            ReleaseUnmanagedResources();
        }
    }
}
