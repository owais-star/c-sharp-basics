string greeting = "      Hello World!       ";
Console.WriteLine($"[{greeting}]");

string trimmedGreeting = greeting.TrimStart();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.TrimEnd();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.Trim();
Console.WriteLine($"[{trimmedGreeting}]");


string songLyrics = "You say goodbye, and I say hello";
Console.WriteLine(songLyrics.Contains("goodbye"));
Console.WriteLine(songLyrics.Contains("greetings"));

int a = 18;
int b = 6;
int c = a + b;
Console.WriteLine(c);

c = a - b;

Console.WriteLine(c);

int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is {min} to {max}");

int what = max + 3;
Console.WriteLine($"An example of overflow: {what}");

double maxDouble = double.MaxValue;

double minDouble = double.MinValue;

Console.WriteLine($"The range of double is {minDouble} to {maxDouble}");

double third = 1.0 / 3.0;

Console.WriteLine(third);

decimal minDecimal = decimal.MinValue;

decimal maxDecimal = decimal.MaxValue;

Console.WriteLine($"The range of decimal is {minDecimal} to {maxDecimal}");


double aDouble = 1.0;
double bDouble = 3.0;

Console.WriteLine(aDouble / bDouble);

decimal aDecimal = 1.0M;

decimal bDecimal = 3.0M;

Console.WriteLine(aDecimal / bDecimal);

double radius = 2.50;

double area = Math.PI * radius * radius;

Console.WriteLine(area);

double angle = 1.0;

double sinAngle = Math.Sin(angle);

Console.WriteLine(sinAngle);

double cosAngle = Math.Cos(angle);

Console.WriteLine(cosAngle);

double tanAngle = Math.Tan(angle);

Console.WriteLine(tanAngle);

double angleInDegrees = 45.0;

double angleInRadians = angleInDegrees * Math.PI / 180.0;

Console.WriteLine(angleInRadians);

if (a + b > 10)
    Console.WriteLine("The answer is greater than 10");
else
    Console.WriteLine("The answer is not greater than 10");

if (a + b > 10)
{
    Console.WriteLine("The answer is greater than 10");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
}


// int a = 5;
// int b = 3;
// int c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}

int counter = 0;
while (counter < 10)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
}


do
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
} while (counter < 20);


for (int counter1 = 0; counter1 < 10; counter1++)
{
    Console.WriteLine($"Hello World! The counter is {counter1}");
}

// scopes
{
    const int let = 5;
    byte number = 0;

    if (number == 3)
    {
        Console.WriteLine("The number is not set");
    }
    else
    {
        Console.WriteLine($"The number is {number}");
    }
}


namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            const int totalNumbers = 1200;

            string name = "Bob";
            int age = 30;
            bool isRaining = true;
            double height = 1.85;
            decimal price = 29.99m;

            var name1 = "Bob";
            var age1 = 30;
            var isRaining1 = true;

            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(isRaining);
            Console.WriteLine(height);
            Console.WriteLine(price);
            Console.WriteLine("{0} {1}", name, name1);
        }
    }
}
