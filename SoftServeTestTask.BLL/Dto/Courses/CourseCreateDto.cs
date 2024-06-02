namespace SoftServeTestTask.BLL.Dto.Courses
{
    public record CourseCreateDto(
        string Name,
        string Description,
        ICollection<EntityDto> Teachers,
        ICollection<EntityDto> Students);
}
