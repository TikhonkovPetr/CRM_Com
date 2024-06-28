namespace Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid Id_Company { get; set; }
        public Guid Id_Product { get; set; }
        public int colvo {  get; set; }
        public string cost {  get; set; }
        public Guid Id_Client { get; set; }
    }
}
