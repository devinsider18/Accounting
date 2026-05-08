using Avalonia;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
namespace Accounting
{
    internal class Program
    {
        private const int ErrorExitCode = 1;
        [STAThread]
        public static int Main(string[] args)
        {
            var (isSupported, errorMessage) = CheckSystemRequirements();
            if (!isSupported)
            {
                ShowFluentError(errorMessage);
                return ErrorExitCode;
            }
            try
            {
                BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ErrorExitCode;
            }
        }
        private static void ShowFluentError(string message)
        {
            var appBuilder = BuildAvaloniaApp().SetupWithoutStarting();
            var window = new Window
            {
                Title = "System Error",
                Width = 400,
                SizeToContent = SizeToContent.Height,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                CanResize = false,
                SystemDecorations = SystemDecorations.Full,
                Content = new Grid
                {
                    Margin = new Thickness(24),
                    ColumnDefinitions = new ColumnDefinitions("Auto,*"),
                    RowDefinitions = new RowDefinitions("*,Auto"),
                    Children = 
                    {
                        new SymbolIcon
                        {
                            Symbol = Symbol.Dismiss, 
                            FontSize = 40,
                            Foreground = Brushes.Red,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin = new Thickness(0,0,16,0)
                        },
                        new TextBlock
                        {
                            [Grid.ColumnProperty] = 1,
                            Text = message,
                            TextWrapping = TextWrapping.Wrap,
                            FontSize = 14,
                            VerticalAlignment = VerticalAlignment.Center
                        },
                        new Button
                        {
                            [Grid.RowProperty] = 1,
                            [Grid.ColumnSpanProperty] = 2,
                            Content = "OK",
                            Width = 80,
                            HorizontalAlignment = HorizontalAlignment.Right,
                            Margin = new Thickness(0,24,0,0),
                            Classes = { "accent" } 
                        }
                    }
                }
            };
            var okButton = (Button)((Grid)window.Content).Children[2];
            okButton.Click += (_, _) => window.Close();
            appBuilder.Instance!.Run(window); 
        }
        private static (bool IsSupported, string Message) CheckSystemRequirements()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Environment.OSVersion.Version.Build < 19045)
                    return (false, "This application requires Windows 10 22H2 or later.");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var kernelVersion = GetLinuxKernelVersion();
                if (kernelVersion == null || kernelVersion < new Version(5, 15))
                    return (false, "This application requires Linux kernel 5.15 or later.");
            }
            return (true, string.Empty);
        }
        private static Version? GetLinuxKernelVersion()
        {
            try
            {
                var psi = new ProcessStartInfo("uname", "-r") { RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true };
                using var process = Process.Start(psi);
                if (process != null)
                {
                    string output = process.StandardOutput.ReadToEnd().Split('-')[0];
                    if (Version.TryParse(output, out var version)) return version;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return null;
        }
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}