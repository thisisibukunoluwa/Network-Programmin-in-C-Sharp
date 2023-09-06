

##Networks in a nutshell

Network - physical implementation of an undirected graph, a series of nodes and edges

A computer network is, for our purposes, an arbitrarily large set of computational or
navigational devices, connected by channels of communication across which computational
resources can be reliably sent, received, forwarded, or processed.


topology of a network describes how the components of that network are arranged relative
to one another

## Physical and logical topology
Physical - how a network is physically connected and orgranized in real space,  the medium
of the connections themselves, the location of devices in physical space, and the layout of
the connections between nodes.

Logical - logical topology of a network explains the conceptual organization of relevant actors
on the network, and the connective paths over which they can, or must, communicate with any other
actors on that network

The specific organization of the logical topology of our network may well have an impact on our
software implementation, however, and there is a variety of common topologies with their own strengths
and disadvantages to consider,

## Point to Point topology
A single logical connection between two ndoes on a network,This topology is how we would define a minimum
complete network, which is to say, at least one connection between at least two nodes. It is the lowest
cost in terms of implementation, and has the lowest impact on the engineering considerations for software
meant to be deployed to such a network.
Any direct peer to peer communication is an instance of a point to point network on your system

## Linear Topology (daisy chaining)
 In a linear network topology, we extend our point-to-point model in such a way as to only ever have one node
 connected to at most two other nodes at a given time. The benefit here is obviously in the physical implementation cost
 (even with high resiliency, this configuration can only ever get so complicated). The drawback, however, should be
 similarly obvious. Communication from one node to any node other than one of its nearest neighbors will require the
 intermediary nodes to do some work investigating the target of the inbound request and determine if they are suitable to
 process the request, and if not, know to pass the request along to the neighbor that didn't originate the request.

## Bus Topology
A bus topology is one in which every single node on the network is connected to every other node on the network by way
of a single channel of communication,Each connection coming off of a node is joined to a shared connection between all
nodes by way of a simple connection interface. Any packets sent by a node on a bus topology will be transmitted on the
same bus as every other packet transmitted over the network, and each node on the bus is responsible for identifying 
whether or not it is the most suitable node to service the request carried by that packet. Similar to the linear network
previously described, packets on a bus topology must contain information about the target node for the request.
The majot drawback is that if the central line of communication goes offline ,then the nodes would be isolated


## Star topology
More common in enterprise networks , The star topology is arranged in such a way as to produce an asterisk-like star shape,
with each peripheral node connected by a single channel to a central hub-node, as demonstrated in the following diagram:this
hub serves as the broker of communication between all peripheral nodes , It receives and forwards requests from each of its
peripheral nodes by way of a direct, point-to-point connection.
This topology provides the benefit of isolating the failures of peripheral nodes or their connections to the hub to those
nodes specifically. Each of the other nodes can maintain their connections to all the other nodes in the network with any
one of them going down
Likewise, a network defined by any two peripheral nodes and the hub node of a star topology is technically a linear topology
(which is itself a specialized implementation of the bus topology)

## Ring topology
A ring topology is very similar to a linear topology (which, as I noted before, is technically an implementation of the bus topology)
except that, in the case of a ring topology, the endpoints are ultimately connected, and communication is unidirectional,
### Benefit
Which each node in the network serving as the peer of the previosu node in the chain , there is no need for any request broker ,
or communication specific software or hardware

### Drawbacks
The drawbacks are similar to each of the previous implementations in that, once a link in the chain is broken, the network is
essentially rendered useless.
Technically, because of the unidirectional communication pattern of a ring topology, the node residing
immediately after the broken link in the chain can still communicate with every other node in the network, and maintain some
degree of operation


## Mesh Topology
The mesh topology is one of the most resilient and common netwrok topologies in use today,
entirely arbitrary in how it is organized. A mesh topology simply describes any non-formal topology of connectivity in which
some nodes are connected by way of a single point-to-point connection to some other nodes, and some may have multiple connections
to multiple nodes.

## Benefits 
You'll note that the nodes in the preceding diagram have anywhere from one to three direct connections to other nodes in the network.
This can provide some of the resilience of other network topologies where necessary, without incurring their costs. Since there is no
obvious specification for a mesh network other than that it does not fully implement any of the other network topologies we discussed,
it can include networks with an arbitrary degree of connectivity between nodes up to, and including, a fully-connected mesh network.

## Fully conected mesh network
it is one in which every node has a direct connection ot every other node in the network
If this diagram looks a bit crowded to you, you've already noticed the single biggest drawback of a fully-connected mesh network. It's nearly
impossible to scale beyond a certain point, because each new node on the network requires a connection for each previously connected node on
the network. The math works out to a quadratic increase in connections for each new node to be added. Moving past a few nodes on the network
becomes physically impossible very quickly.

##Benefts
The incredibly high cost of a fully connected mesh network, however, brings with it the most stable and resilient topology possible. No node has
to be responsible for packet- forwarding or request switching, because there should be no context in which two nodes are communicating with each
other indirectly. Any one node or connection between nodes can go down, and every other node on the network has full connectivity with no loss of performance

## Hybrid topologies
A star topology inwhich of the peripheral nodes is also a link in a linear topology is an example of a hybrid network

Security
Communication Overhead
Resilience
Asynchrony

Network objects and data structures in .NET Core

