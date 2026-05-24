
```
.mcp.json
```

*   https://github.com/search?q=path%3A*.json+path%3A**%2F.mcp.json&type=Code&ref=advsearch&l=&l=


```json
{
  "mcpServers": 
  {
    "deepwiki": {
      "type": "http",
      "url": "https://mcp.deepwiki.com/mcp"
    },
    "linear": {
      "type": "sse",
      "url": "https://mcp.linear.app/sse"
    },
    "fetch": {
      "type": "stdio",
      "command": "uvx",
      "args": [
        "mcp-server-fetch"
      ],
      "env": {}
    },
    "firecrawl": {
      "type": "stdio",
      "command": "npx",
      "args": [
        "-y",
        "firecrawl-mcp"
      ],
      "env": {}
    }
  }
}
```

```
mcp.json
```



```
.vscode/mcp.json
```

```
.mcp.json
Claude Code 
```

.kiro/settings/mcp.json



```json
  "mcp": 
  {
    "ast-grep": 
    {
      "type": "local",
      "command": 
        [
          "uvx", 
          "--from", "git+https://github.com/ast-grep/ast-grep-mcp", 
          "ast-grep-server"
        ],
      "enabled": true
    },
    "serena": 
    {
        "type": "local",
        "command": 
        [
          //"/home/imqqmi/.local/bin/uvx",
          "${env:HOME}/.local/bin/uvx"
          "--from",
          "git+https://github.com/oraios/serena",
          "serena",
          "start-mcp-server",
          "--context", 
          "opencode",
        ],
        "enabled": false
    },
    "context7": 
    {
        "type": "remote",
        "url": "https://mcp.context7.com/mcp",
        "headers": 
        {
          "CONTEXT7_API_KEY": "ctx7sk-11cc2c08-ff3a-4572-9737-000495007a27"
        },
        "enabled": false
    },
    "exa": 
    {
      "headers": {},
      "type": "remote",
      "url": "https://mcp.exa.ai/mcp?tools=web_search_exa,get_code_context_exa,crawling_exa"
    },
  }
```