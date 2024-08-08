namespace TeamBuddy.Application.DTOs.Common
{
    public abstract class BaseDto<T> where T : struct
    {
        public T Id { get; set; }
    }
}
