using Onboarding.Api.MockService;
using Onboarding.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
var openAiApiKey = "sk-proj-ywl34MTkxplnJGBGjA8ET3BlbkFJQrCBZEoqZ3yzKe98J7Ny";
//builder.Services.AddSingleton(new OpenAIService(openAiApiKey));
builder.Services.AddSingleton(new OnboardingService(new OpenAIService1(openAiApiKey), new BusinessRevenueService()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
