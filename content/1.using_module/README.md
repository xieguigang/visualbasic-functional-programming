The ``Module`` type plays a most important role in the functional programming in ``VisualBasic`` language. The ``VisualBasic`` language have a history of using the ``Module`` type since its very old time. A ``Module`` in visualbasic is a kind of alias name of ``Class`` type. ``Module`` type in visualbasic can be almost equivalent to an abstract ``Class``, but much convenient than using ``Class`` type, for example:

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

> The class type can doing almost the same thing as the ``Module``, but much more inconvenient when ``Class`` compare with the ``Module``. 

A standard ``Module`` In ``VisualBasic`` is a code block which can export your computation function API to your application's another module or share your code with other people. You can using this ``Module`` type export your code as a commandline tools in a very easy way and export the API function as the standard dll from ``C99`` language it does. 

