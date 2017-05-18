The ``Module`` type plays a most important role in the functional programming in visualbasic language. The VisualBasic language have a history of using the ``Module`` type since its very old time. A ``Module`` in visualbasic is a kind of alias name of ``Class`` type. ``Module`` type in visualbasic can be almost equivalent to an abstract ``Class``, but much convenient than using ``Class`` type, for example:

```vbnet
Imports System.Runtime.CompilerServices

Namespace using_Module

    Public Module ExportAPI1

        ''' <summary>
        ''' Invariance of variables
        ''' </summary>
        ReadOnly var&

        Sub New()
        End Sub

        <Extension>
        Public Function ComputationAPI(vector&(), value As Func(Of Long, Long)) As Long()
        End Function
    End Module

    Public NotInheritable Class ExportAPI2

        ''' <summary>
        ''' Invariance of variables
        ''' </summary>
        Shared ReadOnly var&

        Shared Sub New()
        End Sub

        Public Shared Function ComputationAPI(vector&(), value As Func(Of Long, Long)) As Long()
        End Function
    End Class
End Namespace
```



