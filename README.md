
Demo .net core3 utility to read filenames in current dir and write them to a result.txt file. 

Files can be filtered by extension and ordered by filesize

to deploy the project as a .net3 core Framework Dependent Executable, go to project root, open cmd and execute(you'll need .NET Core 3.0 sdk installed): 

dotnet publish -r win-x64 -c Release --self-contained=false /p:PublishSingleFile=true

to deploy the project as a .net3 core Self Contained Executable, go to project root, open cmd and execute:

dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true