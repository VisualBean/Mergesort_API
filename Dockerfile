FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Mergesort_API/Mergesort_API.csproj", "Mergesort_API/"]
RUN dotnet restore "Mergesort_API/Mergesort_API.csproj"
COPY . .
WORKDIR "/src/Mergesort_API"
RUN dotnet build "Mergesort_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Mergesort_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mergesort_API.dll"]