var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//A POST endpoint that calls POST users/add with a record with FirstName, LastName and Age 

app.MapPost("/adduser", async (User user) =>
{
    var httpClient = new HttpClient();
    var response = await httpClient.PostAsJsonAsync("https://dummyjson.com/users/add", user);
    if (!response.IsSuccessStatusCode)
    {
        throw new Exception($"Uh-oh!: {response.StatusCode}");
    }

     var data = response.Content.ReadFromJsonAsync<User>();

      var result = new
    {
        StatusCode = response.StatusCode,
        data = data,
    };
    return Results.Ok(result);
    
});

// A POST endpoint that that calls Post products/add with a record with Title and Price (this simulates creating a product)

app.MapPost("/addproduct", async (Product addproduct) => await AddProduct(addproduct));

async Task<Product?> AddProduct(Product addproduct){

    var httpClient = new HttpClient();
    var response = await httpClient.PostAsJsonAsync("https://dummyjson.com/products/add", addproduct);
    if (!response.IsSuccessStatusCode)
    {
        throw new Exception($"Uh-oh!: {response.StatusCode}");
    }

     var result = await response.Content.ReadFromJsonAsync<Product>();
    return result;
 
};
//A POST endpoint that takes a lists of ids and retrieves all of the users with those ids from the GET users (Id, FirstName, LastName and Age)
app.MapPost("/listusers", async (List<int> userIds) => await GetUsers(userIds));

async Task<List<User>> GetUsers(List<int> userIds)
{
    var getUserTasks = new List<Task<User>>();

    foreach (int userId in userIds)
    {
        
        getUserTasks.Add(GetUser(userId));
    }
    var users = await Task.WhenAll(getUserTasks);
    return new List<User>(users);
}
async Task<User> GetUser(int userId){
    var response = await new HttpClient().GetAsync($"https://dummyjson.com/users/{userId}");
    var data = await response.Content.ReadFromJsonAsync<User>();
    return data;
}

// A POST endpoint that takes a lists of ids and retrieves all of the products with those ids GET products(Id, Title)

app.MapPost("/listproducts", async (List<int> productIds) => await GetUsers(productIds));

async Task<List<Product>> GetProducts(List<int> productIds)
{
    var getProductTasks = new List<Task<Product>>();

    foreach (int productId in productIds)
    {
        
        getProductTasks.Add(GetProduct(productId));
    }
    var products = await Task.WhenAll(getProductTasks);
    return new List<Product>(products);
}
async Task<Product> GetProduct(int productId){
    var response = await new HttpClient().GetAsync($"https://dummyjson.com/products/{productId}");
    var data = await response.Content.ReadFromJsonAsync<Product>();
    return data;
}

app.Run();


record User(string FirstName, string LastName, int Age);
record Product(string Title, decimal Price);