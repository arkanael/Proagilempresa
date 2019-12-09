using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProAgilEmpresa.Application.AutoMapper;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Context;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Identity;
using ProAgilEmpresa.Infra.CrossCutting.IoC;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace ProagilEmpresa.WebSite
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
            // Registra o contexto do banco
            BootStrapper.RegisterDbContext(Configuration, services);
            BootStrapper.Register(services);


            BootStrapper.RegisterIdentity(Configuration, services);

            // Configura o mapeamento 
            var mapper = AutoMapperConfig.RegisterMappings();
            BootStrapper.RegisterMappings(services, mapper);

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });

            //});
            services.AddSwaggerGen(
                swagger =>
                    {
                        swagger.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "Sistema de Login de Usuários com JWT",
                            Version = "v1",
                            Description = "Projeto desenvolvido   em aula - COTI Informática"
                        });
                        swagger.OperationFilter<HeaderParameter>();
                    }
                );

            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
          );

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddSignInManager<SignInManager<User>>();



            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        var key = Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
                        var tokenValidationParameters = new TokenValidationParameters();

                        tokenValidationParameters.ValidateIssuerSigningKey = true;
                        tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);
                        tokenValidationParameters.ValidateIssuer = false;
                        tokenValidationParameters.ValidateAudience = false;
                        options.TokenValidationParameters = tokenValidationParameters;
                    }
            );


            //Comentei essa parte para validar o CRUD da APIs,  fique a vontade.
            services
                .AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                    options.Filters.Add(new AuthorizeFilter(policy));
                }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    //Set date configurations
                    options
                        .SerializerSettings
                        .DateTimeZoneHandling = DateTimeZoneHandling.Local;

                    options
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
                );



            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

  
     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
        
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.InjectStylesheet("/Swagger/Ui/custom.css");

            });
            app.UseMvc();
        }
    }
}
