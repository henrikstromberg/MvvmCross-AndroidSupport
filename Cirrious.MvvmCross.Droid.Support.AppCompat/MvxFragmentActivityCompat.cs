// MvxFragmentActivity.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using Android.Content;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Android.Support.V7.App;
using Android.OS;
using Android.Views;
using Java.Lang;
using Android.Graphics;
using Android.Content.Res;
using Android.Util;
using Cirrious.MvvmCross.Droid.Support.AppCompat;
using Android.Support.V7.Widget;

namespace Cirrious.MvvmCross.Droid.Support.Fragging
{
    public class MvxFragmentActivityCompat
        : MvxFragmentActivity
    {
        private AppCompatDelegate _compatDelegate;
        public AppCompatDelegate CompatDelegate
        {
            get
            {
                if (_compatDelegate == null)
                    _compatDelegate = AppCompatDelegate.Create(this, null);
                return _compatDelegate;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            CompatDelegate.InstallViewFactory();
            CompatDelegate.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            CompatDelegate.OnPostCreate(savedInstanceState);
        }

        public ActionBar SupportActionBar
        {
            get
            {
                return CompatDelegate.SupportActionBar;
            }
        }

        public void SetSupportActionBar(Toolbar toolbar)
        {
            CompatDelegate.SetSupportActionBar(toolbar);
        }

        public override MenuInflater MenuInflater
        {
            get
            {
                return CompatDelegate.MenuInflater;
            }
        }

        public override void SetContentView(int layoutResID)
        {
            CompatDelegate.SetContentView(layoutResID);
        }

        public override void SetContentView(View view)
        {
            CompatDelegate.SetContentView(view);
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            CompatDelegate.SetContentView(view, @params);
        }

        public override void AddContentView(View view, ViewGroup.LayoutParams @params)
        {
            CompatDelegate.AddContentView(view, @params);
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();
            CompatDelegate.OnPostResume();
        }

        protected override void OnTitleChanged(ICharSequence title, Color color)
        {
            base.OnTitleChanged(title, color);
            CompatDelegate.SetTitle(title);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            CompatDelegate.OnConfigurationChanged(newConfig);
        }

        protected override void OnStop()
        {
            base.OnStop();
            CompatDelegate.OnStop();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            CompatDelegate.OnDestroy();
        }

        public void InvalidateOptionsMenu()
        {
            CompatDelegate.InvalidateOptionsMenu();
        }

        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            View view = MvxAppCompatActivityHelper.OnCreateView(parent, name, context, attrs);
            return view ?? base.OnCreateView(parent, name, context, attrs);
        }
    }

    public abstract class MvxFragmentActivityCompat<TViewModel>
        : MvxFragmentActivityCompat
    , IMvxAndroidView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}