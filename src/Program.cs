using HabitumAPI.Extensions;
using HabitumAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddControllers();
builder.Services
    .AddApplicationServices()
    .AddRepositories()
    .AddDatabase(builder.Configuration)
    .AddCorsPolicies()
    .AddJwtAuthentication(builder.Configuration)
    .AddQuartzJobs()
    .AddSwaggerDocs(builder.Configuration);

var app = builder.Build();

// Middlewares
app.UseRouting();

app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HabitumAPI v1");
        c.RoutePrefix = "";
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}
else
    app.UseCors("HabitumClient");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<ValidateUserFromTokenMiddleware>();
app.UseMiddleware<UserDataRefreshMiddleware>();
app.UseAuthorization();

app.MapControllers();
app.Run();
