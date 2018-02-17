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