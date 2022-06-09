using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PoeHelper.Source.ViewModel
{
	internal class MainPage_ViewModel :INotifyPropertyChanged
	{
        private Visibility _pageVisibility;
		private bool _isMouseOver = false;
		private bool _isSelected = false;
		private string _showButtonContent = ">";

		private DelegateCommand<object> _startLocatingTimer = new DelegateCommand<object>(
			(o) =>
			{
				MainPage_ViewModel vmRef = o as MainPage_ViewModel;

				DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
				timer.Interval = TimeSpan.FromMilliseconds(500);
				timer.Tick += (s, e) =>
				{
					_ = StaticMethods.IsWindowForeground("PathOfExile")
					? vmRef.PageVisibility = Visibility.Visible
					: vmRef.PageVisibility = Visibility.Visible; //
				};
				timer.Start();
			});


		public DelegateCommand<object> StartLocatingTimer { get { return _startLocatingTimer; } }
		public bool IsMouseOver
		{
			get => _isMouseOver;
			set
			{
				_isMouseOver = value;
				OnPropertyChanged(nameof(IsMouseOver));
			}
		}
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				_isSelected = value;
				OnPropertyChanged(nameof(IsSelected));
			}
		}
		public Visibility PageVisibility
		{
			get => _pageVisibility;
			set
			{
				_pageVisibility = value;
				OnPropertyChanged(nameof(PageVisibility));
			}
		}
		public string ShowButtonContent
		{
			get => _showButtonContent;
			set
			{
				_showButtonContent = value;
				OnPropertyChanged(nameof(ShowButtonContent));
			}
		}

		public void SetMouseOverTrue()
		{
			IsMouseOver = true;
		}


		#region Interface realization

		public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
