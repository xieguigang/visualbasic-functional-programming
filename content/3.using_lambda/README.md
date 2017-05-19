### Declaring a Function

```vbnet
Public Function foo(param As Type) As Type
    ' blablabla
End Function
```

Actually, the function in ``VisualBasic`` is also can be treated as an .NET object, just like the R language it does:

```R
# function declare in R language
foo <- function(param) {
    # blablabla
}
```

The function variable in VisualBasic can be called a ``Local Function`` or ``Lambda Expression`` 

```vbnet
Dim foo = Function(param As Type)
              ' blablabla
          End Function

' Using this local function
Dim input As Type
Dim value = foo(param:=input)
```

```vbnet
' Using the function pointer
Public Function GetFunctionPointer() As Func(Of Type, Type)
    Return foo
End Function

Dim func = GetFunctionPointer()
Dim input As Type
Dim value = func(input)
```

```vbnet
Public Class Foo

    Public ReadOnly Add As Func(Of Integer, Integer, Integer) = Function(x%, y%) x + y
    Public ReadOnly Multiply As Func(Of Integer, Integer, Integer) = Function(x%, y%) x * y

End Class
```

Using the function pointer in this ``Foo`` type:

```vbnet
Dim x As New Foo
Dim func_Add = x.Add
Dim func_Multiply = x.Multiply

' Or Using directly
Dim valueAdd = x.Add(1, 2)
Dim valueMultiply = x.Multiply(2, 2)
```

