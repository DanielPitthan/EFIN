using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFIN.Pages.Componentes.Notification
{
    public class AlertService :IDisposable
    {
        private bool disposedValue;

        public event Action<string, string, AlertLevel> OnShow;
        public event Action OnHide;

        public void ShowAlert(string titulo, string Menssage, AlertLevel alertLevel)
        {
            OnShow?.Invoke(titulo, Menssage, alertLevel);
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~AlertService()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
