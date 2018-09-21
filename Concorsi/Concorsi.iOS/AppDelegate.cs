using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Concorsi.iOS;
using Xamarin.Forms.Platform.iOS;
using ImageCircle.Forms.Plugin.iOS;
using static Concorsi.iOS.AppDelegate;
using System.Threading.Tasks;
using System.ComponentModel;
using Xfx;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
namespace Concorsi.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUIApplicationDelegate
    {
        // Variabile necessaria per notificare nel caso vengano eseguiti screenshot
        NSObject _screenshotNotification = null;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override void OnResignActivation(UIApplication application)
        {
            var view = new UIView(Window.Frame)
            {
                Tag = new nint(101),
                BackgroundColor = UIColor.White
            };
            Window.AddSubview(view);
            Window.BringSubviewToFront(view);

            // Rimuovi se necessario
            try
            {
                // Stop observer
                if (_screenshotNotification != null)
                {
                    NSNotificationCenter.DefaultCenter.RemoveObserver(_screenshotNotification);
                    _screenshotNotification.Dispose();
                    _screenshotNotification = null;
                }
            }
            catch (Exception ex)
            {
                //Do something
            }
        }

        // Remove window hiding app content when app is resumed
        public override void OnActivated(UIApplication application)
        {
            var view = Window.ViewWithTag(new nint(101));
            view?.RemoveFromSuperview();

            // Start observing screenshot notification
            // Rimuovi tutto se necessario
            try
            {
                // Start observing screenshot notification
                if (_screenshotNotification == null)
                {
                    _screenshotNotification = NSNotificationCenter.DefaultCenter.AddObserver(
                        UIApplication.UserDidTakeScreenshotNotification,
                                (NSNotification n) => {
                                    Console.WriteLine("UserDidTakeScreenshotNotification");
                                    n.Dispose();
                                });
                }
            }
            catch (Exception ex)
            {
                //Do something
            }
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            XfxControls.Init();

            LoadApplication(new App());
            ImageCircleRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfSegmentedControlRenderer.Init();
            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            // Serve per non far andare l'applicazione in onSleep automaticamente
            UIApplication.SharedApplication.IdleTimerDisabled = true;
            return base.FinishedLaunching(app, options);
        }

        public class MyButtonRenderer : ButtonRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    Control.TitleLabel.LineBreakMode = UIKit.UILineBreakMode.WordWrap;
                    Control.TitleLabel.LineBreakMode = UILineBreakMode.CharacterWrap;
                    Control.TitleLabel.TextAlignment = UITextAlignment.Center;
                    Control.TitleLabel.Lines = 0;
                }
            }
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (Control != null)
                    Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Normal);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Application);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Disabled);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Focused);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Highlighted);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Selected);
                Control.SetTitleColor(Color.White.ToUIColor(), UIControlState.Reserved);
            }
        }
    }
}
