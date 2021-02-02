package crc640b2286ca4f1c700f;


public class IssuedGoodsIdentEntryWithTrailTablet
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ScannerQR.IssuedGoodsIdentEntryWithTrailTablet, ScannerQR", IssuedGoodsIdentEntryWithTrailTablet.class, __md_methods);
	}


	public IssuedGoodsIdentEntryWithTrailTablet ()
	{
		super ();
		if (getClass () == IssuedGoodsIdentEntryWithTrailTablet.class)
			mono.android.TypeManager.Activate ("ScannerQR.IssuedGoodsIdentEntryWithTrailTablet, ScannerQR", "", this, new java.lang.Object[] {  });
	}


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);


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
