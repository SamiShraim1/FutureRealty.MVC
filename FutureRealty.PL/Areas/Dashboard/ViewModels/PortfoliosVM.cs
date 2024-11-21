using FutureRealty.DAL.Models;

namespace FutureRealty.PL.Areas.Dashboard.ViewModels
{
    public class PortfoliosVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Item>? Items { get; set; }

    }
}
