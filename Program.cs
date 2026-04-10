using Avalonia;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Controls.ApplicationLifetimes;
namespace Accounting
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Environment.OSVersion.Version.Build < 22000)
                {
                    ShowErrorDialog("This application requires Windows 11 or later.");
                    return;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    var psi = new ProcessStartInfo("uname", "-r")
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    using var process = Process.Start(psi);
                    if (process != null)
                    {
                        string output = process.StandardOutput.ReadToEnd().Trim();
                        process.WaitForExit();
                        if (!string.IsNullOrEmpty(output))
                        {
                            string kernelVersion = output.Split('-')[0];
                            if (Version.TryParse(kernelVersion, out var version))
                            {
                                if (version.Major < 5 || (version.Major == 5 && version.Minor < 15))
                                {
                                    ShowErrorDialog("This application requires Linux kernel 5.15 or later.");
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    ShowErrorDialog("Unable to verify system requirements. Please ensure your system meets the minimum requirements.");
                    return;
                }
            }

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        private static void ShowErrorDialog(string message)
        {
            var appBuilder = BuildAvaloniaApp().SetupWithoutStarting();
            Application app = appBuilder.Instance!;
            var window = new Window
            {
                Title = "System Requirement Not Met",
                Width = 400,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = new StackPanel
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap },
                        new Button { Content = "OK", HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0,20,0,0) }
                    }
                }
            };
            var button = (Button)((StackPanel)window.Content).Children[1];
            button.Click += (_, _) => window.Close();
            window.Closed += (_, _) => 
            {
                if (app.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime lifetime)
                {
                    lifetime.Shutdown();
                }
            };
            app.Run(window);
        }

        private static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}
