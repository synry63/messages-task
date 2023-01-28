using messages_task_api;
using messages_task_api.Hubs;
using messages_task_api.IServices;
using messages_task_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
            policy.WithOrigins("http://localhost:8080");
        });

});
builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.AddConsole()
        .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
    loggingBuilder.AddDebug();
});
builder.Services.AddControllers();
builder.Services.AddDbContext<MessagesTaskContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MAIN"))
    .EnableSensitiveDataLogging()
    );

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserNotificationService, UserNotificationService>();
builder.Services.AddScoped<IHistoryLogService, HistoryLogService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<MessageHub>("/message-hub");
app.Run();
