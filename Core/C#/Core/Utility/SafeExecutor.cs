using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utility;

public static class SafeExecutor
{
    public static async Task<Tuple<T, Exception>> ExecuteAsync<T>(Task<T> task, Action<Exception> exceptionHandler = null)
    {
        try
        {
            var result = await task;
            return new Tuple<T, Exception>(result, null);
        }
        catch (Exception e)
        {
            if (exceptionHandler != null) exceptionHandler(e);
            return new Tuple<T, Exception>(default, e);
        }
    }

    public static Tuple<T, Exception> Execute<T>(Func<T> func, Action<Exception> exceptionHandler = null)
    {
        try
        {
            T result = func();
            return new Tuple<T, Exception>(result, null);
        }
        catch (Exception e)
        {
            if (exceptionHandler != null) exceptionHandler(e);
            return new Tuple<T, Exception>(default, e);
        }
    }
}