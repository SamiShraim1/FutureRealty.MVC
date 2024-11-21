namespace FutureRealty.PL.Areas.Dashboard.ViewModels
{
    public class OurTeamFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }

        public string? FacebookLink { get; set; }
        public string? linkedinLink { get; set; }
        public string? TwitterLink { get; set; }


    }
}
