using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NotificationApp.Fragments
{
    public class Dashboard_Fragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.dashboard_fragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //new Thread(new ThreadStart(delegate
            //{
            //    context.RunOnUiThread(() =>
            //    {

            //    });
            //})).Start();

        }
    }
}