using BloggerSample.BLL.Abstract;
using BloggerSample.BLL.BlogService;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DAL;
using BloggerSample.Mapping.ConfigProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;


namespace BloggerSample.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            MapperConfig.RegisterMappers();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(z => z.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BloggerSampleAPI", Version = "V1" }));
            services.AddControllers();

            services.AddSingleton<IUnitofWork, UnitofWork>();
            //services.AddDbContext<BloggerDbContext>(z => z.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<DbContext, BloggerDbContext>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<ICommentService, CommentService>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<IUserDetailService, UserDetailService>();
            services.AddSingleton<IUserService, UserService>();


            //Her repositryde yeni instacnce oluþturur
            //services.AddScoped<ICategoryService, CategoryService>();
            //Singleton bir kere oluþturur
            //Her seferinde yeni obeje yaratýr
            //services.AddTransient<ICategoryService, CategoryService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(z =>
                    z.SwaggerEndpoint("/swagger/v1/swagger.json", "BloggerSampleAPI")
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
