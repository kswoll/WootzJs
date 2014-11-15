namespace WootzJs.Web
{
    public enum CloseReason
    {
        CloseNormal = 1000,
        CloseGoingAway = 1001,
        CloseProtocolError = 1002,
        CloseUnsupported = 1003,
        CloseNoStatus = 1005,
        CloseAbnormal = 1006,
        CloseTooLarge = 1009        
    }
}