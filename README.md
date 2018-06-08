# Xyz for Azure Functions

[![Build status](https://ci.appveyor.com/api/projects/status/x2hcuua5jpm86c2p/branch/master?svg=true)](https://ci.appveyor.com/project/fbeltrao/azurefunctions-contrib-xyz)

 Facilities the usage of xyz in an Azure Function. Following operations are currently supported:

- blah
- blah
- blah


## Installation
Install package AzureFunctions.Contrib.Xyz

```bash
dotnet package add AzureFunctions.Contrib.Xyz
```
```PS
Install-Package AzureFunctions.Contrib.Xyz
```

## Examples
### Simple

```CSharp
[FunctionName(nameof(SimpleScenario))]
public static void SimpleScenario(
    [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,            
    [Xyz] out XyzItem item,
    TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    item = new XyzItem
    {
        Text = "Hello World!"
    };            
}
```