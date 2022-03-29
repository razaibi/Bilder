# Bilder
Generate artifacts for projects from command line.

### Pre-reqs

- .Net 6.0

For installing on Mac, run below command(s):

```bash
DOTNET_FILE=dotnet-sdk-6.0.100-osx-x64.tar.gz
export DOTNET_ROOT=$(pwd)/dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT
```

### Restore Project
```bash
dotnet restore
```

### Running the Project
```bash
dotnet run gen model modeldata -o sample.cs
```