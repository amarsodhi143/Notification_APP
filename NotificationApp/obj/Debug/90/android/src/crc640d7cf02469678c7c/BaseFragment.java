package crc640d7cf02469678c7c;


public class BaseFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NotificationApp.Fragments.BaseFragment, NotificationApp", BaseFragment.class, __md_methods);
	}


	public BaseFragment ()
	{
		super ();
		if (getClass () == BaseFragment.class)
			mono.android.TypeManager.Activate ("NotificationApp.Fragments.BaseFragment, NotificationApp", "", this, new java.lang.Object[] {  });
	}

	public BaseFragment (android.support.v7.app.AppCompatActivity p0)
	{
		super ();
		if (getClass () == BaseFragment.class)
			mono.android.TypeManager.Activate ("NotificationApp.Fragments.BaseFragment, NotificationApp", "Android.Support.V7.App.AppCompatActivity, Xamarin.Android.Support.v7.AppCompat", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
