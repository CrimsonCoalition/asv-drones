using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform;
using FluentAvalonia.UI.Windowing;
using System;
using System.ComponentModel;
using Avalonia.Media.Imaging;
using Avalonia.Media.Immutable;
using FluentAvalonia.Styling;
using FluentAvalonia.UI.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Asv.Cfg;
using Asv.Drones.Gui.Core;
using Avalonia.Platform.Storage;

namespace Asv.Drones.Gui
{
    public class ShellViewConfig
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool IsMaximized { get; set; }
    }
    

    public partial class MainWindow : AppWindow
    {
        private readonly IConfiguration _configuration;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            MinWidth = 450;
            MinHeight = 400;
            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
        }

        
        public MainWindow(IConfiguration configuration) : this()
        {
            _configuration = configuration;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            ShellViewConfig shellViewConfig;

            if (this.WindowState == WindowState.Maximized)
            {
                shellViewConfig = new ShellViewConfig
                {
                    IsMaximized = true
                };
            }
            else
            {
                shellViewConfig = new ShellViewConfig
                {
                    Height = Height,
                    Width = Width,
                    PositionX = Position.X,
                    PositionY = Position.Y
                };
            }

            _configuration.Set(nameof(ShellViewConfig), shellViewConfig);
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

            var thm = AvaloniaLocator.Current.GetService<FluentAvaloniaTheme>();
            thm.RequestedThemeChanged += OnRequestedThemeChanged;
            thm.RequestedTheme = "Dark";
            // Enable Mica on Windows 11
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // TODO: add Windows version to CoreWindow
                if (IsWindows11 && thm.RequestedTheme != FluentAvaloniaTheme.HighContrastModeString)
                {
                    TransparencyBackgroundFallback = Brushes.Transparent;
                    TransparencyLevelHint = WindowTransparencyLevel.Mica;

                    TryEnableMicaEffect(thm);
                }
            }

            // thm.ForceWin32WindowToTheme(this);

            var screen = Screens.ScreenFromVisual(this);
            if (screen != null)
            {
                double width = Width;
                double height = Height;

                if (screen.WorkingArea.Width > 1280)
                {
                    width = 1280;
                }
                else if (screen.WorkingArea.Width > 1000)
                {
                    width = 1000;
                }
                else if (screen.WorkingArea.Width > 700)
                {
                    width = 700;
                }
                else if (screen.WorkingArea.Width > 500)
                {
                    width = 500;
                }
                else
                {
                    width = 450;
                }

                if (screen.WorkingArea.Height > 720)
                {
                    width = 720;
                }
                else if (screen.WorkingArea.Height > 600)
                {
                    width = 600;
                }
                else if (screen.WorkingArea.Height > 500)
                {
                    width = 500;
                }
                else
                {
                    width = 400;
                }
            }

            if (!_configuration.Exist<ShellViewConfig>(nameof(ShellViewConfig))) return;
            
            var shellViewConfig = _configuration.Get<ShellViewConfig>(nameof(ShellViewConfig));

            if (shellViewConfig.IsMaximized)
            {
                WindowState = WindowState.Maximized;
                return;
            }

            var totalWidth = 0;
            var totalHeight = 0;

            foreach (var scr in Screens.All)
            {
                totalWidth += scr.Bounds.Width;
                totalHeight += scr.Bounds.Height;
            }

            if (shellViewConfig.PositionX > totalWidth || shellViewConfig.PositionY > totalHeight)
            {
                Position = new PixelPoint(0, 0);
            }
            else
            {
                Position = new PixelPoint(shellViewConfig.PositionX, shellViewConfig.PositionY);
            }

            if (shellViewConfig.Height > totalHeight || shellViewConfig.Width > totalWidth)
            {
                var scrBounds = Screens.Primary.Bounds;
                    
                Height = scrBounds.Height * 0.9;
                Width = scrBounds.Width * 0.9;
                    
                Position = new PixelPoint(0, 0);
            }
            else
            {
                Height = shellViewConfig.Height;
                Width = shellViewConfig.Width;
            }
        }

        protected override void OnRequestedThemeChanged(FluentAvaloniaTheme sender, RequestedThemeChangedEventArgs args)
        {
            base.OnRequestedThemeChanged(sender, args);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // TODO: add Windows version to CoreWindow
                if (IsWindows11 && args.NewTheme != FluentAvaloniaTheme.HighContrastModeString)
                {
                    TryEnableMicaEffect(sender);
                }
                else if (args.NewTheme == FluentAvaloniaTheme.HighContrastModeString)
                {
                    // Clear the local value here, and let the normal styles take over for HighContrast theme
                    SetValue(BackgroundProperty, AvaloniaProperty.UnsetValue);
                }
            }
        }

        private void TryEnableMicaEffect(FluentAvaloniaTheme thm)
        {

            // The background colors for the Mica brush are still based around SolidBackgroundFillColorBase resource
            // BUT since we can't control the actual Mica brush color, we have to use the window background to create
            // the same effect. However, we can't use SolidBackgroundFillColorBase directly since its opaque, and if
            // we set the opacity the color become lighter than we want. So we take the normal color, darken it and 
            // apply the opacity until we get the roughly the correct color
            // NOTE that the effect still doesn't look right, but it suffices. Ideally we need access to the Mica
            // CompositionBrush to properly change the color but I don't know if we can do that or not
            if (thm.RequestedTheme == FluentAvaloniaTheme.DarkModeString)
            {
                var color = this.TryFindResource("SolidBackgroundFillColorBase", out var value) ? (Color2)(Color)value : new Color2(32, 32, 32);

                color = color.LightenPercent(-0.8f);

                Background = new ImmutableSolidColorBrush(color, 0.78);
            }
            else if (thm.RequestedTheme == FluentAvaloniaTheme.LightModeString)
            {
                // Similar effect here
                var color = this.TryFindResource("SolidBackgroundFillColorBase", out var value) ? (Color2)(Color)value : new Color2(243, 243, 243);

                color = color.LightenPercent(0.5f);

                Background = new ImmutableSolidColorBrush(color, 0.9);
            }
        }

    }
}
