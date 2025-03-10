namespace Infrastructure.Memory.Generators;

public interface IGenericGenerator<out TK>
{
    TK Next { get; }
    TK Current { get; }
}