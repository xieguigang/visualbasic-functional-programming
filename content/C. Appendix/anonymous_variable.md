Using the anonymous variable feature in VisualBasic can make our code more brief, and allow us using less variable in a function.

```vbnet
Dim title$, describ$, email$

With request.POSTData.Form.ToDictionary
    title   = .TryGetValue("task.title")
    describ = .TryGetValue("task.describ")
    email   = .TryGetValue("task.email")
End With
```

Out of the range of the ``With`` block, then we will not able to reference the anonymous variable again, so that

The anonymous variable syntax can be equivalent to:

```vbnet
Dim title$, describ$, email$
Dim tmpVar = request.POSTData.Form.ToDictionary

title   = tmpVar.TryGetValue("task.title")
describ = tmpVar.TryGetValue("task.describ")
email   = tmpVar.TryGetValue("task.email")
```

```vbnet
Dim contributions As Dictionary(Of Date, Integer)
Dim oneYear$

With contributions.Keys.OrderBy(Function(day) day).ToArray
    oneYear = $"{ .First.ToString("MMM dd, yyyy")} - { .Last.ToString("MMM dd, yyyy")}"
End With
```

```vbnet
''' <summary>
''' VisualBasic ``With`` source reference helper
''' </summary>
''' <typeparam name="T"></typeparam>
''' <param name="x"></param>
''' <returns></returns>
<Extension> Public Function ref(Of T)(x As T) As T
    Return x
End Function
```

### With Default Value

You can combine the ``With`` anonymous variable with the VB.NET default value syntax:

```vbnet
Function(Optional out As StreamWriter)

    ' Output the content to a specific output stream or just print on the console 
    ' if the output stream is not presented.
    With out Or New StreamWriter(Console.OpenStandardOutput).AsDefault
        ' ...
    End With

End Function
```