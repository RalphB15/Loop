## Handy `Loop` Class

Represents a loop that executes a specified action with a specified interval.

### Constructor

```csharp
public Loop(Func<Task> asyncAction, int intervalMs)
```

Creates a new instance of the `Loop` class with the specified async action and interval.

- `asyncAction`: The async action to execute in the loop.
- `intervalMs`: The interval at which to execute the action, in milliseconds.

### Methods

#### `Start()`

```csharp
public void Start()
```

Starts the loop.

#### `Stop()`

```csharp
public void Stop()
```

Stops the loop.

#### `Pause()`

```csharp
public void Pause()
```

Pauses the loop.

#### `Resume()`

```csharp
public void Resume()
```

Resumes the loop.

### Examples

#### Simple example

```csharp
var myLoop = new Loop(async () =>
{
    Console.WriteLine("Looping...");
    await Task.Delay(1000);
}, 1000);

myLoop.Start();

Console.ReadKey();

myLoop.Stop();
```

This example creates an instance of the `Loop` class with an async action that writes a message to the console and waits for 1 second. The loop is started and runs indefinitely until a key is pressed. The loop is then stopped.

#### Pause and resume example

```csharp
var myLoop = new Loop(async () =>
{
    Console.WriteLine("Looping...");
    await Task.Delay(1000);
}, 1000);

myLoop.Start();

Console.ReadKey();

myLoop.Pause();

Console.ReadKey();

myLoop.Resume();

Console.ReadKey();

myLoop.Stop();
```

This example creates an instance of the `Loop` class with an async action that writes a message to the console and waits for 1 second. The loop is started and runs indefinitely until a key is pressed. The loop is then paused and resumed twice with key presses in between. The loop is finally stopped.

#### Multiple loops example

```csharp
var loop1 = new Loop(async () =>
{
    Console.WriteLine("Loop 1...");
    await Task.Delay(1000);
}, 1000);

var loop2 = new Loop(async () =>
{
    Console.WriteLine("Loop 2...");
    await Task.Delay(500);
}, 500);

loop1.Start();
loop2.Start();

Console.ReadKey();

loop1.Stop();
loop2.Stop();
```

This example creates two instances of the `Loop` class with different async actions and intervals. Both loops are started and run indefinitely until a key is pressed. The loops are then stopped.

## License

Loop.cs is released under the MIT License. See the [LICENSE](LICENSE) file for more information.