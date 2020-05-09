using System.Linq;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using NotificationApp.Lib;
using NotificationApp.Model;

namespace NotificationApp.Fragments
{
    public class Notification_List_Fragment : BaseFragment
    {
        public Notification_List_Fragment(AppCompatActivity context) : base(context)
        {

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            return inflater.Inflate(Resource.Layout.notification_list_fragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var data = new SqlHelper().GetAllData<NotificationModel>();

            var sfDataGrid = new SfDataGrid(_BaseContext);

            sfDataGrid.Columns = data.Table.Columns.Select(x => x.Name).ToList();
            sfDataGrid.ItemsSource = data;

            var linearLeayout = view.FindViewById<LinearLayout>(Resource.Id.lLayoutList);
            linearLeayout.AddView(sfDataGrid);
        }
    }
}