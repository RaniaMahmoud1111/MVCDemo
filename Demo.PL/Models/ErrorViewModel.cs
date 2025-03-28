// that directory should called viewModels not Models 
namespace Demo.PL.Models
{
    //
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
