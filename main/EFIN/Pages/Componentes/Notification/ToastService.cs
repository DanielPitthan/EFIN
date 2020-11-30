using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;

namespace EFIN.Pages.Componentes.Notification
{
    public class ToastService : IDisposable
    {
        public event Action<string, ToastLevel,int> OnShow;
        public event Action OnHide;
        private Timer Countdown;
        private int time;

        public void ShowToast(string message, ToastLevel level,int _time=2500)
        {
            this.time = _time;
            OnShow?.Invoke(message, level,time);
            StartCountdown();
        }

        private void StartCountdown()
        {
            SetCountdown();
            if (Countdown.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown.Start();
            }
        }

        private void SetCountdown()
        {
            if (Countdown == null)
            {
                Countdown = new Timer(time);
                Countdown.Elapsed += HideToast;
                Countdown.AutoReset = false;
            }
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            if (Countdown != null)
            {
                Countdown.Dispose();
            }           
        }
    }
}
