using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Sys
{
    public class ReadFileExample
    {
        public void Execute()
        {
            using var readFileContext = new ReadFile("file.txt");
        }
    }

    /// <summary>
    /// Example of implementing IDisposable.
    /// </summary>
    public class ReadFile : IDisposable
    {
        private bool _disposed = false;
        private StreamReader _streamReader;
        public List<string> Lines { get; private set; } = new List<string>();

        public ReadFile(string path)
        {
            _streamReader = new StreamReader(path);

            string line;
            while ((line = _streamReader.ReadLine()) != null)
            {
                Lines.Add(line);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            _streamReader.Dispose();
            this._disposed = disposing;
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