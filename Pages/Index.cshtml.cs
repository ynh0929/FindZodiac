using FindZodiac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindZodiac.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int? Year { get; set;}
    public string? Zodiac { get; set;}

    public bool IsValidYear  => Year.HasValue && Year >= 1900 && Year <= (DateTime.Now.Year + 1);

   
   public void OnPost()
   {
        if(!IsValidYear)
        {
            ModelState.AddModelError("Year", "Enter a valid year between 1900 and " + (DateTime.Now.Year + 1));
        }

        Zodiac = Utils.GetZodiac(Year!.Value);
   }
    public void OnGet()
    {

    }
}
