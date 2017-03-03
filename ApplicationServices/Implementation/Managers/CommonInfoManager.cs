namespace ApplicationServices
{
    using Models.Global;
    using Connect.Helpers;

    public class CommonInfoManager : ICommonInfoManager
    {
        public ActivityAreaReadModel GetActivityArea()
        {
            return WebServiceProvider<ActivityAreaReadModel>.Get(UrlHelper.ActivityAreaUrl);
        }
    }
}
