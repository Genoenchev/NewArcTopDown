# C# Complete Cheat Sheet

> Practical reference for modern C# and .NET. Designed for quick lookup
> rather than beginner-only teaching.

## Contents

1.  Syntax & types
2.  Strings
3.  Operators & control flow
4.  Methods
5.  Arrays & collections
6.  OOP
7.  Records, structs & enums
8.  Interfaces, inheritance & polymorphism
9.  Nullability & pattern matching
10. Exceptions
11. Generics
12. Delegates, lambdas & events
13. LINQ
14. Async, tasks & cancellation
15. Files, JSON, dates & HTTP
16. Resource management
17. Modern C#
18. Dependency injection
19. Testing
20. Common pitfalls
21. .NET CLI
22. Fast lookup tables

------------------------------------------------------------------------

# 1. Syntax & Types

## Program entry point

Modern top-level statements:

``` csharp
Console.WriteLine("Hello!");
```

Traditional:

``` csharp
namespace MyApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
    }
}
```

## Variables

``` csharp
int age = 27;
long population = 8_000_000_000L;
float ratio = 1.5f;
double distance = 21.0975;
decimal price = 19.99m;
bool active = true;
char letter = 'A';
string name = "Alice";
object anything = 42;

var inferred = "string"; // still statically typed
```

## Constants and readonly

``` csharp
const double Pi = 3.14159;

class Example
{
    private readonly Guid _id = Guid.NewGuid();
}
```

`const` is compile-time constant. `readonly` can be assigned at
declaration or in a constructor.

## Numeric literals

``` csharp
int million = 1_000_000;
int binary = 0b1010;
int hex = 0xFF;
```

## Conversions

``` csharp
double d = 12.8;
int i = (int)d;                  // 12

int x = Convert.ToInt32("42");
int y = int.Parse("42");

if (int.TryParse(input, out int value))
{
    Console.WriteLine(value);
}
```

Use `TryParse` for untrusted/user input.

## Value vs reference types

Typical value types:

``` text
int, double, decimal, bool, char, enum, struct, record struct
```

Typical reference types:

``` text
class, record class, string, array, delegate, interface
```

------------------------------------------------------------------------

# 2. Strings

``` csharp
string a = "Hello";
string b = "World";
string combined = a + " " + b;
```

## Interpolation

``` csharp
string message = $"{name} is {age} years old.";
string money = $"{price:C}";
string rounded = $"{Math.PI:F2}";
string percent = $"{0.256:P1}";
```

## Verbatim string

``` csharp
string path = @"C:\Users\Alice\Documents";
```

## Raw string literal

``` csharp
string json = """
{
    "name": "Alice"
}
""";
```

## Common methods

``` csharp
text.Length;
text.ToUpper();
text.ToLower();
text.Trim();
text.Contains("abc");
text.StartsWith("A");
text.EndsWith("Z");
text.Replace("old", "new");
text.Substring(2, 5);
text.IndexOf("abc");
text.Split(',');
string.Join(", ", values);
string.IsNullOrEmpty(text);
string.IsNullOrWhiteSpace(text);
```

## StringBuilder

``` csharp
using System.Text;

var sb = new StringBuilder();
sb.Append("Hello");
sb.Append(' ');
sb.AppendLine("World");

string result = sb.ToString();
```

Prefer it for lots of repeated concatenation.

------------------------------------------------------------------------

# 3. Operators & Control Flow

## Arithmetic

``` csharp
a + b;
a - b;
a * b;
a / b;
a % b;
```

Watch integer division:

``` csharp
5 / 2;      // 2
5 / 2.0;    // 2.5
```

## Assignment

``` csharp
x++;
x--;
x += 5;
x -= 5;
x *= 2;
x /= 2;
```

## Comparison / logic

``` csharp
a == b;
a != b;
a < b;
a <= b;
a > b;
a >= b;

a && b;
a || b;
!a;
```

## Null operators

``` csharp
string result = value ?? "default";
value ??= "default";
int? length = value?.Length;
```

## Ternary

``` csharp
string type = age >= 18 ? "Adult" : "Minor";
```

## if / else

``` csharp
if (age >= 18)
{
    HandleAdult();
}
else if (age >= 13)
{
    HandleTeen();
}
else
{
    HandleChild();
}
```

## switch statement

``` csharp
switch (status)
{
    case Status.Pending:
        Start();
        break;

    case Status.Completed:
        Finish();
        break;

    default:
        HandleUnknown();
        break;
}
```

## switch expression

``` csharp
string label = status switch
{
    Status.Pending => "Waiting",
    Status.Completed => "Done",
    _ => "Unknown"
};
```

## Loops

``` csharp
for (int i = 0; i < 10; i++)
{
}

foreach (var item in items)
{
}

while (condition)
{
}

do
{
}
while (condition);
```

Control:

``` csharp
break;
continue;
return;
```

------------------------------------------------------------------------

# 4. Methods

``` csharp
int Add(int a, int b)
{
    return a + b;
}

int Multiply(int a, int b) => a * b;
```

## Optional and named parameters

``` csharp
void Print(string text, bool uppercase = false)
{
}

Print(text: "hello", uppercase: true);
```

## ref / out / in

``` csharp
void Increment(ref int value) => value++;

bool TryRead(out int value)
{
    value = 42;
    return true;
}

void Inspect(in LargeStruct value)
{
}
```

## params

``` csharp
int Sum(params int[] values) => values.Sum();

Sum(1, 2, 3, 4);
```

## Local function

``` csharp
int Calculate(int value)
{
    int Double(int x) => x * 2;
    return Double(value) + 1;
}
```

## Method overloading

``` csharp
void Print(string value) { }
void Print(int value) { }
void Print(string value, int count) { }
```

------------------------------------------------------------------------

# 5. Arrays & Collections

## Arrays

``` csharp
int[] numbers = new int[3];
int[] values = { 1, 2, 3 };
int[] modern = [1, 2, 3];

numbers[0] = 10;
int first = numbers[0];
int count = numbers.Length;
```

Multidimensional:

``` csharp
int[,] matrix =
{
    { 1, 2 },
    { 3, 4 }
};

int x = matrix[1, 0];
```

Jagged:

``` csharp
int[][] rows =
[
    [1, 2],
    [3, 4, 5]
];
```

## List`<T>`{=html}

``` csharp
List<string> names = ["Alice", "Bob"];

names.Add("Charlie");
names.AddRange(["Dave", "Eve"]);
names.Remove("Bob");
names.RemoveAt(0);
names.Clear();

bool contains = names.Contains("Alice");
int count = names.Count;
```

## Dictionary\<TKey,TValue\>

``` csharp
Dictionary<string, int> ages = new()
{
    ["Alice"] = 30,
    ["Bob"] = 25
};

ages["Charlie"] = 40;

if (ages.TryGetValue("Alice", out int age))
{
    Console.WriteLine(age);
}
```

Useful:

``` csharp
ages.ContainsKey("Alice");
ages.Remove("Alice");
ages.Keys;
ages.Values;
```

## HashSet`<T>`{=html}

Unique values:

``` csharp
HashSet<int> ids = [1, 2, 3];

ids.Add(4);
ids.Contains(2);
ids.Remove(3);

a.UnionWith(b);
a.IntersectWith(b);
a.ExceptWith(b);
```

## Queue`<T>`{=html}

FIFO:

``` csharp
var queue = new Queue<string>();
queue.Enqueue("A");
queue.Enqueue("B");

string next = queue.Dequeue();
string peek = queue.Peek();
```

## Stack`<T>`{=html}

LIFO:

``` csharp
var stack = new Stack<string>();
stack.Push("A");
stack.Push("B");

string top = stack.Pop();
string peek = stack.Peek();
```

## Common collection contracts

``` text
IEnumerable<T>          enumerate
IReadOnlyCollection<T> enumerate + Count
IReadOnlyList<T>       enumerate + Count + index
ICollection<T>         mutable collection
IList<T>               mutable indexed collection
```

Prefer the least-powerful interface your method actually needs.

------------------------------------------------------------------------

# 6. OOP

## Class

``` csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Birthday()
    {
        Age++;
    }
}
```

Usage:

``` csharp
var person = new Person("Alice", 30);
person.Birthday();
```

## Properties

``` csharp
public string Name { get; set; }
public string Id { get; private set; }
public string Code { get; init; }
public required string Email { get; init; }
public string FullName => $"{FirstName} {LastName}";
```

Validation:

``` csharp
private int _age;

public int Age
{
    get => _age;
    set
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _age = value;
    }
}
```

## Object initializer

``` csharp
var user = new User
{
    Name = "Alice",
    Email = "alice@example.com"
};
```

## Static

``` csharp
public static class MathHelper
{
    public static int Double(int x) => x * 2;
}

int value = MathHelper.Double(5);
```

## this / base

``` csharp
this.Name = name;
base.DoSomething();
```

## Access modifiers

  Modifier               Access
  ---------------------- -------------------------------
  `public`               Everywhere
  `private`              Same type
  `protected`            Type + derived types
  `internal`             Same assembly
  `protected internal`   Same assembly OR derived type
  `private protected`    Derived type in same assembly

------------------------------------------------------------------------

# 7. Records, Structs & Enums

## Record

``` csharp
public record User(string Name, int Age);

var a = new User("Alice", 30);
var b = new User("Alice", 30);

bool equal = a == b; // true
```

Non-destructive mutation:

``` csharp
var older = a with { Age = 31 };
```

## Struct

``` csharp
public readonly struct Coordinate
{
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
```

## Record struct

``` csharp
public readonly record struct Point(int X, int Y);
```

## Enum

``` csharp
public enum Status
{
    Pending,
    Running,
    Completed,
    Failed
}
```

Explicit values:

``` csharp
public enum HttpStatus
{
    Ok = 200,
    NotFound = 404
}
```

Flags:

``` csharp
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4
}

var p = Permissions.Read | Permissions.Write;
bool canWrite = p.HasFlag(Permissions.Write);
```

------------------------------------------------------------------------

# 8. Interfaces, Inheritance & Polymorphism

## Interface

``` csharp
public interface ILogger
{
    void Log(string message);
}
```

``` csharp
public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
```

## Inheritance

``` csharp
public class Animal
{
    public virtual void Speak() => Console.WriteLine("...");
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof");
}
```

``` csharp
Animal animal = new Dog();
animal.Speak(); // Woof
```

## Abstract class

``` csharp
public abstract class Shape
{
    public abstract double Area();

    public void PrintArea() => Console.WriteLine(Area());
}

public class Circle(double radius) : Shape
{
    public override double Area() => Math.PI * radius * radius;
}
```

## sealed

``` csharp
public sealed class FinalService
{
}
```

Rule of thumb:

-   **interface** → contract/capability
-   **abstract class** → shared base behavior/state
-   **class** → reference-type object with identity/behavior
-   **record** → data-centric object with value equality

------------------------------------------------------------------------

# 9. Nullability & Pattern Matching

## Nullable value

``` csharp
int? age = null;

int value = age ?? 0;

if (age.HasValue)
{
    Console.WriteLine(age.Value);
}
```

## Nullable reference

``` csharp
string name = "Alice";
string? nickname = null;
```

## Safe access

``` csharp
int? length = user?.Name?.Length;
string name = user?.Name ?? "Unknown";
```

## Null-forgiving

``` csharp
string value = possiblyNull!;
```

`!` only suppresses compiler warnings; it does not prevent runtime
`NullReferenceException`.

## Type pattern

``` csharp
if (obj is string text)
{
    Console.WriteLine(text.Length);
}
```

## Null patterns

``` csharp
if (user is null) { }
if (user is not null) { }
```

## Property pattern

``` csharp
if (person is { Age: >= 18 })
{
}
```

## Logical patterns

``` csharp
if (age is >= 18 and < 65)
{
}

if (status is Status.Pending or Status.Running)
{
}
```

## Pattern switch

``` csharp
string Describe(object? value) => value switch
{
    int n => $"Integer {n}",
    string s => $"String {s}",
    null => "Null",
    _ => "Other"
};
```

## List patterns

``` csharp
if (values is [1, 2, 3])
{
}

if (values is [1, .., 3])
{
}
```

------------------------------------------------------------------------

# 10. Exceptions

``` csharp
try
{
    DoWork();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
finally
{
    Cleanup();
}
```

Throw:

``` csharp
throw new InvalidOperationException("Invalid state.");
```

Validation:

``` csharp
ArgumentNullException.ThrowIfNull(user);
ArgumentException.ThrowIfNullOrWhiteSpace(name);
```

Rethrow:

``` csharp
catch (Exception)
{
    Log();
    throw;
}
```

Prefer `throw;` over `throw ex;`.

Filter:

``` csharp
catch (HttpRequestException ex)
    when (ex.StatusCode == HttpStatusCode.NotFound)
{
}
```

Useful exception types:

``` text
ArgumentException
ArgumentNullException
ArgumentOutOfRangeException
InvalidOperationException
NotSupportedException
KeyNotFoundException
IOException
TimeoutException
```

------------------------------------------------------------------------

# 11. Generics

## Generic class

``` csharp
public class Box<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }
}

var box = new Box<int>(42);
```

## Generic method

``` csharp
T First<T>(IEnumerable<T> values)
{
    return values.First();
}
```

## Constraints

``` csharp
where T : class
where T : struct
where T : notnull
where T : new()
where T : BaseClass
where T : IInterface
```

Example:

``` csharp
T Create<T>() where T : new()
{
    return new T();
}
```

Multiple:

``` csharp
void Process<T>(T item)
    where T : class, IDisposable
{
}
```

------------------------------------------------------------------------

# 12. Delegates, Lambdas & Events

## Delegate

``` csharp
public delegate int Operation(int a, int b);

Operation op = Add;
int result = op(2, 3);
```

## Action

Returns void:

``` csharp
Action<string> print = Console.WriteLine;
print("Hello");
```

## Func

Last generic type is return type:

``` csharp
Func<int, int, int> add = (a, b) => a + b;
```

## Predicate

``` csharp
Predicate<int> isEven = x => x % 2 == 0;
```

## Lambdas

``` csharp
x => x * 2
(a, b) => a + b

x =>
{
    Console.WriteLine(x);
    return x * 2;
}
```

## Events

``` csharp
public class Downloader
{
    public event EventHandler? Completed;

    protected virtual void OnCompleted()
    {
        Completed?.Invoke(this, EventArgs.Empty);
    }
}
```

Subscribe:

``` csharp
downloader.Completed += (_, _) =>
{
    Console.WriteLine("Finished");
};
```

Unsubscribe when appropriate:

``` csharp
downloader.Completed -= Handler;
```

------------------------------------------------------------------------

# 13. LINQ

``` csharp
using System.Linq;
```

Given:

``` csharp
List<int> numbers = [1, 2, 3, 4, 5, 6];
```

## Filter / transform

``` csharp
var evens = numbers.Where(x => x % 2 == 0);
var doubled = numbers.Select(x => x * 2);
```

## Sort

``` csharp
users.OrderBy(x => x.Name);
users.OrderByDescending(x => x.Age);
users.OrderBy(x => x.LastName)
     .ThenBy(x => x.FirstName);
```

## Find

``` csharp
items.First();
items.FirstOrDefault();

items.Single();
items.SingleOrDefault();

items.Last();
items.LastOrDefault();
```

Meaning:

  Method              Behavior
  ------------------- ---------------------------------
  `First`             First item; throws if none
  `FirstOrDefault`    First or default
  `Single`            Exactly one required
  `SingleOrDefault`   Zero or one; throws if multiple

## Test

``` csharp
numbers.Any(x => x > 5);
numbers.All(x => x > 0);
numbers.Contains(3);
```

## Aggregate

``` csharp
numbers.Count();
numbers.Count(x => x % 2 == 0);
numbers.Sum();
numbers.Average();
numbers.Min();
numbers.Max();
```

## Distinct

``` csharp
items.Distinct();
users.DistinctBy(x => x.Email);
```

## Pagination

``` csharp
items.Skip(20).Take(10);
```

## Chunk

``` csharp
foreach (var chunk in items.Chunk(100))
{
}
```

## Group

``` csharp
var groups = users.GroupBy(x => x.Department);

foreach (var group in groups)
{
    Console.WriteLine(group.Key);
}
```

## Flatten

``` csharp
var orders = customers.SelectMany(x => x.Orders);
```

## Dictionary / lookup

``` csharp
var byId = users.ToDictionary(x => x.Id);
var lookup = users.ToLookup(x => x.DepartmentId);
```

## Join

``` csharp
var result = users.Join(
    departments,
    user => user.DepartmentId,
    department => department.Id,
    (user, department) => new
    {
        user.Name,
        Department = department.Name
    });
```

## Materialization

``` csharp
query.ToList();
query.ToArray();
query.ToHashSet();
query.ToDictionary(x => x.Id);
```

LINQ usually uses deferred execution:

``` csharp
var query = numbers.Where(x => x > 3); // not necessarily executed yet
var list = query.ToList();             // executed/materialized
```

## Query syntax

``` csharp
var result =
    from user in users
    where user.Age >= 18
    orderby user.Name
    select user.Name;
```

------------------------------------------------------------------------

# 14. Async, Tasks & Cancellation

## Basic async

``` csharp
public async Task<string> GetDataAsync()
{
    await Task.Delay(1000);
    return "Done";
}

string data = await GetDataAsync();
```

No result:

``` csharp
public async Task SaveAsync()
{
    await database.SaveAsync();
}
```

Avoid `async void` except event handlers.

## Concurrent independent calls

``` csharp
Task<User> userTask = GetUserAsync();
Task<List<Order>> ordersTask = GetOrdersAsync();

await Task.WhenAll(userTask, ordersTask);

User user = await userTask;
List<Order> orders = await ordersTask;
```

## WhenAny

``` csharp
Task first = await Task.WhenAny(tasks);
```

## Cancellation

``` csharp
public async Task WorkAsync(CancellationToken ct)
{
    await Task.Delay(1000, ct);
    ct.ThrowIfCancellationRequested();
}
```

Caller:

``` csharp
using var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(5));

await WorkAsync(cts.Token);
```

## Async streams

``` csharp
async IAsyncEnumerable<int> GetValuesAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}

await foreach (int value in GetValuesAsync())
{
    Console.WriteLine(value);
}
```

## Task.Run

Use mainly for deliberately moving CPU-bound work to the thread pool:

``` csharp
int result = await Task.Run(() => ExpensiveCalculation());
```

Do not wrap normal asynchronous I/O in `Task.Run`.

## Parallel.ForEachAsync

``` csharp
await Parallel.ForEachAsync(items, async (item, ct) =>
{
    await ProcessAsync(item, ct);
});
```

Beware of shared mutable state and race conditions.

------------------------------------------------------------------------

# 15. Files, JSON, Dates & HTTP

## Files

``` csharp
string text = File.ReadAllText(path);
string asyncText = await File.ReadAllTextAsync(path);

File.WriteAllText(path, "Hello");
await File.WriteAllTextAsync(path, "Hello");

File.AppendAllText(path, "More");
File.Exists(path);
```

Lines:

``` csharp
string[] lines = File.ReadAllLines(path);
File.WriteAllLines(path, lines);
```

Directories:

``` csharp
Directory.Exists(path);
Directory.CreateDirectory(path);
Directory.GetFiles(path);
Directory.GetDirectories(path);
Directory.Delete(path);
```

Paths:

``` csharp
string path = Path.Combine("data", "users", "user.json");

Path.GetFileName(path);
Path.GetExtension(path);
Path.GetDirectoryName(path);
Path.ChangeExtension(path, ".txt");
```

## JSON

``` csharp
using System.Text.Json;
```

Serialize:

``` csharp
string json = JsonSerializer.Serialize(user);

string pretty = JsonSerializer.Serialize(
    user,
    new JsonSerializerOptions { WriteIndented = true });
```

Deserialize:

``` csharp
User? user = JsonSerializer.Deserialize<User>(json);
```

Options:

``` csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
};
```

Attributes:

``` csharp
[JsonIgnore]
public string InternalValue { get; set; }

[JsonPropertyName("user_name")]
public string Name { get; set; }
```

## Date / time

``` csharp
DateTime local = DateTime.Now;
DateTime utc = DateTime.UtcNow;
DateTimeOffset instant = DateTimeOffset.UtcNow;

DateOnly date = new(2026, 9, 27);
TimeOnly time = new(19, 30);

TimeSpan duration = TimeSpan.FromMinutes(90);
```

Arithmetic:

``` csharp
dateTime.AddDays(7);
dateTime.AddMonths(1);

TimeSpan elapsed = end - start;
```

Formatting:

``` csharp
dateTime.ToString("yyyy-MM-dd");
dateTime.ToString("dd.MM.yyyy");
dateTime.ToString("HH:mm:ss");
```

Parsing:

``` csharp
DateTime.TryParse(input, out DateTime result);
```

## HTTP

Simple:

``` csharp
using var client = new HttpClient();

string body = await client.GetStringAsync(url);
```

GET:

``` csharp
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string body = await response.Content.ReadAsStringAsync();
```

POST JSON:

``` csharp
HttpResponseMessage response =
    await client.PostAsJsonAsync(url, request);
```

In DI-based applications, prefer `IHttpClientFactory` for managed
clients.

------------------------------------------------------------------------

# 16. Resource Management

## using

``` csharp
using var stream = File.OpenRead(path);
```

Block form:

``` csharp
using (var stream = File.OpenRead(path))
{
    // use stream
}
```

## IDisposable

``` csharp
public class ResourceHolder : IDisposable
{
    private bool _disposed;

    public void Dispose()
    {
        if (_disposed)
            return;

        // Dispose owned resources.

        _disposed = true;
    }
}
```

## Async disposal

``` csharp
await using var resource = CreateAsyncResource();
```

Interface:

``` csharp
IAsyncDisposable
```

------------------------------------------------------------------------

# 17. Modern C

## Target-typed new

``` csharp
List<string> names = new();
```

## Collection expressions

``` csharp
int[] numbers = [1, 2, 3];
List<string> names = ["Alice", "Bob"];

int[] first = [1, 2];
int[] second = [3, 4];
int[] all = [.. first, .. second];
```

## Primary constructors

``` csharp
public class UserService(IUserRepository repository)
{
    public User? Get(int id) => repository.Get(id);
}
```

## Index from end

``` csharp
var last = values[^1];
var secondLast = values[^2];
```

## Ranges

``` csharp
var middle = values[1..4];
var fromTwo = values[2..];
var firstThree = values[..3];
```

## Tuples

``` csharp
(string Name, int Age) user = ("Alice", 30);

var (name, age) = user;
var (_, onlyAge) = user;
```

Return tuple:

``` csharp
(string Name, int Age) GetUser()
{
    return ("Alice", 30);
}
```

## yield

``` csharp
IEnumerable<int> CountTo(int max)
{
    for (int i = 1; i <= max; i++)
        yield return i;
}
```

## Anonymous types

``` csharp
var result = new
{
    Name = "Alice",
    Age = 30
};
```

## nameof / typeof / GetType

``` csharp
nameof(User);
typeof(User);
user.GetType();
```

## Extension method

``` csharp
public static class StringExtensions
{
    public static bool IsLong(this string value)
        => value.Length > 10;
}

bool result = "Hello world!".IsLong();
```

## Span`<T>`{=html}

``` csharp
Span<int> span = numbers.AsSpan();
Span<int> slice = span[1..4];
```

Useful in performance-sensitive code to work with memory without
unnecessary allocations.

------------------------------------------------------------------------

# 18. Dependency Injection

Constructor injection:

``` csharp
public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
}
```

Registrations:

``` csharp
services.AddTransient<IEmailSender, EmailSender>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddSingleton<ICache, Cache>();
```

  Lifetime    Meaning
  ----------- --------------------------------
  Transient   New instance per resolution
  Scoped      One instance per scope/request
  Singleton   One instance for app lifetime

Do not directly inject shorter-lived scoped services into a singleton.

------------------------------------------------------------------------

# 19. Testing

xUnit examples:

``` csharp
[Fact]
public void Add_ReturnsSum()
{
    int result = Calculator.Add(2, 3);

    Assert.Equal(5, result);
}
```

Parameterized:

``` csharp
[Theory]
[InlineData(1, 2, 3)]
[InlineData(5, 5, 10)]
public void Add_ReturnsExpected(int a, int b, int expected)
{
    Assert.Equal(expected, Calculator.Add(a, b));
}
```

Exceptions:

``` csharp
Assert.Throws<ArgumentException>(() => service.Run());

await Assert.ThrowsAsync<InvalidOperationException>(
    () => service.RunAsync());
```

Typical structure:

``` text
Arrange
Act
Assert
```

Mocking concept (Moq-style):

``` csharp
var repository = new Mock<IUserRepository>();

repository
    .Setup(x => x.Get(1))
    .Returns(new User());

var service = new UserService(repository.Object);

repository.Verify(x => x.Get(1), Times.Once);
```

------------------------------------------------------------------------

# 20. Common Pitfalls

## Integer division

``` csharp
5 / 2;   // 2
5 / 2.0; // 2.5
```

## Modifying collection during foreach

Avoid:

``` csharp
foreach (var item in items)
{
    items.Remove(item);
}
```

Prefer:

``` csharp
items.RemoveAll(x => ShouldRemove(x));
```

## Blocking async

Avoid:

``` csharp
GetDataAsync().Result;
GetDataAsync().Wait();
```

Prefer:

``` csharp
await GetDataAsync();
```

## async void

Avoid except event handlers:

``` csharp
async Task DoWorkAsync()
```

## Single vs First

`Single()` throws when more than one match exists. Use it only when
uniqueness is a business invariant.

## FirstOrDefault may return null

``` csharp
User? user = users.FirstOrDefault(x => x.Id == id);
```

Handle the null.

## Deferred LINQ execution

``` csharp
var query = users.Where(x => x.Active);
```

The source may not be read until enumeration. Use `.ToList()` when you
intentionally need a snapshot.

## Multiple enumeration

``` csharp
if (query.Any())
{
    foreach (var item in query)
    {
    }
}
```

may execute the query twice.

## Floating-point equality

Avoid assuming exact binary floating-point equality for calculations:

``` csharp
Math.Abs(actual - expected) < 0.000001;
```

## Money

Prefer `decimal` over `double` for ordinary financial calculations:

``` csharp
decimal price = 19.99m;
```

## Null-forgiving operator

``` csharp
user!.Name
```

does not magically make `user` non-null.

## Swallowing exceptions

Avoid:

``` csharp
catch (Exception)
{
}
```

## throw ex

Avoid:

``` csharp
catch (Exception ex)
{
    throw ex;
}
```

Prefer:

``` csharp
catch
{
    throw;
}
```

## Repeated string concatenation

For heavy loops, use `StringBuilder`.

## Public fields

Usually prefer properties:

``` csharp
public string Name { get; set; }
```

## Concrete collection return types

If callers should not mutate:

``` csharp
public IReadOnlyList<User> GetUsers()
```

instead of exposing a mutable `List<User>` unnecessarily.

------------------------------------------------------------------------

# 21. .NET CLI

Create projects:

``` bash
dotnet new console -n MyApp
dotnet new classlib -n MyLibrary
dotnet new xunit -n MyApp.Tests
dotnet new webapi -n MyApi
```

Common commands:

``` bash
dotnet restore
dotnet build
dotnet run
dotnet test
dotnet clean
dotnet publish -c Release
```

Packages:

``` bash
dotnet add package Package.Name
dotnet remove package Package.Name
dotnet list package
```

References:

``` bash
dotnet add reference ../MyLibrary/MyLibrary.csproj
```

Solution:

``` bash
dotnet new sln -n MySolution
dotnet sln add MyApp/MyApp.csproj
dotnet sln list
```

------------------------------------------------------------------------

# 22. Fast Lookup Tables

## Which collection?

  Need                       Type
  -------------------------- ---------------------------
  Ordered mutable items      `List<T>`
  Fixed-size indexed items   `T[]`
  Key → value lookup         `Dictionary<TKey,TValue>`
  Unique values              `HashSet<T>`
  FIFO                       `Queue<T>`
  LIFO                       `Stack<T>`
  Enumeration only           `IEnumerable<T>`
  Read-only indexed result   `IReadOnlyList<T>`

## Which type construct?

  Need                         Use
  ---------------------------- ----------------------------
  Behavior + identity          `class`
  Data + value equality        `record`
  Small value type             `struct` / `record struct`
  Contract                     `interface`
  Shared base implementation   `abstract class`
  Fixed named choices          `enum`

## Common LINQ

  Goal               Method
  ------------------ --------------------------
  Filter             `Where`
  Transform          `Select`
  Flatten            `SelectMany`
  Sort               `OrderBy`, `ThenBy`
  Exists?            `Any`
  All match?         `All`
  First              `FirstOrDefault`
  Exactly one        `SingleOrDefault`
  Unique             `Distinct`, `DistinctBy`
  Group              `GroupBy`
  Count              `Count`
  Page               `Skip` + `Take`
  Materialize        `ToList`, `ToArray`
  Keyed collection   `ToDictionary`

## Naming conventions

``` text
PascalCase    classes, records, methods, properties, public members
camelCase     parameters and locals
_camelCase    private fields
IName         interfaces
T / TKey      generic type parameters
```

Example:

``` csharp
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetUser(int userId)
    {
        return _userRepository.Get(userId);
    }
}
```

------------------------------------------------------------------------

# Combined Example

``` csharp
public record Player(Guid Id, string Name, int Score);

public interface IPlayerRepository
{
    Task<IReadOnlyList<Player>> GetPlayersAsync(
        CancellationToken cancellationToken);
}

public class LeaderboardService(IPlayerRepository repository)
{
    public async Task<IReadOnlyList<Player>> GetTopPlayersAsync(
        int count,
        CancellationToken cancellationToken = default)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        IReadOnlyList<Player> players =
            await repository.GetPlayersAsync(cancellationToken);

        return players
            .OrderByDescending(player => player.Score)
            .Take(count)
            .ToList();
    }
}
```

This combines records, interfaces, DI, primary constructors,
async/await, cancellation, validation, LINQ, generics through collection
types, and read-only contracts.

------------------------------------------------------------------------

# What To Know By Heart

For normal professional C# work, make these automatic:

``` text
variables and types
if / switch
for / foreach
methods
classes / properties / constructors
interfaces
List<T> / Dictionary<TKey,TValue> / HashSet<T>
null handling
exceptions
generics
lambdas
LINQ
async / await / Task
CancellationToken
IDisposable / using
dependency injection
unit-test fundamentals
```

Everything else can happily remain something you look up. That is what
cheat sheets are for.
