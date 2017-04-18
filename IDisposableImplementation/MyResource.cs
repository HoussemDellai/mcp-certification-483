using System;
using System.Runtime.InteropServices;

public class MyResource : IDisposable
{
    private IntPtr nativeResource = Marshal.AllocHGlobal(100);
    private AnotherResource managedResource = new AnotherResource();

    // Dispose() calls Dispose(true)  
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // NOTE: Leave out the finalizer altogether if this class doesn't   
    // own unmanaged resources itself, but leave the other methods  
    // exactly as they are.   
    ~MyResource()
    {
        // Finalizer calls Dispose(false)  
        Dispose(false);
    }

    // The bulk of the clean-up code is implemented in Dispose(bool)  
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // free managed resources  
            if (managedResource != null)
            {
                managedResource = null;
            }
        }
        // free native resources if there are any.  
        if (nativeResource != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(nativeResource);
            nativeResource = IntPtr.Zero;
        }
    }
}