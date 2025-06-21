using Microsoft.AspNetCore.Identity;

public class RegisterModel : PageModel
{
    [BindProperty]
    public RegisterViewModel Input { get; set; }

    private readonly HttpClient _httpClient;

    public RegisterModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("IdentityAPI");
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var response = await _httpClient.PostAsJsonAsync("api/Auth/register", Input);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("/Auth/Login");
        }

        var errors = await response.Content.ReadFromJsonAsync<List<IdentityError>>();
        foreach (var error in errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return Page();
    }
}
