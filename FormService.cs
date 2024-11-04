class FormService
{
    private void SetCookie(HttpResponse response, string key, string value, DateTime expirationTime)
    {
        var cookieOptions = new CookieOptions
        {
            Expires = expirationTime,
            Secure = true,
            HttpOnly = true,
        };

        response.Cookies.Append(key, value, cookieOptions);
    }

    private string GetCookie(HttpRequest request, string key)
    {
        return request.Cookies.TryGetValue(key, out var value) ? value : null;
    }

    public bool HandleSubmission(HttpContext context)
    {
        var value = context.Request.Form["value"];
        var expiration = DateTime.Parse(context.Request.Form["time"]);
        if (expiration <= DateTime.Now)
        {
            return false;
        }
        else
        {
            SetCookie(context.Response, "myCookie", value, expiration);
            return true;
        }
    }

    public string OutputCookie(HttpContext context)
    {
        return GetCookie(context.Request, "myCookie");
    }
}