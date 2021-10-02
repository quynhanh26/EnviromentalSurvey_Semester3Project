using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace Client
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
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddSession();
            services.AddScoped<ISeminarAPI, SerminarAPI>();
            services.AddScoped<IAccountAPI, AccountAPI>();
            services.AddScoped<IQuestionAPI, QuestionAPI>();
            services.AddScoped<IAnswerAPI, AnswerAPI>();
            services.AddScoped<IFaqAPI, FaqAPI>();
            services.AddScoped<IScoreAPI, ScoreAPI>();
            services.AddScoped<IAllPeopleAPI, AllpeopleAPI>();
            services.AddScoped<IPerformerAPI, PerformerAPI>();
            services.AddScoped<IImgAPI, ImgAPI>();
            services.AddScoped<ISurveyAPI, SurveyAPI>();
            services.AddScoped<ICommentAPI, CommentAPI>();
            services.AddScoped<IQuestionSurveyAPI, QuestionSurveyAPI>();
            services.AddScoped<IRegisterSeminarAPI, RegisterSeminarAPI>();
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
            }
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
