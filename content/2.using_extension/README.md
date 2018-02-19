在前言之中我们了解到，函数式编程主要是由两部分元素来构成的：一个是构建任务使用的描述性的流程框架，另外一个就是填充进入这个描述性的任务框架所需要使用的任务内容的表达式。在VB.NET之中，这个描述性的框架是主要通过函数拓展来完成一个任务流程框架的构建的，而对于VB程序处理一个数据集，则需要将你的任务框架结合Linq表达式来进行使用。

在本小结之中，我们在这里为你尽量解释VB之中的函数拓展特性：

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

总结：

+ 拓展必须要使用``<Extension>``来修饰你的函数
+ 拓展与Public Private Friend 这些访问控制无关
+ 拓展必须要构建在一个标准模块之中
+ 拓展必须要至少有一个函数参数

## Linq pipeline(Parallel computing)

The .NET framework provides a set of extension function for processing the data collection in functional programming way, this set of the extension function are located at namespace ``System.Linq``.

Linq任务管道是建立在拓展和枚举接口之上的用于处理数据集的函数式编程框架，关于Linq的介绍，将在后面的小结之中进行介绍

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