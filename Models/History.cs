namespace Models
{
    public class History
    {
        public Guid Id { get; set; }
        public Guid Id_Changeling{get;set; }
        public Guid Id_Company { get;set; }
        public Guid Id_Object { get;set; }
        public string Action {  get;set; }
        public string Ddate { get; set; }
    }
}
