using Hanssens.Net;
using HR_Management.MVC.Contracts;

namespace HR_Management.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage  _LocalStorage=new LocalStorage();
        public LocalStorageService() {
        
            var configuration=new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename="HR.LEAVEMGMT"
            };
        }
        public void ClearStorage(List<string> keys)
        {
            foreach (var item in keys)
            {
                _LocalStorage.Remove(item);
            }
        }

        public bool Exsits(string key)
        {
            return _LocalStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _LocalStorage.Get<T>(key);
        }

        public void SeTStorgeValue<T>(string key, T value)
        {
           _LocalStorage.Store<T>(key, value);
            _LocalStorage.Persist();
           
        }
    }
}
