import java.lang.Runnable;

public class ThreadB implements Runnable
{
	private String name;

	public ThreadB(String name)
	{
		this.name=name;	
	}

	public void run()
	{
	   System.out.println("hello from :" + name);
	}
}
