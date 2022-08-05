using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utility;
public static class SafeExecutor
{
    public static async Task<Tuple<T, Exception>> ExecuteAsync<T>(Task<T> task)
    {
        try
        {
            var result = await task;
            return new Tuple<T, Exception>(result, null);
        }
        catch (Exception e)
        {
            return new Tuple<T, Exception>(default, e);
        }
    }

    public static Tuple<T, Exception> Execute<T>(Func<T> func)
    {
        try
        {
            T result = func();
            return new Tuple<T, Exception>(result, null);
        }
        catch (Exception e)
        {
            return new Tuple<T, Exception>(default, e);
        }
    }
}