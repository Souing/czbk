

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

### 2.1 委托和事件的概念语法 

> 声明委托的方式:delegate返回值类型   委托类型名(参数)
>
> 比如delegate void MyDel(int n)
>
> 事件语法：event Mydelegate mdl;
>
> 加了event关键字实现事件机制的好处：用了event事件，不可以修改事件已经注册的值；不可以冒充进行事件通知了。只能+=、-=！
>
> 两种概念，事件的声明需要委托

```
public delegate void CardOutPutAction();
public event Action CardOutEvent;
public event CardOutPutAction CardOutPutEvent;
```

### 2.2 委托和事件的作用总结

#### 2.2.1 委托的作用

> 占位，在不知道将来要执行的方法的具体代码时，可以先用一个委托变量来代替方法调用（委托的返回值，参数列表要确定）。在实际调用之前，需要为委托赋值,否则为null

#### 2.2.2 事件的作用

> 事件的作用与委托变量一样，只是功能上比委托变量有更多的限制。（比如：1.只能通过+=或-=来绑定方法（事件处理程序）2.只能在类内部调用（触发）事件。）

### 2.3 委托和事件的区别和关系

> 错误的说法“事件是一种特殊的委托”
>
> 委托用的比较多，事件只有开发WinForm、WPF的时候用的才比较多，而WinForm、WPF则不是学习重点。掌握“事件和语法”、“委托和事件的关系和区别（面试题）”即可。
>
> 事件监听的代码的快速生成；WinForm中的事件简单分析（谁调用的Onclick方法）
>
> 事件、索引器、属性本质上都是方法。（面试题）接口中可以定义什么？接口中只可以定义方法。接口中也可以定义“事件、索引器、属性”，因为他们本质上也都是方法。
>

### 2.4 集合常用扩展方法

> * Where（支持委托）、Select（支持委托）、Max、Min、OrderBy
> * First（获取第一个，如果一个都没有则异常）
> * FirstOrDefault（获取第一个，如果一个都没有则返回默认值）
> * Single （获取唯一一个，如果没有或者有多个则异常） 
> * SingleOrDefault（获取唯一一个，如果没有则返回默认值，如果有多个则异常



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



### 3. int、int.parse、convert.int区别

> (int)适合***简单数据类型***之间的转换；
>
> int.Parse适合将***string***类类型转换成***int***类型
>
> convert适合将***object***类类型转换成***int***类型
>
> Convert.ToInt32(null)会返回0而不会产生任何异常，但int.Parse(null)则会产生异常。