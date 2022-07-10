# Core / C#
The core C# folder contains core code implementations that further the understanding of C# and programming in general.

## DataStructures
Explores different implementations of data structures in C#.

## Extensions
Explores different quality of life extension methods.

## Searching
Explores how different searching algorithms can be implemented in C#.

## Sorting
Explores how different sorting anlgorithms can be implemented in C#.

## Threading
Explores threading in C#.

## Sys
Explores the C# System API.

## Testing
Explores testing dotnet applications and verifies implementations in other folders.
Sub-project created with `dotnet new xunit -o Testing`. To run tests, execute `dotnet test`.

<br/>
<br/>

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