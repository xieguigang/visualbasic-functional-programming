## What is functional programming?

### Imperative programming example

进行指令式编程的时候需要为你的程序精确的制定出动作指令：

```vbnet
Dim result As New List(Of Task)

' Where Select
For Each task As Task In "smrucc-cloud".task_pool()
    If TIMESTAMPDIFF(Unit.HOUR, task.time_complete, now()) <= 24 Then
        result += task
    End If
Next

' Order result using simple bubble sort
For i% = 0 To result.Count - 1
    For j% = i To result.Count - 1
        If result(i).uid > result(j).uid Then
            Call result.Swap(i, j)
        End If
    Next
Next

' Take 10
Dim out As New List(Of Task)

For i% = 0 To 9
    If i < result.Count Then
        out += result(i)
    End If
Next
```

I'm trying to make this normal visualbasic code as short as enough, but it is still have nearly 20 lines of the code.

### FP examples

The FP language that we most frequent used is the SQL language,

###### SQL

MySQL example for implements the functional of the Imperative programming example code:

```SQL
SELECT *
FROM `smrucc-cloud`.task_pool
WHERE TIMESTAMPDIFF(HOUR, time_complete, now()) <= 24
ORDER BY uid ASC
LIMIT 10;
```

###### LINQ(VisualBasic)

This visualbasic LINQ code provides the same function as the example SQL it does:

```vbnet
From task As Task IN "smrucc-cloud".task_pool()
LET time_complete As Date = task.time_complete
WHERE TIMESTAMPDIFF(Unit.HOUR, time_complete, now()) <= 24
SELECT task
Order By task.uid Ascending
Take 10
```

###### FP VisualBasic

In another way using LINQ caller chain:

```vbnet
Dim result As Task() =
    "smrucc-cloud".task_pool()
    .Where(Function(task) TIMESTAMPDIFF(Unit.HOUR, task.time_complete, now()) <= 24)
    .OrderBy(Function(task) task.uid)
    .Take(10)
    .ToArray
```

From the example that we could learn that the FP style programming is 

总结：

函数式编程和VB传统的指令式编程的最大的区别在于表达式的广泛应用：传统的指令式编程需要一个单词一个单词的精确制定程序需要完成的工作，而函数式编程则更加倾向于在一个描述性的框架之下放入需要完成的工作的函数表达式来构成一个完整的执行程序。在VB.NET之中，这种描述性的程序框架是构建于Linq表达式和函数拓展上面的。

函数式编程和指令式编程的另外一个在代码上面的最主要的区别就是在对待数据序列上面，传统的指令式编程运用了大量的For和If等关键词。

函数式编程相较于指令式编程的优点有：

1. 代码复用
2. 结果一致性


为了保持结果的一致性，函数需要做到与外界尽量少的交互，一个优秀的函数，应该是只通过函数参数来获取外界输入，只通过Return返回来对外界进行输出的。为了做到尽量少的外界交互，你的函数之中应当不可以引用模块变量，函数的参数应该尽量是值类型，而非内存的引用指针，不可以存在对文件系统的读取操作，也应该尽量删去对文件系统的写入操作的代码。

对于传统的面向对象的编程而言，由于VB之中的对象是一种内存地址引用的类型，所以假若使用对象的话，在函数的运行的期间，程序之中的其他的地方的多线程代码可能会修改对象引用的内容，例如可能会修改属性值，这将会导致即使你的函数拥有一致的参数输入，但是由于执行期间其他的线程对对象的内容作出了修改，这将会导致函数产生不一样的输出。因为传统的面向对象的编程不利于并行化，而且也不利于科学计算之中所要求的一致性。

目前的科学计算程序大部分都是采用与外界最小交互的函数式编程模型


## Hello Functional Programming

1. We just describ how to complete the job in functional programming, instead of giving the computer the complete commands
Example as:

Select the expired task:

In FP, we can describ the job by using lambda:

```vbnet
"smrucc-cloud".task_pool()
    .Where(Function(task) TIMESTAMPDIFF(Unit.HOUR, task.time_complete, now()) <= 24)
```

And here is how we do in Imperative Programming

```vbnet
Dim expired As New List(Of Task)

For Each task As Task In "smrucc-cloud".task_pool()
    If TIMESTAMPDIFF(Unit.HOUR, task.time_complete, now()) <= 24 Then
        expired += task
    End If
Next
```


```vbnet
Dim fib As Func(Of Integer, Integer) = Function(n) If(n <= 1, n, fib(n - 1) + fib(n - 2))
```

但是我更加希望能够使用下面的更加接近自然语言式的编程风格

```vbnet
Dim fib(~x) = (fib(x - 1) + fib(x - 2)) Or x As Default If x <= 1
```
