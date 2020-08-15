# HackerNews

RESTful API to retrieve the details of the first 20 "best
stories" from the Hacker News API.

## Usage

1. Open the file HackerNews.sln;
2. Press F5 or select the menu Debug \ Start Debugging
3. The URL is https://localhost:44363/api/beststories
4. The URl to SWAGGER: https://localhost:44363/swagger/

## Resources

1. **DDD (domain driven design):** using DDD to build the application;
2. **Automapper:** to map the domain model and DTO object;
3. **AspNetCoreRateLimit:** stream-limiting middleware for ASPNETCore that controls how often clients invoke APIs;
 

## Configuration


The url base and, the max records is configured in appsettings.json:

```
"UrlBase": "https://hacker-news.firebaseio.com/v0/",
"MaxSize": 20,
```

The number of request alloweds is configured in appsettings.json (1000 request each 1 seconds), this value can be changed if necessary:


```
"IpRateLimit": {
    "EnableEndpointRateLimiting": true,
    "StackBlockedRequests": false,
    "RealIPHeader": "X-Real-IP",
    "ClientIdHeader": "X-ClientId",
    "HttpStatusCode": 429,
    "GeneralRules": [
      {
        "Endpoint": "*:/api/*",
        "Period": "1s",
        "Limit": 1000
      }
    ]
  }
```

## Future Improvements
1. Add a log service to save important informations about the process;
2. Save the result in a cache to improve the performance;
3. Use Polly (Retry pattern) to provide resilience;
