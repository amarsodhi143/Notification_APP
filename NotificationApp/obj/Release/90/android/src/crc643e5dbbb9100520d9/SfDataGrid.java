package crc643e5dbbb9100520d9;


public class SfDataGrid
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NotificationApp.Lib.SfDataGrid, NotificationApp", SfDataGrid.class, __md_methods);
	}


	public SfDataGrid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfDataGrid.class)
			mono.android.TypeManager.Activate ("NotificationApp.Lib.SfDataGrid, NotificationApp", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfDataGrid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfDataGrid.class)
			mono.android.TypeManager.Activate ("NotificationApp.Lib.SfDataGrid, NotificationApp", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfDataGrid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfDataGrid.class)
			mono.android.TypeManager.Activate ("NotificationApp.Lib.SfDataGrid, NotificationApp", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
