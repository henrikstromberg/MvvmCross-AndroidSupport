using MvvmCross.Core.ViewModels;

namespace Example.Core.ViewModels
{
    public class SettingsViewModel
        : MvxViewModel
    {
        private string _name;
        private string _lastName;

        public SettingsViewModel()
        {
            _name = "kalle";
            _lastName = "Nisse"
;        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            _name = null;
            _name = null;
            base.InitFromBundle(parameters);            
        }

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
            }
        }
    }
}