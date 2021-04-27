# IEXCloud.Client
## Installation
You can either download the source and compile or use NuGet at http://nuget.org. To install with nuget:
```
dotnet add package IEXCloud.Client
```

## Usage
### Ref data isin
```
var client = new IEXCloudClient("token");
var mappings = await client.RefDataIsin("NL0000852564");
```
