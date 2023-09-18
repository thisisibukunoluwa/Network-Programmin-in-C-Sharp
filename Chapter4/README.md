
## Packets and Streams

The encapsulation of data in packets ensure that packet are delivered
to the correct destination and are decoded properly.

data stream as a serialized sequence of discrete packets,


## Constraints of a network that necessitates packets

understand the limitations of bandwidth, latency, signal strength

Each of these constraints plays a key role in determining the maximum size
of an atomic unit of data that can be transmitted over a given network.
These limitations demand that pieces of data transmitted over the network
include a number of attributes to ensure any measure of reliability.


## Bandwidth
I tis the maximum rate of adata transmission over a given network connection

### Two things to consider

#### using a car on a highway as an analogy 
The speed of throughput
Analogous to the speedlimit of the highway, It's the physical maximum velocity
that a signal can travel over a connection, boils donw to the physical transmission
medium 

#### The channels maximum capacity
this refers to how many physical wires can actively carry an individual bit at any
given moment along a channel. In our highway analogy, the channel capacity will
describe the number of lanes on our highway that a car could travel.


## Latency
Latency is the time between the initial moment a signal is sent, and the first
moment a response to that signal can be initiated. Its the delay of a network
You can measure it as one way , or round trip

### One way latency
Describes the delay from the moment a signal is sent from one device to the time
it is received by the target device

### Round trip latency
This is the delay between the moment a signal is sent from a device and the moment
a response from the target is received by that same device
Note that round trip latency excludes the amount of time the recipient spends processing
the initial signal before sending a response 

### Ping
It's not uncommon for a software platform to provide a service that simply echoes the
request it was sent without any processing applied in response. This is typically called a
ping service, and is used to provide a useful measurement of the current round-trip latency
for network requests between two devices. For this reason, latency is commonly called ping.

### Mechanical Latency
The different ocntributng factos to latency sometimes categorized slightly differently
Mechanical latency, for instance, describes the delay introduced into a network by the time it
takes for the physical components to actually generate or receive a signal. So, for instance,
if your 64-bit computer has a clock speed of 4.0 GHz, this sets a physical, mechanical limit
on the total amount of information that can be processed in a given second.

### Operating Sysstem Latency
an operating system (OS) will be handling requests from the application and system software to
send over that hypothetical packet, and it will be doing so while simultaneously processing thousands
of other requests from hundreds of other pieces of software running on the host machine. Almost all
modern OSes have a system for interlacing operations from multiple requests so that no one process is
unreasonably delayed by the execution of another. So really, we will never expect to achieve latency
as low as the minimum mechanical latency defined by our clock speed. Instead, what might realistically h
appen is that the first byte of our packet will be queued up for transport, and then the OS will switch
to servicing another operation on its procedure queue, some time will be spent executing that operation,
and then it might come back and ready the second byte of our packet for transport. So, if your software
is trying to send a packet on an OS that is trying to execute a piece of long-running or blocking software,
you may experience substantial latency that is entirely out of your control. The latency introduced by how
your software's requests are prioritized and processed by the OS is, hopefully very obviously, called OS latency.

## Operational Latency 
overall window of time necessary to process a given network request, including the processing time on the remote host.
This measurement is the most meaningful when considering the impact of network operations on your user's experience,
and is what's called operational latency.

## Signal Strength
The strength of a signal can be impacted by anything form the distance between wireless transmitters and
receivers , to just plain distance between two gateways connected by a wire


## WHy are packet sizes small
However, as your software is deployed to wider and wider networks, the extent to which you can rely on a modern and well-designed
network infrastructure diminishes significantly. Data loss is inevitable, and that can introduce a number of problems for those
responsible for ensuring the reliable delivery of your requests.
So, how does this intermittent data loss impact the design of network transmission formats? It enforces a few necessary attributes
of our packets that we'll explore in greater depth later, but we'll mention them here quickly. Firstly, it demands the transmission
of the smallest packets that can reasonably be composed. This is for the simple reason that, if there is an issue of data corruption,
it invalidates the whole payload of a packet. In a sequence of zeroes and ones, uncertainty about the value of a single bit can make
a world of difference in the actual meaning of the payload. Since the payloads are only segments of the overall request or response
object, we can't rely on having sufficient context within a given packet itself to make the correct assertion about the value of an
indeterminate bit. So, if one bit goes bad and is deemed indeterminable, the entire payload is invalidated, and must be thrown out.
By reducing the packet size to the smallest reasonable size achievable, we minimize the impact of invalid bits on the whole of our
request payload
packets also will need to have some sort of error detection baked into the standard headers

## The anatomy of a packet
Features a network apcket must exhibit to be useful as a piee of information

## What is a packet
packet refers specifically to the most atomic piece of data transmitted by the network layer of the Open Systems Interconnection (OSI)
network stack. In the transport layer, where we'll be most concerned with it (since that is the lowest layer in the stack we'll directly
interact with through C#), the atomic unit of data transmission is actually called a datagram. However, it is much more common
to refer to data units of the transmission layer as packets than datagrams

A packet is an atomic unit of data, encapsulated with sufficient context for reliable transmission over an arbitrary network implementation.
So basically, it's a payload (unit of data) with a header (sufficient context).


we can use wireshark sniffing functionality to examine the packets that comes through our ethernet connection


## Atomic Data
- The smallest components into which a record can be broken down without losing their meaning
when we talk about atomic data in the context of network transactions, we're really talking about the minimum size that we can truncate our
data into, beyond which we will stop seeing the desired benefits of shrinking our data into smaller and smaller chunks.



 The context is the information necessary to either forward or process a packet correctly.
 Sufifcient context depends on the protocol under which the packet was constructed


## TCP vs UDP sufficient context
The two most commonly used transport layer protocols are TCP and User Datagram Protocol (UDP),
and each of them have different service
contracts for the application software that leverages them.
Both of them have very distinct header specifications.

The sufficient context for UDP is actually substantially less than for that of a TCP packet.

### TCP
TCP seeks to provide sequential, reliable, error-checked transmission service for packets traveling between hosts.




### UDP 
UDP, as a connection-less protocol doesn't explicitly aim to provide the reliability of transmission
or a guarantee of the ordering of data, it seeks to provide light weight communication with a minimal protocol definition to enforce.
A UDP packet header consists of a 8 bytes of data broken up into four individual fields that are 2 bytes in length each

Source port: The specific port of the socket connection on the source machine generating the request.

Destination port: The port of the connection on the destination machine.

Length: The exact length of the packet, including the payload that immediately
follows the 8-byte header.

Checksum: A simple value used to verify the data integrity of the payload.


## Note
while the UDP header itself is 8 bytes, the total length of a captured packet can be larger due to additional headers
(such as IP and Ethernet) and application-specific data payloads.


the transport layer will recompose our packets into a sequence of bits fo rus to consume it as it
becomes available to us, we can consume it as an IOStream

In .NET Core, we can import the System.IO namespace to our application to start working directly with the data returned by a
TCP/IP socket by simply opening up a new StreamReader object, initialized with a NetworkStream instance connected to the target socket.

Streams are powerful in processing serialized data , They provide one-way access to a sequential data source and allow you to handle the
processing of that data explicitly.



The shape of the abstraction is made clear by the properties of the interface. This gives users a concrete idea of the proper context in
which instances of the interface should be used.
Abstract classes do, in fact, define an interface for working with their implementations. The relevant distinction between the two is that,
with an abstract class, any given method provided as part of the interface will typically have a default implementation defined within the
abstract base class itself. So, the methods provided by an abstract class still define the interface through which you, as a consumer of
the concrete classes, will interact with the implementations of the class. It's really just a distinction of where the obligation falls to
define the expected behavior for that interface. Since you can't instantiate an abstract class any more than you can instantiate an interface definition,
the difference is entirely trivial. 

## WebRequest 
The WebRequest abstract class of the System.Net namespace is the public interface for creating and working with general-purpose
network requests that are meant to be sent over the internet.
 WebRequest class is primarily a tool for creating lower- level, protocol agnostic request/response transactions with other resources
 on your network

### Constructors in the class
WebRequest defines only two base constructors for its sub-classes. The first is the default parameter-less constructor. The second allows developers to specify an instance of
the SerializationInfo and StreamingContext classes to more narrowly define the scope of valid use cases for the newly-created instance of the class. So, our constructor signatures will look like the following code block:
   public WebRequest() {
       ...
}
   public WebRequest(SerializationInfo si, StreamingContext sc) {
       ...
}



