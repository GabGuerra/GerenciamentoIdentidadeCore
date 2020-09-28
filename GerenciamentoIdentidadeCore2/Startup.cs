using System;
using System.Collections.Generic;
using GerenciamentoIdentidadeCore2.Controllers;
using GerenciamentoIdentidadeCore2.Repositories;
using GerenciamentoIdentidadeCore2.Repositories.Modulo;
using GerenciamentoIdentidadeCore2.Repositories.Repository;
using GerenciamentoIdentidadeCore2.Repositories.Perfil;
using GerenciamentoIdentidadeCore2.Services;
using GerenciamentoIdentidadeCore2.Services.Modulo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GerenciamentoIdentidadeCore2.Services.Perfil;
using GerenciamentoIdentidadeCore2.Services.Funcionario;
using GerenciamentoIdentidadeCore2.Repositories.Usuario;
using GerenciamentoIdentidadeCore2.Services.Usuario;

namespace GerenciamentoIdentidadeCore2
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllersWithViews();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);            

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository,LoginRepository>();

            services.AddTransient<IModuloService, ModuloService>();
            services.AddTransient<IModuloRepository, ModuloRepository>();

            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IFuncionarioRepository, UsuarioGerenciamentoRepository>();

            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
