package crc64f0e155b6502ec419;


public class IssuedGoodsBusinessEventSetup
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		com.toptoche.searchablespinnerlibrary.SearchableListDialog.OnSearchTextChanged
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"n_onSearchTextChanged:(Ljava/lang/String;)V:GetOnSearchTextChanged_Ljava_lang_String_Handler:Com.Toptoche.Searchablespinnerlibrary.SearchableListDialog/IOnSearchTextChangedInvoker, EDMTBinding\n" +
			"";
		mono.android.Runtime.register ("Scanner.IssuedGoodsBusinessEventSetup, WMS", IssuedGoodsBusinessEventSetup.class, __md_methods);
	}


	public IssuedGoodsBusinessEventSetup ()
	{
		super ();
		if (getClass () == IssuedGoodsBusinessEventSetup.class)
			mono.android.TypeManager.Activate ("Scanner.IssuedGoodsBusinessEventSetup, WMS", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);


	public void onSearchTextChanged (java.lang.String p0)
	{
		n_onSearchTextChanged (p0);
	}

	private native void n_onSearchTextChanged (java.lang.String p0);

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
