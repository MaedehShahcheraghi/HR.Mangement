namespace HR_Management.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        void SeTStorgeValue<T>(string key,T value);
        T GetStorageValue<T>(string key);
        bool Exsits(string key);
    }
}
