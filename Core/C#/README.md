# Core / C#
The core C# folder contains core code implementations that further the understanding of C# and programming in general.

Ale, early 2021 -

C# is a little different to all the rest, one thing I can note is that it seems to be a very Microsoft (Windows) programming language. To create a small dotnet project, exec `dotnet new console` in the desired folder. To then compile and run the code you must execute `dotnet run` inside the folder. C# and the .NET framework form a symbiance.

Notes on C#
- Very windows like/related.
- Like Java it also makes use of classes containing `public static void Main(string[] args)` (Java string type is String)
- The language uses `{<arg num>}` to concat variables into strings e.g. 
`Console.WriteLine("Is unique \"abcdefg\": {0}", QuestionOne.IsUnique("abcdefg"));`
- Also classes can be wrapped in a namespace e.g.
```
namespace QuestionOne {
  class QuestionOne {
    public static void Main(string[] args) { ... }
  }
}
```