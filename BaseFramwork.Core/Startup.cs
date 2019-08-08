using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using BaseFramwork.Common;
using BaseFramwork.Core.AOP;
using BaseFramwork.Core.AuthHelper;
using BaseFramwork.Core.AuthHelper.OverWrite;
using BaseFramwork.Core.AuthHelper.Policys;
using BaseFramwork.IRepository;
using BaseFramwork.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;


namespace BaseFramwork.Core
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //数据库配置
            //Repository.BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:SqlServerConnection").Value;
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        //配置服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            // 缓存注入
            services.AddScoped<ICaching, MemoryCaching>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();


            //#region CORS
            ////跨域第二种方法，声明策略，记得下边app中配置
            //services.AddCors(c =>
            //{
            //    //↓↓↓↓↓↓↓注意正式环境不要使用这种全开放的处理↓↓↓↓↓↓↓↓↓↓
            //    c.AddPolicy("AllRequests", policy =>
            //    {
            //        policy
            //        .AllowAnyOrigin()//允许任何源
            //        .AllowAnyMethod()//允许任何方式
            //        .AllowAnyHeader()//允许任何头
            //        .AllowCredentials();//允许cookie
            //    });
            //    //↑↑↑↑↑↑↑注意正式环境不要使用这种全开放的处理↑↑↑↑↑↑↑↑↑↑


            //    //一般采用这种方法
            //    c.AddPolicy("LimitRequests", policy =>
            //    {
            //        // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
            //        // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
            //        policy
            //        .WithOrigins("http://127.0.0.1:1818", "http://localhost:8080", "http://localhost:8021", "http://localhost:8081", "http://localhost:1818")
            //        .AllowAnyHeader()//Ensures that the policy allows any header.
            //        .AllowAnyMethod();
            //    });
            //});

            ////跨域第一种办法，注意下边 Configure 中进行配置
            ////services.AddCors();
            //#endregion


            #region Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion


            #region Swagger

            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.1.0",
                    Title = "BaseFramWork.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "BaseFramWork.Core", Email = "BaseFramWork.Core@xxx.com", Url = "https://www.*******.com/" }
                });

                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "BaseFramwork.Core.xml");//这个就是刚刚配置的xml文件名

                var xmlModelPath = Path.Combine(basePath, "BaseFramwork.Model.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                c.IncludeXmlComments(xmlModelPath);


                #region Token绑定到ConfigureServices
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "BaseFramwork", new string[] { } }, };
                c.AddSecurityRequirement(security);
                //方案名称“BaseFramwork”可自定义，上下一致即可
                c.AddSecurityDefinition("BaseFramwork", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion


                //// 1【授权】、这个和上边的异曲同工，好处就是不用在controller中，写多个 roles 。
                //// 然后这么写 [Authorize(Policy = "Admin")]
                //services.AddAuthorization(options =>
                //{
                //    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                //    options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
                //});


                //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //    .AddJwtBearer(options =>
                //    {
                //        options.TokenValidationParameters = new TokenValidationParameters
                //        {
                //            ValidateIssuer = false,
                //            ValidateAudience = false,
                //            ValidateLifetime = false,
                //            ValidateIssuerSigningKey = false,
                //            ValidIssuer = Configuration["Audience:Issuer"],
                //            ValidAudience = Configuration["Audience:Audience"],
                //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Audience:Secret"])),
                //    };
                //});





            });

            #endregion


            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
            //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
            //    options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            //});


            ////2.1【认证】
            //services.AddAuthentication(x =>
            //{
            //    //看这个单词熟悉么？没错，就是上边错误里的那个。
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //     .AddJwtBearer(o =>
            //     {
            //         o.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuerSigningKey = true,
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Audience:Secret"])),
            //             ValidateIssuer = true,
            //             ValidIssuer = Configuration["Audience:Issuer"],//发行人
            //                 ValidateAudience = true,
            //             ValidAudience = Configuration["Audience:Audience"],//订阅人
            //                 ValidateLifetime = true,
            //             ClockSkew = TimeSpan.Zero,
            //             RequireExpirationTime = true,
            //         };

            //     });


    



            #region JWT Token Service
            //读取配置文件
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            // 令牌验证参数，之前我们都是写在AddJwtBearer里的，这里提出来了
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,//验证发行人的签名密钥
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,//验证发行人
                ValidIssuer = audienceConfig["Issuer"],//发行人
                ValidateAudience = true,//验证订阅人
                ValidAudience = audienceConfig["Audience"],//订阅人
                ValidateLifetime = true,//验证生命周期
                ClockSkew = TimeSpan.Zero,//这个是定义的过期的缓存时间
                RequireExpirationTime = true,//是否要求过期

            };
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<PermissionItem>();

            // 角色与接口的权限要求参数
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",// 拒绝授权的跳转地址（目前无用）
                permission,//这里还记得么，就是我们上边说到的角色地址信息凭据实体类 Permission
                ClaimTypes.Role,//基于角色的授权
                audienceConfig["Issuer"],//发行人
                audienceConfig["Audience"],//订阅人
                signingCredentials,//签名凭据
                expiration: TimeSpan.FromSeconds(60 * 2)//接口的过期时间，注意这里没有了缓冲时间，你也可以自定义，在上边的TokenValidationParameters的 ClockSkew
                );

            // ① 核心之一，配置授权服务，也就是具体的规则，已经对应的权限策略，比如公司不同权限的门禁卡
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client",
                    policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin",
                    policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin",
                    policy => policy.RequireRole("Admin", "System"));

                // 自定义基于策略的授权权限
                options.AddPolicy("Permission",
                         policy => policy.Requirements.Add(permissionRequirement));
            })
            // ② 核心之二，必需要配置认证服务，这里是jwtBearer默认认证，比如光有卡没用，得能识别他们
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // ③ 核心之三，针对JWT的配置，比如门禁是如何识别的，是放射卡，还是磁卡
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
            });


            // 依赖注入，将自定义的授权处理器 匹配给官方授权处理器接口，这样当系统处理授权的时候，就会直接访问我们自定义的授权处理器了。
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            // 将授权必要类注入生命周期内
            services.AddSingleton(permissionRequirement);


            #endregion


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //// 注入 service
            //services.AddScoped<IAdvertisementServices, AdvertisementServices>();

            //// 注入 repository
            //services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

            #region AutoFac

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();

            //注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

            //注册拦截器
            builder.RegisterType<BlogLogAOP>();
            builder.RegisterType<BlogCacheAOP>();
            builder.RegisterType<BlogRedisCacheAOP>();


            var cacheType = new List<Type>();

            cacheType.Add(typeof(BlogLogAOP));
            cacheType.Add(typeof(BlogCacheAOP));
            cacheType.Add(typeof(BlogRedisCacheAOP));


            //使用 LoadFile 加载服务层的程序集
            var basePathdll = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;//获取项目路径
            var servicesDllFile = Path.Combine(basePathdll, "Services.dll");//获取注入项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法
                                                                       //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。

            //注入拦截器
            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                .InterceptedBy(cacheType.ToArray());
            //.InterceptedBy(typeof(BlogLogAOP));//可以直接替换拦截器


            //#region Repository.dll 注入，有对应接口
            var repositoryDllFile = Path.Combine(basePathdll, "Repository.dll");
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();







            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            #endregion


            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //中间件
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            //如果你想使用官方认证，必须在上边ConfigureService 中，配置JWT的认证服务 (.AddAuthentication 和 .AddJwtBearer 二者缺一不可)
            app.UseAuthentication();


            //app.UseMiddleware<JwtTokenAuth>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            #region CORS
            //跨域第二种方法，使用策略，详细策略信息在ConfigureService中
            app.UseCors("LimitRequests");//将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。


            #region 跨域第一种版本
            //跨域第一种版本，请要ConfigureService中配置服务 services.AddCors();
            //    app.UseCors(options => options.WithOrigins("http://localhost:8021").AllowAnyHeader()
            //.AllowAnyMethod());  
            #endregion

            #endregion


            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");

                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ApiHelp V1");//注意这个 v1 要和上边 ConfigureServices 中配置的大小写一致
                                                                                // 将swagger设置成首页
                c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉


            });
            #endregion





            //使用自定义认证
            //自定义认证中间件
            //app.UseJwtTokenAuth(); //也可以app.UseMiddleware<JwtTokenAuth>();


            app.UseMvc();
        }
    }
}
