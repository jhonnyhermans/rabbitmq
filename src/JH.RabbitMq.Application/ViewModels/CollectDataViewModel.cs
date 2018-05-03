namespace JH.RabbitMq.Application.ViewModels
{
    public class CollectDataViewModel
    {

        public CollectDataViewModel(string locale, string token, string from)
        {
            Locale = locale;
            Token = token;
            From = from;
        }
        public string Locale { get; set; }
        public string Token { get; set; }
        public string From { get; set; }
    }
}
