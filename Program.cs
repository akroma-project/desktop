using PhotinoNET;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Api.Model;

namespace HelloPhotinoReact
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Window title declared here for visibility
            string windowTitle = "Photino.Vue Demo App";

            // Creating a new PhotinoWindow instance with the fluent API
            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                // Resize to a percentage of the main monitor work area
                //.Resize(50, 50, "%")
                // Center window in the middle of the screen
                .Center()
                // Users can resize windows by default.
                // Let's make this one fixed instead.
                // .SetResizable(false)
                // .RegisterCustomSchemeHandler("app", (object sender, string scheme, string url, out string contentType) =>
                // {
                //     contentType = "text/javascript";
                //     return new MemoryStream(Encoding.UTF8.GetBytes(@"
                //         (() =>{
                //             window.setTimeout(() => {
                //                 alert(`🎉 Dynamically inserted JavaScript.`);
                //             }, 1000);
                //         })();
                //     "));
                // })
                // Most event handlers can be registered after the
                // PhotinoWindow was instantiated by calling a registration 
                // method like the following RegisterWebMessageReceivedHandler.
                // This could be added in the PhotinoWindowOptions if preferred.
                .RegisterWebMessageReceivedHandler((object sender, string message) => {
                    var window = (PhotinoWindow)sender;
                    // var windowMessage = JsonSerializer.Deserialize<WindowMessage>(message);
                    Console.WriteLine($"Received message: {message}");
                    // switch (wm.Command){
                    //     case "getInitialPath" :{
                    //         var userHome = FileSystem.GetUserHome();
                            
                    //         FileSystem fs = new FileSystem(userHome);
                    //         var response = new {command=wm.Command,data=userHome,fsi=fs.GetAllFileSystemItems()};
                    //         //Console.WriteLine(JsonSerializer.Serialize(fs.GetAllFileSystemItems()));
                            
                    //         //fs.GetAllFileSystemItems();
                    //         window.SendWebMessage(JsonSerializer.Serialize( response));
                    //         break;
                    //     }
                    //     case "getPathData" :{
                    //         FileSystem fs = new FileSystem(wm.Data);
                    //         var outPath = wm.Data;
                            
                    //         var response = new {command=wm.Command,data=outPath,fsi=fs.GetAllFileSystemItems()};
                    //         window.SendWebMessage(JsonSerializer.Serialize(response));
                    //         break;
                    //     }
                    //     default:{
                    //         // The message argument is coming in from sendMessage.
                    //         // "window.external.sendMessage(message: string)"
                    //          var response = new {command=wm.Command,
                    //             data=wm.Data};
                    //         // Send a message back the to JavaScript event handler.
                    //         // "window.external.receiveMessage(callback: Function)"
                    //         window.SendWebMessage(JsonSerializer.Serialize( response));
                    //         break;
                    //     }                        
                    // }
                    // The message argument is coming in from sendMessage.
                    // "window.external.sendMessage(message: string)"
                    string response = $"Received message: \"{message}\"";

                    // Send a message back the to JavaScript event handler.
                    // "window.external.receiveMessage(callback: Function)"
                    window.SendWebMessage(response);
                })
                .Load("build/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.

            window.WaitForClose(); // Starts the application event loop
        }
    }
}
