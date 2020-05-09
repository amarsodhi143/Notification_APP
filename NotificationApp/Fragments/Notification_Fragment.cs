using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using NotificationApp.Lib;
using NotificationApp.Model;
using RestSharp;

namespace NotificationApp.Fragments
{
    public class Notification_Fragment : BaseFragment
    {
        public Notification_Fragment(AppCompatActivity context) : base(context)
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

            return inflater.Inflate(Resource.Layout.notification_fragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var handler = new Handler();
            Action callback = null;

            var textView = view.FindViewById<TextView>(Resource.Id.textView);

            view.FindViewById<Button>(Resource.Id.btnSubmit).Click += (sender, e) =>
            {
                callback = () =>
                {
                    BaseActivity.ShowSuccessMessage(_BaseContext, "Start Call Back");

                    var next2Days = DateTime.Now.AddDays(2);
                    var notifications = new SqlHelper().GetAllData<NotificationModel>(x => x.Date <= next2Days).ToList();

                    var message = string.Empty;
                    foreach (var item in notifications)
                    {
                        message += "Your " + item.Name + " will expire on " + item.Date.Value.ToString("dd/MMM/yyyy") + "\r\n";
                    }

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        var url = "https://www.fast2sms.com/dev/bulk";
                        url += "?authorization=t3DJ45qSxmbNci2F7YrMHhw0LdRAy98EfBUXjeCuKZazlnOv1sbgWvV581DGnHxBKZM64SPpocihImOJ";
                        url += "&sender_id=FSTSMS";
                        url += "&message=" + message;
                        url += "&language=english&route=p";
                        url += "&numbers=7009741360";

                        var client = new RestClient(url);
                        var request = new RestRequest(Method.GET);
                        IRestResponse response = client.Execute(request);

                        SaveNotificationLog(response.Content);
                    }

                    BaseActivity.ShowSuccessMessage(_BaseContext, "Next Call Back " + notifications.Count);

                    handler.PostDelayed(callback, 86400000); // 24 Hours
                };

                handler.PostDelayed(callback, 1000);

                textView.Text = "Service Working";
            };

            view.FindViewById<Button>(Resource.Id.btnCancel).Click += (sender, e) =>
            {
                handler.RemoveCallbacksAndMessages(null);
                textView.Text = "Service Stopped";
            };
        }

        private void SaveNotificationLog(string content)
        {
            var messageToken = JToken.Parse(content)["message"];
            var notificationLog = new NotificationLog
            {
                IsSuccess = JToken.Parse(content)["return"].Value<bool>(),
                RequestId = Convert.ToString(JToken.Parse(content)["request_id"]),
                StatusCode = Convert.ToString(JToken.Parse(content)["status_code"]),
                Message = messageToken.HasValues ? string.Join(", ", messageToken.Values()) : messageToken.Value<string>(),
                Date = DateTime.Now
            };

            var sqlHelper = new SqlHelper();
            var errorMsg = sqlHelper.InsertData(notificationLog);
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                BaseActivity.ShowSuccessMessage(_BaseContext, errorMsg);
            }
        }
    }
}