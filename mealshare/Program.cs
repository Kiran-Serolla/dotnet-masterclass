var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/meals", ([FromServices] IMealSharingService mealSharingService) =>
{
    return mealSharingService.ListMeals();
});
app.MapPost("/meals", ([FromServices] IMealSharingService mealSharingService, Meal meal) =>
{
    return mealSharingService.AddMeal(meal);
});


app.Run();
public class Meal
{
    public string Headline { get; set; }
    public string ImageUrl { get; set; }
    public string BodyText { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
}
public interface IMealService
{
    List<Meal> ListMeals();
    void AddMeal(Meal meal);
}
class FileMealService : IMealService
{
    public void AddMeal(Meal meal)
    {
        var meals = ListMeals();
        meals.Add(meal);
        var json = System.Text.Json.JsonSerializer.Serialize(meals);
        File.WriteAllText("meals.json", json);
        throw new NotImplementedException();
    }
    public List<Meal> ListMeals()
    {
        var json = File.ReadAllText("meals.json");
        var meals = System.Text.Json.JsonSerializer.Serialize<List<Meal>>(json);
        return meals;
    }
}