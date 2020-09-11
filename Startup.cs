using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SeparatorBack.Models;

namespace SeparatorBack
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=groupsdbstore;Trusted_Connection=True;";
������������// ������������� �������� ������
������������services.AddDbContext<GroupContext>(options => options.UseSqlServer(con));
            services.AddCors();

            services.AddControllers(); // ���������� ����������� ��� �������������
��������}

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors(builder => { builder.AllowAnyOrigin(); builder.AllowAnyHeader(); builder.AllowAnyMethod(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // ���������� ������������� �� �����������
������������});
        }
    }
}