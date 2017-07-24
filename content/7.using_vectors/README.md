## Using VB.NET VectorShadows

One of the most difference between R and other programming language, is that all of the variable in R language is a vector. So that people can write R program in a very brief way when we compare the R program with the Imperative programming like VB.NET. For example, calculate the average value of a numeric array:

In R language just required a function calls:

```R
avg <- mean(numeric_vector);
```

In VisualBasic required a For Loop in Imperative programming:

```vbnet
Dim avg#

For Each x In numeric_vector
    avg += x
Next

avg = avg / numeric_vector.Length
```

But in VisualBasic functional programming using Linq:

```vbnet
Dim avg# = numeric_vector.Average
```
