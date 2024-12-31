namespace BackOffice.Masters.Models
{
    public class Services
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int TenantId { get; set; }
    }
}
