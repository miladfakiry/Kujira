namespace Kujira.Gui.Services
{
    public class LoadingService
    {
        public event Action<bool> OnLoadingChanged;

        public void StartLoading() => OnLoadingChanged?.Invoke(true);

        public void StopLoading() => OnLoadingChanged?.Invoke(false);
    }
}
