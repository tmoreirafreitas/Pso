FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS base
MAINTAINER tfreitas
WORKDIR /app
ARG DEFAULT_CONNECTION
ENV DEFAULT_CONNECTION=$DEFAULT_CONNECTION
ENV ASPNETCORE_URLS="http://*:8080"
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /src
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore 

COPY . .
WORKDIR "/src/Pso.BackEnd.WebApi"
RUN dotnet build "Pso.BackEnd.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pso.BackEnd.WebApi.csproj" -o /app
 
FROM base AS final
WORKDIR /app 
COPY --from=publish /app . 
#run as www-data(33), readonly
RUN chown -R 33:33 ./
RUN chmod -R 0500 ./
RUN chmod -R 0700 *.dll #if the dll's are not writeable, it won't start
ENTRYPOINT ["dotnet", "Pso.BackEnd.WebApi.dll"]
CMD tail -f /dev/null