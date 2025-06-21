using Shopping.Web.Models;

public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public LoginViewModel LoginData { get; set; }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    var client = _httpClientFactory.CreateClient("IdentityAPI");

    //    var response = await client.PostAsJsonAsync("Auth/login", LoginData);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
    //        // store token in cookie/session/etc.
    //        return RedirectToPage("/Index");
    //    }

    //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    //    return Page();
    //}
    public async Task<IActionResult> OnPostAsync()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("http://yarpapigateway/"); // or your gateway URL

        var response = await client.PostAsJsonAsync("auth/login", LoginData);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            // Store token in cookies or local storage
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(60)
            };
            Response.Cookies.Append("auth_token", result.Token, cookieOptions);

            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return Page();
    }
}
