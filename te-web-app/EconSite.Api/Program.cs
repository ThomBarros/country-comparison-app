// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();
// builder.Services.AddHttpClient();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("ReactPolicy",
//         policy =>
//         {
//             policy
//                 .WithOrigins("http://localhost:5173")
//                 .AllowAnyHeader()
//                 .AllowAnyMethod();
//         });
// });

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseCors("ReactPolicy");

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");

// serve frontend
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// React/Vite SPA fallback
app.MapFallbackToFile("index.html");

app.Run();