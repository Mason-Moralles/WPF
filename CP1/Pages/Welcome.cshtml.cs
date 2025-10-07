using Microsoft.AspNetCore.Mvc.RazorPages;

public class WelcomeModel : PageModel
{
    public string Message { get; set; }
    public DateTime CurrentDate { get; set; }

    public void OnGet()
    {
        Message = "����� ���������� �� ����!";
        CurrentDate = DateTime.Now;
    }
}