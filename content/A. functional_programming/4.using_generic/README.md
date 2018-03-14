在编程的世界里，面对不同的问题我们会创建出无穷种数据类型，对于VB而言，其是一种强类型的编程语言，
在面对一些通用的编程操作的时候，我们不可能会对每一种数据类型都要copy一份代码然后编写一个完成相同功能的函数。泛型函数就是为了解决这个问题而出现的。在VB的函数式编程之中，为了构建出一个通用的描述性计算框架，你将会大量的使用到泛型函数。

## Generic vs Lambda

```vbnet
Interface ICompleteTime
    ReadOnly Property CompleteTime As Date
End Interface

Public Function IsExpired(Of T As ICompleteTime)(task As T) As Boolean
    Return TIMESTAMPDIFF(Unit.HOUR, task.CompleteTime, Now) <= 24
End Function

```

Even the object is not implements the ``ICompleteTime`` interface

```vbnet
Public Structure HaveTime
    Dim myTime As Date
End Structure

<Extension>
Public Function IsExpired(Of T)(x As T, getTime As Func(Of T, Date)) As Boolean
    Return TIMESTAMPDIFF(Unit.HOUR, getTime(x), Now) <= 24
End Function

Dim o As HaveTime

If o.IsExpired(Function(x) x.myTime) Then
End If

Dim i As ICompleteTime

If i.IsExpired(Function(x) x.CompleteTime) Then
End If
```