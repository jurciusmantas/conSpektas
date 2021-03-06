﻿using conSpecktas.Model.Repositories.Categories;
using conSpecktas.Model.Repositories.Conspects;
using conSpecktas.Model.Services.Categories;
using conSpecktas.Model.Services.Conspects;
using conSpektas.Data;
using conSpektas.Model.Repositories.Comment;
using conSpektas.Model.Repositories.Login;
using conSpektas.Model.Repositories.Register;
using conSpektas.Model.Repositories.Users;
using conSpektas.Model.Services.Comments;
using conSpektas.Model.Services.Login;
using conSpektas.Model.Services.Register;
using conSpektas.Model.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using conSpecktas.Model.Services.Ratings;
using conSpecktas.Model.Repositories.Ratings;
using Newtonsoft.Json;

namespace conSpektas.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                }); ;

            services.AddDbContext<ConspectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConSpektasConnection")));

            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IConspectsService, ConspectsService>();
            services.AddScoped<IConspectsRepository, ConspectsRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IRatingsService, RatingsService>();
            services.AddScoped<IRatingsRepository, RatingsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
                
        }
    }
}
