namespace Masa.Webaligner.Core.Entities
{
    public class User : IEntityBase
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string? LastName { get; private set; }

        #pragma warning disable CS8618
        private User()
        {
            //
        }
        #pragma warning restore CS8618

        public User(Guid? id, string email, string firstName, string? lastName)
        {
            Id = id ?? Guid.NewGuid();
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
