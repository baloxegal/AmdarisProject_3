using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.RegAndAuth;
using AmdarisProject_3.API.Repositories;
using AmdarisProject_3.API.Services;

namespace AmdarisProject_3.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();            

            services.AddSwaggerGen(c =>
            {                
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AmdarisProject_3.API",                    
                    Description = "ASP.NET Core 5.0 WEB API"                    
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Cookie,
                    Description = "ApplicationSettings:JWT_Secret",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddDbContext<SocialMediaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("AmdarisProject_3.API")));

            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<SocialMediaDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 20;

                //options.Tokens.PasswordResetTokenProvider = "222";
                //options.Tokens.PasswordResetTokenProvider = "222";
                //options.Tokens.ChangeEmailTokenProvider = "222";
                //options.SignIn.RequireConfirmedAccount = true;
                //options.User.RequireUniqueEmail = true;
            });

            services.AddCors();

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero

                        //ValidateLifetime = false,
                        //ValidateIssuer = true,
                        //ValidateAudience = true,                        
                        //ValidIssuer = Configuration["ApplicationSettings:Client_URL"],
                        //ValidAudience = Configuration["ApplicationSettings:Client_URL"],

                    };
                });

            //services.AddScoped<IRepository<IEntity, string>, EntityRepository<IEntity, string>>();
            //services.AddScoped<IRepository<IEntity, long>, EntityRepository<IEntity, long>>();
            //services.AddScoped<IService<IEntity, string>, EntityService<IEntity, string>>();
            //services.AddScoped<IService<IEntity, long>, EntityService<IEntity, long>>();

            services.AddAutoMapper(typeof(Startup).Assembly);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AmdarisProject_3.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
                builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString()).
                AllowAnyHeader().
                AllowAnyMethod());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
