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

    Public ReadOnly Add As Func(Of Integer, Integer, Integer) = Function(x%, y%) 
        Return x + y
    End Function
    Public ReadOnly Multiply As Func(Of Integer, Integer, Integer) = Function(x%, y%) 
        Return x * y
    End Function

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

在VB之中的函数指针，其实并不是真正的内存指针，VB的函数指针是基于来自于VB6之中的类似于接口方法的实现来完成的：在VB6之中是没有函数指针的，但是却拥有接口编程这个概念，你可以在VB6之中将需要传递的函数实现在一个接口方法之中，然后只需要调用实现的实例中这个接口方法就可以实现类似于函数指针的效果了。在VB之中的函数指针就是通过类似的技术来实现的，你在代码之中可以通过Function或者Sub关键词来申明一个函数指针，但是在程序编译之后这些函数指针将会被转换为匿名对象的方法来进行调用，实际上这里的指针指的是匿名对象在内存之中的位置指针。
