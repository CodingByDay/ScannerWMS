package crc649f1916a4b4635b36;


public class TakeOver2OrdersTablet
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ScannerQR.TakeOver2OrdersTablet, WMSScanner", TakeOver2OrdersTablet.class, __md_methods);
	}


	public TakeOver2OrdersTablet ()
	{
		super ();
		if (getClass () == TakeOver2OrdersTablet.class)
			mono.android.TypeManager.Activate ("ScannerQR.TakeOver2OrdersTablet, WMSScanner", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
