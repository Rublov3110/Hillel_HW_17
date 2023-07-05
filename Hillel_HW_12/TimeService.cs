namespace Hillel_HW_12
{
    public class TimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToLongTimeString();
        }
        public string Time { get; }
    }
}
