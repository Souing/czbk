[TOC]

# C#路径/文件/目录/IO/常见操作汇总

## 1.0 

### 1.1 路径相关操作

> 

## 7.0 备忘

### 7.1 如何使用通配符搜索指定目录内的所有文件；

> 使用DirectoryInfo.GetFiles方法的重载版本，它可以接受一个过滤表达式，返回FileInfo数组，另外它的参数还可以指定是否对子目录进行查找。如：
>
> dir.GetFiles("*.txt"， SearchOption.AllDirectories);

## 8.0 代码

### 8.1 判断两个文件内容是否一致

```c#
/// <summary>
     /// 判断两个文件内容是否一致
     /// </summary>
     public static bool IsFilesEqual(string fileName1, string fileName2)
     {
         using (HashAlgorithm hashAlg = HashAlgorithm.Create())
         {
             using (FileStream fs1 = new FileStream(fileName1, FileMode.Open), fs2 = new FileStream(fileName2, FileMode.Open))
             {
                 byte[] hashBytes1 = hashAlg.ComputeHash(fs1);
                 byte[] hashBytes2 = hashAlg.ComputeHash(fs2);

                 // 比较哈希码
                 return (BitConverter.ToString(hashBytes1) == BitConverter.ToString(hashBytes2));
             }
         }
     }
```

### 8.2 如何获得指定目录的大小；

```C#
/// <summary>
     /// 计算一个目录的大小
     /// </summary>
     /// <param name="di">指定目录</param>
     /// <param name="includeSubDir">是否包含子目录</param>
     /// <returns></returns>
     private long CalculateDirSize(DirectoryInfo di, bool includeSubDir)
     {
         long totalSize = 0;
         // 检查所有（直接）包含的文件
         FileInfo[] files = di.GetFiles();
         foreach (FileInfo file in files)
         {
             totalSize += file.Length;
         }
         // 检查所有子目录，如果includeSubDir参数为true
         if (includeSubDir)
         {
             DirectoryInfo[] dirs = di.GetDirectories();
             foreach (DirectoryInfo dir in dirs)
             {
                 totalSize += CalculateDirSize(dir, includeSubDir);
             }
         }
         return totalSize;
     }
```

### 8.3 复制目录到目标目录

```C#
/// <summary>
     /// 复制目录到目标目录
     /// </summary>
     /// <param name="source">源目录</param>
     /// <param name="destination">目标目录</param>
     public static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
     {
         // 如果两个目录相同，则无须复制
         if (destination.FullName.Equals(source.FullName))
         {
             return;
         }
         // 如果目标目录不存在，创建它
         if (!destination.Exists)
         {
             destination.Create();
         }
         // 复制所有文件
         FileInfo[] files = source.GetFiles();
         foreach (FileInfo file in files)
         {
             // 将文件复制到目标目录
             file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
         }
         // 处理子目录
         DirectoryInfo[] dirs = source.GetDirectories();
         foreach (DirectoryInfo dir in dirs)
         {
             string destinationDir = Path.Combine(destination.FullName, dir.Name);
             // 递归处理子目录
             CopyDirectory(dir, new DirectoryInfo(destinationDir));
         }
     }
```

### 8.4 写文本

```C#
using (FileStream fs = new FileStream(fileName, FileMode.Create))
     {
         // 创建一个StreamWriter对象，使用UTF-8编码格式
         using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
         {
             // 分别写入十进制数，字符串和字符类型的数据
             writer.WriteLine(123.45M);
             writer.WriteLine("String Data");
             writer.WriteLine('A');
         }
     }


```

### 8.5 读文本

```C#
// 以只读模式打开一个文本文件
     using (FileStream fs = new FileStream(fileName, FileMode.Open))
     {
         using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
         {
             string text = string.Empty;

             while(!reader.EndOfStream)
             {
                 text = reader.ReadLine();
                 txtMessage.Text += text + Environment.NewLine;
             }
         }
     }
```

### 8.6 监控文件夹、文件变化

> 如 果程序与其它多个程序或业务处理相关，常常需要创建一个程序，并且只有文件系统发生变化时它才处于活动状态。你可以创建一个这样的程序，让它定期区检测指 定目录，此时会发现有件事情让你苦恼：检测得越频繁，就会浪费越多的系统资源；而检测得越少，那么检测到变化的时间就会越长。
> 这时可以使用FileSystemWatcher组件，指定要进行监视的目录或文件，并处理其Created，Deleted，Renamed，Changed事件。
> 要使用FileSystemWatcher组件，首先要创建它的一个实例，然后设置下列属性：
> Path：指定要监视的目录；
> Filter：指定要监视的文件类型，如”*.txt”；
> NotifyFilter：指定要监视的变化类型；
> FileSystemWatcher 会引发四个关键的事件：Created，Deleted，Renamed，Changed。这些事件都在其FileSystemEventArgs参数中 提供了相关文件的信息：如文件名，路径，改变类型，Renamed事件中还可以了解到改变前的文件名和路径。如果要禁用这些事件，则将它的 EnableRaisingEvents属性设置为false。Created，Deleted，Renamed三个事件比较容易处理，但Changed 事件就得当心了，你需要设置它的NotifyFilter属性以指示监视那些类型的变化。否则，程序会在文件被修改时淹没在不断发生的事件中（缓存区溢 出）。

```C#
  watcher.Path = appPath;
     watcher.Filter = "*.txt";
     watcher.IncludeSubdirectories = true;
     // 添加事件处理函数
     watcher.Created += new FileSystemEventHandler(OnChanged);
     watcher.Deleted += new FileSystemEventHandler(OnChanged);
     watcher.Changed += new FileSystemEventHandler(OnChanged);
     watcher.Renamed += new RenamedEventHandler(OnRenamed);

     void OnRenamed(object sender, RenamedEventArgs e)
     {
         string renamedFormat = "File: {0} 被重命名为 :{1}";
         txtChangedInfo.Text = string.Format(renamedFormat, e.OldFullPath, e.FullPath);
     }
     void OnChanged(object sender, FileSystemEventArgs e)
     {
         // 显示通知信息
         txtChangedInfo.Text = "文件: " + e.FullPath + "发生改变" + Environment.NewLine;
         txtChangedInfo.Text += "改变类型: " + e.ChangeType.ToString();
     }
```



## 9.0 链接

* [C#路径/文件/目录/I/O常见操作汇总(上)](http://www.360doc.com/content/12/0326/12/1472642_197807690.shtml)
* [C#路径/文件/目录/I/O常见操作汇总(下)](http://www.360doc.com/content/12/0326/12/1472642_197807826.shtml)


