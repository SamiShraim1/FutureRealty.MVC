using FutureRealty.DAL.Models;

namespace FutureRealty.PL.Areas.Dashboard.ViewModels
{
    public class PortfolioDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Item>? Items { get; set; }
    }
}
