

[TOC]

# 笔记
## 1. 反射和Attribute(新版)
### 1.1 反射相关

#### 1.1.1 创建反射

```c#
Type type = p1.GetType();
Type type1 = typeof(Person);
Type type2 = Type.GetType("Type1.Person");
object obj = Activator.CreateInstance(type);//new Person();

Type type = typeof (Person);
ConstructorInfo constructorInfo = type.GetConstructor(new Type[2] { typeof(string), typeof(string) });
var person = (Person) constructorInfo.Invoke(new object[2]{"1","2"});
```

## 2. 委托、lambda、事件(新版)

### 2.1 

## 3. 各种知识点(新版)

## 3.1 

> 通用类型系统 CTS，Common Type System
>
> 通用语言规范 CLS， Common Language Specification
>
> 公共语言运行时 CLR， Common Language Runtime 
>
> 垃圾回收 GC， Garbage Collection

## 4. 正则、序列化、XML(新版)

## 4.1 正则表达式

### 4.1.1 正则判断

> Regex.IsMatch("18911111234333", @"^\d{11}$")

> 1、日期格式：^\d{4}\-\d{1,2}\-\d{1,2}$
>
> 2、手机号：@"^1\d{10}$"
>
> 3、@"^\d{5,10}$"匹配QQ号
>
> 4、ipv4地址：@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"  正则表达式很难“一步到位”。192.168.1.15   
>
> 5、@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 匹配邮箱
>
> 6、[\u4e00-\u9fa5]  单个汉字      @"^[\u4e00-\u9fa5]{2,4}$" 长度为2-4的汉字姓名
>
> 7、身份证号(15位、18位数字)：@"^(\d{15})$|^(\d{18})$"
>
> 8、身份证号（18位，最后一位可能是x）  @"^(\d{17})[\dxX]$"

### 4.1.2 正则匹配

``` c#
 MatchCollection mc = Regex.Matches("况德鹏54654kin地方", @"[\u4e00-\u9fa5]");
 foreach (Match item in mc)
 {
     Console.WriteLine(item);
 }
```

### 4.1.3 序列化

> 要序列化的类型必须标记为:[Serializable]
> 该类型的父类也必须标记为: [Serializable]
> 该类型中的所有成员的类型也必须标记为: [Serializable]

```c#
XmlDocument doc = new XmlDocument();
doc.Load(@"C:\temp\a.xml");
XmlNodeList students = doc.DocumentElement.ChildNodes;//Student节点集合
foreach (XmlNode stu in students)
{
    XmlElement element = (XmlElement)stu;
    string stuId = element.GetAttribute("StuID");
    XmlNode nameNode = element.SelectSingleNode("StuName");//获取Person节点的Name节点
    string name = nameNode.InnerText;
    Console.WriteLine(stuId + "," + name);
}
```



## 9. 备忘

### 1. 比较精度问题 

> 比较相等就判断他们的相差范围在某个精度内就认为他们相等，这个精度是自己设定的

```
double d1=3.1411111;
double d2=3.1411110;
if(Math.Abs(d1-d2)<0.001)
{
	//相等
}
```
### 2. 比较对象引用问题 
> 判断是否是一个引用

```c#
object.ReferenceEquals(t1, t2)
对于引用类型而言,equals和referenceequals都是比较的对象引用是否相同
浅拷贝就是两个对象共享被引用的对象
深拷贝就是把所有的东西都复制一份，浅拷贝就是一部分复制一份、一部分还是引用之前的对象
```

> String是C#封装的比较特殊的引用类型,每一次字符串的创建都会开辟一个新的内存空间。所以string类型,更像是值类型的特性。

![img](http://static.rupeng.com/upload/chatimage/20173/14B52ACD87898C5830C793B0DCA89C48.png)



