# sciBASIC CLI scripting

<!-- vscode-markdown-toc -->
* 1. [Color Designer API](#ColorDesignerAPI)
* 2. [Quantile Selector](#QuantileSelector)
* 3. [CTypeDynamics](#CTypeDynamics)

<!-- vscode-markdown-toc-config
	numbering=true
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

##  1. <a name='ColorDesignerAPI'></a>Color Designer API

It supports ``ColorBrewer``

##  2. <a name='QuantileSelector'></a>Quantile Selector

There are three quantity selector for the CLI scripting: ``quantile``, ``quartile`` and ``select n``

### quantile

1. ``quantile:percentage%`` means takes all of the objects from the source sequence which its quantity value is greater than the total percentage% quantile.
2. ``quantile:value`` means takes all off the objects from the source sequence which its quantity value is greater than the total quantile value x.

### quartile

1. Q1
2. Q2
3. Q3

### select n

1. ``asc:n`` means order the source sequence by its quantity value and then take the first n objects
2. ``desc:n`` means order descding the source sequence by its quantity value and then take the top n objects. 

##  3. <a name='CTypeDynamics'></a>CTypeDynamics

The ``CTypeDynamics`` scripting API is located at the namespace reference path: ``Microsoft.VisualBasic.Scripting.InputHandler``, from the core runtime of the sciBASIC framework, which is using for handles the CLI inputs string value conversion to a specific .NET type. The target .NET type should have a text parser API for construct its instance from parsing string value.

The most often used CLI api from the ``Microsoft.VisualBasic.CommandLine.CommandLine`` is power by this ``CTypeDynamics`` scripting API.

```vbnet
' Get the string value from cli parameter and then parse it as .NET object
CommandLine.GetObject(Of T)(String, System.Func(Of String, Object)) As T

' Get the optional cli parameter value and parse it as .NET object, if the parameter is nothing, then returns default value.
CommandLine.GetValue(Of T)(String, T, System.Func(Of String, T)) As T
```

