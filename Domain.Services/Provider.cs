using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class Provider
    {
        IAdapter _adapter;
        IRepository _repository;

        public Provider(IAdapter adapter, IRepository repository)
        {
            _adapter = adapter;
            _repository = repository;
        }

        public void Work()
        {
            var path = @"C:\Users\thema_000\Documents\Visual Studio 2017\Projects\Earcast\Test.Translation.Services\Artifacts\ccd.qfx";

        }
    }
}
