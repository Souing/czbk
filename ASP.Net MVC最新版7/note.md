# ASP.Net MVC最新版

## 5. EntityFramework

### 5.1 Database.SetInitializer的几种参数

#### 5.1.1  数据库不存在时重新创建数据库

> Database.SetInitializer<testContext>(new CreateDatabaseIfNotExists<testContext>());

#### 5.1.2  每次启动应用程序时创建数据库 

> Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<testContext>());

#### 5.1.3 模型更改时重新创建数据库  

> Database.SetInitializer<testContext>(new DropCreateDatabaseIfModelChanges<testContext>());

#### 5.1.4 从不创建数据库

> Database.SetInitializer<testContext>(null);

## 5.2 EF Code First一对一、一对多、多对多关联关系配置 

```c#
this.Property(t => t.AccountID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
this.Property(t => t.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
this.Property(t => t.UnitPrice).HasPrecision(10, 2);
this.HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryID)
                .WillCascadeOnDelete(false);
                
    modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });
```



> 1.    //判断该action方法时候有贴上MyFilter1Attribute标签  
> 2.    if (filterContext.ActionDescriptor.IsDefined(typeof (MyFilter1Attribute),false))  
>
>           //        object[] attrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(ViewPageAttribute), true);
>           //        var isViewPage = attrs.Length == 1;//当前Action请求是否为具体的功能页

## 8.0 备忘

### 8.1 DbEntityValidationException 

```C#
var p = new Person();
p.Name = "非常长的字符串";
ctx.Persons.Add(p);
try
{
    ctx.SaveChanges();
}
catch(DbEntityValidationException ex)
{
    StringBuilder sb = new StringBuilder();
    foreach(var ve in ex.EntityValidationErrors.SelectMany(eve=>eve.ValidationErrors))
    {
        sb.AppendLine(ve.PropertyName+":"+ve.ErrorMessage);
    }
Console.WriteLine(sb);
}
```



## 9.0 链接

* [EF Code First一对一、一对多、多对多关联关系配置](https://www.cnblogs.com/libingql/archive/2013/01/31/2888201.html)