

## Sockets and Ports

Socket - as software structure that exposes access to a port for network interaction

## Sockets and ports

## Ports - a hardware interface
Machines are identified by their Ipaddress , or the hostname assigned to the IpAddress in the DNS registry
So for any conneciton between mahcines to be resolved, the initiating host will need the underlying IPaddress
of the target host, but this is insufficent , to target a service or application running on the host,
It only gives us the location of the host itself. That's where ports come in.
A port is a two byte unsigned integer that identifies a running process on a target machine.
Everytime you want to start your application and listen for network requests you must assign it
to an unsigned port on the machine
If you want to host multiple services on a single device, you will need some way of distinguishing between
incoming requests for service A and incoming requests for service B. By designating mutually-exclusive listening
ports for each hosted application, you move the burden of proper routing back to the client.


### Reserved Ports
As we know that a port is an unsigned 2 byte int, the possible range of values are from 0 to 65535
but just because they fall into the valid range, doesn't mean you should listen to it

#### well known ports
Fall betwen 0 and 1023 and are used for anything DNS resolution, eg
80 - incoming Http requests
443 is for HTTPS
They are unavilable for you to register your application

#### Dynamic ports range
Dynamic ports, or private ports, are used to establish connections for private or customized services
or interactions, or used for temporary Transmission Control Protocol (TCP) or User Datagram Protocol (UDP)
interactions between two hosts. When used in a temporary context to service a brief need from either machine,
the designated port is known as an ephemeral port. These ports cannot be registered with the Internet Assigned
Numbers Authority (IANA) for use in general- purpose network interactions on a given host. The range for these
ports begins at port number 49152 and ends at 65535.


#### Registered Ports
Betwen 1024 and 49151 are available for use by your applications They are available for assignment by user applications
or system services as needed, and won't interfere with default behavior from your hardware or other connected hosts.


## Sockets - a software interface to a port

A socket provides a software interface to a specific port on a specific remote host


