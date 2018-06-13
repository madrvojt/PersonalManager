using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= HandlePropertyChanged;


            if (this.Element != null)
            {
                //UpdateContent ();
                this.Element.PropertyChanged += HandlePropertyChanged;
            }

            Android.Support.V4.View.ViewCompat.SetBackgroundTintList(fab, ColorStateList.ValueOf(Element.ColorNormal.ToAndroid()));

            fab.RippleColor = Element.ColorRipple.ToAndroid();
            fab.UseCompatPadding = true;

            //var elementImage = Element.ImageName;

            //var imageFile = elementImage?.File;
            //if (imageFile != null)
            //{
            //    fab.SetImageDrawable(Context.Resources.GetDrawable(imageFile));
            //}

            SetNativeControl(fab);
            SetFabImage(Element.ImageName);
            fab.Click += Fab_Click;

        }

        private void Fab_Click(object sender, EventArgs e)
        {
            // proxy the click to the element
            ((IButtonController)Element).SendClicked();
        }


        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {

            base.OnLayout(changed, l, t, r, b);
            Control.BringToFront();
        }


        public void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "Content")
            {
                Tracker.UpdateLayout();
            }

            else if (e.PropertyName == FloatingActionButtonView.ColorNormalProperty.PropertyName)
            {
                fab.SetBackgroundColor(Element.ColorNormal.ToAndroid());
            }

            else if (e.PropertyName == FloatingActionButtonView.ColorRippleProperty.PropertyName)
            {
                fab.RippleColor = Element.ColorRipple.ToAndroid();
            }

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