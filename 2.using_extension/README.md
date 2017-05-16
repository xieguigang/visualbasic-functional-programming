## Caller Chain &amp; Pipeline

The caller chain from the extension method in VisualBasic language, is also can be named as pipeline. For example, here is what you can do on Linux bash:

```bash
# application foo print its content output to standard output on the console 
# and then calling the replace function, at last capitalize all 
# of the string result
foo | replace("foo", "bar") | capitalize
```

And you can also does this pipeline in VisualBasic using extension method, like:

```vbnet
' function foo returns its result content from function return 
' and then calling the replace function, at last capitalize all 
' of the string result
Dim s$ = foo().Replace("foo", "bar").Capitalize()

<Extension> Function foo$()
End Function

<Extension> Function Capitalize$(s$)
End Function
```
