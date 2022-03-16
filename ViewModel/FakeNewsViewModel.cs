using System.Windows.Input;
using FakeNewsGenerator.Model;
using FakeNewsGenerator.Service.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace FakeNewsGenerator.ViewModel
{
    public class FakeNewsViewModel : ObservableRecipient
    {
        public FakeNews? FakeNews { get; set; }

        public ICommand GenerateFakeNewsCommand { get; set; }

        public FakeNewsViewModel(IFakeNewsService service)
        {
            GenerateFakeNewsCommand = new RelayCommand(() => FakeNews = service.GenerateFakeNews());
        }
    }
}
