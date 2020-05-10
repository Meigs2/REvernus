namespace REvernus.Utilities
{
    using System;

    public class StatusHandle : Status, IDisposable
    {
        public int NumActivities { get; set; } = 0;

        public new string StatusText { get; set; } = "";

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