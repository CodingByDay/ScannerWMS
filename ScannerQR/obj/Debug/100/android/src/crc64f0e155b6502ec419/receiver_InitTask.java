package crc64f0e155b6502ec419;


public class receiver_InitTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"";
		mono.android.Runtime.register ("Scanner.receiver+InitTask, WMS", receiver_InitTask.class, __md_methods);
	}


	public receiver_InitTask ()
	{
		super ();
		if (getClass () == receiver_InitTask.class)
			mono.android.TypeManager.Activate ("Scanner.receiver+InitTask, WMS", "", this, new java.lang.Object[] {  });
	}

	public receiver_InitTask (crc64f0e155b6502ec419.receiver p0)
	{
		super ();
		if (getClass () == receiver_InitTask.class)
			mono.android.TypeManager.Activate ("Scanner.receiver+InitTask, WMS", "Scanner.receiver, WMS", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();

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
