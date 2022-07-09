using System;

namespace Core.Sys
{
    public class ReadFile : IDisposable
    {

        public ReadFile(string fileName)
        {

        }

        // A derived class should not be able to override this method.
        public void Dispose()
        {
            // Call the correct dispose function.
            Dispose(true);

            // Notify the garbage collector that this object does not need
            // to be part of the finalisation queue. We took care of everything!
            GC.SuppressFinalize(this);
        }
        

    }
}