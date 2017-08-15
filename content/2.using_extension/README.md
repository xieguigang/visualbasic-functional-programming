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
Function foo$()
End Function

<Extension> Function Capitalize$(s$)
End Function

' function foo returns its result content from function return
' and then calling the replace function, at last capitalize all
' of the string result
Dim s$ = foo().Replace("foo", "bar").Capitalize()
```

### How to declare a pipeline operation

One operation step in the pipeline is an extension function in VisualBasic, and the extension function should be declared in a VB standard ``Module``, example like:

```vbnet
' The Extension attribute applied on this module is optional
<Extension> Module PipelineOperations

    ' The operation function should be applied an ExtensionAttribute and have at least one parameter.
    <Extension> Function Capitalize$(s$)
    End Function

End Module
```

The extension function is some kind of like the .NET object instance method, but seperated apart from the object type definition(as the meaning of **Extension**). Which it means you can add more behavior to any .NET type without modify any original source code of the target type.

## Linq pipeline(Parallel computing)

The .NET framework provides a set of extension function for processing the data collection in functional programming way, this set of the extension function are located at namespace ``System.Linq``.

### What is parallel?

+ Pipeline technology
+ Threading technology

#### Pipeline technology

As we describ above, that we knows that the very base of the Linq technology is the data collection, corresponding to the .NET type is the interface type ``IEnumerable(Of T)``.

##### The ``Iterator``

The ``Iterator`` function can provides the ``IEnumerable(Of T)`` data source for your linq pipeline in a more elegant and efficient.

```vbnet
Public Iterator Function datasource() As IEnumerable(Of T)
End Function
```

Returns an element value in the data collection by using ``Yield`` keyword, and exit the function by using ``Return`` keyword.

```vbnet
Iterator Function vector As IEnumerable(Of Integer)
    Yield -2
    Yield -1
    Yield 0
    Yield 1
    Yield 2
    Yield 3

    Return

    Yield 10
End Function

Dim vectorJSON$ = vector().ToArray.GetJson
' [-2, -1, 0, 1, 2, 3]
```

As you can see, in the iterator function, each ``Yield`` operation produce a element in the generated data collection. Due to the reason of a ``Return`` operation was applied to early break the function, so that the last element ``10`` will be never added into the resulted collection.

#### Threading technology