using FakeNewsGenerator.Model;
using FakeNewsGenerator.Service.Interfaces;

namespace FakeNewsGenerator.Service
{
    public class FakeNewsService : IFakeNewsService
    {
        public FakeNews GenerateFakeNews() 
            => new()
            {
                ImageDescription = "Some, Location",
                Title = "Some Fake News",
                Body = "Lorem Ipsum, Lorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem Ipsum"
            };
    }
}
