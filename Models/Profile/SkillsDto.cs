namespace Models
{
    public class SkillsDto
    {
        public SkillsDto() { }

        public SkillsDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
