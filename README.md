# IEXCloud.Client
## Installation
You can either download the source and compile or use NuGet at http://nuget.org. To install with nuget:
```
dotnet add package IEXCloud.Client
```

## Usage
### Crypto Exchanges
```
var client = new FinnhubClient("token");
var result = await client.CryptoExchanges();
```

### Crypto Symbol
```
var client = new FinnhubClient("token");
var result = await client.CryptoSymbol("KRAKEN");
```

### Crypto Candle
```
var client = new FinnhubClient("token");                   
var result = await client.CryptoCandle("symbol", "D", 1572651390, 1575243390);
```

### Forex Exchanges
```
var client = new FinnhubClient("token");                   
var result = await client.ForexExchanges();
```

### Crypto Symbol
```
var client = new FinnhubClient("token");
var result = await client.ForexSymbol("forex.com");
```
