using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormDataBinding
{
    public class Form1ViewModel : INotifyPropertyChanged
    {
        private readonly Form1Logic _logic;
        private readonly SynchronizationContext _syncContext;

        private string _processingMessage;
        public string ProcessingMessage
        {
            get { return _processingMessage; }
            set
            {
                _processingMessage = value;
                OnPropertyChanged("ProcessingMessage");
            }
        }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = !value;
                OnPropertyChanged("IsProcessing");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public Form1ViewModel()
        {
            _syncContext = SynchronizationContext.Current;
            _logic = new Form1Logic();

            IsProcessing = false;
        }

        public async Task ProcessData()
        {
            IsProcessing = true;

            UpdateProcessingMessage("DoWork1");
            await Task.Delay(2000);
            await _logic.DoWork1((m) =>
            {
                UpdateProcessingMessage(m);
            });

            UpdateProcessingMessage("DoWork2");
            await Task.Delay(2000);
            await _logic.DoWork2((m) =>
            {
                UpdateProcessingMessage(m);
            });

            UpdateProcessingMessage("DoWork3");
            await Task.Delay(2000);
            await _logic.DoWork3((m) =>
            {
                UpdateProcessingMessage(m);
            });

            ProcessingMessage = "Complete";

            IsProcessing = false;
        }

        private void UpdateProcessingMessage(string message)
        {
            _syncContext.Post(new SendOrPostCallback(o =>
            {
                ProcessingMessage = (string)o;
            }), message);

        }
    }
}
