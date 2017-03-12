
namespace Elurnity.Animations
{
    public interface Property<T>
    {
        T Lerp(T src, T dst, float prog);
    }
}
