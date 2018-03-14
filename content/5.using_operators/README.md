## Available Operators in VisualBasic

在VB程序之中使用操作符可以使你的程序代码尽可能的言简意赅，相较于使用英文单词方式的函数调用，一些比较容易理解的操作可以重构为同义的操作符将会大大增加代码的可读性。因为VB代码的风格主要是面向自然语言的，你可以尽量使用一些英文单词的操作符或者数学运算符来将你的代码公式化

### VB Exclusive operators

|Operator|Description                       |
|--------|----------------------------------|
|Like    |Measure the .NET object similarity|


###### Like

The ``Like`` operator in VisualBasic can be using for measure the similarity between the two .NET objects, example as the ``Like`` operator in ``String`` type for measuring the string similarity in patterns. But the ``Like`` operator in VisualBasic is not limited to the string type, you can define this ``Like`` operator for any .NET user type.

###### Or

Simulate the perl ``Or`` exception handler, and you can found this code at source file **[die.vb](https://github.com/xieguigang/sciBASIC/blob/master/Microsoft.VisualBasic.Architecture.Framework/Language/lang/Perl/die.vb)** :

```vbnet
Public Structure ExceptionHandler

    Dim Message$
    Dim failure As Func(Of Object, Boolean)

    ''' <summary>
    ''' Perl like exception handler syntax for testing the result is failure or not?
    ''' </summary>
    ''' <param name="result"></param>
    ''' <param name="h"></param>
    ''' <returns></returns>
    Public Shared Operator Or(result As Object, h As ExceptionHandler) As Object
        If h.failure(result) Then
            Throw New Exception(h.Message)
        Else
            Return result
        End If
    End Operator
End Structure

Public Function die(message$) As ExceptionHandler
    Return New ExceptionHandler With {.Message = message$}
End Function
```

If the ``WriteText`` function returns value ``False``, which it means we save the text string failure. So that we can throw a exception by using die function:

```vbnet
<Extension> Public Function WriteText(text$, file$) As Boolean
End Function

' Usage
Dim s$
Return s.WriteText(path$) Or die($"Unable save the text data to file: {path$}!", Function(result) result = False)
```