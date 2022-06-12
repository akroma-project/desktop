using PhotinoNET;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Api.Model;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using Api.Commands;
using System.Linq;

namespace HelloPhotinoReact
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var mediator = BuildMediator();

            // Window title declared here for visibility
            string windowTitle = "Akroma Desktop";

            // Creating a new PhotinoWindow instance with the fluent API
            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                .SetUseOsDefaultSize(false) 
                // Resize to a percentage of the main monitor work area
                .SetSize(800, 600)
                // Center window in the middle of the screen
                .Center()
                // method like the following RegisterWebMessageReceivedHandler.
                // This could be added in the PhotinoWindowOptions if preferred.
                .RegisterWebMessageReceivedHandler(async (object sender, string message) => {
                    var window = (PhotinoWindow)sender;
                    var windowMessage = JsonSerializer.Deserialize<WindowMessage>(message);

                    var match = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where type.FullName == windowMessage.Command
                    select type).FirstOrDefault();

                    if (match == null) {
                        window.SendWebMessage("{\"error\":\"Command not found\"}");
                        return;
                    }

                    var cmd = Activator.CreateInstance(match);

                    var command = JsonSerializer.Deserialize(windowMessage.Data.ToString(), cmd.GetType());
                    
                    var response = await mediator.Send(command);
                    
                    window.SendWebMessage(JsonSerializer.Serialize(response));
                   
                })
                .Load("build/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.

            window.WaitForClose(); // Starts the application event loop
        }

        private static IMediator BuildMediator()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<CreateWalletCommand>();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestExceptionAction<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestExceptionHandler<,,>));
                });

                //Pipeline
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestExceptionProcessorBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestExceptionActionProcessorBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPreProcessorBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPostProcessorBehavior<,>));
            
                // This is the default but let's be explicit. At most we should be container scoped.
                cfg.For<IMediator>().Use<Mediator>().Transient();

                cfg.For<ServiceFactory>().Use(ctx => ctx.GetInstance);
            });

            var mediator = container.GetInstance<IMediator>();

            return mediator;
        }
    }
}
