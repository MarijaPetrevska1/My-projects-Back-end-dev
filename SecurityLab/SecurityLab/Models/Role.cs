namespace SecurityLab.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // true = organization-level
        // false = resource-specific
        public bool IsOrganizationLevel { get; set; }
    }
}

