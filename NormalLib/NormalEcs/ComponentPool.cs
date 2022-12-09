namespace NormalEcs
{
    public interface INormalComponent
    {
    }

    public interface INormalLabel
    {
    }
    
    public class ComponentPool
    {
        public NormalArray<INormalComponent> componentPool;

        public ComponentPool()
        {
            componentPool = new NormalArray<INormalComponent>(64);
        }
    }
}