namespace Common.Entities
{
    public class Developer
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string WorkType { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }
    }
}

