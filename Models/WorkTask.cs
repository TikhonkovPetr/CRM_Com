namespace Models
{
    public class WorkTask
    {
        public Guid Id { get; set; }
        public Guid Id_Company { get; set; }
        public Guid Id_Person {  get; set; }
        public Guid Id_Sender {  get; set; }
        public string message {  get; set; }
        public bool IsCompleted { get; set; }
    }
}
