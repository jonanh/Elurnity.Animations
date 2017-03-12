
namespace Elurnity.Animations
{
    public interface ISubject<P> where P : Property<P>
    {
        void Apply(P state);
    }
}
