package crc644448ab6399bb57f3;


public class CornerOutlineProvider
	extends android.view.ViewOutlineProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOutline:(Landroid/view/View;Landroid/graphics/Outline;)V:GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinBackgroundKit.Android.Renderers.CornerOutlineProvider, XamarinBackgroundKit.Android", CornerOutlineProvider.class, __md_methods);
	}


	public CornerOutlineProvider ()
	{
		super ();
		if (getClass () == CornerOutlineProvider.class)
			mono.android.TypeManager.Activate ("XamarinBackgroundKit.Android.Renderers.CornerOutlineProvider, XamarinBackgroundKit.Android", "", this, new java.lang.Object[] {  });
	}

	public CornerOutlineProvider (float[] p0)
	{
		super ();
		if (getClass () == CornerOutlineProvider.class)
			mono.android.TypeManager.Activate ("XamarinBackgroundKit.Android.Renderers.CornerOutlineProvider, XamarinBackgroundKit.Android", "System.Single[], mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void getOutline (android.view.View p0, android.graphics.Outline p1)
	{
		n_getOutline (p0, p1);
	}

	private native void n_getOutline (android.view.View p0, android.graphics.Outline p1);

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
