namespace ModuleManager.Web.ViewModels.RequestViewModels
{
    public class ArgumentsViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Search search { get; set; }
        public Order order { get; set; }
        public Filter filter { get; set; }
    }
}