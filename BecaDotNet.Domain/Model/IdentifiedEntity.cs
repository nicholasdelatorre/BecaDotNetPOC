namespace BecaDotNet.Domain.Model
{
    public abstract class IdentifiedEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public IdentifiedEntity() { IsActive = true; }
    }
}
