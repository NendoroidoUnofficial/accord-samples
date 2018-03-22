using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Form.Pages.Search.Instructions
{
    /// <summary>
    /// introduce how to take the photo with right position
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TakePhotoInstructions : ContentPage
	{
	    public TakePhotoInstructions()
	    {
	        InitializeComponent();
	    }

        public TakePhotoInstructions (string str="")
		{
			InitializeComponent ();
		}
	}
}