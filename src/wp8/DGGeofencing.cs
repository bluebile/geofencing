namespace Cordova.Extension.Commands
{
	public class DGGeofencing : BaseCommand
    {

    	public string CurrentCommandCallbackId { get; set; }
    	public static Geolocator Geolocator { get; set; }
		public static bool RunningInBackground { get; set; }


    	public BaseCommand()
        {
            PhoneApplicationService service = PhoneApplicationService.Current;
            service.RunningInBackground += this.Application_RunningInBackground;
            if (App.Geolocator == null)
		    {
		        App.Geolocator = new Geolocator();
		        App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
		        App.Geolocator.MovementThreshold = 10; // The units are meters.
		        App.Geolocator.PositionChanged += geolocator_PositionChanged;
		    }
        }

        public void initCallbackForRegionMonitoring(string options)
        {
            
        }

        public void startMonitoringSignificantLocationChanges(string options)
        {
            
        }

        public void Application_RunningInBackground(object sender, RunningInBackgroundEventArgs args)
		{
		    RunningInBackground = true;
		    // Suspend all unnecessary processing such as UI updates
		}

		void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
		{

		    if (!App.RunningInBackground)
		    {
		        Dispatcher.BeginInvoke(() =>
		        {
		        	System.Diagnostics.Debug.WriteLine("======= Geolocator =======");
		            System.Diagnostics.Debug.WriteLine(args.Position.Coordinate.Latitude.ToString("0.00"));
		            System.Diagnostics.Debug.WriteLine(args.Position.Coordinate.Longitude.ToString("0.00"));
		        });
		    }
		    else
		    {
		    	System.Diagnostics.Debug.WriteLine("======= Geolocator RunningInBackground =======");
		        Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
		        System.Diagnostics.Debug.WriteLine(args.Position.Coordinate.Latitude.ToString("0.00"));
	            System.Diagnostics.Debug.WriteLine(args.Position.Coordinate.Longitude.ToString("0.00"));
		    }
		}
    }
}