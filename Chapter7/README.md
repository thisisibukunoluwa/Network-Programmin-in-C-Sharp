


Polly is a .NET resilience and transient-fault-handling library that allows developers
to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, Rate-limiting
and Fallback in a fluent and thread-safe manner.


There is an inexhaustible number of problems that can occur on even simple software when you
introduce the unpredictability of network interactions. A single off-by-one error in an upstream
service could mean a missing the closing curly-brace in a JSON string, rendering an entire payload
impossible to parse. Internet service provider (ISP) service interruptions or weak wireless signals
can result in timeouts and incomplete payload delivery.


## Golden Rule 
As a rule, any time you are reading data from an external dependency, you must implement proper
exception handling. Always assume that something could go wrong, always assume accessing external
dependencies will eventually fail.


but what if your own software is a dependency for another application? The next strategy for resilient
application behavior is to always assume that your own software will eventually fail.


## Parsing the exception status for context
The information you can discern simply from checking the value of the status code can tell you a lot
about what specifically failed and what recovery strategy is most likely to yield positive results.

## Examples - Case Scenarios 
If the DNS failed to identify the host based on the provided name at your first attempt, subsequent attempts
with the same hostname are unlikely to prove fruitful. However, if you receive an error status of the Timeout type,
you could potentially increase your timeout threshold on your request client and submit a series of retries, up
to a predetermined maximum timeout length.


## Circuit Breaker and Fallback policy
The fallback policy allows you to designate an alternative response to return in the event of the specified
exception being handled

The Circuit-breaker policy designates that multiple failed attempts to resolve a request should open the circuit
to the requested resource, and stop subsequent requests before they start. This is useful in scenarios like the one we've
defined for name resolution failures, where, based on the error message subsequent attempts are no more likely to be
successful than the original request. Opening the circuit (and thus stopping the flow of requests over that circuit)
gives the upstream system a chance to recover without being bombarded by a series of retry attempts. You can configure
the circuit to open after a designated number of failed attempts or after a designated timeout, and you can set it to
stay open for as long as you determine would probably be necessary to allow the upstream system to recover.


