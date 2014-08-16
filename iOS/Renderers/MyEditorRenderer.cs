using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;
using SignalX.iOS;
using MonoTouch.CoreGraphics;

[assembly: ExportRenderer (typeof(Editor), typeof(MyEditorRenderer))]

namespace SignalX.iOS
{
	public class MyEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeTextField = (UITextView)Control;

				nativeTextField.Layer.BorderColor = UIColor.LightGray.CGColor;
				nativeTextField.Layer.BorderWidth = 1; 

			}

		}
	}
}