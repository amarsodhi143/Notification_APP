using System;
using System.Linq;
using System.IO;
using System.Threading;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using NotificationApp.Lib;
using NotificationApp.Model;

namespace NotificationApp.Fragments
{
    public class Notification_Panel_Fragment : BaseFragment
    {
        public Notification_Panel_Fragment(AppCompatActivity context) : base(context)
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

            return inflater.Inflate(Resource.Layout.notification_panel_fragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var txtDate = view.FindViewById<TextInputEditText>(Resource.Id.txtDate);
            txtDate.Click += (sender, e) =>
            {
                DatePickerFragment frag = new DatePickerFragment(delegate (DateTime time)
                {
                    txtDate.Text = time.ToString("dd/MM/yyyy");
                });
                frag.Show(FragmentManager, DatePickerFragment.TAG);
            };

            view.FindViewById<Button>(Resource.Id.btnSubmitButton).Click += delegate
            {
                var dialog = BaseActivity.ShowProgressDialog();

                new Thread(new ThreadStart(delegate
                {
                    var dbNotificationModel = new NotificationModel
                    {
                        Name = view.FindViewById<TextInputEditText>(Resource.Id.txtName).Text,
                        Description = view.FindViewById<TextInputEditText>(Resource.Id.txtDescription).Text,
                        Date = Convert.ToDateTime(txtDate.Text)
                    };

                    var sqlHelper = new SqlHelper();
                    var errorMsg = sqlHelper.InsertData(dbNotificationModel);

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        _BaseContext.RunOnUiThread(() => BaseActivity.ShowSuccessMessage(_BaseContext, errorMsg));
                        dialog.Dismiss();
                        return;
                    }
                    else
                    {
                        _BaseContext.RunOnUiThread(() =>
                        {
                            _BaseContext.RunOnUiThread(() => BaseActivity.ClearFields(view.FindViewById<LinearLayout>(Resource.Id.lLayoutNotification)));
                            Toast.MakeText(_BaseContext, "Record saved successfully", ToastLength.Long).Show();
                        });

                        dialog.Dismiss();
                    }
                })).Start();
            };
        }
    }
}