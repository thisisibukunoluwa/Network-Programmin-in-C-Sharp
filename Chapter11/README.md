
## The transport Layer
The protocols of the application layer are concerned with the communication between business objects.
They should only deal with the high-level representations of your application's domain entities, and
how those entities move through your system.

Meanwhile, with transport layer protocols, the concern is around atomic network packets, which are
used to transmit context-agnostic data packets as well as to establish and negotiate connections.

## The objectives of the transport layer

-  Establishing a connection
-  Ensuring Reliability
-  Error Connection
-  Managing Traffic
-  Segmentation of Data


## Classes of the Transport Layer
standards organizations have defined a classification system for connection mode protocols based on
the features they implement. According to this classification scheme, there are five different classes
of connection mode (or transport layer) protocols, with each implementing different combinations of
the list of services that a transport protocol might implement.

### class 0 - Simple Class
simlest type of transport connection , with sufficient data segmentation , t is explicitly described
in the standard as being suitable only for network connections with acceptable residual error rate
and an acceptable rate of signaled errors. Basically, given the simplicity of the protocol, it is only
suitable for use on highly reliable local networks with nearly guaranteed error-free connections between hosts.

### class 1 - Basic Recovery Class
Protocols that fall under class 1 are specified to provide basic transport connection with minimal
overhead. However, what distinguishes class 1 from class 0 is that class 1 protocols are expected to
recover from signaled errors, or errors that are immediately detectable, such as a network disconnection
or a network reset . protocols of this class are sufficient for use on network with an acceptable error rate
but an unnnacceptable rate of signaled errors

### class 2 - Multiplexing class
The defining characteristic of class 2 protocols is their ability to multiplex several transport connections on
to a single network connection. It's designed to work on the same exceptionally reliable networks as class 0
protocols.

### class 3 - Error Recovery and the multiplexing class
The multiplexing class is, essentially, a combination of classes 1 and 2. Protocols in class 3 introduce the
performance benefits (or packet overhead) of the class 2 multiplexing functionality into a protocol with
sufficient error recovery for a network with less-reliable signaled error rates, where class 1 would otherwise
be preferred.

### class 4 -Detecting errors and the Recovery class
Class 4 protocols are by far the most robust of any protocol. They are explicitly stated to be suitable for
networks with an unacceptable residual error rate and an unacceptable signal error rate, which is to say,
basically, any large-scale distributed network with a high probability of interference of interruption of service
The errors for which a class 4 protocol should provide recovery include, but are not limited to
Data packet loss, data packet duplciation , data packet corruption , Delivery of a data packet out of sequence in a
data stream
Protocols in class 4 are expected to have the highest resiliency against network failure as well as increased
throughput by way of improved multiplexing and packet segmentation.


## Connection-based and connection-less communication
There are primary transport layer protocols e work with
The first is the TCP. Commonly called TCP/IP due to its prevalent use on the internet-based network software and
tight coupling with the Internet Protocol (IP), TCP is the transport layer protocol underlying all of the application
layer protocols we've looked at so far. The second protocol we'll be looking at is the UDP. It stands as an alternative
approach to TCP with respect to transport layer implementations, aiming to provide better performance in more tightly
constrained use cases.
The primary difference between them is that , TCP operates in what is known as connection-based communication mode,
whereas UDP operates in whats called a connectionless communication mode

### Connection - based communication 

connections to established sessions
For the purposes of clarity and understanding, I think we would benefit from thinking of a connection as a session.
In connection-oriented protocols, a session must first be established between the two hosts prior to any meaningful
work being done. That session must be negotiated with a handshake between the two hosts, and it should coordinate
the nature of the pending data transfer. The session allows the two hosts to determine what, if any, orchestration
must happen between the two machines over the lifetime of the request to fulfill the request reliably.
Once the session is established, the benefits of a connection-based communication mechanism can be realized. This
includes a guarantee of the ordered delivery of data, as well as the reliable re-transmission of lost data packets.
This can happen because the session context gives both machines an interaction mechanism that will allow them to
communicate when a message has been delivered and received. This shared, active context is important for our
understanding of connection-based protocols, 

### Circuit switched versus packet-switched connections
## Circuit Switched Connection
- direct hardware circuit link between hosts , the data needs to routing information
applied to the header because it travels over a close circuit between the tweo devices
- guarantees packets will arrive in constant time
- guarantees the ordering of packets
- incredibly costly to implement

## Packet switched connection

 These connections are established through the use of hardware switches and software deployed on routing devices that
 virtualize the behavior or a circuit-switched connection. With connection mode, routers and switches set up an in-memory
 circuit that manages a queue of all inbound requests for a target location. Those devices parse the addressing information
 of each incoming packet and pass it into the queue for the appropriate circuit

## TCP as a connecton-oriented protocol
When the TCP layer breaks up a request into packets and applies its headers, it does so on the assumption that the packets
will be sent over a packet-switched network.

That means it must be certain that switches and routers along the network path have provisioned a virtual circuit for each
payload between the two hosts. This certainty is provided by a multi-step handshake between the two hosts. The specific details
of the handshake are a bit more complicated, but it can be boiled down to three fundamental transactions for each step in the
process:

SYN stands for synchronization and is a request sent from the client to the server indicating a desire to
establish a connection
SYN-ACK : This stands for synchronization and acknowledgment and is the response a server sends to an initial
SYN request.

ACK: At this point, the client acknowledges that its own synchronization request was sent and received correctly, and confirms
the same for the server by sending a payload setting the sequence number to the acknowledgment value it received from the server

## Connectionless Communication

## Stateless Protocols
Without any session to manage, connectionless protocols are typically described as being stateless. Without a state to manage,
each transaction happens without any broader context telling the recipient how an individual packet fits into the wider stream of
incoming packets.

## Broadcasting oer connectionless communication
One of the benefits of this lack of shared state being managed between two hosts is the ability of connectionless communication to
multicast. In this way, a single host can transmit the same packet out to multiple recipients simultaneously, as the outbound port
isn't bound by a single active connection with a single other host.
 This multicasting, or broadcasting, is especially useful for services such as a live video stream or feed,

## UDP as a connectionless communication protocol

UDP serves as the connectionless communication protocol of choice . It  exhibits all of the expected traits of a connectionless protocol
, including the lack of any handshake or session negotiation prior to data transfer, and minimal error-checking and error correction techniques

The need for such speed and the acceptability of intermittent packet loss is perfectly suited to low-level network operations to send out
notifications or basic queries of other devices on the network. It's for that reason that UDP is the protocol of choice for Domain Name System
(DNS) lookups and the Dynamic Host Configuration Protocol (DHCP). In both of these contexts, the requesting host needs an immediate response to a
single, simple query.


## Detecting errors in connectionless protocols
connection less TLPs are far more susceptible to errors, but at least within UDP, there is at least one simple , error
detection mechanism called a check sum
a checksum is similar to a hash function where each input will provide a drastically different output. In UDP packets, the checksum input is essentially
the entirety of the headers and body of the packet. Those bytes are sent through a standard algorithm for generating the checksum. Then, once the packet
is received, the recipient puts the content of the packet through the same checksum algorithm as the client, and validates that it received the same
response as was delivered. If there is even a minor discrepancy, the recipient can be certain that some data was modified in transit and an error has occurred.

## Tranmitting data over an active connection
### mutation test
 mutation test, it's a simple way of tracking that changes to your system are detected by the tests that validate your system. The idea is that you make a change
 or a mutation somewhere in your code, and confirm that somewhere downstream, usually in your unit tests, that change has an impact, typically by failing a previously
 passing unit test.