FROM mcr.microsoft.com/dotnet/sdk:6.0

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.CautionaryAlerts.sln ./
COPY ./Hackney.Shared.CautionaryAlerts/Hackney.Shared.CautionaryAlerts.csproj ./Hackney.Shared.CautionaryAlerts/
COPY ./Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj ./Hackney.Shared.CautionaryAlerts.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./Hackney.Shared.CautionaryAlerts/Hackney.Shared.CautionaryAlerts.csproj
RUN dotnet restore ./Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj

CMD dotnet test
