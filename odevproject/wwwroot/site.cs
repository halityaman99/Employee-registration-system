using Microsoft.AspNetCore.Mvc;

namespace odevproject.wwwroot
{
    public class site : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        .search-form-container {
    text-align: right; /* Formu sağ tarafa hizalar */
    margin-bottom: 20px; /* Form ile tablo arasına boşluk ekler */
}

.search-form-container.form-control {
    display: inline-block; /* Form kontrolünün sadece içeriği kadar geniş olmasını sağlar */
    width: auto; /* Genişliği otomatik olarak ayarlar */
}

.search - form - container.btn {
display: inline - block; /* Butonun sadece içeriği kadar geniş olmasını sağlar */
}
    }
}
