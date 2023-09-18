

## DNS and Resource Location

To ensure reliable delivery of requests broadcast on a network, each device on that network must be uniquely addressed,
and any software that wants to communicate with a device must know the address of the target device.

On all modern computational networks, the fixed-length numerical address by which you can reliably locate an external device
is the Internet Protocol (IP) address. Meanwhile, the system from which you can reliably ask for the address of a given device
is the Domain Name System (DNS). This, the DNS, is the computer network's phone book. It's essentially an elaborate, distributed
mapping of human-readable domain names to their underlying IP addresses.


DNS provides a bridge between the usability of URLs or domain names


URLs - user friendly addressing

Uniform Resource Locator (URL) is a universally agreed-upon standard for (unsurprisingly) locating resources on the web. It does so
by specifying the mechanism by which to retrieve the resource, as well as the specific route over which to retrieve it. It does so by
specifying the order of, and delimiters between, specific components that collectively define the specific physical location of any resource

## URL Components
Every URL begins with the scheme by which a resource should be located . This specifies the transport mechanism, or location type, that should
be used to find what you're looking for. There is a finite list of universally valid schemes that you can specify, including http, ftp, and even
file for locally hosted resources. The scheme is always followed by a colon (:) delimiter. After the scheme specification, a URL could contain
an optional authority specification, which itself contains a small handful of sub-components.

### The authority component
it has a designated prefix, the special delimiter of two consecutive forward slash characters , whose presence indicated that characters that follow should
be parsed according to the specification for a URL authority

### The path component
The path component specifies a series of path segments over which requests must travel to arrive at the searched for resource, each segent of the path
is individually delimited with a forward slash character (/)

### The query component
After the final segment of the path, the URL may contain an optional query component, indicated by the presence of the question mark character (?) delimiter.
The query component allows users to specify additional parameters for more specific results from the requested resource.

### The fragment component
An optional piece of the URL string and its rpesence it indiated by the reserved pound


 scheme:[//authority/]path[?query][#fragment]


## The URL as a subtype of the URI

A URL is a single specific kind of sowmthing known as a Uniform Resource Identifier (URI)
which is a string of characters adhering to a well- defined syntax that universally and uniquely identifies a resource on a network.


## Dont get it twised
In practice, however, the terms URL and URI are frequently used interchangeably. This is because, since URL is a specific kind of URI, it's always valid to
characterize a URL as a URI. Meanwhile, it is often sufficient to characterize a URI as a URL since knowing the specific identity of a resource within the
context of a network is usually enough to then locate that resource.

## Hosts - domain names and IPs
Host domain can either be a domain name or an IP address
The DNS is a distributed decentralized network of authoritative servers that hosts a
directory of all sub domain servers, as well as any domain names that can be resolved by that authoritative server
Any domain name that has been registered with a certified domain name registrar, and which meets the syntax standards of a domain name
(and which hasn't already been registered), is considered valid.
Each server will inspect the domain name given, and look up the domain in its own directory of names and IP address mappings. Naturally,
the server will first determine if the given name can be resolved by that server, or at least by one of its subordinate servers. If so, the authoritative server simply replaces the domain name in the request with the IP address to which it maps, and forwards the request along accordingly. If the current server cannot resolve the domain name, however, it will forward it along up the hierarchy of name servers to a more general, parent domain. This process continues up to the root name server, or until the name is resolved.
