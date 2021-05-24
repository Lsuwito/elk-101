FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY ./app/MyApi.csproj ./MyApi.csproj
RUN dotnet restore

COPY ./app .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS="http://*:5001"
EXPOSE 5001

# install filebeat and supervisord
RUN apt-get update && apt-get install -y wget gnupg apt-transport-https supervisor
RUN wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | apt-key add -
RUN echo "deb https://artifacts.elastic.co/packages/7.x/apt stable main" | tee -a /etc/apt/sources.list.d/elastic-7.x.list
RUN apt-get update && apt-get install filebeat
RUN mkdir -p /var/log/supervisor

#ENTRYPOINT ["dotnet", "MyApi.dll"]
# Run supervisord using the mounted config so we can run the app and filebeat processes in the docker container
# In real world, the filebeat should be installed in the container host.
CMD ["/usr/bin/supervisord"]