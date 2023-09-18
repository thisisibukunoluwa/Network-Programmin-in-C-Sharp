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
in 

