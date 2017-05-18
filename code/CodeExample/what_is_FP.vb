Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language

Module what_is_FP

    Public Structure Task
        Dim uid&
        Dim time_complete As Date
    End Structure

    Enum Unit
        HOUR
        DAY
    End Enum

    <Extension> Public Iterator Function task_pool(mysql$) As IEnumerable(Of Task)
        ' mysql query
    End Function

    Function TIMESTAMPDIFF(unit As Unit, t1 As Date, t2 As Date) As Integer
        Return 0
    End Function

    Sub ImperativeProgramming()
        Dim result As New List(Of Task)

        ' Where Select
        For Each task As Task In "smrucc-cloud".task_pool()
            If TIMESTAMPDIFF(Unit.HOUR, task.time_complete, Now()) <= 24 Then
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
    End Sub

    Sub Linq_FP()
        Dim result = From task As Task In "smrucc-cloud".task_pool()
                     Let time_complete As Date = task.time_complete
                     Where TIMESTAMPDIFF(Unit.HOUR, time_complete, Now()) <= 24
                     Select task
                     Order By task.uid Ascending
                     Take 10
    End Sub

    Sub FP_visualBasic()
        Dim result As Task() =
            "smrucc-cloud".task_pool() _
            .Where(Function(task) TIMESTAMPDIFF(Unit.HOUR, task.time_complete, Now()) <= 24) _
            .OrderBy(Function(task) task.uid) _
            .Take(10) _
            .ToArray
    End Sub
End Module
