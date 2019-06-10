using MgnWebApi.Context;
using MgnWebApi.Interface;
using MgnWebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MgnWebApi
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
            //services.AddDbContext<ClienteContext>(opt =>
            //opt.UseInMemoryDatabase("ClienteList"));

            //services.AddDbContext<TelefonesContext>(opt =>
            //opt.UseInMemoryDatabase("TelefoneList"));

            //services.AddDbContext<EnderecoContext>(opt =>
            //opt.UseInMemoryDatabase("EnderecoList"));

            services.AddDbContext<PessoaContext>(o => o.UseSqlServer(this.Configuration.GetConnectionString("DbPessoa")));
            services.AddTransient<IPessoaRepository, PessoaRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
