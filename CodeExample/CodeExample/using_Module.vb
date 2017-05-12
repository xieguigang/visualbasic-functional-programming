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
