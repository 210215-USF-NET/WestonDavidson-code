# base image for the image. need this to run your application
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

# baby of mkdir and cd (it makes the directory if it doesn't exist and then navigates to that directory)
WORKDIR /app

# copy the sln and csproj files first to restore them and the deps
COPY *.sln ./
COPY ToHBL/*.csproj ToHBL/
COPY ToHDL/*.csproj ToHDL/
COPY ToHModels/*.csproj ToHModels/
COPY ToHMVC/*.csproj ToHMVC/
COPY ToHTests/*.csproj ToHTests/

# your image is basically just a file system! We are containerizing 
# you can do stuff
#*******^^^^^^^^^
# CMD /bin/bash

#restore the dependencies once you have what you need! all the different projects need to exist in the container
RUN dotnet restore


# this is just us copying our codebase (but there are some things i don't want copied over)
COPY . ./

# the dotnet publish command packages our application into a deployable version
RUN dotnet publish ToHMVC -c Release -o publish --no-restore

# we do multi stage build to write over our base image
# after we've deployed our application, what does a file system need?
# it just needs the runtime, not the sdk probs
# here we just need the runtime for an asp.net project
# so from the base image, we say we just want some files from our first build

# we're doing a multi stage build. after we restore our app and create a deployable
# version of it using publish, we leave the code base, and we only take the published
# version of it to the final image that will be built
# so that we won't have to deploy the SDK (which is memory heavy) or our codebase (to protect our implementation details)
# what we're deploying to the public is a runtime, and a executable version of our app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
#specify our working directory
WORKDIR /app
#from our old app build, we just want to copy over the publish folder - this contains the deployable version of our app
# from earlier stage, get publish folder
COPY --from=build /app/publish ./
#then, say hey, run this executable on this container
CMD ["dotnet", "ToHMVC.dll"]