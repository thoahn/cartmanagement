FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
COPY ./CartManagement.UnitTest/*.csproj ./CartManagement.UnitTest/
COPY ./CartManagement.API/*.csproj ./CartManagement.API/
COPY ./CartManagement.Core/*.csproj ./CartManagement.Core/
COPY ./CartManagement.Data/*.csproj ./CartManagement.Data/
COPY ./CartManagement.Service/*.csproj ./CartManagement.Service/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet build ./CartManagement.UnitTest
COPY ./CartManagement.API/LocalRepo/*.db ./CartManagement.UnitTest/bin/Debug/net5.0/LocalRepo/
RUN dotnet test ./CartManagement.UnitTest/*.csproj
RUN dotnet publish ./CartManagement.API -o /publish/
COPY ./CartManagement.API/LocalRepo/*.db /publish/LocalRepo/
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:4500"
ENTRYPOINT ["dotnet", "CartManagement.API.dll"]