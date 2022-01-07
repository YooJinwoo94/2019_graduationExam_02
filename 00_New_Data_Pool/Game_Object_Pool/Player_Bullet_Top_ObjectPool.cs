using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Top_ObjectPool<T> where T : class
{

    short count;
    public delegate T Func();
    Func create_fn;
    // Instances.  
    Stack<T> objects;
    // Construct  
    public Player_Bullet_Top_ObjectPool(short count, Func fn)
    {
        this.count = count;
        this.create_fn = fn;
        this.objects = new Stack<T>(this.count);
        allocate();

    }
    void allocate()
    {
        for (int i = 0; i < this.count; ++i)
        {
            this.objects.Push(this.create_fn());
        }
    }
    public T pop()
    {
        if (this.objects.Count <= 0)
        {
            allocate();
        }
        return this.objects.Pop();
    }
    public void push(T obj)
    {
        this.objects.Push(obj);
    }
}
