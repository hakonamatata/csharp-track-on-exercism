// See https://aka.ms/new-console-template for more information

// Console.WriteLine(helloWorldString);

// https://blog.okyrylchuk.dev/20-new-apis-in-net-6

using Microsoft.Win32.SafeHandles;
using System.Text;

var helloWorldString = "Hello, World! From txt file!";
var path = "file.txt";

if (!File.Exists(path))
{
    File.Create(path);
}

using SafeFileHandle handle = File.OpenHandle(path, access: FileAccess.ReadWrite);

// Write to file
byte[] strBytes = Encoding.UTF8.GetBytes(helloWorldString);
ReadOnlyMemory<byte> buffer1 = new(strBytes);
await RandomAccess.WriteAsync(handle, buffer1, 0);

// Get file length
long length = RandomAccess.GetLength(handle);

// Read from file
Memory<byte> buffer2 = new(new byte[length]);
await RandomAccess.ReadAsync(handle, buffer2, 0);
string content = Encoding.UTF8.GetString(buffer2.ToArray());
Console.WriteLine(content); // Hello world


PriorityQueue<string, int> priorityQueue = new();

priorityQueue.Enqueue("Second", 2);
priorityQueue.Enqueue("Fourth", 4);
priorityQueue.Enqueue("Third 1", 3);
priorityQueue.Enqueue("Third 2", 3);
priorityQueue.Enqueue("First", 1);

while (priorityQueue.Count > 0)
{
    string item = priorityQueue.Dequeue();
    Console.WriteLine(item);
}

