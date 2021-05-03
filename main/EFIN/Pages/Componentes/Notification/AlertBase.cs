using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFIN.Pages.Componentes.Notification
{
    public class AlertBase : ComponentBase, IDisposable
    {
        [Inject] AlertService AlertService { get; set; }

        protected string Titulo { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string CssColorIcon { get; private set; }

        
        protected override void OnInitialized()
        {
            AlertService.OnShow += ShowAlert;
            AlertService.OnHide += HideAlert;
        }

        private void ShowAlert(string titulo,string menssage, AlertLevel level)
        {
            BuildAlertSetting(level);
            this.Titulo = titulo;
            this.Message = menssage;
            this.IsVisible = true;
            InvokeAsync(StateHasChanged);
        }

        private void HideAlert()
        {
            IsVisible = false;
            InvokeAsync(StateHasChanged);
        }


        private void BuildAlertSetting(AlertLevel level)
        {
            switch (level)
            {
                case AlertLevel.Error:
                    CssColorIcon = "color:red;";
                    break;
                case AlertLevel.Alert:
                    CssColorIcon = "color:yellow;";
                    break;
                case AlertLevel.Info:
                    CssColorIcon = "color:green;";
                    break;
                default:
                    break;
            }
        }

     


        public void Dispose()
        {
            AlertService.OnShow -= ShowAlert;
        }
    }
}
