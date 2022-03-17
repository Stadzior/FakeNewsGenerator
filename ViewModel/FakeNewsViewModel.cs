using System.Windows.Input;
using FakeNewsGenerator.Model;
using FakeNewsGenerator.Service.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace FakeNewsGenerator.ViewModel
{
    public class FakeNewsViewModel : ObservableRecipient
    {
        private FakeNews? _fakeNews;
        public FakeNews? FakeNews
        {
            get => _fakeNews;
            set => SetProperty(ref _fakeNews, value);
        }

        public ICommand GenerateFakeNewsCommand { get; set; }

        public FakeNewsViewModel(IFakeNewsService service)
        {
            GenerateFakeNewsCommand = new RelayCommand(async () => FakeNews = await service.GenerateFakeNewsAsync());
        }
    }
}
