FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.CautionaryAlerts.sln ./
COPY ./Hackney.Shared.CautionaryAlerts/Hackney.Shared.CautionaryAlerts.csproj ./Hackney.Shared.CautionaryAlerts/
COPY ./Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj ./Hackney.Shared.CautionaryAlerts.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config
# We mount secrets so they can't end up in logs or build layers.
# We chain both restore commands so we only make the token available
# once and don't store it elsewhere.
# see:
#   - https://docs.docker.com/reference/dockerfile/#arg
#   - https://docs.docker.com/compose/how-tos/use-secrets/
RUN --mount=type=secret,id=LBHPACKAGESTOKEN \
  export LBHPACKAGESTOKEN=$(cat /run/secrets/LBHPACKAGESTOKEN) && \
  dotnet restore ./Hackney.Shared.CautionaryAlerts/Hackney.Shared.CautionaryAlerts.csproj && \
  dotnet restore ./Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out Hackney.Shared.CautionaryAlerts.Tests/Hackney.Shared.CautionaryAlerts.Tests.csproj

CMD dotnet test
