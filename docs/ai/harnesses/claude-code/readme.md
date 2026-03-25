# Claude Code


```shell
export ANTHROPIC_AUTH_TOKEN=ollama
export ANTHROPIC_API_KEY=""
export ANTHROPIC_BASE_URL=http://localhost:11434

open -a claude-devtools 
claude --model qwen3-coder-next:q8_0
```


*   https://github.com/matt1398/claude-devtools

```shell
claude \
    --verbose \
        --output-format stream-json \
        -p "Why is the sky blue?" \
        | \
        ./claude_stream.jq
```

*   https://gist.github.com/ljw1004/5782702c7a54b18734c0e7f5e1119010

```
#!/usr/bin/env -S jq -n -r --unbuffered -f

# This is a script to turn Claude's stream-json output into stream-text for human consumption, to see its progress.
# e.g. claude --verbose --output-format stream-json -p "Why is the sky blue?" | ./claude_stream.jq


def trunc($s):
  if $s == null then ""
  else ($s | tostring | if length > 280 then .[0:280] + "…" else . end)
  end;

def one_line($s):
  $s | tostring | gsub("\n"; " ");

def ts_str:
  (now | strftime("%H:%M:%S"));

def join_todos($todos):
  $todos
  | map(.content + " (" + (.status // "pending") + ")")
  | join(", ");

def tool_detail($name; $input):
  if ($name == "Read" or $name == "Edit" or $name == "Write") then
    ($input.file_path // $input.filepath // $input.file // $input.filename // $input.path // "")
  elif $name == "Bash" then
    ($input.command // $input.cmd // "")
  elif $name == "TodoWrite" and ($input.todos? | type) == "array" then
    "todos: " + join_todos($input.todos)
  elif $name == "Task" then
    ($input.prompt // $input.description // "")
  elif $name == "WebFetch" or $name == "web_search" or $name == "WebSearch" then
    ($input.url // $input.query // "")
  else
    ($input.command // $input.cmd // $input.query // $input.file // $input.filename // $input.path // $input.filepath // $input.description // "")
  end
  | one_line(.)
  | trunc(.);

def format_tool($name; $input):
  tool_detail($name; $input) as $detail |
  "[" + ts_str + "] 🔧 " + $name
  + (if ($detail | length) > 0 then ": " + $detail else "" end);

def emit($s):
  if $s == null or $s == "" then empty else $s end;

("[" + ts_str + "] Starting Claude..."),

(inputs |
  if .type == "assistant" then
    .message.content[]? |
      if .type == "text" then
        emit("\n" + .text + "\n")
      elif .type == "thinking" then
        emit("[" + ts_str + "] 🧠 " + (.thinking | one_line(.) | trunc(.)))
      elif .type == "tool_use" then
        emit(format_tool(.name; .input))
      else
        empty
      end
  else
    empty
  end
),

("[" + ts_str + "] Finished.")
```

*   https://jqlang.org/

*   https://github.com/jqlang/awesome-jq