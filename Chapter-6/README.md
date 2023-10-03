## Streams , Threads and asynchronous data

We need a way to process data in a way that is resilient and non blocking to our application

Microsoft provides a well desogned way to read and write forom data streams , the Stream class
the objective of the stream class is to provide access to an ordered sequence of bytes
Because the data stream is an ordered array of arbitrary bytes, reading from and writing
to it are unidirectional operations.

Note that a Stream is an active connection to a data source. That means it needs to be opened before it can be used,
and it should be closed, and then disposed of before you're done with it. Failing to do so can result in memory leaks,
thread starvation, and other performance or reliability issues with your code.


 a using statement is different from the using directives at the top of your file that allows you to reference classes
 and data structures outside of your current namespace. In the context of a method, in C#, the using statement is used
 to instantiate a disposable class (which is to say, any class that implements the IDisposable interface), and define the
 scope within which the instance should be kept alive. The syntax for using this is as follows:

   using (variable assignment to disposable instance) {
       scope in which the disposable instance is alive.
}


With the using declaration, the scope is defined by the code block in which the disposable instance
was declared.


Once the flow of program control exits the scope to which your instance is bound, the .NET runtime will take all the necessary
steps to call the Dispose() method, which is responsible for ensuring that the state of the object is valid for disposal. In doing
so, the using statement implicitly assumes the responsibility of cleaning up any unmanaged resources and any connection pools set
up for the object it created.


Every time we open a stream connected to a data source, we're getting the complete ordered list of bytes stored at that source,
along with a pointer to the start of that array. Every operation we execute on the stream moves our pointer in one direction.
If we write 10 bytes, we find ourselves 10 positions further down the array than when we started. The same happens if we read
10 bytes. So, each of our primary operators can only ever move in one direction from whatever point along the stream we happen
to be at when we start executing them. How, then, do we set those operations up to read or write what we want, where we want?
The answer is, with the Seek() method.

The Seek method gives us arbitrary access to any index in our byte array through the specification of a few simple parameters.
Simply specify where you want to start relative to a designated starting position, and then designate the starting position with
one of the three values of the SeekOrigin enum.

On the modern web, the common language for communication is, irrefutably, Javascript Object Notation (JSON). This simple specification
for composing and parsing hierarchical data translates so elegantly to almost every data structure you could possibly devise in almost
any language that, at this point, it is the transport format of choice for almost every API or web service being written today.

Newtonsoft.Json - simplicity as you work with more network transactions, very reliable , it remains the library of choice for JSON parsing
With it we can cleanly and reliably serialize and deserialize your data into a well-understood and widely-used format for network messaging.


## StreamReader and StreamWriter classes
We can easily and efficiently write and read from streams directly with streams

## Note
When working with strings from remote resources, knowing the specific encoding with which to translate the incoming bytes is key. If a
character is encoded as UTF32, and decoded using ASCII, the result wouldn't match the input, rendering your output string a garbled mess.
If you ever find a message that you've parsed to be indecipherable, make sure you're using the right encoding.

## Seek versus Peek
Difference in changing you current index with a StreamWriter or a StreamReader instance
With the Stream class we can eaily use the Seek operation to move through our byte array
by a given number of postions from the starting point

But with the StreamWriter and StreamReader utility clases , we do not have that option
The wrapper classes can only move forward with their base operations using the current index
on the stream , if you want to change that index, you can access the underlying stream directly

it's exposed by the wrapper classes through the BaseStream property. So, if you want to change your
position in the stream without performing the operations of the wrapper, you'd use the BaseStream's
Seek operation

But theres an issue, modifying that is underlying the Wrapper class will directly
change the positon to which the wrapper class can write , so the first 10 characters of our output
are null as it has its index shifter by 10 characters

It's not uncommon to forward search through a string until arriving at a terminating character or flag value.
Doing so with the StreamReader.Read() operation will result in moving the index past the terminating character
and popping the terminating character off the array. If you want to simply read the last character before the
terminating character, though, you have the Peek() operation. Peek() will return the next character in the array
without advancing the current index of the StreamReader. This is good when you don't know the length of the string

## Network Stream class
Underlying data source is an instance of the Socket class connected to an external
resource

## multithreading data processing
We have only done with the synchrnous Read() and Write() methods , imagine if we had to
get 2 million records from a database , if the process that had to perform these operations
was also responsible for user beahviour through a graphical interface , the long running
data processing task would render the GUI completely useless , .NET Core provides programmers with the concept of threads.
With threads, certain operations can be relegated to background tasks that are executed as soon as is feasible for the host
process to do so, but won't block the operations of the main thread of your application. So, with this simple, powerful concept,
we can assign our potentially long-running, or processor-intensive operations to a background thread, and mitigates the impact
of that operation on the performance of the rest of our application. This performance improvement is the single biggest benefit of
working with threads.

Because of the volatile nature of network connections and the unreliable availability of remote resources, any attempt to access
data or services from a remote resource should be handled on a background thread. Fortunately, assigning those tasks to a background
thread for parallel processing is actually fairly simple to do. All we have to do is start leveraging those asynchronous methods

## Asynchronous programming for asynchrnous data sources
Performing computational tasks out of order or out of sync , allwoing us to defer blocking the execution of their program to wait for a long running
task until we absolutely have to

## await keyword
By calling the await keyword, we're telling our program that we cannot meaningfully proceed until the awaited operation is complete.
So, if the task isn't done yet, the program should now block further execution until it is. This is what I meant by defer blocking the execution of
their program. We were able to proceed with executing other, unrelated code while this task was finishing up. It's only when there is no more work
that can be done without the result of the asynchronous task that you must block, and await the result. That's what we're doing here with the await call.

## Never use .Result to access the result of an asynchrnous task
You might notice that there is a Result property on the task instance returned whenever you call an asynchronous method. While it may seem tempting to simply use
GetResponseAsync().Result to avoid having to await your asynchronous operations, as well as avoid having to apply asynchronous patterns all the way up the stack, this is a terrible practice.
It not only blocks your code by forcing synchronous execution, but it also prevents anyone who is calling your methods from being able to defer execution either. Unfortunately,
this is one of the most common mistakes that new developers make when they first start working with asynchronous programming. However, you should almost never mix async and blocking code
together. As a very simple rule, if any of your code requires async processing, all of it does.