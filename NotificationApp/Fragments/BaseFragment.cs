using Android.Support.V4.App;
using Android.Support.V7.App;

namespace NotificationApp.Fragments
{
    public class BaseFragment : Fragment
    {
        public static AppCompatActivity _BaseContext;

        public BaseFragment(AppCompatActivity context)
        {
            _BaseContext = context;
        }
    }
}