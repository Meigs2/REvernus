using System;

namespace REvernus.Utilities
{
    public class StatusHandle : Status, IDisposable
    {
        public new string StatusText { get; set; } = "";
        public int NumActivities { get; set; } = 0;

        public void Dispose()
        {
            DisposeHandle(this);
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        private void ReleaseUnmanagedResources()
        {
        }

        ~StatusHandle()
        {
            ReleaseUnmanagedResources();
        }
    }
}