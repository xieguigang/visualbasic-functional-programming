## Using VB.NET VectorShadows

One of the most difference between R and other programming language, is that all of the variable in R language is a vector. So that people can write R program in a very brief way when we compare the R program with the Imperative programming like VB.NET. For example, calculate the average value of a numeric array:

```R
# example is that we have a object array like:
success value
   TRUE 1.236
   TRUE 0.559
   TRUE 0.148
  FALSE 9.369
```

In R language just required a function calls:

```R
avg <- mean(array[, "value"]);
```

In VisualBasic required a For Loop in Imperative programming:

```vbnet
Dim avg#

For Each x In array
    avg += x.value
Next

avg = avg / array.Length
```

But in VisualBasic functional programming using Linq:

```vbnet
Dim avg# = array.Average(Function(x) x.value)
```

But when the situation becomes more sophisticated, like calculate the average where the success property is TRUE:

```R
# Still very easy in R language
avg <- mean(array[array[, "success"], "value"])
```

```vbnet
Dim avg#
Dim l%

For Each x In array
    If x.success Then
        avg += x.value
        l += 1
    End If
Next

avg = avg / l
```

```vbnet
Dim avg# = array.Where(Function(x) x.success).Average(Function(x) x.value)
```

We can calculate the average value in one line by using Linq, but it is still not so brief like R language. So I would like to introduce the ``VectorShadows`` language feature for VB.NET:

```vbnet
Dim array = {}.VectorShadows
Dim avg# = Average(array(array.success).value)

' here is how you can compare the VB.NET vector with the R vector,
' Both of their usage are almost keep the same!
' avg <- mean(array[array[, "success"], "value"])
```

Using the VectorShadows language feature from VB.NET is supper easy and brief, right? 

### Compare VB.NET and R

```vbnet
Dim avg# = Average(array(array.success).value)
```

decomposing steps in VB.NET:

```vbnet
Dim success = array.success  ' Where condiction
Dim subset  = array(success) ' row selector
Dim values  = subset.value   ' column projection
```

decomposing steps in R language:

```R
# here is how you can compare the VB.NET vector with the R vector,
# Both of their usage are almost keep the same!
# avg <- mean(array[array[, "success"], "value"])

success <- array[, "success"] # Where condiction
subset  <- array[success, ]   # row selector
values  <- subset[, "value"]  # column projection
```

The operation ``object[, "name"]`` is a kind of field project on R dataframe, which is similar to the ``DotProperty`` project in VisualBasic. The expression ``array[, "success"]`` in R language, project the dataframe object ``array`` as a boolean vector from its ``success`` column. This corresponding projection operation in VisualBasic language is the ``Vector DotProperty`` project, which is resulted the same output as the field projection in R language. For example, the ``array.success`` project the vector object ``array`` as a ``Boolean`` vector through the ``success`` property in the vector's base element type.

And here is how you can do in another functional programming language, SQL language:

```SQL
SELECT AVG(`value`) FROM array WHERE `success`;
```

