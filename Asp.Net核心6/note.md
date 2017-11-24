# Asp.Net  核心

## 1.0 HTTP响应状态码

>  响应码：“200” : OK； “302” : Found 暂时转移，用于重定向, Response.Redirect()会让浏览器再请求一次重定向的地址，重定向的请求是Get方式； "404" : Not Found 未找到。500 服务器错误（一般服务器出现异常），通过报错信息找出异常的点。403：客户端访问未被授权。304(服务器把文件的修改日期通过Last-Modified返回给浏览器，浏览器缓存这个文件，下次向服务器请求这个文件的时候，通过If-Modified-Since问服务器说“我本地的文件的修改日期是。。。”，服务器端如果发现文件还是那个文件，则告诉浏览器（304
> Not Modified）文件没修改，还用本地的吧。ctrl+f5)。2xx：没问题；3xx代表浏览器需要干点啥；4***浏览器的问题；5xx服务器错误

## 2.0 下载附件 

```C#
            context.Response.ContentType = "image/png";
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + context.Server.UrlEncode("动态文件.txt"));

            string path = context.Server.MapPath("~/img/1.png");
            using (var streamRead = File.OpenRead(path))
            {
                streamRead.CopyTo(context.Response.OutputStream);
            }
```

## 3.0 图片打水印

```C#
 HttpPostedFile file1 = context.Request.Files["test"];
            string logoFileName = context.Server.MapPath("~/rupenglogo.png");
            string destFileName = context.Server.MapPath("~/" + DateTime.Now.ToString("yyyMMddhhmmss") + Path.GetExtension(file1.FileName));
            using (Bitmap bmpLogo = new Bitmap(logoFileName))
            using (Bitmap srcBmp = new Bitmap(file1.InputStream))
            using (Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height))
            {
                using (Graphics gSrc = Graphics.FromImage(srcBmp))
                using (Graphics gDest = Graphics.FromImage(destBmp))
                {
                    gDest.DrawImage(srcBmp, new Point(0, 0));
                    //如果图片宽度高度不够，则不打水印
                    if (srcBmp.Width > bmpLogo.Width && srcBmp.Height > bmpLogo.Height)
                    {
                        gDest.DrawImage(bmpLogo, new Point(srcBmp.Width - bmpLogo.Width, srcBmp.Height - bmpLogo.Height));
                    }
                }
                destBmp.Save(destFileName);
            }
```

## 4.0 Session和Cookie

### 4.1 Session

> 在web.config的system.web节点下配置sessionState节点的timeout，单位是分钟，默认是20（也只是一个建议，也许服务器10分钟的时候就让Session失效了）
>

