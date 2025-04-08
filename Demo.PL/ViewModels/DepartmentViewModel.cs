namespace Demo.PL.ViewModels
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = string.Empty;// if i not send name it will be set empty string 
        public string Code { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }

    }
}
