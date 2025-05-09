FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG TARGETARCH
WORKDIR /app

COPY *.csproj ./
ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
RUN dotnet restore -a $TARGETARCH

COPY . .
RUN dotnet publish -c Release -o out -a $TARGETARCH

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5241
ENTRYPOINT ["dotnet", "Sexia.dll"]