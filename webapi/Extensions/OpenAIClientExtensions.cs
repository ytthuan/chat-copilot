// #region Assembly Azure.AI.OpenAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8
// // /Users/leo-imac/.nuget/packages/azure.ai.openai/1.0.0-beta.15/lib/netstandard2.0/Azure.AI.OpenAI.dll
// // Decompiled with ICSharpCode.Decompiler 
// #endregion
// using System;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Text.Json;
// using System.Threading;
// using System.Threading.Tasks;
// using Azure;
// using Azure.AI.OpenAI;
// using Azure.Core;
// using Azure.Core.Pipeline;
// // namespace Azure.AI.OpenAI;
// namespace CopilotChat.WebApi.Extensions;
// public class MyOpenAIClient
// {
//     private const string PublicOpenAIApiVersion = "1";

//     private const string PublicOpenAIEndpoint = "https://api.groq.com/openai/v1";

//     private bool _isConfiguredForAzureOpenAI = true;

//     private const string AuthorizationHeader = "api-key";

//     private readonly AzureKeyCredential _keyCredential;

//     private static readonly string[] AuthorizationScopes = new string[1] { "https://cognitiveservices.azure.com/.default" };

//     private readonly TokenCredential _tokenCredential;

//     private readonly HttpPipeline _pipeline;

//     private readonly Uri _endpoint;

//     private readonly string _apiVersion;

//     private static RequestContext DefaultRequestContext = new RequestContext();

//     private static ResponseClassifier _responseClassifier200;

//     //
//     // Summary:
//     //     The ClientDiagnostics is used to provide tracing support for the client library.
//     public Azure.Core.DiagnosticsOptions ClientDiagnostics { get; }

//     //
//     // Summary:
//     //     The HTTP pipeline for sending and receiving REST requests and responses.
//     public virtual HttpPipeline Pipeline => _pipeline;

//     private static ResponseClassifier ResponseClassifier200
//     {
//         get
//         {
//             ResponseClassifier responseClassifier = _responseClassifier200;
//             if (responseClassifier == null)
//             {
//                 responseClassifier = (_responseClassifier200 = new StatusCodeClassifier(stackalloc ushort[1] { 200 }));
//             }

//             return responseClassifier;
//         }
//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with an Azure OpenAI resource.
//     //
//     //
//     // Parameters:
//     //   endpoint:
//     //     The URI for an Azure OpenAI resource as retrieved from, for example, Azure Portal.
//     //     This should include protocol and hostname. An example could be: https://my-resource.openai.azure.com
//     //     .
//     //
//     //   keyCredential:
//     //     A key credential used to authenticate to an Azure OpenAI resource.
//     //
//     //   options:
//     //     The options for configuring the client.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     endpoint or keyCredential is null.
//     //
//     // Remarks:
//     //     Azure.AI.OpenAI.OpenAIClient objects initialized with this constructor can only
//     //     be used with Azure OpenAI resources. To use Azure.AI.OpenAI.OpenAIClient with
//     //     the non-Azure OpenAI inference endpoint, use a constructor that accepts a non-Azure
//     //     OpenAI API key, instead.
//     public MyOpenAIClient(Uri endpoint, AzureKeyCredential keyCredential, OpenAIClientOptions options)
//     {

//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with an Azure OpenAI resource.
//     //
//     //
//     // Parameters:
//     //   endpoint:
//     //     The URI for an Azure OpenAI resource as retrieved from, for example, Azure Portal.
//     //     This should include protocol and hostname. An example could be: https://my-resource.openai.azure.com
//     //     .
//     //
//     //   keyCredential:
//     //     A key credential used to authenticate to an Azure OpenAI resource.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     endpoint or keyCredential is null.
//     //
//     // Remarks:
//     //     Azure.AI.OpenAI.OpenAIClient objects initialized with this constructor can only
//     //     be used with Azure OpenAI resources. To use Azure.AI.OpenAI.OpenAIClient with
//     //     the non-Azure OpenAI inference endpoint, use a constructor that accepts a non-Azure
//     //     OpenAI API key, instead.
//     public MyOpenAIClient(Uri endpoint, AzureKeyCredential keyCredential)
//         : this(endpoint, keyCredential, new OpenAIClientOptions())
//     {
//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with an Azure OpenAI resource.
//     //
//     //
//     // Parameters:
//     //   endpoint:
//     //     The URI for an Azure OpenAI resource as retrieved from, for example, Azure Portal.
//     //     This should include protocol and hostname. An example could be: https://my-resource.openai.azure.com
//     //     .
//     //
//     //   options:
//     //     The options for configuring the client.
//     //
//     //   tokenCredential:
//     //     A token credential used to authenticate with an Azure OpenAI resource.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     endpoint or tokenCredential is null.
//     public MyOpenAIClient(Uri endpoint, TokenCredential tokenCredential, OpenAIClientOptions options)
//     {
//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with an Azure OpenAI resource.
//     //
//     //
//     // Parameters:
//     //   endpoint:
//     //     The URI for an Azure OpenAI resource as retrieved from, for example, Azure Portal.
//     //     This should include protocol and hostname. An example could be: https://my-resource.openai.azure.com
//     //     .
//     //
//     //   tokenCredential:
//     //     A token credential used to authenticate with an Azure OpenAI resource.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     endpoint or tokenCredential is null.
//     public MyOpenAIClient(Uri endpoint, TokenCredential tokenCredential)
//         : this(endpoint, tokenCredential, new OpenAIClientOptions())
//     {
//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with the non-Azure OpenAI endpoint.
//     //
//     //
//     // Parameters:
//     //   openAIApiKey:
//     //     The API key to use when connecting to the non-Azure OpenAI endpoint.
//     //
//     //   options:
//     //     The options for configuring the client.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     openAIApiKey is null.
//     //
//     // Remarks:
//     //     Azure.AI.OpenAI.OpenAIClient objects initialized with this constructor can only
//     //     be used with the non-Azure OpenAI inference endpoint. To use Azure.AI.OpenAI.OpenAIClient
//     //     with an Azure OpenAI resource, use a constructor that accepts a resource URI
//     //     and Azure authentication credential, instead.
//     public MyOpenAIClient(string openAIApiKey, OpenAIClientOptions options)
//         : this(new Uri("https://api.groq.com/openai/v1"), CreateDelegatedToken(openAIApiKey), options)
//     {
//         _isConfiguredForAzureOpenAI = false;
//     }

//     //
//     // Summary:
//     //     Initializes a instance of OpenAIClient for use with the non-Azure OpenAI endpoint.
//     //
//     //
//     // Parameters:
//     //   openAIApiKey:
//     //     The API key to use when connecting to the non-Azure OpenAI endpoint.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     openAIApiKey is null.
//     //
//     // Remarks:
//     //     Azure.AI.OpenAI.OpenAIClient objects initialized with this constructor can only
//     //     be used with the non-Azure OpenAI inference endpoint. To use Azure.AI.OpenAI.OpenAIClient
//     //     with an Azure OpenAI resource, use a constructor that accepts a resource URI
//     //     and Azure authentication credential, instead.
//     public MyOpenAIClient(string openAIApiKey)
//         : this(new Uri("https://api.groq.com/openai/v1"), CreateDelegatedToken(openAIApiKey), new OpenAIClientOptions())
//     {
//         _isConfiguredForAzureOpenAI = false;
//     }

//     //
//     // Summary:
//     //     Return textual completions as configured for a given prompt.
//     //
//     // Parameters:
//     //   completionsOptions:
//     //     The options for this completions request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     completionsOptions or completionsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     completionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<Completions> GetCompletions(CompletionsOptions completionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         // using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
//         // diagnosticScope.Start();
//         // completionsOptions.InternalShouldStreamResponse = null;
//         RequestContent content = completionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             using HttpMessage message = CreatePostRequestMessage(completionsOptions, content, requestContext);
//             Response response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
//             return Response.FromValue(Completions.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             throw exception;
//         }
//     }

//     //
//     // Summary:
//     //     Return textual completions as configured for a given prompt.
//     //
//     // Parameters:
//     //   completionsOptions:
//     //     The options for this completions request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     completionsOptions or completionsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     completionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<Completions>> GetCompletionsAsync(CompletionsOptions completionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletions");
//         scope.Start();
//         completionsOptions.InternalShouldStreamResponse = null;
//         RequestContent content = completionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             using HttpMessage message = CreatePostRequestMessage(completionsOptions, content, requestContext);
//             Response response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
//             return Response.FromValue(Completions.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Begin a completions request and get an object that can stream response data as
//     //     it becomes available.
//     //
//     // Parameters:
//     //   completionsOptions:
//     //     the chat completions options for this completions request.
//     //
//     //   cancellationToken:
//     //     a cancellation token that can be used to cancel the initial request or ongoing
//     //     streaming operation.
//     //
//     // Returns:
//     //     A response that, if the request was successful, may be asynchronously enumerated
//     //     for Azure.AI.OpenAI.Completions instances.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     completionsOptions or completionsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     completionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual StreamingResponse<Completions> GetCompletionsStreaming(CompletionsOptions completionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
//         diagnosticScope.Start();
//         completionsOptions.InternalShouldStreamResponse = true;
//         RequestContent content = completionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage httpMessage = CreatePostRequestMessage(completionsOptions, content, requestContext);
//             httpMessage.BufferResponse = false;
//             return StreamingResponse<Completions>.CreateFromResponse(_pipeline.ProcessMessage(httpMessage, requestContext, cancellationToken), (Response responseForEnumeration) => SseAsyncEnumerator<Completions>.EnumerateFromSseStream(responseForEnumeration.ContentStream, (JsonElement e) => Completions.DeserializeCompletions(e), cancellationToken));
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Begin a completions request and get an object that can stream response data as
//     //     it becomes available.
//     //
//     // Parameters:
//     //   completionsOptions:
//     //     the chat completions options for this completions request.
//     //
//     //   cancellationToken:
//     //     a cancellation token that can be used to cancel the initial request or ongoing
//     //     streaming operation.
//     //
//     // Returns:
//     //     A response that, if the request was successful, may be asynchronously enumerated
//     //     for Azure.AI.OpenAI.Completions instances.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     completionsOptions or completionsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     completionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<StreamingResponse<Completions>> GetCompletionsStreamingAsync(CompletionsOptions completionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetCompletionsStreaming");
//         scope.Start();
//         RequestContent content = completionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage httpMessage = CreatePostRequestMessage(completionsOptions, content, requestContext);
//             httpMessage.BufferResponse = false;
//             return StreamingResponse<Completions>.CreateFromResponse(await _pipeline.ProcessMessageAsync(httpMessage, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), (Response responseForEnumeration) => SseAsyncEnumerator<Completions>.EnumerateFromSseStream(responseForEnumeration.ContentStream, (JsonElement e) => Completions.DeserializeCompletions(e), cancellationToken));
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Get chat completions for provided chat context messages.
//     //
//     // Parameters:
//     //   chatCompletionsOptions:
//     //     The options for this chat completions request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     chatCompletionsOptions or chatCompletionsOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     chatCompletionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<ChatCompletions> GetChatCompletions(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
//         diagnosticScope.Start();
//         chatCompletionsOptions.InternalShouldStreamResponse = null;
//         RequestContent content = chatCompletionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             using HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, requestContext);
//             Response response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
//             return Response.FromValue(ChatCompletions.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Get chat completions for provided chat context messages.
//     //
//     // Parameters:
//     //   chatCompletionsOptions:
//     //     The options for this chat completions request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     chatCompletionsOptions or chatCompletionsOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     chatCompletionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<ChatCompletions>> GetChatCompletionsAsync(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletions");
//         scope.Start();
//         chatCompletionsOptions.InternalShouldStreamResponse = null;
//         RequestContent content = chatCompletionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             using HttpMessage message = CreatePostRequestMessage(chatCompletionsOptions, content, requestContext);
//             Response response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
//             return Response.FromValue(ChatCompletions.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Begin a chat completions request and get an object that can stream response data
//     //     as it becomes available.
//     //
//     // Parameters:
//     //   chatCompletionsOptions:
//     //     the chat completions options for this chat completions request.
//     //
//     //   cancellationToken:
//     //     a cancellation token that can be used to cancel the initial request or ongoing
//     //     streaming operation.
//     //
//     // Returns:
//     //     The response returned from the service.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     chatCompletionsOptions or chatCompletionsOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     chatCompletionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual StreamingResponse<StreamingChatCompletionsUpdate> GetChatCompletionsStreaming(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
//         diagnosticScope.Start();
//         chatCompletionsOptions.InternalShouldStreamResponse = true;
//         RequestContent content = chatCompletionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage httpMessage = CreatePostRequestMessage(chatCompletionsOptions, content, requestContext);
//             httpMessage.BufferResponse = false;
//             return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(_pipeline.ProcessMessage(httpMessage, requestContext, cancellationToken), (Response responseForEnumeration) => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(responseForEnumeration.ContentStream, (Func<JsonElement, IEnumerable<StreamingChatCompletionsUpdate>>)StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates, cancellationToken));
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Begin a chat completions request and get an object that can stream response data
//     //     as it becomes available.
//     //
//     // Parameters:
//     //   chatCompletionsOptions:
//     //     the chat completions options for this chat completions request.
//     //
//     //   cancellationToken:
//     //     a cancellation token that can be used to cancel the initial request or ongoing
//     //     streaming operation.
//     //
//     // Returns:
//     //     A response that, if the request was successful, may be asynchronously enumerated
//     //     for Azure.AI.OpenAI.StreamingChatCompletionsUpdate instances.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     chatCompletionsOptions or chatCompletionsOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     chatCompletionsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<StreamingResponse<StreamingChatCompletionsUpdate>> GetChatCompletionsStreamingAsync(ChatCompletionsOptions chatCompletionsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetChatCompletionsStreaming");
//         scope.Start();
//         chatCompletionsOptions.InternalShouldStreamResponse = true;
//         RequestContent content = chatCompletionsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage httpMessage = CreatePostRequestMessage(chatCompletionsOptions, content, requestContext);
//             httpMessage.BufferResponse = false;
//             return StreamingResponse<StreamingChatCompletionsUpdate>.CreateFromResponse(await _pipeline.ProcessMessageAsync(httpMessage, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), (Response responseForEnumeration) => SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(responseForEnumeration.ContentStream, (Func<JsonElement, IEnumerable<StreamingChatCompletionsUpdate>>)StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates, cancellationToken));
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Return the computed embeddings for a given prompt.
//     //
//     // Parameters:
//     //   embeddingsOptions:
//     //     The options for this embeddings request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     embeddingsOptions or embeddingsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     embeddingsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<Embeddings> GetEmbeddings(EmbeddingsOptions embeddingsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
//         diagnosticScope.Start();
//         RequestContent content = embeddingsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage message = CreatePostRequestMessage(embeddingsOptions, content, requestContext);
//             Response response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
//             return Response.FromValue(Embeddings.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Return the computed embeddings for a given prompt.
//     //
//     // Parameters:
//     //   embeddingsOptions:
//     //     The options for this embeddings request.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     embeddingsOptions or embeddingsOptions.DeploymentName.DeploymentName is null.
//     //
//     //
//     //   T:System.ArgumentException:
//     //     embeddingsOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<Embeddings>> GetEmbeddingsAsync(EmbeddingsOptions embeddingsOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetEmbeddings");
//         scope.Start();
//         RequestContent content = embeddingsOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         try
//         {
//             HttpMessage message = CreatePostRequestMessage(embeddingsOptions, content, requestContext);
//             Response response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
//             return Response.FromValue(Embeddings.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Get a set of generated images influenced by a provided textual prompt.
//     //
//     // Parameters:
//     //   imageGenerationOptions:
//     //     The configuration information for the image generation request that controls
//     //     the content, size, and other details about generated images.
//     //
//     //   cancellationToken:
//     //     An optional cancellation token that may be used to abort an ongoing request.
//     //
//     //
//     // Returns:
//     //     The response information for the image generations request.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     imageGenerationOptions is null.
//     //
//     //   T:System.ArgumentException:
//     //     imageGenerationOptions.DeploymentName.DeploymentName is null or empty when using
//     //     Azure OpenAI. Azure OpenAI image generation requires a valid dall-e-3 model deployment.
//     public virtual Response<ImageGenerations> GetImageGenerations(ImageGenerationOptions imageGenerationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetImageGenerations");
//         diagnosticScope.Start();
//         try
//         {
//             RequestContext requestContext = FromCancellationToken(cancellationToken);
//             HttpMessage message = CreatePostRequestMessage(imageGenerationOptions.DeploymentName, "images/generations", imageGenerationOptions.ToRequestContent(), requestContext);
//             Response response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
//             return Response.FromValue(ImageGenerations.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Get a set of generated images influenced by a provided textual prompt.
//     //
//     // Parameters:
//     //   imageGenerationOptions:
//     //     The configuration information for the image generation request that controls
//     //     the content, size, and other details about generated images.
//     //
//     //   cancellationToken:
//     //     An optional cancellation token that may be used to abort an ongoing request.
//     //
//     //
//     // Returns:
//     //     The response information for the image generations request.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     imageGenerationOptions is null.
//     //
//     //   T:System.ArgumentException:
//     //     imageGenerationOptions.DeploymentName.DeploymentName is null or empty when using
//     //     Azure OpenAI. Azure OpenAI image generation requires a valid dall-e-3 model deployment.
//     public virtual async Task<Response<ImageGenerations>> GetImageGenerationsAsync(ImageGenerationOptions imageGenerationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(imageGenerationOptions, "imageGenerationOptions");
//         if (_isConfiguredForAzureOpenAI)
//         {
//             Argument.AssertNotNullOrEmpty(imageGenerationOptions.DeploymentName, "DeploymentName");
//         }

//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetImageGenerations");
//         scope.Start();
//         try
//         {
//             RequestContext requestContext = FromCancellationToken(cancellationToken);
//             HttpMessage message = CreatePostRequestMessage(imageGenerationOptions.DeploymentName, "images/generations", imageGenerationOptions.ToRequestContent(), requestContext);
//             Response response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
//             return Response.FromValue(ImageGenerations.FromResponse(response), response);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Transcribes audio into the input language.
//     //
//     // Parameters:
//     //   audioTranscriptionOptions:
//     //     Transcription request. Requesting format 'json' will result on only the 'text'
//     //     field being set. For more output data use 'verbose_json.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     audioTranscriptionOptions or audioTranscriptionOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     audioTranscriptionOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<AudioTranscription>> GetAudioTranscriptionAsync(AudioTranscriptionOptions audioTranscriptionOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(audioTranscriptionOptions, "audioTranscriptionOptions");
//         Argument.AssertNotNullOrEmpty(audioTranscriptionOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranscription");
//         scope.Start();
//         RequestContent content = audioTranscriptionOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         Response response = null;
//         try
//         {
//             using HttpMessage message = CreateGetAudioTranscriptionRequest(audioTranscriptionOptions, content, requestContext);
//             response = await _pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(continueOnCapturedContext: false);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }

//         return Response.FromValue(AudioTranscription.FromResponse(response), response);
//     }

//     //
//     // Summary:
//     //     Transcribes audio into the input language.
//     //
//     // Parameters:
//     //   audioTranscriptionOptions:
//     //     Transcription request. Requesting format 'json' will result on only the 'text'
//     //     field being set. For more output data use 'verbose_json.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     audioTranscriptionOptions or audioTranscriptionOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     audioTranscriptionOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<AudioTranscription> GetAudioTranscription(AudioTranscriptionOptions audioTranscriptionOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(audioTranscriptionOptions, "audioTranscriptionOptions");
//         Argument.AssertNotNullOrEmpty(audioTranscriptionOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranscription");
//         diagnosticScope.Start();
//         RequestContent content = audioTranscriptionOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         Response response = null;
//         try
//         {
//             using HttpMessage message = CreateGetAudioTranscriptionRequest(audioTranscriptionOptions, content, requestContext);
//             response = _pipeline.ProcessMessage(message, requestContext);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }

//         return Response.FromValue(AudioTranscription.FromResponse(response), response);
//     }

//     //
//     // Summary:
//     //     Transcribes and translates input audio into English text.
//     //
//     // Parameters:
//     //   audioTranslationOptions:
//     //     Translation request. Requesting format 'json' will result on only the 'text'
//     //     field being set. For more output data use 'verbose_json.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     audioTranslationOptions or audioTranslationOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     audioTranslationOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<AudioTranslation>> GetAudioTranslationAsync(AudioTranslationOptions audioTranslationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(audioTranslationOptions, "audioTranslationOptions");
//         Argument.AssertNotNullOrEmpty(audioTranslationOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranslation");
//         scope.Start();
//         RequestContent content = audioTranslationOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         Response response = null;
//         try
//         {
//             using HttpMessage message = CreateGetAudioTranslationRequest(audioTranslationOptions, content, requestContext);
//             response = await _pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(continueOnCapturedContext: false);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }

//         return Response.FromValue(AudioTranslation.FromResponse(response), response);
//     }

//     //
//     // Summary:
//     //     Transcribes and translates input audio into English text.
//     //
//     // Parameters:
//     //   audioTranslationOptions:
//     //     Translation request. Requesting format 'json' will result on only the 'text'
//     //     field being set. For more output data use 'verbose_json.
//     //
//     //   cancellationToken:
//     //     The cancellation token to use.
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     audioTranslationOptions or audioTranslationOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     audioTranslationOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<AudioTranslation> GetAudioTranslation(AudioTranslationOptions audioTranslationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(audioTranslationOptions, "audioTranslationOptions");
//         Argument.AssertNotNullOrEmpty(audioTranslationOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.Pipeline.DiagnosticScope diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GetAudioTranslation");
//         diagnosticScope.Start();
//         RequestContent content = audioTranslationOptions.ToRequestContent();
//         RequestContext requestContext = FromCancellationToken(cancellationToken);
//         Response response = null;
//         try
//         {
//             using HttpMessage message = CreateGetAudioTranslationRequest(audioTranslationOptions, content, requestContext);
//             response = _pipeline.ProcessMessage(message, requestContext);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }

//         return Response.FromValue(AudioTranslation.FromResponse(response), response);
//     }

//     //
//     // Summary:
//     //     Generates text-to-speech audio from the input text.
//     //
//     // Parameters:
//     //   speechGenerationOptions:
//     //     A representation of the request options that control the behavior of a text-to-speech
//     //     operation.
//     //
//     //   cancellationToken:
//     //     An optional cancellation token that may be used to abort an ongoing request.
//     //
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     speechGenerationOptions or speechGenerationOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     speechGenerationOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual async Task<Response<BinaryData>> GenerateSpeechFromTextAsync(SpeechGenerationOptions speechGenerationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(speechGenerationOptions, "speechGenerationOptions");
//         Argument.AssertNotNullOrEmpty(speechGenerationOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("OpenAIClient.GenerateSpeechFromText");
//         scope.Start();
//         try
//         {
//             RequestContext requestContext = FromCancellationToken(cancellationToken);
//             HttpMessage message = CreatePostRequestMessage(speechGenerationOptions.DeploymentName, "audio/speech", speechGenerationOptions.ToRequestContent(), requestContext);
//             Response response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
//             return Response.FromValue(response.Content, response);
//         }
//         catch (Exception exception)
//         {
//             scope.Failed(exception);
//             throw;
//         }
//     }

//     //
//     // Summary:
//     //     Generates text-to-speech audio from the input text.
//     //
//     // Parameters:
//     //   speechGenerationOptions:
//     //     A representation of the request options that control the behavior of a text-to-speech
//     //     operation.
//     //
//     //   cancellationToken:
//     //     An optional cancellation token that may be used to abort an ongoing request.
//     //
//     //
//     // Exceptions:
//     //   T:System.ArgumentNullException:
//     //     speechGenerationOptions or speechGenerationOptions.DeploymentName.DeploymentName
//     //     is null.
//     //
//     //   T:System.ArgumentException:
//     //     speechGenerationOptions.DeploymentName.DeploymentName is an empty string.
//     public virtual Response<BinaryData> GenerateSpeechFromText(SpeechGenerationOptions speechGenerationOptions, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         Argument.AssertNotNull(speechGenerationOptions, "speechGenerationOptions");
//         Argument.AssertNotNullOrEmpty(speechGenerationOptions.DeploymentName, "DeploymentName");
//         using Azure.Core.DiagnosticsOptions diagnosticScope = ClientDiagnostics.CreateScope("OpenAIClient.GenerateSpeechFromText");
//         diagnosticScope.Start();
//         try
//         {
//             RequestContext requestContext = FromCancellationToken(cancellationToken);
//             HttpMessage message = CreatePostRequestMessage(speechGenerationOptions.DeploymentName, "audio/speech", speechGenerationOptions.ToRequestContent(), requestContext);
//             Response response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
//             return Response.FromValue(response.Content, response);
//         }
//         catch (Exception exception)
//         {
//             diagnosticScope.Failed(exception);
//             throw;
//         }
//     }

//     internal RequestUriBuilder GetUri(string deploymentOrModelName, string operationPath)
//     {
//         Azure.Core.Http.RawRequestUriBuilder rawRequestUriBuilder = new Azure.Core.Http.RawRequestUriBuilder();
//         rawRequestUriBuilder.Reset(_endpoint);
//         if (_isConfiguredForAzureOpenAI)
//         {
//             rawRequestUriBuilder.AppendRaw("/openai", escape: false);
//             rawRequestUriBuilder.AppendPath("/deployments/", escape: false);
//             rawRequestUriBuilder.AppendPath(deploymentOrModelName, escape: true);
//             rawRequestUriBuilder.AppendPath("/" + operationPath, escape: false);
//             rawRequestUriBuilder.AppendQuery("api-version", _apiVersion, escapeValue: true);
//         }
//         else
//         {
//             rawRequestUriBuilder.AppendPath("/" + operationPath, escape: false);
//         }

//         return rawRequestUriBuilder;
//     }

//     internal HttpMessage CreatePostRequestMessage(CompletionsOptions completionsOptions, RequestContent content, RequestContext context)
//     {
//         return CreatePostRequestMessage(completionsOptions.DeploymentName, "completions", content, context);
//     }

//     internal HttpMessage CreatePostRequestMessage(ChatCompletionsOptions chatCompletionsOptions, RequestContent content, RequestContext context)
//     {
//         string operationPath = "chat/completions";
//         return CreatePostRequestMessage(chatCompletionsOptions.DeploymentName, operationPath, content, context);
//     }

//     internal HttpMessage CreatePostRequestMessage(EmbeddingsOptions embeddingsOptions, RequestContent content, RequestContext context)
//     {
//         return CreatePostRequestMessage(embeddingsOptions.DeploymentName, "embeddings", content, context);
//     }

//     internal HttpMessage CreatePostRequestMessage(string deploymentOrModelName, string operationPath, RequestContent content, RequestContext context)
//     {
//         HttpMessage httpMessage = _pipeline.CreateMessage(context, ResponseClassifier200);
//         Request request = httpMessage.Request;
//         request.Method = RequestMethod.Post;
//         request.Uri = GetUri(deploymentOrModelName, operationPath);
//         request.Headers.Add("Accept", "application/json");
//         request.Headers.Add("Content-Type", "application/json");
//         request.Content = content;
//         return httpMessage;
//     }

//     private static TokenCredential CreateDelegatedToken(string token)
//     {
//         AccessToken accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180.0));
//         return DelegatedTokenCredential.Create((TokenRequestContext _, CancellationToken _) => accessToken);
//     }

//     internal HttpMessage CreateGetAudioTranscriptionRequest(AudioTranscriptionOptions audioTranscriptionOptions, RequestContent content, RequestContext context)
//     {
//         HttpMessage httpMessage = _pipeline.CreateMessage(context, ResponseClassifier200);
//         Request request = httpMessage.Request;
//         request.Method = RequestMethod.Post;
//         request.Uri = GetUri(audioTranscriptionOptions.DeploymentName, "audio/transcriptions");
//         request.Content = content;
//         (content as MultipartFormDataContent).ApplyToRequest(request);
//         return httpMessage;
//     }

//     internal HttpMessage CreateGetAudioTranslationRequest(AudioTranslationOptions audioTranslationOptions, RequestContent content, RequestContext context)
//     {
//         HttpMessage httpMessage = _pipeline.CreateMessage(context, ResponseClassifier200);
//         Request request = httpMessage.Request;
//         request.Method = RequestMethod.Post;
//         request.Uri = GetUri(audioTranslationOptions.DeploymentName, "audio/translations");
//         request.Content = content;
//         (content as MultipartFormDataContent).ApplyToRequest(request);
//         return httpMessage;
//     }

//     //
//     // Summary:
//     //     Initializes a new instance of OpenAIClient for mocking.
//     protected MyOpenAIClient()
//     {
//     }

//     internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default(CancellationToken))
//     {
//         if (!cancellationToken.CanBeCanceled)
//         {
//             return DefaultRequestContext;
//         }

//         return new RequestContext
//         {
//             CancellationToken = cancellationToken
//         };
//     }
// }
// // #if false // Decompilation log
// // '416' items in cache
// // ------------------
// // Resolve: 'netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '2.0.0.0', Got: '2.1.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/netstandard.dll'
// // ------------------
// // Resolve: 'Azure.Core, Version=1.38.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8'
// // Found single assembly: 'Azure.Core, Version=1.38.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8'
// // Load from: '/Users/leo-imac/.nuget/packages/azure.core/1.38.0/lib/net6.0/Azure.Core.dll'
// // ------------------
// // Resolve: 'System.Text.Json, Version=4.0.1.2, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Text.Json, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '4.0.1.2', Got: '8.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/system.text.json/8.0.3/lib/net6.0/System.Text.Json.dll'
// // ------------------
// // Resolve: 'System.Threading.Tasks.Extensions, Version=4.2.0.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Threading.Tasks.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '4.2.0.1', Got: '6.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.Tasks.Extensions.dll'
// // ------------------
// // Resolve: 'System.Memory, Version=4.0.1.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Memory, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '4.0.1.1', Got: '6.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Memory.dll'
// // ------------------
// // Resolve: 'Microsoft.Bcl.AsyncInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'Microsoft.Bcl.AsyncInterfaces, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '1.0.0.0', Got: '8.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.bcl.asyncinterfaces/8.0.0/lib/netstandard2.1/Microsoft.Bcl.AsyncInterfaces.dll'
// // ------------------
// // Resolve: 'System.Memory.Data, Version=1.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Memory.Data, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '1.0.2.0', Got: '8.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/system.memory.data/8.0.0/lib/net6.0/System.Memory.Data.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.DiagnosticSource, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Diagnostics.DiagnosticSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // WARN: Version mismatch. Expected: '6.0.0.0', Got: '8.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/system.diagnostics.diagnosticsource/8.0.0/lib/net6.0/System.Diagnostics.DiagnosticSource.dll'
// // ------------------
// // Resolve: 'System.ClientModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8'
// // Found single assembly: 'System.ClientModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8'
// // Load from: '/Users/leo-imac/.nuget/packages/system.clientmodel/1.0.0/lib/net6.0/System.ClientModel.dll'
// // ------------------
// // Resolve: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.dll'
// // ------------------
// // Resolve: 'System.IO.MemoryMappedFiles, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.IO.MemoryMappedFiles, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.MemoryMappedFiles.dll'
// // ------------------
// // Resolve: 'System.IO.Pipes, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.IO.Pipes, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.Pipes.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.Process, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.Process, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.Process.dll'
// // ------------------
// // Resolve: 'System.Security.Cryptography.X509Certificates, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Cryptography.X509Certificates, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Cryptography.X509Certificates.dll'
// // ------------------
// // Resolve: 'System.Memory, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Memory, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Memory.dll'
// // ------------------
// // Resolve: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Collections.dll'
// // ------------------
// // Resolve: 'System.Collections.NonGeneric, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Collections.NonGeneric, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Collections.NonGeneric.dll'
// // ------------------
// // Resolve: 'System.Collections.Concurrent, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Collections.Concurrent, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Collections.Concurrent.dll'
// // ------------------
// // Resolve: 'System.ObjectModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.ObjectModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.ObjectModel.dll'
// // ------------------
// // Resolve: 'System.Collections.Specialized, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Collections.Specialized, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Collections.Specialized.dll'
// // ------------------
// // Resolve: 'System.ComponentModel.TypeConverter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.ComponentModel.TypeConverter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.ComponentModel.TypeConverter.dll'
// // ------------------
// // Resolve: 'System.ComponentModel.EventBasedAsync, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.ComponentModel.EventBasedAsync, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.ComponentModel.EventBasedAsync.dll'
// // ------------------
// // Resolve: 'System.ComponentModel.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.ComponentModel.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.ComponentModel.Primitives.dll'
// // ------------------
// // Resolve: 'System.ComponentModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.ComponentModel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.ComponentModel.dll'
// // ------------------
// // Resolve: 'Microsoft.Win32.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'Microsoft.Win32.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/Microsoft.Win32.Primitives.dll'
// // ------------------
// // Resolve: 'System.Console, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Console, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Console.dll'
// // ------------------
// // Resolve: 'System.Data.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Data.Common, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Data.Common.dll'
// // ------------------
// // Resolve: 'System.Runtime.InteropServices, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.InteropServices, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.InteropServices.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.TraceSource, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.TraceSource, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.TraceSource.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.Contracts, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.Contracts, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.Contracts.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.TextWriterTraceListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.TextWriterTraceListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.TextWriterTraceListener.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.FileVersionInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.FileVersionInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.FileVersionInfo.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.StackTrace, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.StackTrace, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.StackTrace.dll'
// // ------------------
// // Resolve: 'System.Diagnostics.Tracing, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Diagnostics.Tracing, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Diagnostics.Tracing.dll'
// // ------------------
// // Resolve: 'System.Drawing.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Drawing.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Drawing.Primitives.dll'
// // ------------------
// // Resolve: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Linq.Expressions.dll'
// // ------------------
// // Resolve: 'System.IO.Compression.Brotli, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Found single assembly: 'System.IO.Compression.Brotli, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.Compression.Brotli.dll'
// // ------------------
// // Resolve: 'System.IO.Compression, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Found single assembly: 'System.IO.Compression, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.Compression.dll'
// // ------------------
// // Resolve: 'System.IO.Compression.ZipFile, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Found single assembly: 'System.IO.Compression.ZipFile, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.Compression.ZipFile.dll'
// // ------------------
// // Resolve: 'System.IO.FileSystem.DriveInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.IO.FileSystem.DriveInfo, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.FileSystem.DriveInfo.dll'
// // ------------------
// // Resolve: 'System.IO.FileSystem.Watcher, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.IO.FileSystem.Watcher, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.FileSystem.Watcher.dll'
// // ------------------
// // Resolve: 'System.IO.IsolatedStorage, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.IO.IsolatedStorage, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.IO.IsolatedStorage.dll'
// // ------------------
// // Resolve: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Linq.dll'
// // ------------------
// // Resolve: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Linq.Queryable.dll'
// // ------------------
// // Resolve: 'System.Linq.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Linq.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Linq.Parallel.dll'
// // ------------------
// // Resolve: 'System.Threading.Thread, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Threading.Thread, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.Thread.dll'
// // ------------------
// // Resolve: 'System.Net.Requests, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Requests, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Requests.dll'
// // ------------------
// // Resolve: 'System.Net.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Primitives.dll'
// // ------------------
// // Resolve: 'System.Net.HttpListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Net.HttpListener, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.HttpListener.dll'
// // ------------------
// // Resolve: 'System.Net.ServicePoint, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Net.ServicePoint, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.ServicePoint.dll'
// // ------------------
// // Resolve: 'System.Net.NameResolution, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.NameResolution, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.NameResolution.dll'
// // ------------------
// // Resolve: 'System.Net.WebClient, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Net.WebClient, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.WebClient.dll'
// // ------------------
// // Resolve: 'System.Net.Http, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Http, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Http.dll'
// // ------------------
// // Resolve: 'System.Net.WebHeaderCollection, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.WebHeaderCollection, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.WebHeaderCollection.dll'
// // ------------------
// // Resolve: 'System.Net.WebProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Net.WebProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.WebProxy.dll'
// // ------------------
// // Resolve: 'System.Net.Mail, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Net.Mail, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Mail.dll'
// // ------------------
// // Resolve: 'System.Net.NetworkInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.NetworkInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.NetworkInformation.dll'
// // ------------------
// // Resolve: 'System.Net.Ping, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Ping, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Ping.dll'
// // ------------------
// // Resolve: 'System.Net.Security, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Security, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Security.dll'
// // ------------------
// // Resolve: 'System.Net.Sockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.Sockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.Sockets.dll'
// // ------------------
// // Resolve: 'System.Net.WebSockets.Client, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.WebSockets.Client, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.WebSockets.Client.dll'
// // ------------------
// // Resolve: 'System.Net.WebSockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Net.WebSockets, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Net.WebSockets.dll'
// // ------------------
// // Resolve: 'System.Runtime.Numerics, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.Numerics, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.Numerics.dll'
// // ------------------
// // Resolve: 'System.Numerics.Vectors, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Numerics.Vectors, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Numerics.Vectors.dll'
// // ------------------
// // Resolve: 'System.Reflection.DispatchProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Reflection.DispatchProxy, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Reflection.DispatchProxy.dll'
// // ------------------
// // Resolve: 'System.Reflection.Emit, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Reflection.Emit, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Reflection.Emit.dll'
// // ------------------
// // Resolve: 'System.Reflection.Emit.ILGeneration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Reflection.Emit.ILGeneration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Reflection.Emit.ILGeneration.dll'
// // ------------------
// // Resolve: 'System.Reflection.Emit.Lightweight, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Reflection.Emit.Lightweight, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Reflection.Emit.Lightweight.dll'
// // ------------------
// // Resolve: 'System.Reflection.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Reflection.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Reflection.Primitives.dll'
// // ------------------
// // Resolve: 'System.Resources.Writer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Resources.Writer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Resources.Writer.dll'
// // ------------------
// // Resolve: 'System.Runtime.CompilerServices.VisualC, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.CompilerServices.VisualC, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.CompilerServices.VisualC.dll'
// // ------------------
// // Resolve: 'System.Runtime.InteropServices.RuntimeInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.InteropServices.RuntimeInformation, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.InteropServices.RuntimeInformation.dll'
// // ------------------
// // Resolve: 'System.Runtime.Serialization.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.Serialization.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.Serialization.Primitives.dll'
// // ------------------
// // Resolve: 'System.Runtime.Serialization.Xml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.Serialization.Xml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.Serialization.Xml.dll'
// // ------------------
// // Resolve: 'System.Runtime.Serialization.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.Serialization.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.Serialization.Json.dll'
// // ------------------
// // Resolve: 'System.Runtime.Serialization.Formatters, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Runtime.Serialization.Formatters, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.Serialization.Formatters.dll'
// // ------------------
// // Resolve: 'System.Security.Claims, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Claims, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Claims.dll'
// // ------------------
// // Resolve: 'System.Security.Cryptography.Algorithms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Cryptography.Algorithms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Cryptography.Algorithms.dll'
// // ------------------
// // Resolve: 'System.Security.Cryptography.Csp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Cryptography.Csp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Cryptography.Csp.dll'
// // ------------------
// // Resolve: 'System.Security.Cryptography.Encoding, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Cryptography.Encoding, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Cryptography.Encoding.dll'
// // ------------------
// // Resolve: 'System.Security.Cryptography.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Security.Cryptography.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Security.Cryptography.Primitives.dll'
// // ------------------
// // Resolve: 'System.Text.Encoding.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Text.Encoding.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Text.Encoding.Extensions.dll'
// // ------------------
// // Resolve: 'System.Text.RegularExpressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Text.RegularExpressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Text.RegularExpressions.dll'
// // ------------------
// // Resolve: 'System.Threading, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Threading, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.dll'
// // ------------------
// // Resolve: 'System.Threading.Overlapped, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Threading.Overlapped, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.Overlapped.dll'
// // ------------------
// // Resolve: 'System.Threading.ThreadPool, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Threading.ThreadPool, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.ThreadPool.dll'
// // ------------------
// // Resolve: 'System.Threading.Tasks.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Threading.Tasks.Parallel, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Threading.Tasks.Parallel.dll'
// // ------------------
// // Resolve: 'System.Transactions.Local, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Transactions.Local, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Transactions.Local.dll'
// // ------------------
// // Resolve: 'System.Web.HttpUtility, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'System.Web.HttpUtility, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Web.HttpUtility.dll'
// // ------------------
// // Resolve: 'System.Xml.ReaderWriter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Xml.ReaderWriter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Xml.ReaderWriter.dll'
// // ------------------
// // Resolve: 'System.Xml.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Xml.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Xml.XDocument.dll'
// // ------------------
// // Resolve: 'System.Xml.XmlSerializer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Xml.XmlSerializer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Xml.XmlSerializer.dll'
// // ------------------
// // Resolve: 'System.Xml.XPath.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Xml.XPath.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Xml.XPath.XDocument.dll'
// // ------------------
// // Resolve: 'System.Xml.XPath, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Found single assembly: 'System.Xml.XPath, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Xml.XPath.dll'
// // ------------------
// // Resolve: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Found single assembly: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/netstandard.dll'
// // ------------------
// // Resolve: 'System.Runtime.CompilerServices.Unsafe, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null'
// // Found single assembly: 'System.Runtime.CompilerServices.Unsafe, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
// // WARN: Version mismatch. Expected: '2.0.0.0', Got: '6.0.0.0'
// // Load from: '/Users/leo-imac/.nuget/packages/microsoft.netcore.app.ref/6.0.29/ref/net6.0/System.Runtime.CompilerServices.Unsafe.dll'
// // #endif
