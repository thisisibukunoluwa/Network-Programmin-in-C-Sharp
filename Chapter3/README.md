

## The Open Systems Interconnection Network Stack

OSI is a specification that defines the network stack of a given network device
standardized model for network implementations 

## The basic reference model
The reference model defines network communication streams, as implemented by a
compliant device on a network, in a hierarchy of seven distinct conceptual tiers,
or layers, organized in a stack. This stack is defined as far down as the transmission
of raw bits over physical media, and all the way up to the high-level application software
that might use any resource distributed over a network.

The model defines a strict mechanism of unidirectional interaction between layers. According
to this communication standard, a given layer can only ever communicate with the layer directly
beneath it through an abstract interface exposed by that lower layer. This interface is known as
the service definition of a layer, and it defines the valid operations by which a higher layer can
interact with any lower layers.

As data moves through the layers of the stack, each lower layer wraps the packet in its own series
of headers and footers to be parsed by the recipient device. This contains information about what
layer in the stack the data originated from, as well as how to parse it. The data packet that gets
passed down, layer-to-layer, through the network stack, is known as a Protocol Data Unit (PDU).


## The Host/Media Distinction
### Host Layer
encapsulates the four higher levels of the OSI stack and describes entities or responsibilities
specific to a given host trying to communicate on a network.

### Media Layer
These layers describe the physical implementation of the network components between two hosts.
This provides the expected functionality specified or requested by entities in the Host layers.

### Application Layer
The top most layer of the network stack is also the layer that most developers will interact
with over the course of their careers. The application layer provides the highest-level interface
for interaction with network communication. This is the layer that business application software uses
to interact with the rest of the stack.

### Presentation Layer
While it may sound like a way of visually representing the data, the presentation layer is actually
a way of defining how the data is to be interpreted by any consumer that wants to look at it.

### The session layer
Entities on the session layer are responsible for establishing, maintaining, resuming, and terminating
an active communication session between two hosts on a network. The entities at work on this layer provide
communication mechanisms such as full-duplex interactions, half-duplex interactions, and simplex interactions,

#### Full Duplex, half duplex and simplex communication
When a session is established between hosts ,there are a handful of ways that communication can happen over that session.
The two most common are the full and half- duplex implementations. These simply describe a communication session that both
connected parties can communicate over.
In a full-duplex session, both parties can communicate with one another simultaneously. The typical example for this kind
of communication is a telephone call.
A half-duplex system is one where both parties can communicate over the session, but only one party can communicate at a
given time. A common example of this is a two-way radio or walkie-talkie
Finally, a simplex communication session is one where only a single party can actually transmit data. That is, there is a
sender and a receiver. A common example of this is network television; there is a single broadcast source, with multiple
receivers actually accepting the transmitted signal.

## The Transport Layer
Entities in the transport layer use protocols specifically designed for interacting with other hosts and the network
entities in between.
The transport layer, though, looks at the full block of encoded data that was passed down by the presentation layer,
and determines how to break it apart. It's responsible for cutting the data into segments of otherwise useless streams of binary.
And, importantly, it breaks those segments up in such a way that they can be reassembled on the other side of the connection.
The transport layer is also responsible for error detection and recovery, with different protocols providing different levels of reliability.

## The network layer
Entities on the network layer manage interactions over the network topology. They're responsible for address resolution and routing data to
target hosts once an address has been resolved. They also handle message delivery based on constraints or the resource availability of the
physical network.

## The data-link layer
The data-link layer falls very clearly into the Media layer's grouping, as entities in this layer provide the actual transfer of data between
nodes in a network. It's responsible for error detection from the physical layer, and controls the flow of bits over physical media between nodes.

The data link layer is broken down intow two sub lyaers by the IEEE

### The Medium Access Control Layer :
This sub-layer controls who can transmit data through the data-layer entity, and how that data can be transmitted.

### The Logical Link Control Layer :
This sub-layer encapsulates the logical protocols of network interaction. It is essentially the interface that
provides the entities links as a set of abstract protocol operations.

## The physical layer
Finally, we've arrived at the bottom of the stack, with the simplest layer to understand. The physical layer encapsulates the entities that are
responsible for transmitting raw, unstructured data from one node in the network to another. This is the layer responsible for sending electrical signals
that correspond to the strings of bits in a data packet. It encapsulates the devices responsible for modulating voltage, timing signals, and timing the frequency
of wireless transmitters and receivers


## HTTP
HTTP is a protocol implemented and leveraged by software that lives in the application layer of the OSI network stack
The transfer component of HTTP is, fundamentally, a request/response protocol that assumes a client-server relationship between hosts in an active HTTP session

### Requeest and Response
n describing the nature of the client-server relationship, we've also touched on the nature of the HTTP request/response protocol. This protocol, as a way of serving
up information, is fairly intuitive to understand. When a client makes a request of a server (the request part of request/response), the server, assuming it meets the
specifications of the protocol, is expected to respond with meaningful information about the success or failure of that request, as well as by providing the specific data
initially requested.

### HTTP Sessions
The fluid interaction between the client and the sevrver is facilitated by the underlying session satisfied established prior to satisfying the first request made by a client
 Historically, this session has been provided by a Transmission Control Protocol (TCP) connection established against a specific port on the host server. This port can be
 specified in the URI when designating your target host, but typically will use default ports for HTTP, such as 80, 8080, or 443 (for HTTPS, which we'll cover later in this book).
 Once the connection is established, round trips of HTTP communication can proceed freely until the session is terminated.
 for each of the current versions of HTTP (1.0, 1.1, and now HTTP/2), TCP has been the standard transport layer protocol supporting it. However, in the current proposed specification
 for HTTP/3, the protocol is being modified to take advantage of alternative transport protocols, including the User Datagram Protocol (UDP), or Google's experimental Quick UDP
 Internet Connections (QUIC) protocol
 Each of these protocols server to establish a connection with a listening host and facilitate the transmission of request and response messages.

## Request Sessions
When a client wants to make a request of a server, it must specify the method by which the server will be expected to respond to the given request. These method specifications
are typically called HTTP verbs,

OPTIONS: This returns the list of other HTTP methods supported by the server at the given URL.
TRACE: This is a utility method that will simply echo the original request as received by the server. It is useful for identifying any modifications made to the request by entities
on the network while the request is in transit.
CONNECT: CONNECT requests establish a transparent TCP/IP tunnel between the originating host and the remote host.
GET: This retrieves a copy of the resource specified by the URL to which the HTTP request was sent. By convention, GET requests will only ever retrieve the resource, with no
side-effects on the state of the resources on the server (however, these conventions can be broken by poor programming practices, as we'll see later in the book).
HEAD: This method requests the same response as a GET request to a given URL, but without the body of the response. What is returned is only the response headers.
POST: The POST method transmits data in the body of the request, and requests that the server store the content of the request body as a new resource hosted by the server.
PUT: The PUT method is similar to the POST method in that the client is requesting that the server store the content of the request body. However, in the case of a PUT operation,
if there is already content at the requested URL, this content is then modified and updated with the contents of the request body.
PATCH: The PATCH method will perform partial updates of the resource at the requested URL, modifying it with the contents of the request body. A PATCH request will typically fail
if there is no resource already on the server to be patched.
DELETE: The DELETE method will permanently delete the resource at the specified URL.


## Status Codes
Even when an application has constructed a valid HTTP request object, and submits that request to a valid path on an active host, it's not uncommon for the server to fail to properly
respond. For this reason, HTTP designates, as part of a response object, a status code to communicate the ability of the server to properly service the request. HTTP status codes are,
by convention, 3-digit numeric codes returned as part of every response. The first digit indicates the general nature of the response, and the second and third digits will tell you the
exact issue encountered.

There are only five valid values for the first digit of an HTTP status code, and thus, five categories of responses; they are as follows:
1XX: Informational status code. This indicates that the request was in fact received, and the processing of that request is continuing.
2XX: Success status code. This indicates that the request was successfully received and responded to.
3XX: Redirection. This indicates that the requesting host must send their request to a new location for it to be successfully processed.
4XX: Client Error. An error that is produced by the actions of the client, such as sending a malformed request or attempting to access resources from the wrong location.
5XX: Server Error. There was a fault on the server preventing it from being able to fulfill a request. The client submitted the request correctly, but the server failed to satisfy it.


## FTP and SMTP
FTP (and SFTP) leverages a client-server model similar to the one used by HTTP, but its connection specification is slightly more complicated than we saw before
FTP maintains two connections between the client and server over the course of a stateful session. One connection establishes a stateful control pipeline that tracks the current state
of the directory exposed by the FTP server and submits the commands necessary to execute the desired file transfers. The other connection is stateless, and facilitates the transfer of
the raw file data between hosts


SMTP is a connection-oriented protocol for sending mail messages to remote servers that are configured to receive them. It leverages a client-server model leveraging reliable sessions,
over which a series of commands and data-transfer processes transmit email, unilaterally, from the client to the server.

## TCP
 TCP is defined as a connection-based communication protocol that provides the reliable delivery of ordered packets. It's used to facilitate communication between hosts of all kinds from
 the internet, to SMTP clients and servers, Secure Shell (SSH) connections, FTP clients and servers, and HTTP.

 The widespread adoption of the transport layer supporting most application-layer requests
 is due to the reliability of a TCP connection
  By convention, entities that implement TCP are written to detect packet loss and the out-of-order delivery of data streams, to re-request lost data, and to reorder the out-of-order streams.
  This error correction is resolved prior to returning that data back up the stack to the application layer entities making use of the TCP connection.

## UDP
if the reliability of TCP is not strictly required for an application, then UDP begins to look like a very attractive option for its simplicity and performance. UDP is a simple, unreliable, and
connectionless communication protocol for transmitting data over a network. Where TCP provided robust error handling through its pattern of repeated requests and acknowledgments, UDP has no
handshaking or acknowledgment signals to indicate whether a packet was properly transmitted from host to host.

## Connection versus connectionless communication

## Connection
connection-based communication protocol, both hosts must first establish a line of communication before the transmission of any application- specific data can begin. The handshake sequence in TCP
is the most obvious example of this. There is a complete round-trip of sent/received messages that must succeed before the connection is considered established, and data can be transmitted between
hosts. That established line of communication is the 'connection' in this context.


### Connectionless Communication
connectionless communication, data could be transmitted, and the communication terminated, without even a single complete round-trip from the client to the server, and back to the client again.
The packet has sufficient information in its own headers to be properly routed to a listening host. Provided that host has no follow-up to the initial request, that communication will stop with
only a one-way packet delivery. The low- latency of this transmission pattern could be a major benefit in certain application contexts.
