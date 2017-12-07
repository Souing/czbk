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

```c#
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

```c#
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

```c#
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

## 4.0 HttpContent

> HttpContent是抽象类
>
> 通过HttpContent的子类来构建Post数据。
>
> 比较常用的有[StringContent](https://msdn.microsoft.com/zh-cn/library/system.net.http.stringcontent(v=vs.110).aspx)，[FormUrlEncodedContent](https://msdn.microsoft.com/zh-cn/library/system.net.http.formurlencodedcontent_methods(v=vs.118).aspx)，[MultipartFormDataContent](https://msdn.microsoft.com/zh-cn/library/system.net.http.multipartformdatacontent(v=vs.118).aspx)，ByteArrayContent 等。

## 7.0 HttpClient封装上传文件form-data

```c#
 public static class HttpClientPostFileHelper
    {
        public static readonly HttpClient Client;

        static HttpClientPostFileHelper()
        {
            Client = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(20)
            };
        }

        /// <summary> 
        /// 模拟表单请求/ljw/2017/09/1
        /// </summary>        
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SendToWebByHttpClient<T>(string url, T value)
        {
            var modelType = typeof(T);
            using (var formData = new MultipartFormDataContent())
            {
                //遍历SendData的所有成员
                foreach (var item in modelType.GetProperties())
                {
                    HttpContent content;
                    //文件的处理（这里需要特别注意，流只能读取一次，因为读取之后会把Stream.Positon(当前流中的位置)置为最后读取的位置，除非置为0，第二次才可读到）
                    if (item.PropertyType == typeof(HttpPostedFileBase) && item.GetValue(value) != null)
                    {
                        #region Stream请求
                        //Stream塞进Content会会导致读取这个流，所以之后不能再第二次利用
                        var model = (HttpPostedFileBase)item.GetValue(value);
                        content = new StreamContent(model.InputStream, model.ContentLength);
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(model.ContentType);//ContentType必须赋值,否则文件接收不到此属性
                        content.Headers.ContentLength = model.ContentLength;//ContentLength可不显式的赋值,会自动读取给StreamContent的内容长度
                        formData.Add(content, item.Name, model.FileName);//文件类型,第三个参数必须要赋值,否则不认为这是一个文件

                        #endregion

                        #region 字节方式请求
                        //                        var model = (HttpPostedFileBase)item.GetValue(value);
                        //                        MemoryStream fileTarget = new MemoryStream();
                        //                        model.InputStream.CopyTo(fileTarget);
                        //                        content = new ByteArrayContent(fileTarget.ToArray());
                        //                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(model.ContentType);
                        //                        content.Headers.ContentLength = model.ContentLength;
                        //                        formData.Add(content, item.Name, model.FileName);
                        //
                        #endregion
                    }
                    //文件的处理
                    else if (item.PropertyType == typeof(HttpPostedFileWrapper) && item.GetValue(value) != null)
                    {
                        #region Stream请求
                        var model = (HttpPostedFileWrapper)item.GetValue(value);
                        content = new StreamContent(model.InputStream, model.ContentLength);
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(model.ContentType);
                        content.Headers.ContentLength = model.ContentLength;
                        formData.Add(content, item.Name, model.FileName);

                        #endregion

                    }
                    //文件集合的处理
                    else if (item.PropertyType == typeof(List<HttpPostedFileBase>) && item.GetValue(value) != null)
                    {
                        foreach (var child in ((List<HttpPostedFileBase>)item.GetValue(value)))
                        {
                            #region Stream请求
                            content = new StreamContent(child.InputStream, child.ContentLength);
                            content.Headers.ContentType = MediaTypeHeaderValue.Parse(child.ContentType);
                            content.Headers.ContentLength = child.ContentLength;
                            formData.Add(content, item.Name, child.FileName);
                            #endregion
                        }
                    }
                    //如果执意响应方是接收字节类型,那传输时不能用ByteArrayContent去填充,否则接收方认为这是一个非法数据,故要传base64格式,接收方会自动把base64转成字节接收
                    else if (item.PropertyType == typeof(byte[]) && item.GetValue(value) != null)
                    {
                        content = new StringContent(Convert.ToBase64String((byte[])item.GetValue(value)));
                        formData.Add(content, item.Name);
                    }
                    //其他类型统一按字符串处理(DateTime,Enum;long ;bool;int...)
                    else if (item.GetValue(value) != null && (item.PropertyType != typeof(byte[]) || item.PropertyType != typeof(HttpPostedFileBase)))
                    {
                        content = new StringContent(((string)item.GetValue(value).ToString()));
                        formData.Add(content, item.Name);
                    }
                }

                try
                {
                    var responseMessage = Client.PostAsync(url, formData).Result;

                    // 确认响应成功，否则抛出异常  
                    responseMessage.EnsureSuccessStatusCode();

                    var response = new
                    {
                        ResultCode = "000",
                        Message = "成功",
                        Data = responseMessage.Content.ReadAsStringAsync().Result,
                    };
                    return JsonConvert.SerializeObject(response);
                }
                catch (AggregateException ex)
                {
                    // Timeout Handle
                    var response = new
                    {
                        ResultCode = "610",
                        Message = "响应超时",
                        Describe = ex.Message
                    };
                    return JsonConvert.SerializeObject(response);
                }
                catch (Exception ex)
                {
                    // Others Exception Handle
                    var response = new
                    {
                        ResultCode = "620",
                        Message = "响应异常",
                        Describe = ex.Message
                    };
                    return JsonConvert.SerializeObject(response);
                }

            }
        }
    }
```



## 9.0 链接

* [使用HttpClient的优解](http://www.cnblogs.com/Wddpct/p/6229090.html)
* [C# 中使用System.Net.Http.HttpClient 模拟登录博客园 (GET/POST)](http://www.cnblogs.com/amosli/p/3918538.html)
* [C#中HttpClient使用注意：预热与长连接](http://www.cnblogs.com/dudu/p/csharp-httpclient-attention.html)
* [什么是multipart/form-data请求](http://www.cnblogs.com/tylerdonet/p/5722858.html)


