using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Core.Sys
{
    public class ReadFileAsyncExample
    {
        public async Task Execute()
        {
            await using var readFileContext = new ReadFileAsync("file.txt");
        }
    }

    public class ReadFileAsync : IAsyncDisposable
    {
        private bool _disposed = false;
        private StreamReader _streamReader;
        public List<string> Lines { get; private set; } = new List<string>();

        public ReadFileAsync(string path)
        {
            _streamReader = new StreamReader(path);

            string line;
            while ((line = _streamReader.ReadLine()) != null)
            {
                Lines.Add(line);
            }
        }

        private async Task DisposeFuncThatRequiresAwaiting()
        {
            await Task.Delay(0);
        }

        /// <summary>
        /// Subclasses can override this!
        /// </summary>
        public virtual async ValueTask DisposeAsyncCore()
        {
            _streamReader.Dispose();
            await DisposeFuncThatRequiresAwaiting();
            _disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
        }
    }
}