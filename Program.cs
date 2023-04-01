

class MyStack<T>
{
    private MyStack<T> prev;
    private T value;

    private int size=0;
    
   public int count()
    {
        return size;
    } 
  public T Pop() {
      T v=value;
     if (size==1)
        {
            size--;
            return v;
        }   
        value = prev.value;
        prev = prev.prev;
        size--;
        
        return v;
    }
    public void Push(T value)
    {
        if (size==0)
        {
            this.value = value;
            size++;
            return;
        }
        MyStack<T> a = new MyStack<T>();
        a.value = this.value;
        a.prev = prev; 
        this.value = value;
        
        size++;
        prev = a;

    }
}



class MyList<T> 
{
    private MyList<T> Next;
    private T Value;
    private int Size;
   

    public MyList()
    {
        Size = 0;
        
     
    }
     
    public bool Contains(T element)
    {
        MyList<T> curr = Next;
        for (int i=0;i<Size;i++)
        {
            if (curr.Value.Equals(element))
                    return true;
            curr = curr.Next;
        }

        return false;
    }
    public void Add(T element)
    {
        Size++;
        if (Size == 1)
        {
            Next = new MyList<T>();
            Next.Value = element;
            return;
        }
        MyList<T> newElement = new MyList<T>();
        newElement.Value = element;
        newElement.Next = Next;
        Next = newElement;
    }
    public T Remove(int index)
    {
        if (index >= Size || index<0)
            throw new ArgumentOutOfRangeException();


        var before = Next;
        for (int i = 1; i < index; i++)
            before = before.Next;
        Size--;
       
        if (index==0)
        {
            T ValueToReturn = Next.Value;
            if (Size > 0)
                Next = Next.Next;
                
            return ValueToReturn;

            
        }  
      if (index == Size)
        {
            T ValueToReturn = before.Next.Value;
            before.Next = new MyList<T>();
            return ValueToReturn;
           
        }
        T ValueToReturn2 = before.Next.Value;
        before.Next = before.Next.Next;
        return ValueToReturn2;
          
    }
    public void InsertAt(T element,int index)
    {
        if (index>Size || index <0)
            throw new ArgumentOutOfRangeException();
        
       if (index==0)
        {

            Add(element);
            return;
        }
     
        var before = Next;
        for (int i = 1; i < index; i++)
            before = before.Next;
        MyList<T> ToInsert = new MyList<T>();
        ToInsert.Value = element;
        if (index==Size)
        {
            before.Next = ToInsert;
           ToInsert.Next=new MyList<T>();
            Size++;
            return;


           
            


        }
        Size++;
        ToInsert.Next = before.Next;
        before.Next = ToInsert;

    }
    public void DeleteAt(int index)
    {
       T ob= Remove(index);
    }
    public T Find(int index)
    {
       // Console.WriteLine(Size);
        if (index >= Size || index < 0)
            throw new ArgumentOutOfRangeException();
        MyList<T> curr = Next;

        for (int i = 0; i < index; i++)
        {
            curr = curr.Next;

            //Console.WriteLine(curr.Value);
        }
            return curr.Value;
    }
    public void Clear()
    {
        Size = 0;
        Next = new MyList<T>();
    }



}
interface IRepository<T> 
{
    void Add(T element);
    void Remove(T element);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

interface Entity
{
    int id { get; set; }

}
class GenericRepository<T> : IRepository<T> where T : Entity
{
    private IList<T> List;
    
    public GenericRepository(IList<T> Context){
        this.List = Context;
      }
    
    public void Add(T element)
    {
        List.Add(element);
    }
    public void Remove(T element)
    {
        List=List.Where(x => !element.Equals(x)).ToList();
    }
    public IEnumerable<T> GetAll()
    {
        return List;
    }
    public T GetById(int id)
    {
        return List.Where(x => x.id == id).First();
    }
    public void Save()
    {

    }
    
}

public class Program
{

    public static void Main()
    {
        // MyList<Double> x = new MyList<Double>();
        // x.Add(1);
        // Console.WriteLine(x.Remove(0));

        // x.Clear();
        //MyStack<int> y = new MyStack<int>();
        //y.Push(1);
        //y.Push(2);
        //y.Push(5);
        //y.Push(4);
        //y.Push(5);
        //y.Push(6);
        //Console.WriteLine(y.Pop());
        //Console.WriteLine(y.Pop());
        //Console.WriteLine(y.Pop());
        //Console.WriteLine(y.count());
        //y.Push(7);
        //Console.WriteLine(y.count());
        //Console.WriteLine(y.Pop());
        //Console.WriteLine(y.Pop());
        //Console.WriteLine(y.count());
        MyList<int> a = new MyList<int>();
        a.InsertAt(1, 0);
        a.InsertAt(2, 1);
        a.InsertAt(3, 1);
        a.Add(4);
        a.DeleteAt(2); //4 1 2 
        Console.WriteLine(a.Contains(1));
        
        
     //   Console.WriteLine(a.Remove(1));
      //  Console.WriteLine(a.Remove(0));
      //  Console.WriteLine(a.Remove(0));
       // Console.WriteLine(a.Find(3));
    }


}