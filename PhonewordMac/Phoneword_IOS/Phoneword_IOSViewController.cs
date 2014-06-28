using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Phoneword_IOS
{
	public partial class Phoneword_IOSViewController : UIViewController
	{
		public Phoneword_IOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			string translatedNumber = "";

			TranslateButton.TouchUpInside += (object sender, EventArgs e) => {
				translatedNumber = PhonewordTranslator.ToNumber(PhoneNumberText.Text);

				// Dismiss the keyboard if text field was tapped
				PhoneNumberText.ResignFirstResponder ();

				if (translatedNumber == "") {
					CallButton.SetTitle ("Call", UIControlState.Normal);
					CallButton.Enabled = false;
				} else {
					CallButton.SetTitle ("Call " + translatedNumber, UIControlState.Normal);
					CallButton.Enabled = true;
				}
			};

			CallButton.TouchUpInside += (object sender, EventArgs e) => {
				var url = new NSUrl("tel:" + translatedNumber);

				// use URL handler with tel: prefix to invoke Apples Phone app. Otherwise show alert dialog

				if(!UIApplication.SharedApplication.OpenUrl(url)){
					var av = new UIAlertView("Not supported", "Scheme 'tel:' is not supported on this device",
						null,
						"OK",
						null);
					av.Show();
				}
			};

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

