using Microsoft.AspNetCore.Mvc.Rendering;

namespace FutureRealty.PL.Areas.Dashboard.ViewModels
{
    public class ItemFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PortfolioId { get; set; }
        public SelectList? Portfolios { get; set; }

        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
