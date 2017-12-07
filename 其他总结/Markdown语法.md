[TOC]

# Markdown语法

## 1. 流程图

### 1.1 语法

>1. start,end, 表示程序的开始与结束
>2. operation, 表示程序的处理块
>3. subroutine, 表示子程序块
>4. condition, 表示程序的条件判断
>5. inputoutput, 表示程序的出入输出
>6. right,left, 表示箭头在当前模块上的起点(默认箭头从下端开始)
>7. yes,no, 表示condition判断的分支(其可以和right,left同时使用)

### 1.2 例子

```flow
st=>start: Start
e=>end: End
op1=>operation: My Operation
op2=>operation: Stuff
sub1=>subroutine: My Subroutine
cond=>condition: Yes
or No?
c2=>condition: Good idea
io=>inputoutput: catch something...

st->op1(right)->cond
cond(yes, right)->c2
cond(no)->sub1(left)->op1
c2(yes)->io->e
c2(no)->op2->e
```

## 2. 序列图

### 2.1 语法

>* 其主要有以下几种关键词:
>
>  * title, 定义该序列图的标题
>  * participant, 定义时序图中的对象
>  * note, 定义对时序图中的部分说明
>  * {actor}, 表示时序图中的具体对象（名称自定义）
>* 其中针对note的方位控制主要包含以下几种关键词：
>  * left of, 表示当前对象的左侧
>  * right of, 表示当前对象的右侧
>  * over, 表示覆盖在当前对象（们）的上面
>* 其中针对{actor}的箭头分为以下几种：
>  * -> 表示实线实箭头
>  * –> 表示虚线实箭头
>  * ->> 表示实线虚箭头
>  * –>> 表示虚线虚箭头
>

### 2.2 例子

```sequence
title: 序列图sequence(示例)
participant A
participant B
participant C

note left of A: A左侧说明
note over B: 覆盖B的说明
note right of C: C右侧说明

A->A:自己到自己
A->B:实线实箭头
A-->C:虚线实箭头
B->>C:实线虚箭头
B-->>A:虚线虚箭头
```
> 另外，时序图中的对象定义语句可以忽略，note语句还识别换行符
```sequence
颜回->孔子: 吃饭了没？
note right of 孔子: 孔子思考\n如何回答
孔子-->颜回: 吃过了。你咧？
颜回->>孔子: 吃过了，吃过了！
```
## 3. 甘特图

### 3.1 语法

### 3.2 例子

## 9. 链接

* [Markdown里面的序列图](http://blog.csdn.net/subson/article/details/78032857)
* [Markdown里面的流程图](http://blog.csdn.net/subson/article/details/75126945)
* [markdown的流程图、时序图、甘特图画法](http://blog.csdn.net/subson/article/details/75126945)