// See https://aka.ms/new-console-template for more information

// Console.WriteLine(helloWorldString);

// https://blog.okyrylchuk.dev/20-new-apis-in-net-6

var helloWorldString = "Hello, World!";

using SafeFileHandle handle = File.OpenHandle("file.txt", access: FileAccess.ReadWrite);

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
