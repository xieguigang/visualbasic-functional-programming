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