namespace Presentation_MAUI_BLAZOR
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();
      }

      protected override Window CreateWindow(IActivationState? activationState)
      {
         // CoPilot helped out to get the application to start in full screen mode
         var window = new Window(new MainPage())
         {
            Title = "NET-WIN24 Project Manager Application",
            X = 0,
            Y = 0,
         };

         var displayInfo = DeviceDisplay.MainDisplayInfo;
         window.Width = displayInfo.Width / displayInfo.Density;
         window.Height = displayInfo.Height / displayInfo.Density;

         return window;
      }
   }
}
