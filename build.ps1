dotnet test /nowarn:MSB3277,SA1600,CS1591,CS4014,CS1998
dotnet publish /nowarn:MSB3277,SA1600,CS1591,CS4014,CS1998 -r=win-x64 -c=Release --self-contained=true .\Mergesort_API\Mergesort_API.csproj