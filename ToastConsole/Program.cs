using System;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;

// This example code shows how you could implement the required main function for a 
// Console UWP Application. You can replace all the code inside Main with your own custom code.

// You should also change the Alias value in the AppExecutionAlias Extension in the 
// Package.appxmanifest to a value that you define. To edit this file manually, right-click
// it in Solution Explorer and select View Code, or open it with the XML Editor.

namespace ToastConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = "Hello UWP Console";
            var content = "Sample toast launched from UWP Console app";
            if (args.Length >= 2)
            {
                title = args[0];
                content = args[1];
            }
            else if (args.Length == 1)
            {
                content = args[0];
            }
            ShowToast(title,content);
            Console.WriteLine("Press a key to continue: ");
            Console.ReadLine();
        }

        static void ShowToast(string title, string content)
        {
            ToastVisual visual = new ToastVisual
            {
                BindingGeneric = new ToastBindingGeneric
                {
                    Children =
                    {
                        new AdaptiveText
                        {
                            Text = title
                        },

                        new AdaptiveText
                        {
                            Text = content
                        }
                    }
                }
            };
            ToastContent toastContent = new ToastContent
            {
                Visual = visual,
            };

            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
