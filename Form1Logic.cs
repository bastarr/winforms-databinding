using System;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormDataBinding
{
    public class Form1Logic
    {
        public async Task DoWork1(Action<string> updateMessage)
        {
            await Task.Run(() =>
            {
                if(updateMessage != null)
                    updateMessage.Invoke("Starting DoWork1");
                Thread.Sleep(2000);
            });
        }

        public async Task DoWork2(Action<string> updateMessage)
        {
            await Task.Run(() =>
            {
                if(updateMessage != null)
                    updateMessage.Invoke("Starting DoWork2");
                Thread.Sleep(2000);
            });
        }

        public async Task DoWork3(Action<string> updateMessage)
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    if(updateMessage != null)
                        updateMessage.Invoke("counter: " + i.ToString());
                    Thread.Sleep(500);
                }
            });
        }
    }
}
