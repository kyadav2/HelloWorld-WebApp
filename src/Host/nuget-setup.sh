mkdir -p ~/.nuget/NuGet

cat << EOF > ~/.nuget/NuGet/NuGet.Config
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
    <add key="Platform-Local" value="http://artifactory.hq.practicefusion.com:8081/artifactory/api/nuget/nuget-platform-local" />
  </packageSources>
</configuration>
EOF