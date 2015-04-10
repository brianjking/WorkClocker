﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WorkClocker.Annotations;

namespace WorkClocker.ViewModel
{
	internal class TimeSlot : INotifyPropertyChanged
	{
		private int _seconds = 1;
		private bool _included=true;

		public string Title { get; }
		
		public bool Included
		{
			get { return _included; }
			set
			{
				if (value == _included) return;
				_included = value;
				PropChanged();
			}
		}

		public int Seconds
		{
			get { return _seconds; }
			set
			{
				if (value == _seconds) return;
				_seconds = value;
				PropChanged();
				PropChanged(nameof(Time));
			}
		}

		public TimeSpan Time => new TimeSpan(0, 0, Seconds);

		public event PropertyChangedEventHandler PropertyChanged;

		public TimeSlot(string title)
		{
			Title = title;
		}
		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}