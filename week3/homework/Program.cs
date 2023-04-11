var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/* Create Account class that can be initialized with the amount value.
 Account class contains Withdraw and Deposit methods and Balance (get only) property. 
Make sure that you can't withdraw more than you have in the balance.*/

public class Account{
    private decimal balance;

    public Account (decimal Balance)
    {
        balance = Balance;
    }

    public void Deposit (decimal amount)
    {
        balance+= amount;
    }

    public void Withdraw (decimal amount)
    {
        if (amount > balance)
        {
            throw new ArgumentException(" You cannot withdraw more than your balance amount");
        }
        balance-= amount;
    }

    public decimal balance {
        get {return balance}
    }
}

/* Create a class named Temperature and make a constructor with one decimal parameter - degrees (Celsius)
 and assign its value to Property. The property has a public getter and private setter. 
 The property setter throws an exception if temperature is less than 273.15 Celsius. 
Then, create a property Fahrenheit that will convert Celsius to Fahrenheit (it has no setter similar to NicePrintout)*/

public class Temperature
{
    private decimal degreeCelsius;

    public Temperature (decimal degrees){
        degreeCelsius = degrees;
    }

    public decimal DegreeCelsius
    {
        get {
            return degreeCelsius;
        }
        private set {
            if (value < -273.15)
            {
                throw Exception("Temperature cannot be less than -273.15");
            }

            degreeCelsius = value;
        }
    }

    public decimal Farienheit {
        get { return degreeCelsius*9/5 + 32;}
    }
}

app.Run();
