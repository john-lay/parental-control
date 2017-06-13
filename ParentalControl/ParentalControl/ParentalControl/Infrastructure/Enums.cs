namespace ParentalControl.Infrastructure
{
    public enum Step
    {
        Default = 0,
        Login,
        NavigateLAN,
        NavigateEthernet,
        DeviceInfo,
        NavigateBasicWiFi,
        NavigateWiFiFiltering,
        BlockDevice,
        UnblockDevice
    }
}