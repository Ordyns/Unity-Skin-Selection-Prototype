public interface IInitializable
{
    void Initialize();
}

public interface IInitializable<T>
{
    void Initialize(T t);
}

public interface IInitializable<T1, T2>
{
    void Initialize(T1 t1, T2 t2);
}

public interface IInitializable<T1, T2, T3>
{
    void Initialize(T1 t1, T2 t2, T3 t3);
}