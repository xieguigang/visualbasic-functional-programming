## What is functional programming?

### Imperative programming example

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

## Powerful feature

These language feature makes a powerful supports for the functional programming in visualbasic language

1. ``Module``
2. ``Extension Method``
3. ``Lambda Expression``
4. ``Generic``
5. ``Operator Overrides``
6. ``Linq & Parallel``