The caller chain from the extension method is also can be named as pipline, for example, here is what you can do on Linux bash:

```bash
# application foo print content on the console and then 
# calling the replace function, at last capitalize all 
# of the string result
foo | replace("foo", "bar") | capitalize
```

And you can also does this pipline in VisualBasic using extension method, like:

```vbnet
Dim s$ = foo().Replace("foo", "bar").Capitalize()
```
