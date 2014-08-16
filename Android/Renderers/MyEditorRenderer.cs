using SignalX.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(Editor), typeof(MyEditorRenderer))]

namespace SignalX.Android
{
	public class MyEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeTextField = (EditorEditText)Control;

				nativeTextField.SetBackgroundResource (Resource.Layout.EditorOutline);
			}

		}
	}
}