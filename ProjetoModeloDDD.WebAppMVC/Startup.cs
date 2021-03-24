using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoModeloDDD.Infrastructure.Data.Context;
using ProjetoModeloDDD.WebAppMVC.AutoMapper;
using ProjetoModeloDDD.Infrastructure.Data.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Application;
using AutoMapper;

namespace ProjetoModeloDDD.WebAppMVC
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProjetoModeloDDDMappings());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddDbContext<ProjetoModeloContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProjetoModeloDDD")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped(typeof(IEFCoreRepository<>), typeof(EFCoreRepository<>));

            services.AddControllersWithViews();
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
