## Object data Query

As we all known that the SQL language is a kind of functional programming language, and it is widely used in database query today. You can perform the slicing, projection, aggregation on the target data set to generates the dataset that you want. There is a kind of language syntax in VB.NET that produce the same function as the SQL language it does, which we calls it Linq. The different between the SQL and Linq, is that the different between the data source: the data source for the SQL is the database, and the data source for the Linq is an object collection in your VB.NET program's memory. 

### Linq and parallel

+ Pipeline technology
+ Threading technology

### Using Linq (Pipeline technology)


### Using PLinq(Threading technology)
 
You can using ``WithDegreeOfParallelism(Integer)`` for specific the threads number that your PLinq used.



常用的Linq函数有：

+ Select 数据投影
+ OrderBy/OrderByDesciding 排序
+ First/Last 取序列的第一个或者最后一个元素
+ Take/Skip 取前n个元素或者跳过前n个元素
+ AsParallel 使用并行计算架构