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