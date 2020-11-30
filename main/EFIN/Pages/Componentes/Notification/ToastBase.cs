using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFIN.Pages.Componentes.Notification
{
    public class ToastBase : ComponentBase, IDisposable
    {
        [Inject] ToastService ToastService { get; set; }
        protected string Heading { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string BackgroundCssClass { get; set; }
        protected string IconCssClass { get; set; }
        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }
        private void ShowToast(string message, ToastLevel level,int time=2500)
        {
            BuildToastSettings(level, message);
            IsVisible = true;
            InvokeAsync(StateHasChanged);
        }
        private void HideToast()
        {
            IsVisible = false;
            InvokeAsync(StateHasChanged);
        }
        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    BackgroundCssClass = "bg-info";
                    IconCssClass = "info";
                    Heading = "Info";
                    break;
                case ToastLevel.Success:
                    BackgroundCssClass = "bg-success";
                    IconCssClass = "check_circle";
                    Heading = "Success";
                    break;
                case ToastLevel.Warning:
                    BackgroundCssClass = "bg-warning";
                    IconCssClass = "warning";
                    Heading = "Warning";
                    break;
                case ToastLevel.Error:
                    BackgroundCssClass = "bg-danger";
                    IconCssClass = "not_interested";
                    Heading = "Error";
                    break;
            }
            Message = message;
        }
        public void Dispose()
        {
            ToastService.OnShow -= ShowToast;
        }
    }
}
