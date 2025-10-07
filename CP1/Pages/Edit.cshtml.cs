using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    [BindProperty]
    public string Message { get; set; }
    public bool IsPosted { get; set; }

    public void OnGet()
    {
        IsPosted = false;
    }

    public void OnPost()
    {
        IsPosted = true;
    }
}