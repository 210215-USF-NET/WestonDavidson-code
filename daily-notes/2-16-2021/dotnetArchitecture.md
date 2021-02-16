.NET
    - a free, open-source dev platform
    - a collection of libraries
    - the SDK includes everything you need to build and run - .net core applications, cl toos and editor
    - the runtime includes just the resources required to run existing applications. The runtime is included in the SDK
    - .NET standard is the base class library AKA all the base class resources that come in .NET
        - basically out of the box APIs and libraries
    - .NET base classes work with all .NET compliant languages! csharp, fsharp, etc. will all work with the .NET standard
        -dealing with string and primitive types, database connections, IO operations, etc. are all included as operations
        within the .NET standard library

CLR
    - CLR or common language runtime provides memory management, JIT compilation, and exception handling support
    - .exe and .dll are the output types in our output folders - the CLR then compiles these and executes those.
    - AOT-compiler is ahead-of-time compiler and it's different than a JIT compiler, read up on it!
    - msbuild is our compiler engine. It compiles the code into a .exe or dll which is the intermediate language
    - then THAT goes into our CLR, which uses a JIT compiler to compile to native code depending on machine type