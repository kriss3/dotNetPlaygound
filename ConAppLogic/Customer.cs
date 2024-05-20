namespace ConAppLogic;

public class Customer 
{
    public int Id { get; set; }
    public bool IsMedical { get; set; }
    public MedicalInformation? MedicalInfo { get; set; }
    public Address? BillingAddress { get; set; }
}
