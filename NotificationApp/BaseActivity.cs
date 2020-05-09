using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android;
using Android.Content.PM;
using Com.Liuguangqiang.Cookie;
using Taishi.FlipProgressDialogLib;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace NotificationApp
{
    [Activity(Label = "BaseActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class BaseActivity : AppCompatActivity
    {
        static FragmentManager fManager;

        public enum PopupActions
        {
            Exit = 0,
            Location = 1,
            Settings = 2,
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //AppCenter.Start("15a5cdc8-fead-41cc-b33c-b820ed4b7ec0", typeof(Analytics), typeof(Crashes));

            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }

            fManager = this.FragmentManager;

            // Create your application here
        }

        public static void ShowSuccessMessage(AppCompatActivity context, string message)
        {
            ShowMessage(context, "Success", message);
        }

        public static void ShowErrorMessage(AppCompatActivity context, string message)
        {
            ShowMessage(context, "Error", message);
        }

        public static void ShowMessage(AppCompatActivity context, string title, string message)
        {
            new CookieBar.Builder(context)
                  .SetTitle(title)
                  .SetMessage(message)
                  .SetBackgroundColor(Resource.Color.white)
                  .SetIcon(Resource.Drawable.ic_navigate_next_orange_400_36dp)
                  .SetMessageColor(Resource.Color.primary)
                  .SetTitleColor(Resource.Color.primaryDark)
                  .SetLayoutGravity((int)GravityFlags.Bottom)
                  .Show();
        }

        public static FlipProgressDialog ShowProgressDialog()
        {
            List<int> imageList = new List<int>();
            imageList.Add(Resource.Drawable.Wait_1);
            imageList.Add(Resource.Drawable.Wait2_2);

            FlipProgressDialog fpd = new FlipProgressDialog();
            fpd.SetImageList(imageList);
            fpd.SetCanceledOnTouchOutside(false);
            fpd.SetBackgroundColor(Color.ParseColor("#f5bf86"));
            fpd.FullRound();
            fpd.SetBorderStroke(0);
            fpd.SetBorderColor(-1);
            fpd.SetCornerRadius(16);
            fpd.SetImageSize(200);
            fpd.SetImageMargin(20);
            fpd.SetOrientation("rotationY");
            fpd.SetDuration(800);
            fpd.SetStartAngle(0.0f);
            fpd.SetEndAngle(180.0f);
            fpd.SetMinAlpha(0.0f);
            fpd.SetMaxAlpha(1.0f);
            fpd.Show(fManager, "");
            return fpd;
        }

        public static void ClearFields(ViewGroup group)
        {
            for (int i = 0; i < group.ChildCount; i++)
            {
                View view = group.GetChildAt(i);
                if (view.GetType() == typeof(EditText))
                {
                    ((EditText)view).Text = string.Empty;
                }
                if (view.GetType() == typeof(AppCompatEditText))
                {
                    ((EditText)view).Text = string.Empty;
                }
                else if (view.GetType() == typeof(TextInputEditText))
                {
                    ((TextInputEditText)view).Text = string.Empty;
                }
                else if (view as ViewGroup != null && (((ViewGroup)view).ChildCount > 0))
                {
                    ClearFields((ViewGroup)view);
                }
            }
        }

        public static void TrackCrashError(Exception ex)
        {
            Crashes.TrackError(ex);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}