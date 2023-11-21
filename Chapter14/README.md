
## Authentication
Put simply, authentication is the process of verifying a user's claim about who they are.
Your user is making a claim about their identity, and you want to make sure that the identity
is authentic. This is typically done by having the user provide some information that only they
could be reasonably expected to have. In access-controlled software, that information is typical
ly a set of credentials, such as a username and password combination, but it could be any number
of things, such as knowledge of previous addresses or familial ties.


## Authorization
On the other side of the access-control coin is authorization. This is about determining what
a user should be allowed to do within a system, from modifying or adding information stored by
a system to even accessing it in the first place. Just as the name suggests, authorization is
a precaution of not allowing a user to perform an action until the system knows that the user
is authorized to do so.


## Authorization header values
When a user attempts to access a site that is access-controlled, they might be prompted to provide
an Authorization header from the server. For a client to authorize themselves with the server,
they must do so using an authorization mechanism the server is prepared to handle. If the server
is only set up for basic authentication, but the client tries to pass a bearer token, the server
won't be able to parse the Authorization header, and will return a 401-Unauthorized status code,
regardless of the validity of the token sent by the client.

## Bearer token authorization
While Basic authentication simply provided a raw username and password credentials, the bearer
authentication deals in what is known as bearer tokens. A bearer token is simply a security token
that notifies the server that the user presenting the token (the bearer) has the credentials and
permissions granted by the token.


Within the context of the Authorization header, the bearer authentication scheme is used specifically
to support what are known as OAuth tokens. Open Authentication (OAuth) is a standard that was designed
explicitly to support token-based authentication mechanisms for access-control of web-based resources.
It's incredibly common across the internet.

## HTTP origin-bound access
While not a fully-realized standard, the HTTP origin-bound access (HOBA) authentication scheme represents
an exciting paradigm shift in the design of access-control mechanisms. Each of the previous forms of
authentication
we've discussed all revolved around users providing credentials (usually in the form of a username and
password)
to gain access to a system. With HOBA, no credentials are ever transmitted. Instead, a client (usually
a specific web browser)
persists a digital signature, which is given to the server in a challenge- response scheme.


## Token generation
While OAuth specifies the interactions between a client and the corresponding resource and auth
orization servers, it says nothing about how the access_token field is actually generated. Ins
tead, that detail is left up to each server that implements or relies on OAuth. So, how are tok
ens generated and validated?


## Persisted tokens
It's not uncommon for a token to be nothing more than a randomly generated string. In this toke
n generation mechanism, there is a database shared by both the authorization server and the res
ource server, which contains all of the relevant user access credentials and permissions. On s
ome predetermined schedule, tokens are randomly generated and then associated with each user i
n the database. Then, upon successful authentication, the authorization server looks up the cur
rent token for a given user and returns it as the access token.


## Self-encoded tokens
Perhaps one of the most robust and useful token generation mechanisms is the self-encoded token.
Self-encoded tokens are tokens whose bodies contain all of the information that's necessary for the
resource server to authorize the bearer. So, when a user is authenticated to a system and granted a
token by an authorization server, the resource server can simply inspect the body of the token to
determine the success of the authorization request and any permissions or claims the user has. With
the context contained entirely in the token, the resource server never has to access a shared database
to validate the user or their permissions, thus saving on the orchestration of resources in a distributed
environment.
Perhaps the most widely used, and widely supported, self-encoded token scheme is
the JSON Web Token (JWT). A JWT implements the self-encoded token mechanism by providing a set of claims
the bearer has as properties in an encoded JSON object. The structure of a JWT token consists of three separate
components, which are concatenated together and separated by a period.
The first of these components is a header, which is a base-64 encoded string with well- known header parameters
represented as a JSON object. This specifies the algorithm that's used for the signature (which we'll look at in
just a moment) and the token type, which is typically just JWT.
Next is the body, which is a base-64 encoded JSON object containing the complete list of claims the bearer of
the token has. There are a few required parameters in this object, such as sub (subject, or the name of the bearer)
and iat (issued at). However, since the specification of the token body is done entirely at the discretion of the
resource server, any number of claims can be added with any given values.
The final piece of a JWT is the verification signature. This is how your resource server will know the token came
from its associated authorization server. The verify signature is an encrypted hashed message authentication code (HMAC),
which is derived from the base-64 encoded strings of the previous two sections combined with a secret key, if the body is
tampered with , then it would not produce the same HMAC.



