global using Microsoft.AspNetCore.ResponseCompression;
global using PMSystem.Server.Enums;
global using PMSystem.Server.Entities;
global using AutoMapper;
global using PMSystem.Shared.Models;
global using PMSystem.Shared;
global using SqlSugar;
global using PMSystem.Server.Services.AuthService;
global using PMSystem.Server.Services.UserService;
global using PMSystem.Server.Services.RoleService;

global using PMSystem.Server.Services.WarehouseService;
global using PMSystem.Server.Services.PartsService;
global using PMSystem.Server.Services.InboundListService;
global using PMSystem.Server.Services.OutboundListService;
global using PMSystem.Server.Services.CheckListService;
global using PMSystem.Server.Services.TransferListService;
global using PMSystem.Server.Services.StorageInfoService;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PMSystem.Server.DataBase;
using PMSystem.Server.Profiles;
using PMSystem.Server.Util;
using System.Text;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => {
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "PMSystem API", Version = "v1" });
});
//获取Config配置

LogHelper.ConfigureLog();
LogHelper.Info(Path.GetDirectoryName(Environment.ProcessPath));

//添加数据库单例
builder.Services.AddSingleton<ISqlSugarClient, SqlSugarScope>(options =>
{
    return new SqlSugarScope(new List<ConnectionConfig>
    {
        new ConnectionConfig()
        {
            ConfigId=DbEnum.SqlServer,
            ConnectionString = builder.Configuration.GetConnectionString("SqlServerString"),
            DbType=DbType.SqlServer,
            IsAutoCloseConnection = true,
        },
    },
    db =>
    {
        //5.1.3.24统一了语法和SqlSugarScope一样，老版本AOP可以写外面
        db.Aop.OnLogExecuting = (sql, pars) =>
        {
            //Log4Net记录数据库日志
            LogHelper.SqlInfo(sql,pars);
            //Console.WriteLine(sql);//输出sql,查看执行sql 性能无影响
            //5.0.8.2 获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
            //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)
        };

    });
});


builder.Services.AddHttpContextAccessor();

LogHelper.Info("添加Service服务,Repository仓储,Profile...");
//反射
foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
{
    //添加服务Service
    if (!type.IsInterface && !type.IsAbstract && type.ToString().EndsWith("Service"))
    {
        var interfaceTypes = type.GetInterfaces();
        foreach (var interfaceType in interfaceTypes)
        {
            builder.Services.AddScoped(interfaceType, type);
            //LogHelper.Info($"添加Service:{interfaceType.Name}-{type.Name}");
        }
    }
    //添加仓储
    if (type.Name.Contains("Repository"))
    {
        builder.Services.AddScoped(type);
        //LogHelper.Info($"添加Repository:{type.Name}");
    }
    //添加AutoMapper
    if (type.Name.Contains("Profile"))
    {
        builder.Services.AddAutoMapper(type);
        //LogHelper.Info($"添加Profile:{type.Name}");
    }
}

LogHelper.Info("添加完成!");

//添加身份验证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });


//LogHelper.ConfigureLog();//log4net
LogHelper.Info($"日志配置完毕...");


var app = builder.Build();

app.UseSwaggerUI(config => {
    config.DocumentTitle = "API 文档";
    config.SwaggerEndpoint("/swagger/v1/swagger.json", "API文档 V1");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

LogHelper.Info("启动成功!");

app.Run();

