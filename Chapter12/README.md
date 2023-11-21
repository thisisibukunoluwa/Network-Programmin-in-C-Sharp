


## The origins of IP

originally implemented as a packet transmission mechanism in the earliest version of the TCP

IPV0
The first of these experiments, IEN 2, was written in August 1977. It explicitly states that
engineers had been screwing up in their design of IPs by violating the principle of layering.
In its initial draft, TCP was responsible for the abstraction of both the host-to-host
transmission of application layer packets, and for negotiating the hops between network
devices along the route between the two connected hosts. By over-engineering TCP in this way,
engineers created a single protocol that spanned both the transport and network layers of the
OSI network stack. This violation of boundaries between OSI layers was almost immediately
recognized as a bad design, and a bad practice. So, with IEN 2, the authors proposed a new
and distinct internetwork protocol, and that TCP be used strictly as a host level end-to-end
protocol. And with this experiment, IP was born.



The second protocol described was the internet Hop interface It's this part of the IEN that
described what would eventually become IP. The hops in this context are hops along a single
edge in the network diagram between two nodes, or hosts. The goal of this section of the IEN
was to define the minimum amount of information necessary to bundle with a packet to allow
any step on the path to route it accordingly, without routing multiple instances of the same
packet to the destination, and to allow fragmentation in such a way that the packet can be
reassembled at the destination gateway.


ipv1 to ipv3 formalizing a header format
Several more IENs were written to describe and evolving IP interface .
Each of these in their own way formalized some detail of IP that would eventually become the broadly
realeased and universally supported IPV4
Beginning with IPv1, as described by IEN 26, the first task engineers set to accomplish was
defining the minimum necessary headers, along with their minimum necessary size specifications,
to successfully route packets across an arbitrarily large and arbitrarily organized network.


in IEN 28, the team defined IPv2, which further crystallized the interface's header, as well
as the process of fragmentation of packets over a network. This was also the first IEN to
posit a mechanism for detecting packet corruption, though it provided no guidance on how that
could be accomplished. Finally, it described a rudimentary addressing component of a packet,
and the addressing mechanism for hosts on a network.

IPV4 - establishing the IP
over several iterations the team finalized the header definition that would be standardized by RFC 791
as IPv4


