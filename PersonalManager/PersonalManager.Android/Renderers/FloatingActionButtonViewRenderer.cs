using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using PersonalManager.Droid.Renderers;
using PersonalManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(FloatingActionButtonView), typeof(FloatingActionButtonViewRenderer))]
namespace PersonalManager.Droid.Renderers
{
    public class FloatingActionButtonViewRenderer : ViewRenderer<FloatingActionButtonView, FloatingActionButton>
    {

        private readonly Context _context;
        private readonly FloatingActionButton fab;

        public FloatingActionButtonViewRenderer(Context context) : base(context)
        {
            _context = context;
            fab = new FloatingActionButton(context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButtonView> e)
        {
            base.OnElementChanged(e);
            Android.Support.V4.View.ViewCompat.SetBackgroundTintList(fab, ColorStateList.ValueOf(Element.ButtonColor.ToAndroid()));
            fab.UseCompatPadding = true;
            SetNativeControl(fab);
            var tabIconId = IdFromTitle(Element.ImageName, ResourceManager.DrawableClass);

            fab.SetImageResource(tabIconId);
            fab.Click += Fab_Click;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            Control.BringToFront();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FloatingActionButtonView.ButtonColorProperty.PropertyName)
            {
                fab.SetBackgroundColor(Element.ButtonColor.ToAndroid());
            }

        }

        private void Fab_Click(object sender, EventArgs e)
        {
            // proxy the click to the element
            ((IButtonController)Element).SendClicked();
        }

        internal static int IdFromTitle(string title, Type type)
        {
            string name = Path.GetFileNameWithoutExtension(title);
            int id = GetId(type, name);
            return id; // Resources.System.GetDrawable (Resource.Drawable.dashboard);
        }

        private static int GetId(Type type, string propertyName)
        {
            FieldInfo[] props = type.GetFields();
            FieldInfo prop = props.Select(p => p).FirstOrDefault(p => p.Name == propertyName);
            if (prop != null)
                return (int)prop.GetValue(type);
            return 0;
        }



        private void SetFabImage(string imageName)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
            {
                try
                {
                    var drawableNameWithoutExtension = Path.GetFileNameWithoutExtension(imageName);
                    var resources = _context.Resources;
                    var imageResourceName = resources.GetIdentifier(drawableNameWithoutExtension, "drawable", _context.PackageName);
                    fab.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeResource(_context.Resources, imageResourceName));
                }
                catch (Exception ex)
                {
                    throw new FileNotFoundException("There was no Android Drawable by that name.", ex);
                }

            }

        }

    }
}