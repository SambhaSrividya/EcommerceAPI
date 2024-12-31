namespace BackOffice.Masters.Models
{
    public class CompanyDetails
    {
        public int CompanyId { get; set; }
        public string CompanyCode {  get; set; }
        public string CompanyName { get; set; }
        public string CompanyGroup { get; set; }
        public int CurrencyId {  get; set; }
        public string Address1 {  get; set; }
        public string Address2 {  get; set; }
        public string City {  get; set; }
        public string State {  get; set; }
        public string Country { get; set; }
        public string PostalCode {  get; set; }
        public string ContactNumber { get; set; }
        public string Fax { get; set; }
        public string Email {  get; set; }
        public string ContactPerson {  get; set; }
        public string AccountSpecificCode {  get; set; }
        public bool IsRoundOff {  get; set; }
        public int NoOfDigits {  get; set; }
        public string NumberDisplayType { get; set; }
        public string Logo {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy {  get; set; }
        public string UpdatedBy {  get; set; }
        public int TenantId {  get; set; }
    }
}
