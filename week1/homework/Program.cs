var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// String Manipulation

app.MapGet("/reverse", (string input) => {
    char[] charArray = input.ToCharArray();
     int left = 0;
        int right = charArray.Length - 1;

        while (left < right)
        {
            char temp = charArray[left];
            charArray[left] = charArray[right];
            charArray[right] = temp;

            left++;
            right--;
        }

        string reversedString = new string(charArray);
        return reversedString;
});

app.Run();

// Vowel count

app.MapGet("/vowelCount", (string inputString) =>{

    //inputString = "Intellectualization";

    int vowelCount =0;
    char[] vowels = {'a','e','i','o','u'};

    foreach(char c in inputString.ToLower())
    {
        if (vowels.Contains(c))
        {
            vowelCount++;
        }
    }
    
    return vowelCount;
    //Console.WriteLine($"Number of vowels: {vowelCount}");
});
app.Run();

//Math/Array
app.MapGet("/math", () =>{

int[] numbers = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59,  -1852, 41, 5 };
int positiveProduct = 1;
int negativeSum = 0;

foreach(int i in numbers)
{
    if (i >0 ) positiveProduct*=i;
   if(i<0) negativeSum+=i;
    
}
      
 return $"Sum of negative numbers - {negativeSum} \nMultiplication of positive numbers - {positiveProduct}";
});
app.Run();

//Classical task

app.MapGet("/fibonacci",(int n)=>{
    
    int prev1 = 1;
    int prev2 = 0;
    int current = 0;

    for (int i = 2; i <= n; i++) {
        current = prev1 + prev2;
        prev2 = prev1;
        prev1 = current;
    }

    return current;
});
app.Run();
// Arrays