

## (FTP) File transfer Protocol and (SMTP) Simple mail transfer protocol

## File transfer over the web
as an application-layer protocol on the Open Systems Interconnection (OSI) stack, the primary
concern of its design is in optimizing a specific common business task for execution over a
network. However, just because a task is optimally done over a given protocol, it doesn't mean
it must be done over that protocol.

## The intent of FTP

Built on a client-server model architecture, FTP is designed and implemented to leverage two
separate connections for establishing the state of the target filesystem and transferring files.
The first of these connections is what's called a control connection, and it is used to hold
various details about the state of the remote host, such as the current working directory exposed
to the FTP client. Meanwhile, for each transfer of data, a second data connection is established
using information maintained by the control connection. When the data connection is engaged and
transferring data, the control connection is idled.

## Active and passive connections
Once a control connection is established, the data connection can be made using one of two possible modes.
The server can establish an active connection, which is the default state for most FTP servers, or a passive
connection. These different types of connection refer specifically to how the data connection is established
and handled. In either case, the client initiates a control connection with a message using the underlying
transport protocol (usually Transmission Control Protocol (TCP))

## Active Connection 
In an active connection - ocne the control connection is established and the data transder can begin, its the
server that establoshes a data connection to transmit the file over the wire.
The client transmits the information during the command connection phase, notifying the server about which port
is actively listening for the data connection
Then the server attempts to establish a connection with the client on the designated port , which is used for the server
to push out the file data . The server is said to be actively transmitted the data to the client

## Passive Connection
In a passive connection , the client use the control conneciton to notify the server that the connection should be passive
The server responds with an IP address and port designation for the client to establish a connection with
At that point, its the client that establishes the data conneciton to the server's designated IP address and port
One this connection is established , the client can transmit the file data


## Transfer modes and data representations

Once the file transfer has been established, there is a number of ways to transmit the file in such a way as to
have it readable on the target machine. Text files written on different operating sysytems will have different character encodings
FTP is a platform agnostic network transmission protocol, it must account for the possible disparities
between binary representations of a file's content on different systems, it provides three
different common data representation mechanisms for files transferred over a conneciton

ASCII mode : The character and bytes are converted from the source machine's native character representation to
an 8- bit ASCII encoding
prior to transmission, and then converted, again, to the target machine's native character representation from that 8-bit ASCII encoding

Image (or binary) mode: In this mode, the underlying binary data of the file on the source machine is sent over, unchanged, in a sequential
byte stream. The target machine then stores that stream at the target file location on its local system, byte by byte, as it receives packets
from the source.

Local mode: This is for two computers with a shared local configuration to transfer data
in any proprietary representation without a need to convert it to ASCII

Then after choosing a way to represent data for transmission , FTP provides three mechanisms for actually executing that transmission

Stream Mode : Datagrams are sent as a continuous stream
Block Mode : This mechanism will chunk the file data into discrete application- layer packets and transfer them one block at a time
to the source system
Compressed Mode : This mode simply enables a simple data compressiom algorithm to minimize the total volume of data sent between hosts


## File permissions
If you've never seen the string of characters at the start of each of those lines before, those are codes that define the permissions you have for each file in the directory listing. If there is a letter present, it means the permission or status is true for that folder. The structure is as follows:
   [directoryFlag][owner-set][group-set][other-set]
The directory flag indicates whether the entry listed is, itself, a directory that can be navigated to and have files pulled from it. If d is present at the start of the entry, it's a folder containing files, not a file itself. Next is the permission sets for each kind of user that might want to interact with it. These are groupings of three characters indicating which permissions members of the set have for the file listed. In the order they are displayed, those characters are as follows:
r: read
w: write x: execute
So, for each set, there are three characters that are either set or null (represented here as a - character) indicating whether that set has the permission.
Using this, we can see that, for the files in our directory, FitnessApp and FitnessDataStore are both directories (they have d at the start of their permissions record), and both of them have the following permissions for each group:
Owner: Read, write, and execute permissions Group: Read and execute permissions
Other: Read and execute permissions

## Securing FTP requests
We were actually interacting with the server in an unsecure manner , those credentials
were only of value the moment they were received by the server and the command connection
was established , after that , they provided no more security of the data we were transmitting than if we had allowed entirely anonymous access
to our directory 
## Securing FTP with SFTP and FTPS
we can mitigate our exposure to risks
### SFTP
A new standarad for file transfer interactions that leveraged the SSH for auth and secure tunneling
it was dubbed SSH file transfer protocol , or Secure File Transfer Protocol (SFTP)
This application protocol provides security by establishing a secure tunnel between the two host machines.
All data is sent that via tunnel once the client host has been authenticated by the server host machine
(as opposed to the simple server-user authentication of our example in the previous section). This is not
entirely dissimilar to simply transferring files over a VPN.


### FTPS
While SFTP exists as a file transfer subsystem added as an extension to SSH, the alternative approach for
encrypting traffic sent over an open connection (one that hasn't established a secure tunnel between hosts)
is to use what's called FTPS. An abbreviation of FTP over SSL, or FTP Secure, FTPS leverages the encryption
mechanisms of the underlying transport layer to provide encryption for data transferred between hosts


## The email protocol
 Simple Mail Transfer Protocol (SMTP) is the de- facto protocol for transmitting electronic messages. It's
 a connection-oriented protocol using the client-server architecture we've become so familiar with over the
 course of this book. Similar to FTP, SMTP transactions happen over a sequence of commands and responses
 transmitted over a dedicated SMTP session. Those commands notify the server of what the addressing information
 is for a message (the To: and From: components of an email), transmit the message itself, and finally confirm
 receipt of the message.


  Simple Mail Transfer Protocol (SMTP) is the de- facto protocol for transmitting electronic messages.
  It's a connection-oriented protocol using the client-server architecture we've become so familiar with
  over the course of this book. Similar to FTP, SMTP transactions happen over a sequence of commands and
  responses transmitted over a dedicated SMTP session. Those commands notify the server of what the addressing
  information is for a message (the To: and From: components of an email), transmit the message itself, and
  finally confirm receipt of the message.

  The important thing to note about SMTP is that it is entirely about the outbound transmission of a new message
  . There is no mechanism in the protocol itself to request messages back from a server. Applications that maintain
  a mailbox for users to access are doing so by leveraging entirely different messaging protocols, such as the Internet
  Message Access Protocol (IMAP) or the Post Office Protocol (POP). However, while those protocols are useful to update
  your phone's mail app, the application will still depend on SMTP to transmit any new messages you want to send to a remote
  address.



## MIME TYPE
Having been defined in 1982, there are a number of limitations to SMTP when implemented strictly according to the standard.
This includes the range of valid character encodings and alternative representations of certain content, such as images or
sounds, directly in the message body of an email. To that end, IETF extended the protocol with the Multipurpose Internet Mail Extensions (MIME).
MIME provides users with the following: non-ASCII character representation; audio, image, video, and application attachments;
multipart message bodies; and additional context and metadata in the message headers. Interestingly, this is where SMTP overlaps
the most with HTTP. Even though MIME was originally designed and implemented as an SMTP extension, the ability to specify the character
encoding and data structure of an incoming message was quickly identified as a useful feature for other application protocols transmitting
text content. Naturally, it was adopted into use by HTTP in no time. MIME- type is the name of the value of the ContentType header sent with
HTTP messages that contain a message body, and this is exactly how the extension is used by SMTP.

