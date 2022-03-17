using System.Threading.Tasks;
using FakeNewsGenerator.Model;

namespace FakeNewsGenerator.Service.Interfaces;

public interface IFakeNewsService
{
    public Task<FakeNews> GenerateFakeNewsAsync();
}