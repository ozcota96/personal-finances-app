using core_api.Services;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// CORS policy
var allowFrontend = "_allowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowFrontend,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



// Add services to the container.
builder.Services.AddControllers();

// Error messages formatting
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
        var result = new
        {
            Message = "Validation errors occurred.",
            Errors = errors
        };

        return new BadRequestObjectResult(result);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services concrete implementation
builder.Services.AddSingleton<IUsersService, UsersService>();
builder.Services.AddSingleton<IAccountsService, AccountsService>();
builder.Services.AddSingleton<IMovementsService, MovementsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowFrontend);

app.UseAuthorization();

app.MapControllers();

app.Run();
