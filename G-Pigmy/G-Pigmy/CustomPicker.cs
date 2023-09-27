using Xamarin.Forms;

namespace G_Pigmy
{
    public class CustomPicker : Picker
    {




        public static readonly BindableProperty BorderColorProperty =
     BindableProperty.Create(nameof(BorderColor),
         typeof(Color), typeof(CustomEntry), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        //{
        //    base.OnElementChanged(e);

        //    if (Control != null)
        //    {
        //        // Customize the native control here
        //        // For example, you can change the appearance or behavior
        //    }
        //}
    }
}
