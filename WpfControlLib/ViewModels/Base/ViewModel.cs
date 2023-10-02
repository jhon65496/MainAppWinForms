﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.Xaml;

namespace WpfControlLib.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            var handlers = PropertyChanged;
            if (handlers is null) return;

            var invocation_list = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(PropertyName);
            foreach (var action in invocation_list)
                if (action.Target is DispatcherObject disp_object)
                    disp_object.Dispatcher.Invoke(action, this, arg);
                else
                    action.DynamicInvoke(this, arg);
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }      

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if(!Disposing || _Disposed) return;
            _Disposed = true;
            // Освобождение управляемых ресурсов
        }
    }
}
