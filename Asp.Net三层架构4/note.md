# Asp.NET 三层架构

## 1. 三层架构中如何处理事务（TransactionScope）

### 概念

> * TransactionScope是ADO.Net提供的事务机制（需要添加对system.transactioins的引用），在普通ADO.Net代码中也可以用、在Entity Framework、Dapper等ORM中也可以用；
> * 把相关需要事务处理的代码用TransactionScope包裹起来即可， 只要没有Complete()的就会回滚
>
> * 使用TransactionScope包围的范围，只要是同一个连接字符串创建的SqlConnection对象（MySQL等也支持），即使是多个Connection对象也会在一个事务中。
>
> * 还支持嵌套事务：演示一下。这个在开发大型系统中会涉及到，因为大型系统中一个方法会在很多地方被使用，一个方法有时候是自己独立完成一件事情，有时候是被别人组合完成一件事。 TransactionScope可以嵌套， TransactionScope嵌套的情况，只有最外层的TransactionScope提交后所有的操作才会提交，否则所有操作都回滚。
> * 如果在TransactionScope嵌套的范围内出现多个不同连接字符串构造的Connection（比如同时连接多个同构或者异构的数据库）则需要启用MSDTC服务，否则会“MSDTC不可用”的异常，即使数据库ip地址从127.0.0.1变成localhost甚至加上一个无关痛痒的空格都会要求启用MSDTC服务。
>

### 代码

```c#
using (TransactionScope sc = new TransactionScope())
{
    A();
    B();
    sc.Complete();
}
```

### note

> * 事务不是属于DAL的吗？怎么放到Service、UI层了？架构是帮助我们的，不是约束死我们的，架构是经验，不是法律。而且事务的概念很宽，所以TransactionScope不是在ado.net的命名空间下。

### 重要

> 

## 6. MD5

```C#
        public static string MD5(string s)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider provider 
                = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            StringBuilder builder = new StringBuilder();
            bytes = provider.ComputeHash(bytes);
            foreach (byte b in bytes)
                builder.Append(b.ToString("x2").ToLower());
            return builder.ToString();
        }

        public static string MD5(Stream stream)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 
                = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
```

## 7. 数据库null 和C# null 

```
数据库null转c# null值
row.IsNull("Age") ? null : (int?)row["Age"];
c# null转数据库null
new SqlParameter("@Age", age??(object)DBNull.Value)

public static object FromDBValue(this object dbValue)
{
     return dbValue == DBNull.Value ? null : dbValue;
}

public static object ToDBVlaue(this object value)
{
     return value ?? DBNull.Value;
}
```



