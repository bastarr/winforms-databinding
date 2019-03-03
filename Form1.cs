using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDataBinding
{
    public partial class Form1 : Form
    {
        private Form1ViewModel _viewModel;

        public Form1()
        {
            InitializeComponent();
            _viewModel = new Form1ViewModel();

            SetBindings();
        }

        private void SetBindings()
        {
            this.label1.DataBindings.Add(new Binding("Text", _viewModel, "ProcessingMessage"));
            this.button1.DataBindings.Add(new Binding("Enabled", _viewModel, "IsProcessing"));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _viewModel.ProcessData();
        }
    }
}
