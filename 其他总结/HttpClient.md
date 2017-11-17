[TOC]

# HttpClient

> 单例模式扩展开来也有很多的说法，根据C#的一些规范，在编程中我推荐两种做法
>
> 因此，在使用 `HttpClient` 时我们知道以下几件小事
>
> - 将其定义为单例模式（由单独的HttpClient维护连接池）
> - 不要使用using关键字包裹（无效，套接字资源不会跟随释放）
> - 尽量不要额外改变 `HttpClient` 的一些特殊行为（如上文中的TimeOut）

## 1.0 静态构造器

```
class Program
    {
        private static readonly HttpClient Client;
        static Program()
        {
            Client=new HttpClient();
        }
        static void Main(string[] args)
        {
            //do something
        }
    }
```

## 2.0 HttpClientHelper

> 单例模式中，经典的双重检查锁定机制。

```
public static class HttpClientHelper
    {
        private static readonly object LockObj = new object();
        private static HttpClient _client;
        public static HttpClient HttpClient {
            get
            {
                if (_client == null)
                {
                    lock (LockObj)
                    {
                        if (_client == null)
                        {
                            _client= new HttpClient();
                        }
                    }
                }
                return _client;
            }
        }
    } 
```

## 3.0 HttpClientHelper

> 这是在编程规范中推荐的一种的做法，通过使用静态构造函数能够精确保证Client变量能够在它第一次被使用前被实例化

```
public sealed class HttpClientHelper
    { 

        private HttpClientHelper(){}
        
        public static readonly HttpClient Client;

        static HttpClientHelper()
        {
            Client=new HttpClient();   
        }
    }
```



## 9.0 链接

* [使用HttpClient的优解](http://www.cnblogs.com/Wddpct/p/6229090.html)

* [C# 中使用System.Net.Http.HttpClient 模拟登录博客园 (GET/POST)](http://www.cnblogs.com/amosli/p/3918538.html)

* [C#中HttpClient使用注意：预热与长连接](http://www.cnblogs.com/dudu/p/csharp-httpclient-attention.html)


