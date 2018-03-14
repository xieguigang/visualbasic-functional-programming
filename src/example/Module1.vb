Module Module1

    ' Dim fib As ~f(x)
    ' Dim f(x) = x + 2
    ' Dim z(x, y) = (x * y) ^ 2

    Delegate Function fx(x As Integer) As Integer

    Sub fibTest()
        Dim fib As fx = Function(n) If(n <= 1, n, fib(n - 1) + fib(n - 2))

        Call fib(1).__DEBUG_ECHO
        Call fib(2).__DEBUG_ECHO
        Call fib(6).__DEBUG_ECHO

        Call cat("\n")

        Call fibFunc(1).__DEBUG_ECHO
        Call fibFunc(2).__DEBUG_ECHO
        Call fibFunc(6).__DEBUG_ECHO
    End Sub

    Sub Main()
        fibTest()

        Pause()
    End Sub

    Function fibFunc(n%) As Integer
        Return If(n <= 1, n, fibFunc(n - 1) + fibFunc(n - 2))
    End Function
End Module
