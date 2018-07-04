# githubhook

A framework to develop GitHub webhook receiver hosted in AWS Lambda.

## Usage ##

The [S3Dump sample](./samples/GitHubHook.S3Dump) provides a simple starter code to implement your own GitHub webhook receiver.

### Concepts ###

**EventHandlersRegistry**

Register your handler to an EventHandlersRegistry instance. During execution, all handlers that can handle the event payload will be executed synchronously, in the order it is registered.

**Handler**

`BaseEventHandler` Provides basic handler public API. Unless overridden, all handler that implements this abstract class will handle all event types.

`DefaultHandler` Provides fallback handler implementation when no handler is available to handle a specific event type.

`DefaultPingHandler` Provides a basic handler implementation for ping events. GitHub will send a ping event when a new webhook is registered.

`EventHandler<T>` Provides basic handler implementation for a specific event payload of type T. Use this base class if your handler will handle a specific event type. This is the most common abstract class to implement in your function.

**Events**

Known GitHub webhook event types are listed under `GitHubHook.Events` namespace.
