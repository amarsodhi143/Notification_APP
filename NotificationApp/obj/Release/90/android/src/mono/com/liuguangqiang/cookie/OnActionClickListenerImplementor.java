package mono.com.liuguangqiang.cookie;


public class OnActionClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.liuguangqiang.cookie.OnActionClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:()V:GetOnClickHandler:Com.Liuguangqiang.Cookie.IOnActionClickListenerInvoker, CookieBar\n" +
			"";
		mono.android.Runtime.register ("Com.Liuguangqiang.Cookie.IOnActionClickListenerImplementor, CookieBar", OnActionClickListenerImplementor.class, __md_methods);
	}


	public OnActionClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnActionClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Liuguangqiang.Cookie.IOnActionClickListenerImplementor, CookieBar", "", this, new java.lang.Object[] {  });
	}


	public void onClick ()
	{
		n_onClick ();
	}

	private native void n_onClick ();

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
