namespace SoftServeTestTask.BLL.Dto.Courses
{
    public record CourseUpdateDto(
        int Id, 
        string Name,
        string Description,
        ICollection<EntityDto> Teachers,
        ICollection<EntityDto> Students);   
}
