using BusinessLogic; 
using DataAccess;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(builder.Configuration); 
builder.Services.AddBusinessLogic(); 

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
