MD is a markdown file

CLR (Common Language Runtime)
-   runtime that manages a bunch of stuff, garbage collection, etc.
-   JIT - (Just In Time) compiler
    - Takes in code, transforms code into machine code so machine can run your code.
obj, bin folders
-   build output
-   result of running dotnet build
dotnet run
-   dotnet build + dotnet run (the code)
dotnet build
-   compiles code but doesn't run it

TLDR the compiilation process:. machine code
.cs file > compiled using MSBUILD > IL (Intermediate Language) > CLR (common language runtime) processed by JIT 