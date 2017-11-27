# Nuget

## 8.0 Nuget使用命令

> Get-Help NuGet		 	命令查看帮助
>
> Install-Package			安装库包，安装时会自动安装当前Framework知道的库包及依赖包，若不支持则会提示错误。
>
> Install-Package XXX -Version 1.1.0  	
>
> ​						若库包有多个版本则在库包后面加上`-Version 版本号`参数安装指定版本的库包。若依赖包指定版本已经安装则不会重复重新安装。
>
> Get-Package				获取已安装的库包
>
> Uninstall-Package			卸载已安装的库包，依赖包不会自动卸载，有需要则需要手工卸载依赖包

## 9.0 链接

[NuGet的使用、部署、搭建私有服务](http://www.cnblogs.com/Jack-Blog/p/7890369.html?utm_source=gold_browser_extension#nuget%E7%9A%84%E4%BD%BF%E7%94%A8%E9%83%A8%E7%BD%B2%E6%90%AD%E5%BB%BA%E7%A7%81%E6%9C%89%E6%9C%8D%E5%8A%A1)