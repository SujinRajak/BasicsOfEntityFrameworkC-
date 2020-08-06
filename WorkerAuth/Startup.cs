using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkerAuth
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
            #region Manululating with database connection
            // this all wiil bee done using a single line
            /* //summary
            //the for working mechanish of the databse of the application
            //summary
            using (var context = new applicationdbcontext())
            {
                //make sure we have the database
                context.database.ensurecreated();

                //if no entries in the useracc then
                if (!context.user.any())
                {
                    //add items but not in db only in memory
                    context.user.add(new useracc
                    {
                        id = "1",
                        username = "sujin",
                        email = "sujin@example.com",
                        passwordhashed = "asdada",
                        phonenumber = "121313",
                        inactiveusers = false
                    });



                    //counting no of user from memeory
                    var count = context.user.local.count();
                    //counting no of user from database
                    var countdb = context.user.count();

                    //checking the values of the first element memeory
                    var firstelem = context.user.local.firstordefault();
                    //checking the values of the first element database
                    var firstlemdb = context.user.firstordefault();

                    //this will commit to the db
                    context.savechanges();

                    count = context.user.local.count();
                    countdb = context.user.count();

                    //checking the values of the first element
                    firstelem = context.user.local.firstordefault();
                    firstlemdb = context.user.firstordefault();
                }
            }*/
            #endregion


            //this can be done with htis too
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=DESKTOP-THG2BP2;Database=Worker;Trusted_Connection=True;MultipleActiveResultSets=true"));
            
            //as we know rthat the configuration has the appsetting the json file loadded in the directory and contains all the directory of the folder we are working in so configuration.getconnectionstring("default connection is the name in appseting.json")
            //this is the connecting string added to the pipeline with the help of dependency injection which helps to connect to the db and perform CRUD operations
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // In here the iserviceProvider is an IOC a framework which helps to create and manage objects and its life time, and it also injects dependency to classes which is done through costructor and this is done so that we dont need to create and manage objects manually  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {

            ////store instance of the Di container tso that the application can access it anywhere
            //IocCotainer.Provider= (ServiceProvider)serviceProvider;
            
            
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
