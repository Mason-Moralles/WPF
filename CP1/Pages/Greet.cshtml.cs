using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class GreetModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }

    public void OnGet()
    {
        if (string.IsNullOrEmpty(Name))
            Name = "Гость";
    }
}