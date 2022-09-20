namespace Marvin.Web.Domain
{
    public partial class User
    {
        public string Name { get { return FirstName + " " + LastName; } }
    }
}
