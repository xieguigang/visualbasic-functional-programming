## Available Operators in VisualBasic

###### Like

###### Or

Simulate the perl ``Or`` exception handler:

```vbnet
Public Structure ExceptionHandler

    Dim Message$

    Public Shared Operator Or(result As Boolean, h As ExceptionHandler) As Boolean
        If Not result Then
            Throw New Exception(h.Message)
        Else
            Return True
        End If
    End Operator
End Structure

Public Function die(message$) As ExceptionHandler
    Return New ExceptionHandler With {.Message = message$}
End Function

<Extension> Public Function WriteText(text$, file$) As Boolean
End Function


' Usage
Dim s$

Return s.WriteText(path$) Or die($"Unable save the text data to file: {path$}!")
```